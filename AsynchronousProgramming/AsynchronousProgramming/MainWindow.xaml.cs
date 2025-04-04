using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsynchronousProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Existing code...

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //DownloadHtml("http://msdn.microsoft.com"); 
            //DownloadHtmlAsync("http://msdn.microsoft.com");
            //var message = GetHtml("http://msdn.microsoft.com");

            //Solution 1 - Await until Task is complete before assigning.
            // var message = await GetHtmlAsync("http://msdn.microsoft.com"); 
            var task = GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show("Waiting for Task to Complete...");

            //Solution 2 - Convert Task Objec to String Results
            var message = await task; //Wait Until Task completes, and becomes Object we need.
            MessageBox.Show(message.Substring(0, 10));
        }
        //1. Traditional Synchronous Method - Everything Unresponsive until download it complete. Not Ideal!
        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"C:\Users\J90\Documents\Visual Studio 2017\Projects\testoutput.html"))
            {
                streamWriter.Write(html);
            }
        }
        //2. Asynchronous Method - Task Object encapsulates state of Asynchronous opertion.
        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            //Asynchronous Version - Await Keyword, lets compiler know this operation is going to be costly.
            //
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"C:\Users\J90\Documents\Visual Studio 2017\Projects\testoutput.html"))
            {
                await streamWriter.WriteLineAsync(html);
            }
        }

        //3. Synchronous Non Void Method
        public string GetHtml(string url)
        {
            var webclient = new WebClient();
            return webclient.DownloadString(url);
        }
        //3. Asynchronous Non Void Method
        public async Task<string> GetHtmlAsync(string url)
        {
            var webclient = new WebClient();
            return await webclient.DownloadStringTaskAsync(url);
        }
    }
}
