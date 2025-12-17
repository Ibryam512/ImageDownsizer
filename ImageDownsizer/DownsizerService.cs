using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageDownsizer
{
    public class ProgressEventArgs : EventArgs
    {
        public int Percentage { get; set; }
    }

    public class DownsizerService
    {
        private ManualResetEventSlim cancelEvent = new();
        private int percentage = 0;
        private readonly object progressLock = new();

        public event EventHandler<ProgressEventArgs> PercentageChanged;

        protected void OnPercentageChanged(int newPercentage)
        {
            PercentageChanged?.Invoke(this, new ProgressEventArgs { Percentage = newPercentage });
        }

        private void UpdateProgress(int newPercentage)
        {
            lock (progressLock)
            {
                if (newPercentage > percentage)
                {
                    percentage = newPercentage;
                    OnPercentageChanged(percentage);
                }
            }
        }

        private byte BilinearInterpolate(byte[] pixels, int width, int height, int stride, double x, double y, int channel)
        {
            int x1 = (int)Math.Floor(x);
            int y1 = (int)Math.Floor(y);
            int x2 = Math.Min(x1 + 1, width - 1);
            int y2 = Math.Min(y1 + 1, height - 1);

            double dx = x - x1;
            double dy = y - y1;

            int offset11 = y1 * stride + x1 * 4 + channel;
            int offset21 = y1 * stride + x2 * 4 + channel;
            int offset12 = y2 * stride + x1 * 4 + channel;
            int offset22 = y2 * stride + x2 * 4 + channel;

            byte p11 = pixels[offset11];
            byte p21 = pixels[offset21];
            byte p12 = pixels[offset12];
            byte p22 = pixels[offset22];

            double value = p11 * (1 - dx) * (1 - dy) +
                          p21 * dx * (1 - dy) +
                          p12 * (1 - dx) * dy +
                          p22 * dx * dy;

            return (byte)Math.Min(255, Math.Max(0, value));
        }

        private Bitmap DownscaleSequential(Bitmap original, double scaleFactor)
        {
            int newWidth = (int)(original.Width * scaleFactor / 100.0);
            int newHeight = (int)(original.Height * scaleFactor / 100.0);

            Bitmap result = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            BitmapData originalData = original.LockBits(
                new Rectangle(0, 0, original.Width, original.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            BitmapData resultData = result.LockBits(
                new Rectangle(0, 0, newWidth, newHeight),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            try
            {
                int originalBytes = Math.Abs(originalData.Stride) * original.Height;
                int resultBytes = Math.Abs(resultData.Stride) * newHeight;

                byte[] originalPixels = new byte[originalBytes];
                byte[] resultPixels = new byte[resultBytes];

                Marshal.Copy(originalData.Scan0, originalPixels, 0, originalBytes);

                double scaleX = (double)(original.Width - 1) / (newWidth - 1);
                double scaleY = (double)(original.Height - 1) / (newHeight - 1);

                int lastReportedProgress = 0;

                for (int y = 0; y < newHeight; y++)
                {
                    if (cancelEvent.Wait(0))
                    {
                        original.UnlockBits(originalData);
                        result.UnlockBits(resultData);
                        return null;
                    }

                    for (int x = 0; x < newWidth; x++)
                    {
                        double srcX = x * scaleX;
                        double srcY = y * scaleY;

                        int resultOffset = y * resultData.Stride + x * 4;

                        resultPixels[resultOffset] = BilinearInterpolate(originalPixels, original.Width, original.Height, originalData.Stride, srcX, srcY, 0);
                        resultPixels[resultOffset + 1] = BilinearInterpolate(originalPixels, original.Width, original.Height, originalData.Stride, srcX, srcY, 1);
                        resultPixels[resultOffset + 2] = BilinearInterpolate(originalPixels, original.Width, original.Height, originalData.Stride, srcX, srcY, 2);
                        resultPixels[resultOffset + 3] = BilinearInterpolate(originalPixels, original.Width, original.Height, originalData.Stride, srcX, srcY, 3);
                    }

                    int progress = (y * 100) / newHeight;
                    if (progress > lastReportedProgress)
                    {
                        lastReportedProgress = progress;
                        UpdateProgress(progress);
                    }
                }

                Marshal.Copy(resultPixels, 0, resultData.Scan0, resultBytes);
            }
            finally
            {
                original.UnlockBits(originalData);
                result.UnlockBits(resultData);
            }

            UpdateProgress(100);

            return result;
        }

        private class DownscaleWorkerParams
        {
            public int ChunkIndex { get; set; }
            public int StartY { get; set; }
            public int EndY { get; set; }
            public int NewWidth { get; set; }
            public int NewHeight { get; set; }
            public int OriginalWidth { get; set; }
            public int OriginalHeight { get; set; }
            public byte[] OriginalPixels { get; set; }
            public byte[] ResultPixels { get; set; }
            public int OriginalStride { get; set; }
            public int ResultStride { get; set; }
            public double ScaleX { get; set; }
            public double ScaleY { get; set; }
        }

        private void DownscaleWorker(object objParam)
        {
            DownscaleWorkerParams p = (DownscaleWorkerParams)objParam;

            for (int y = p.StartY; y < p.EndY; y++)
            {
                if (cancelEvent.Wait(0)) return;

                for (int x = 0; x < p.NewWidth; x++)
                {
                    double srcX = x * p.ScaleX;
                    double srcY = y * p.ScaleY;

                    int resultOffset = y * p.ResultStride + x * 4;

                    p.ResultPixels[resultOffset] = BilinearInterpolate(
                        p.OriginalPixels, p.OriginalWidth, p.OriginalHeight, p.OriginalStride, srcX, srcY, 0);
                    p.ResultPixels[resultOffset + 1] = BilinearInterpolate(
                        p.OriginalPixels, p.OriginalWidth, p.OriginalHeight, p.OriginalStride, srcX, srcY, 1);
                    p.ResultPixels[resultOffset + 2] = BilinearInterpolate(
                        p.OriginalPixels, p.OriginalWidth, p.OriginalHeight, p.OriginalStride, srcX, srcY, 2);
                    p.ResultPixels[resultOffset + 3] = BilinearInterpolate(
                        p.OriginalPixels, p.OriginalWidth, p.OriginalHeight, p.OriginalStride, srcX, srcY, 3);
                }

                int progress = ((y - p.StartY + 1) * 100) / (p.EndY - p.StartY);
                if (progress % 10 == 0)
                {
                    UpdateProgress((p.ChunkIndex * 100 + progress) / Environment.ProcessorCount);
                }
            }
        }

        private Bitmap DownscaleParallel(Bitmap original, double scaleFactor)
        {
            int newWidth = (int)(original.Width * scaleFactor / 100.0);
            int newHeight = (int)(original.Height * scaleFactor / 100.0);

            Bitmap result = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            BitmapData originalData = original.LockBits(
                new Rectangle(0, 0, original.Width, original.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            BitmapData resultData = result.LockBits(
                new Rectangle(0, 0, newWidth, newHeight),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            try
            {
                int originalStride = originalData.Stride;
                int resultStride = resultData.Stride;
                int originalBytes = Math.Abs(originalStride) * original.Height;
                int resultBytes = Math.Abs(resultStride) * newHeight;

                byte[] originalPixels = new byte[originalBytes];
                byte[] resultPixels = new byte[resultBytes];

                Marshal.Copy(originalData.Scan0, originalPixels, 0, originalBytes);

                double scaleX = (double)(original.Width - 1) / (newWidth - 1);
                double scaleY = (double)(original.Height - 1) / (newHeight - 1);

                int chunks = 8;
                Thread[] threads = new Thread[chunks];
                int chunkHeight = newHeight / chunks;

                for (int i = 0; i < chunks; i++)
                {
                    int startY = i * chunkHeight;
                    int endY = (i == chunks - 1) ? newHeight : (i + 1) * chunkHeight;

                    var workerParams = new DownscaleWorkerParams
                    {
                        ChunkIndex = i,
                        StartY = startY,
                        EndY = endY,
                        NewWidth = newWidth,
                        NewHeight = newHeight,
                        OriginalWidth = original.Width,
                        OriginalHeight = original.Height,
                        OriginalPixels = originalPixels,
                        ResultPixels = resultPixels,
                        OriginalStride = originalStride,
                        ResultStride = resultStride,
                        ScaleX = scaleX,
                        ScaleY = scaleY
                    };

                    threads[i] = new Thread(DownscaleWorker);
                    threads[i].Start(workerParams);
                }

                foreach (Thread thread in threads) thread.Join();

                Marshal.Copy(resultPixels, 0, resultData.Scan0, resultBytes);
            }
            finally
            {
                original.UnlockBits(originalData);
                result.UnlockBits(resultData);
            }

            UpdateProgress(100);
            return result;
        }

        public void Start(Bitmap original, double scaleFactor, bool useParallel)
        {
            cancelEvent.Reset();
            percentage = 0;

            Thread t = new(() =>
            {
                Stopwatch sw = Stopwatch.StartNew();
                Bitmap result = useParallel ? DownscaleParallel(original, scaleFactor) : DownscaleSequential(original, scaleFactor);
                sw.Stop();
                MessageBox.Show($"{sw.ElapsedMilliseconds}ms");
                result.Save(@$"C:\downscaled\{DateTime.UtcNow}");
            });
        }

        public void Cancel()
        {
            cancelEvent.Set();
        }
    }
}