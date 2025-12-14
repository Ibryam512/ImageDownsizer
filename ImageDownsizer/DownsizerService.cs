namespace ImageDownsizer
{
    public class ProgressEventArgs : EventArgs
    {
        public int Percentage { get; set; }
    }

    public class DownsizerService
    {
        private ManualResetEventSlim cancelEvent = new ManualResetEventSlim();
        private int percentage = 0;

        public event EventHandler<ProgressEventArgs> PercentageChanged;

        protected virtual void OnPercentageChanged(int newPercentage)
        {
            PercentageChanged?.Invoke(this, new ProgressEventArgs { Percentage = newPercentage });
        }

        private void TestWorker()
        {
            for (int i = 0; percentage < 100; i++)
            {
                if (cancelEvent.Wait(0))
                {
                    return;
                }

                Thread.Sleep(500);
                percentage = Math.Min(percentage + 12, 100);

                OnPercentageChanged(percentage);
            }
        }

        public void Start()
        {
            cancelEvent.Reset();
            percentage = 0;

            Thread t = new Thread(TestWorker);
            t.Start();
        }

        public void Cancel()
        {
            cancelEvent.Set();
        }
    }
}