using System.Windows.Forms;

namespace ImageDownsizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            buttonSelectImage = new Button();
            textBoxImagePath = new TextBox();
            trackBarScalingFactor = new TrackBar();
            numericUpDownScalingFactor = new NumericUpDown();
            buttonSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarScalingFactor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScalingFactor).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24F);
            labelTitle.Location = new Point(279, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(264, 45);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Image Downsizer";
            // 
            // buttonSelectImage
            // 
            buttonSelectImage.Anchor = AnchorStyles.Top;
            buttonSelectImage.Cursor = Cursors.Hand;
            buttonSelectImage.Font = new Font("Segoe UI", 12F);
            buttonSelectImage.Location = new Point(458, 171);
            buttonSelectImage.Name = "buttonSelectImage";
            buttonSelectImage.Size = new Size(134, 35);
            buttonSelectImage.TabIndex = 1;
            buttonSelectImage.Text = "Select Image";
            buttonSelectImage.UseVisualStyleBackColor = true;
            buttonSelectImage.Click += buttonSelectImage_Click;
            // 
            // textBoxImagePath
            // 
            textBoxImagePath.Anchor = AnchorStyles.Top;
            textBoxImagePath.BackColor = SystemColors.Window;
            textBoxImagePath.Font = new Font("Segoe UI", 12F);
            textBoxImagePath.ForeColor = SystemColors.WindowText;
            textBoxImagePath.Location = new Point(167, 175);
            textBoxImagePath.Name = "textBoxImagePath";
            textBoxImagePath.PlaceholderText = "Image path...";
            textBoxImagePath.ReadOnly = true;
            textBoxImagePath.ScrollBars = ScrollBars.Horizontal;
            textBoxImagePath.Size = new Size(245, 29);
            textBoxImagePath.TabIndex = 2;
            // 
            // trackBarScalingFactor
            // 
            trackBarScalingFactor.Anchor = AnchorStyles.Top;
            trackBarScalingFactor.Location = new Point(167, 229);
            trackBarScalingFactor.Maximum = 100;
            trackBarScalingFactor.Minimum = 1;
            trackBarScalingFactor.Name = "trackBarScalingFactor";
            trackBarScalingFactor.Size = new Size(245, 45);
            trackBarScalingFactor.TabIndex = 3;
            trackBarScalingFactor.Value = 1;
            // 
            // numericUpDownScalingFactor
            // 
            numericUpDownScalingFactor.Anchor = AnchorStyles.Top;
            numericUpDownScalingFactor.DataBindings.Add(new Binding("Value", trackBarScalingFactor, "Value", true, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownScalingFactor.Font = new Font("Segoe UI", 12F);
            numericUpDownScalingFactor.Location = new Point(458, 229);
            numericUpDownScalingFactor.Name = "numericUpDownScalingFactor";
            numericUpDownScalingFactor.Size = new Size(134, 29);
            numericUpDownScalingFactor.TabIndex = 4;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Anchor = AnchorStyles.Top;
            buttonSubmit.Font = new Font("Segoe UI", 16F);
            buttonSubmit.Location = new Point(321, 342);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(172, 43);
            buttonSubmit.TabIndex = 5;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSubmit);
            Controls.Add(numericUpDownScalingFactor);
            Controls.Add(trackBarScalingFactor);
            Controls.Add(textBoxImagePath);
            Controls.Add(buttonSelectImage);
            Controls.Add(labelTitle);
            Name = "MainForm";
            Text = "Image Downsizer";
            ((System.ComponentModel.ISupportInitialize)trackBarScalingFactor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScalingFactor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Button buttonSelectImage;
        private TextBox textBoxImagePath;
        private TrackBar trackBarScalingFactor;
        private NumericUpDown numericUpDownScalingFactor;
        private Button buttonSubmit;
    }
}
