using Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = @"C:\Users\Office\Downloads\veggblcb_2.zip";
            //CreateFileRequest(filePath);
            string url = @"https://localhost:5001/File/UploadFileBytesJson";
            string result= await UploadFileBytesJson(filePath, url);
            Console.WriteLine("Hello World!");
        }

        private static async void CreateFileRequest(string filePath, string url)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            JsonFileModel fileJson = new JsonFileModel();
            fileJson.fileName = fileInfo.Name;
            fileJson.fileByteArray = Convert.ToBase64String(fileBytes);
            string fileJsonString = JsonSerializer.Serialize<JsonFileModel>(fileJson);
            File.WriteAllText(@"C:\Temp\FileRequest.txt", fileJsonString);

        }
        private static async Task<string> UploadFileBytesJson(string filePath, string url)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            JsonFileModel fileJsonModel = new JsonFileModel();
            fileJsonModel.fileName = fileInfo.Name;
            fileJsonModel.fileByteArray = Convert.ToBase64String(fileBytes);
            string fileJson = JsonSerializer.Serialize<JsonFileModel>(fileJsonModel);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpContent content = new StringContent(fileJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync(url, content);
            string resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;


        }
    }
}
