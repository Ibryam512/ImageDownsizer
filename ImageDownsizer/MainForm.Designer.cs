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
            groupBoxRadioButtons = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)trackBarScalingFactor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScalingFactor).BeginInit();
            groupBoxRadioButtons.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24F);
            labelTitle.Location = new Point(319, 53);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(327, 54);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Image Downsizer";
            // 
            // buttonSelectImage
            // 
            buttonSelectImage.Anchor = AnchorStyles.Top;
            buttonSelectImage.Cursor = Cursors.Hand;
            buttonSelectImage.Font = new Font("Segoe UI", 12F);
            buttonSelectImage.Location = new Point(522, 175);
            buttonSelectImage.Margin = new Padding(3, 4, 3, 4);
            buttonSelectImage.Name = "buttonSelectImage";
            buttonSelectImage.Size = new Size(153, 47);
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
            textBoxImagePath.Location = new Point(190, 180);
            textBoxImagePath.Margin = new Padding(3, 4, 3, 4);
            textBoxImagePath.Name = "textBoxImagePath";
            textBoxImagePath.PlaceholderText = "Image path...";
            textBoxImagePath.ReadOnly = true;
            textBoxImagePath.ScrollBars = ScrollBars.Horizontal;
            textBoxImagePath.Size = new Size(279, 34);
            textBoxImagePath.TabIndex = 2;
            // 
            // trackBarScalingFactor
            // 
            trackBarScalingFactor.Anchor = AnchorStyles.Top;
            trackBarScalingFactor.Location = new Point(190, 252);
            trackBarScalingFactor.Margin = new Padding(3, 4, 3, 4);
            trackBarScalingFactor.Maximum = 100;
            trackBarScalingFactor.Minimum = 1;
            trackBarScalingFactor.Name = "trackBarScalingFactor";
            trackBarScalingFactor.Size = new Size(280, 56);
            trackBarScalingFactor.TabIndex = 3;
            trackBarScalingFactor.Value = 1;
            // 
            // numericUpDownScalingFactor
            // 
            numericUpDownScalingFactor.Anchor = AnchorStyles.Top;
            numericUpDownScalingFactor.DataBindings.Add(new Binding("Value", trackBarScalingFactor, "Value", true, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownScalingFactor.Font = new Font("Segoe UI", 12F);
            numericUpDownScalingFactor.Location = new Point(522, 252);
            numericUpDownScalingFactor.Margin = new Padding(3, 4, 3, 4);
            numericUpDownScalingFactor.Name = "numericUpDownScalingFactor";
            numericUpDownScalingFactor.Size = new Size(153, 34);
            numericUpDownScalingFactor.TabIndex = 4;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Anchor = AnchorStyles.Top;
            buttonSubmit.Font = new Font("Segoe UI", 16F);
            buttonSubmit.Location = new Point(367, 456);
            buttonSubmit.Margin = new Padding(3, 4, 3, 4);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(197, 57);
            buttonSubmit.TabIndex = 5;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // groupBoxRadioButtons
            // 
            groupBoxRadioButtons.Anchor = AnchorStyles.Top;
            groupBoxRadioButtons.Controls.Add(radioButton2);
            groupBoxRadioButtons.Controls.Add(radioButton1);
            groupBoxRadioButtons.FlatStyle = FlatStyle.Flat;
            groupBoxRadioButtons.Font = new Font("Segoe UI", 12F);
            groupBoxRadioButtons.Location = new Point(190, 320);
            groupBoxRadioButtons.Margin = new Padding(3, 4, 3, 4);
            groupBoxRadioButtons.Name = "groupBoxRadioButtons";
            groupBoxRadioButtons.Padding = new Padding(3, 4, 3, 4);
            groupBoxRadioButtons.Size = new Size(486, 69);
            groupBoxRadioButtons.TabIndex = 6;
            groupBoxRadioButtons.TabStop = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(333, 25);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(97, 32);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "parallel";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(45, 25);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(154, 32);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "consequential";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(groupBoxRadioButtons);
            Controls.Add(buttonSubmit);
            Controls.Add(numericUpDownScalingFactor);
            Controls.Add(trackBarScalingFactor);
            Controls.Add(textBoxImagePath);
            Controls.Add(buttonSelectImage);
            Controls.Add(labelTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Image Downsizer";
            ((System.ComponentModel.ISupportInitialize)trackBarScalingFactor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScalingFactor).EndInit();
            groupBoxRadioButtons.ResumeLayout(false);
            groupBoxRadioButtons.PerformLayout();
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
        private GroupBox groupBoxRadioButtons;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}
