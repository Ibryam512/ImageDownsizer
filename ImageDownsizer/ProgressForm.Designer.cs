namespace ImageDownsizer
{
    partial class ProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelStatus = new Label();
            progressBar = new ProgressBar();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 12F);
            labelStatus.Location = new Point(20, 20);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(154, 28);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "Resizing image...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 69);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(342, 29);
            progressBar.TabIndex = 1;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(376, 69);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 132);
            Controls.Add(buttonCancel);
            Controls.Add(progressBar);
            Controls.Add(labelStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProgressForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Processing...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelStatus;
        private ProgressBar progressBar;
        private Button buttonCancel;
    }
}