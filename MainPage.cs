using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RedditParser
{
    public partial class MainPage : Form
    {
        public string howMany { get; set; }

        public string keyword { get; set; }

        public string typeOfRequest { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Download_Click(object sender, EventArgs e)
        {
            try
            {
                var token = Downloader.GetLastPosted(keyword, int.Parse(howMany), typeOfRequest).Result;
                Downloader.Download(token, keyword);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Subreddit sayısı için sayısal bir değer girdiğinize emin olun. Program sonlandırılıyor.", "Değer Türü Hatası",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void about_Click(object sender, EventArgs e)
        {
            About test = new About();
            test.Show();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openInExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory);
        }
        private void CleanUp_Click(object sender, EventArgs e)
        {
            Downloader.CleanUp(keyword);
        }
        private void subredditTextBox_TextChanged(object sender, EventArgs e)
        {
            keyword = keywordTextBox.Text;
        }

        private void howMany_TextChanged(object sender, EventArgs e)
        {
            howMany = howManyTextBox.Text;
        }

        private void TypeOfRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeOfRequest = TypeOfRequest.Text;
        }
    } // Made by Anıl Berke Sağlam for Object Oriented Programming Class at Gelisim University
}
