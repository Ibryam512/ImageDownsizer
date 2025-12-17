namespace ImageDownsizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an image to downsize",
                RestoreDirectory = true,
                Filter = "Images (*.jpg;*.png)|*.jpg;*.png"
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult is not DialogResult.OK) return;

            textBoxImagePath.Text = openFileDialog.FileName;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            DownsizerService downsizerService = new DownsizerService();
            ProgressForm progressForm = new ProgressForm();

            Bitmap image = Image.FromFile(textBoxImagePath.Text) as Bitmap;

            progressForm.AttachService(downsizerService);
            progressForm.Show();
            downsizerService.Start(image, (double)numericUpDownScalingFactor.Value, radioButtonParallel.Checked);
        }
    }
}