namespace ZayavkaTom1Tom2
{
    public partial class MainForm
    {

        public MainForm()
        {
            InitializeComponent();
        }

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
            textBoxFilePath = new TextBox();
            buttonFileBrowse = new Button();
            labelFilePath = new Label();
            buttonProcess = new Button();
            SuspendLayout();
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(170, 12);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(522, 27);
            textBoxFilePath.TabIndex = 0;
            // 
            // buttonFileBrowse
            // 
            buttonFileBrowse.Location = new Point(698, 12);
            buttonFileBrowse.Name = "buttonFileBrowse";
            buttonFileBrowse.Size = new Size(27, 27);
            buttonFileBrowse.TabIndex = 1;
            buttonFileBrowse.Text = "...";
            buttonFileBrowse.UseVisualStyleBackColor = true;
            buttonFileBrowse.Click += buttonFileBrowse_Click;
            // 
            // labelFilePath
            // 
            labelFilePath.AutoSize = true;
            labelFilePath.Location = new Point(12, 15);
            labelFilePath.Name = "labelFilePath";
            labelFilePath.Size = new Size(152, 20);
            labelFilePath.TabIndex = 2;
            labelFilePath.Text = "Форма для загрузки:";
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(485, 45);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(240, 29);
            buttonProcess.TabIndex = 3;
            buttonProcess.Text = "Сформировать заявки в папку";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonProcess);
            Controls.Add(labelFilePath);
            Controls.Add(buttonFileBrowse);
            Controls.Add(textBoxFilePath);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFilePath;
        private Button buttonFileBrowse;
        private Label labelFilePath;
        private Button buttonProcess;
    }
}
