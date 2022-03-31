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
            await CallFileUpload();
            Console.WriteLine("Hello World!");
        }

        private static async Task CallFileUpload()
        {
            string filePath = @"C:\Temp\TestFiles\TestFile.txt";
            string url = @"https://localhost:44393/File/UploadFileBytesJson";
            string result = await UploadFileBytes(filePath, url, false);
        }

        private static async Task<string> UploadFileBytes(string filePath, string url,bool createJson)
        {
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                JsonFileModel fileJsonModel = new JsonFileModel();
                fileJsonModel.fileName = fileInfo.Name;
                fileJsonModel.fileByteArray = Convert.ToBase64String(fileBytes);
                string fileJson = JsonSerializer.Serialize<JsonFileModel>(fileJsonModel);
                if (createJson)
                {
                    await File.WriteAllTextAsync(@"C:\\Temp\FileJson.txt", fileJson);
                    return "Done";
                }
                else
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(url);
                    HttpContent content = new StringContent(fileJson);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var result = await client.PostAsync(url, content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return resultContent;
                }
            }
            else
                return "FileNotFound";

        }
    }
}
