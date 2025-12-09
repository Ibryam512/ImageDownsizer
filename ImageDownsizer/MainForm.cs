using System.Diagnostics;

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
            using (ProgressForm progressForm = new ProgressForm())
            {
                progressForm.Show();
                Application.DoEvents();
                Thread.Sleep(5000);
            }
        }
    }
}
