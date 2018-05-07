namespace CharacterStatistics
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSelectPhraseFiles = new System.Windows.Forms.Button();
            this.openFileDialogPhrase = new System.Windows.Forms.OpenFileDialog();
            this.btnAnalyzePhrase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "分卷字";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "选择文件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "分卷话";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(139, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "分卷";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSelectPhraseFiles
            // 
            this.btnSelectPhraseFiles.Location = new System.Drawing.Point(28, 172);
            this.btnSelectPhraseFiles.Name = "btnSelectPhraseFiles";
            this.btnSelectPhraseFiles.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPhraseFiles.TabIndex = 4;
            this.btnSelectPhraseFiles.Text = "选择分词";
            this.btnSelectPhraseFiles.UseVisualStyleBackColor = true;
            this.btnSelectPhraseFiles.Click += new System.EventHandler(this.btnSelectPhraseFiles_Click);
            // 
            // openFileDialogPhrase
            // 
            this.openFileDialogPhrase.DefaultExt = "*.txt";
            this.openFileDialogPhrase.FileName = "openFileDialogPhrase";
            this.openFileDialogPhrase.Multiselect = true;
            // 
            // btnAnalyzePhrase
            // 
            this.btnAnalyzePhrase.Location = new System.Drawing.Point(139, 172);
            this.btnAnalyzePhrase.Name = "btnAnalyzePhrase";
            this.btnAnalyzePhrase.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyzePhrase.TabIndex = 5;
            this.btnAnalyzePhrase.Text = "分析分词";
            this.btnAnalyzePhrase.UseVisualStyleBackColor = true;
            this.btnAnalyzePhrase.Click += new System.EventHandler(this.btnAnalyzePhrase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.btnAnalyzePhrase);
            this.Controls.Add(this.btnSelectPhraseFiles);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSelectPhraseFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialogPhrase;
        private System.Windows.Forms.Button btnAnalyzePhrase;
    }
}

