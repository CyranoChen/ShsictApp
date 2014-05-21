namespace Shsict.Thread.WinForm
{
    partial class ThreadFormTest
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
            this.Start = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.lblLineCounts = new System.Windows.Forms.Label();
            this.lblWordCounts = new System.Windows.Forms.Label();
            this.lblCompareString = new System.Windows.Forms.Label();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.tbLineCounts = new System.Windows.Forms.TextBox();
            this.tbWordCounts = new System.Windows.Forms.TextBox();
            this.tbCompareString = new System.Windows.Forms.TextBox();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.bwThreadTest = new System.ComponentModel.BackgroundWorker();
            this.gbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.Location = new System.Drawing.Point(99, 230);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(80, 40);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(185, 230);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(80, 40);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // gbPanel
            // 
            this.gbPanel.Controls.Add(this.lblLineCounts);
            this.gbPanel.Controls.Add(this.lblWordCounts);
            this.gbPanel.Controls.Add(this.lblCompareString);
            this.gbPanel.Controls.Add(this.lblSourceFile);
            this.gbPanel.Controls.Add(this.tbLineCounts);
            this.gbPanel.Controls.Add(this.tbWordCounts);
            this.gbPanel.Controls.Add(this.tbCompareString);
            this.gbPanel.Controls.Add(this.tbSourceFile);
            this.gbPanel.Location = new System.Drawing.Point(12, 13);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(330, 204);
            this.gbPanel.TabIndex = 2;
            this.gbPanel.TabStop = false;
            this.gbPanel.Text = "Mutli Thread";
            // 
            // lblLineCounts
            // 
            this.lblLineCounts.AutoSize = true;
            this.lblLineCounts.Location = new System.Drawing.Point(5, 166);
            this.lblLineCounts.Name = "lblLineCounts";
            this.lblLineCounts.Size = new System.Drawing.Size(60, 13);
            this.lblLineCounts.TabIndex = 7;
            this.lblLineCounts.Text = "LineCounts";
            // 
            // lblWordCounts
            // 
            this.lblWordCounts.AutoSize = true;
            this.lblWordCounts.Location = new System.Drawing.Point(5, 119);
            this.lblWordCounts.Name = "lblWordCounts";
            this.lblWordCounts.Size = new System.Drawing.Size(66, 13);
            this.lblWordCounts.TabIndex = 6;
            this.lblWordCounts.Text = "WordCounts";
            // 
            // lblCompareString
            // 
            this.lblCompareString.AutoSize = true;
            this.lblCompareString.Location = new System.Drawing.Point(5, 72);
            this.lblCompareString.Name = "lblCompareString";
            this.lblCompareString.Size = new System.Drawing.Size(62, 13);
            this.lblCompareString.TabIndex = 5;
            this.lblCompareString.Text = "CompareStr";
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.AutoSize = true;
            this.lblSourceFile.Location = new System.Drawing.Point(5, 25);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(57, 13);
            this.lblSourceFile.TabIndex = 4;
            this.lblSourceFile.Text = "SourceFile";
            // 
            // tbLineCounts
            // 
            this.tbLineCounts.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLineCounts.Location = new System.Drawing.Point(78, 157);
            this.tbLineCounts.Name = "tbLineCounts";
            this.tbLineCounts.Size = new System.Drawing.Size(232, 29);
            this.tbLineCounts.TabIndex = 3;
            this.tbLineCounts.Text = "0";
            // 
            // tbWordCounts
            // 
            this.tbWordCounts.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWordCounts.Location = new System.Drawing.Point(78, 111);
            this.tbWordCounts.Name = "tbWordCounts";
            this.tbWordCounts.Size = new System.Drawing.Size(232, 29);
            this.tbWordCounts.TabIndex = 2;
            this.tbWordCounts.Text = "0";
            // 
            // tbCompareString
            // 
            this.tbCompareString.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCompareString.Location = new System.Drawing.Point(78, 65);
            this.tbCompareString.Name = "tbCompareString";
            this.tbCompareString.Size = new System.Drawing.Size(232, 29);
            this.tbCompareString.TabIndex = 1;
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSourceFile.Location = new System.Drawing.Point(78, 19);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.Size = new System.Drawing.Size(232, 29);
            this.tbSourceFile.TabIndex = 0;
            // 
            // bwThreadTest
            // 
            this.bwThreadTest.WorkerReportsProgress = true;
            this.bwThreadTest.WorkerSupportsCancellation = true;
            this.bwThreadTest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwThreadTest_ProgressChanged);
            this.bwThreadTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwThreadTest_RunWorkerCompleted);
            // 
            // ThreadFormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 282);
            this.Controls.Add(this.gbPanel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Start);
            this.Name = "ThreadFormTest";
            this.Text = "Thread Text Example";
            this.gbPanel.ResumeLayout(false);
            this.gbPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.TextBox tbLineCounts;
        private System.Windows.Forms.TextBox tbWordCounts;
        private System.Windows.Forms.TextBox tbCompareString;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.Label lblLineCounts;
        private System.Windows.Forms.Label lblWordCounts;
        private System.Windows.Forms.Label lblCompareString;
        private System.Windows.Forms.Label lblSourceFile;
        private System.ComponentModel.BackgroundWorker bwThreadTest;
    }
}

