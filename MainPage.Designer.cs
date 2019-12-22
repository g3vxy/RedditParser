namespace RedditParser
{
    partial class MainPage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.label1 = new System.Windows.Forms.Label();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.Download = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.howManyTextBox = new System.Windows.Forms.TextBox();
            this.about = new System.Windows.Forms.Button();
            this.TypeOfRequest = new System.Windows.Forms.ComboBox();
            this.Exit = new System.Windows.Forms.Button();
            this.openInExplorer = new System.Windows.Forms.Button();
            this.CleanUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keyword :";
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(73, 6);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(100, 20);
            this.keywordTextBox.TabIndex = 1;
            this.keywordTextBox.TextChanged += new System.EventHandler(this.subredditTextBox_TextChanged);
            // 
            // Download
            // 
            this.Download.Location = new System.Drawing.Point(215, 12);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(75, 23);
            this.Download.TabIndex = 2;
            this.Download.Text = "Download";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "How Many :";
            // 
            // howManyTextBox
            // 
            this.howManyTextBox.Location = new System.Drawing.Point(73, 29);
            this.howManyTextBox.Name = "howManyTextBox";
            this.howManyTextBox.Size = new System.Drawing.Size(100, 20);
            this.howManyTextBox.TabIndex = 4;
            this.howManyTextBox.TextChanged += new System.EventHandler(this.howMany_TextChanged);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(12, 109);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(161, 23);
            this.about.TabIndex = 5;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // TypeOfRequest
            // 
            this.TypeOfRequest.FormattingEnabled = true;
            this.TypeOfRequest.Items.AddRange(new object[] {
            "Subreddit",
            "User"});
            this.TypeOfRequest.Location = new System.Drawing.Point(12, 55);
            this.TypeOfRequest.Name = "TypeOfRequest";
            this.TypeOfRequest.Size = new System.Drawing.Size(161, 21);
            this.TypeOfRequest.TabIndex = 6;
            this.TypeOfRequest.Text = "Type of Request";
            this.TypeOfRequest.SelectedIndexChanged += new System.EventHandler(this.TypeOfRequest_SelectedIndexChanged);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(215, 109);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // openInExplorer
            // 
            this.openInExplorer.Location = new System.Drawing.Point(12, 80);
            this.openInExplorer.Name = "openInExplorer";
            this.openInExplorer.Size = new System.Drawing.Size(161, 23);
            this.openInExplorer.TabIndex = 8;
            this.openInExplorer.Text = "Open in Explorer";
            this.openInExplorer.UseVisualStyleBackColor = true;
            this.openInExplorer.Click += new System.EventHandler(this.openInExplorer_Click);
            // 
            // CleanUp
            // 
            this.CleanUp.Location = new System.Drawing.Point(215, 55);
            this.CleanUp.Name = "CleanUp";
            this.CleanUp.Size = new System.Drawing.Size(75, 23);
            this.CleanUp.TabIndex = 9;
            this.CleanUp.Text = "CleanUp";
            this.CleanUp.UseVisualStyleBackColor = true;
            this.CleanUp.Click += new System.EventHandler(this.CleanUp_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 134);
            this.Controls.Add(this.CleanUp);
            this.Controls.Add(this.openInExplorer);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.TypeOfRequest);
            this.Controls.Add(this.about);
            this.Controls.Add(this.howManyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.keywordTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "RedditParser | MainPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox howManyTextBox;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.ComboBox TypeOfRequest;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button openInExplorer;
        private System.Windows.Forms.Button CleanUp;
    }
}

