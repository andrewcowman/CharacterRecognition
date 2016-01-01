namespace CharacterRecognition {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pnlSample = new System.Windows.Forms.Panel();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.lstLetters = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlSample
            // 
            this.pnlSample.Location = new System.Drawing.Point(13, 125);
            this.pnlSample.Name = "pnlSample";
            this.pnlSample.Size = new System.Drawing.Size(140, 126);
            this.pnlSample.TabIndex = 0;
            this.pnlSample.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSample_Paint);
            // 
            // pnlEntry
            // 
            this.pnlEntry.Location = new System.Drawing.Point(13, 13);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(142, 95);
            this.pnlEntry.TabIndex = 1;
            this.pnlEntry.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEntry_Paint);
            this.pnlEntry.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlEntry_MouseDown);
            this.pnlEntry.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlEntry_MouseMove);
            this.pnlEntry.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlEntry_MouseUp);
            // 
            // lstLetters
            // 
            this.lstLetters.FormattingEnabled = true;
            this.lstLetters.Location = new System.Drawing.Point(161, 125);
            this.lstLetters.Name = "lstLetters";
            this.lstLetters.Size = new System.Drawing.Size(120, 95);
            this.lstLetters.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(161, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Location = new System.Drawing.Point(161, 41);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(75, 23);
            this.btnClearImage.TabIndex = 4;
            this.btnClearImage.Text = "Clear Image";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(161, 226);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 5;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(161, 70);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(75, 23);
            this.btnRecognize.TabIndex = 6;
            this.btnRecognize.Text = "Recognize";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 272);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstLetters);
            this.Controls.Add(this.pnlEntry);
            this.Controls.Add(this.pnlSample);
            this.Name = "Main";
            this.Text = "Character Recognizer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSample;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.ListBox lstLetters;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnRecognize;
    }
}