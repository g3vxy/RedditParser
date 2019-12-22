namespace RedditParser
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anıl Berke Sağlam tarafından Gelişim Üniversitesi OOP dersi için yapılmıştır. MIT" +
    " lisansı ile lisanslanmıştır. Kaynak koduna https://repos.berke.codes adresinden" +
    " erişebilirsiniz.  ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Snoo ve Reddit ismi, Reddit INC\'e ait markalardır. Sadece eğitim amaçlı bir proje" +
    " için kullanılmıştır. ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 71);
            this.label3.TabIndex = 2;
            this.label3.Text = "JSON Parser olarak JSON.Net ismiyle dağıtılan MIT lisanslı bir paket kullanılmışt" +
    "ır. Repolarına https://github.com/JamesNK/Newtonsoft.Json adresinden erişebilirs" +
    "iniz.";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 177);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "RedditParser | About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}