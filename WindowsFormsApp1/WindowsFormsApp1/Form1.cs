using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1

{
    public partial class Form1 : Form
    {
        private const string  path = @"C:\Users\101_test_pc\Desktop\18-1.bmp";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:5001/api/FileUpload"))
                {

                    request.Headers.TryAddWithoutValidation("accept", "files/plain");//-H  "accept: files/plain" 
                    
                    var multipartContent = new MultipartFormDataContent();
                    var file1 = new ByteArrayContent(File.ReadAllBytes(path));
                    file1.Headers.Add("Content-Type", "image/.bmp");
                    multipartContent.Add(file1, "files", Path.GetFileName(path));
                    request.Content = multipartContent;
                    var response = await httpClient.SendAsync(request);//post
                }
            }

        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:5001/api/FileUpload/ng"))
                {
                    var response = await httpClient.SendAsync(request);
                }
            }
            //test
        }
    }
}
