namespace ImageDownsizer
{
    public partial class ProgressForm : Form
    {
        private DownsizerService downsizerService;

        public bool IsCancelled { get; private set; }

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void AttachService(DownsizerService service)
        {
            downsizerService = service;
            downsizerService.PercentageChanged += OnPercentageChanged;
        }

        private void OnPercentageChanged(object sender, ProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(e.Percentage)));
            }
            else
            {
                UpdateProgress(e.Percentage);
            }
        }

        public void UpdateProgress(int percentage)
        {
            progressBar.Value = Math.Min(percentage, 100);
            labelStatus.Text = $"Processing: {percentage}%";

            if (percentage >= 100)
            {
                labelStatus.Text = "Complete!";
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
            downsizerService.Cancel();
            labelStatus.Text = "Cancelling...";

            if (InvokeRequired)
                Invoke(new Action(Close));
            else
                Close();
        }
    }
}