namespace ImageDownsizer
{
    public partial class ProgressForm : Form
    {
        public bool IsCancelled { get; private set; }

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int percentage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(percentage)));
                return;
            }

            progressBar.Value = Math.Min(percentage, 100);
            labelStatus.Text = $"Processing: {percentage}%";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
            labelStatus.Text = "Cancelling...";
            this.Close();
        }
    }
}
