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
            string filePath = @"C:\Users\Office\Downloads\TestFile.txt";
            //CreateFileRequest(filePath);
            string url = @"https://localhost:44393/File/UploadFileBytesJson";
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
            JsonFileModel fileJson = new JsonFileModel();
            fileJson.fileName = fileInfo.Name;
            fileJson.fileByteArray = Convert.ToBase64String(fileBytes);
            string fileJsonString = JsonSerializer.Serialize<JsonFileModel>(fileJson);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpContent content = new StringContent(fileJsonString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync(url, content);
            string resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;


        }
    }
}
