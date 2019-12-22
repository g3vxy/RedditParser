using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace RedditParser
{
    class Downloader
    {
        protected static string uriSubreddit = "https://api.pushshift.io/reddit/search/submission/?subreddit={0}&size={1}&filter=author,url,created_utc";
        protected static string uriUser = "https://api.pushshift.io/reddit/search/submission/?author={0}&size={1}&filter=author,url,created_utc";
        public static async Task<List<JToken>> GetLastPosted(string subreddit, int howMany, string typeOfRequest)
        {
            HttpClient getClient = new HttpClient();
            string url;
            if(String.Compare(typeOfRequest, "User") == 0)
            {
                url = uriUser;
            }
            else
            {
                url = uriSubreddit;
            }
            try
            {
                if (howMany > 1000)
                {
                    int counter = 0;
                    List<JToken> results = new List<JToken>();
                    string responseBodyB = await getClient.GetStringAsync(String.Format(url, subreddit, howMany)).ConfigureAwait(false);
                    JObject responseJsonB = JObject.Parse(responseBodyB);
                    string lastTime = responseJsonB["data"].First["created_utc"].ToString();
                    url = url.Insert(url.Length, "&before={2}");
                    while (counter <= howMany)
                    {
                        string responseBody = await getClient.GetStringAsync(String.Format(url, subreddit, howMany, lastTime)).ConfigureAwait(false);
                        JObject responseJson = JObject.Parse(responseBody);
                        JToken token = responseJson["data"];
                        lastTime = token.Last["created_utc"].ToString();
                        foreach (var item in token)
                        {
                            results.Add(item);
                        }
                        counter = results.Count();
                    }
                    Console.WriteLine(counter);
                    return results;
                }
                else
                {
                    string responseBody = await getClient.GetStringAsync(String.Format(url, subreddit, howMany)).ConfigureAwait(false);
                    JObject responseJson = JObject.Parse(responseBody);
                    JToken token = responseJson["data"];
                    if (token.IsNullOrEmpty())
                    {
                        throw new SubredditNotFoundException();
                    }
                    List<JToken> items = new List<JToken>();
                    foreach(var item in token)
                    {
                        items.Add(item);
                    }
                    return items;
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                MessageBox.Show("Bağlantınızda bir hata var.",  
                    "Bağlantı Hatası", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (SubredditNotFoundException)
            {
                MessageBox.Show("Aradığınız subreddit ne yazık ki boş.", 
                    "Subreddit Hatası", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
            return null;
        }
        public static async Task Download(List<JToken> token, string keyword)
        {
            int i = 0;
            foreach (var item in token)
            {
                Console.WriteLine(i);
                using(WebClient downloadClient = new WebClient()) { 
                    CheckAndCreateFolder(keyword);
                    string url = item["url"].ToString();
                    string author = item["author"].ToString();
                    string domain = new Uri(url).Host;
                    if (String.Compare(domain, "gfycat.com") == 0) {
                        HttpClient getClient = new HttpClient();
                        string responseBody = await getClient.GetStringAsync(url).ConfigureAwait(false);
                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(responseBody);
                        string fileName = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}\{item["author"].ToString() + " - " + Path.GetFileName(url)}{".mp4"}";
                        if (!File.Exists(fileName))
                        {
                            await downloadClient.DownloadFileTaskAsync(new Uri(htmlDoc.DocumentNode.SelectSingleNode("//body").SelectSingleNode("//video").SelectNodes("source")[2].Attributes["src"].Value), fileName);
                            Console.WriteLine(keyword + ": " + author + " " + Path.GetFileName(url) + " indirildi");
                        }
                    
                    }
                    else if(String.Compare(domain, "imgur.com") == 0 || String.Compare(domain, "i.imgur.com") == 0)
                    {
                        url = url.Replace("imgur.com", "imgurp.com");
                        if (url.Contains("/a/"))
                        {
                            string responseBody = null;
                            try {
                                var chromeOptions = new ChromeOptions();
                                chromeOptions.AddArguments(new List<string>() { "headless" });
                                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                                chromeDriverService.HideCommandPromptWindow = true;
                                var driver = new ChromeDriver(chromeDriverService, chromeOptions);
                                driver.Navigate().GoToUrl(url);
                                responseBody = driver.PageSource;
                                driver.Quit();
                            }
                            catch (System.InvalidOperationException)
                            {
                                continue;
                            }
                            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                            htmlDoc.LoadHtml(responseBody);
                            var linkNodes = htmlDoc.DocumentNode.SelectNodes("/html/body/a");
                            if (linkNodes != null) { 
                                List<String> uris = new List<String>();
                                foreach(var node in linkNodes)
                                {
                                    uris.Add(node.FirstChild.Attributes["src"].Value);
                                }
                                foreach(var uri in uris)
                                {
                                    if (uri.Contains("gifv"))
                                    {
                                        string fileName = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}\{item["author"].ToString() + Path.GetFileName(url)}{".mp4"}";
                                        CheckFileAndDownload(fileName, url, keyword, author, downloadClient);
                                    }
                                    else {
                                        string fileName = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}\{item["author"].ToString() + " - Album " + Path.GetFileName("https:" + uri)}{".jpg"}";
                                        CheckFileAndDownload(fileName, url, keyword, author, downloadClient);
                                    }
                                }
                            }
                        }
                        else if(url.Contains("gifv")) {
                            string fileName = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}\{item["author"].ToString() + Path.GetFileName(url)}{".mp4"}";
                            CheckFileAndDownload(fileName, url, keyword, author, downloadClient);
                        }
                        else
                        {
                            string fileName = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}\{item["author"].ToString() + " - " + Path.GetFileName(url)}{".jpg"}";
                            CheckFileAndDownload(fileName, url, keyword, author, downloadClient);
                        }
                    }
                    else
                    {
                        string fileName = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}\{item["author"].ToString() + " - " + Path.GetFileName(url)}";
                        CheckFileAndDownload(fileName, url, keyword, author, downloadClient);
                    }
                    i++;
                }
            }
            MessageBox.Show("Tarama bitti, indiriliyor!", "İndiriliyor", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static void CheckAndCreateFolder(string keyword)
        {
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Download"))
            {
                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Download");
            }
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Download\\" + keyword))
            {
                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Download\\" + keyword);
            }
        }

        public static async void CheckFileAndDownload(string fileName, string url, string keyword, string author, WebClient downloadClient)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    await downloadClient.DownloadFileTaskAsync(new Uri(url), fileName);
                    Console.WriteLine(keyword + ": " + author + " " + Path.GetFileName(url) + " indirildi");
                }
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("Bir resim linki değil: " + url);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                Console.WriteLine(keyword + ": " + author + " " + Path.GetFileName(url) + " 404");
            }
            catch (System.NotSupportedException)
            {
                Console.WriteLine("NotSupported");
            }
        }

        public static void CleanUp(string keyword) // Buglı ve programın sonunda form çalıştırmayı engelliyor.
        {
            int sizeLimit = 1024 * 30;
            DirectoryInfo directory = new DirectoryInfo($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Download\{keyword}");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
                if (file.Length < sizeLimit)
                {
                    file.Delete();
                }
                    
        }
    }
}