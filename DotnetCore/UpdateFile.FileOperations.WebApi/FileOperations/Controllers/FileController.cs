using FileOperations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FileOperations.Common;
using System.IO;
using System.Net;
using System.Net.Http;
using System;
using FileOperations.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileOperations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IFileOperation _fileOperation;
        private readonly string _rootFolderPath;
        public FileController(IConfiguration configuration, ILogger<FileController> logger, IFileOperation fileOperation)
        {
            _configuration = configuration;
            _logger = logger;
            _fileOperation = fileOperation;
            _rootFolderPath = configuration.GetValue<string>(ConfigKeys.RootFolderPath);
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            _logger.LogDebug("UploadFile method called");
            if (file is null)
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File is empty");
            }
            else if (Utilities.FileExist($"{_rootFolderPath}\\{file.FileName}"))
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File already exists");
            }

            _logger.LogDebug("File upload started");
            bool uploaded = await _fileOperation.UploadFile($"{_rootFolderPath}\\{file.FileName}", file);
            IActionResult processResult = ProcessResult(uploaded);
            _logger.LogDebug("UploadFile method call completed");
            return processResult;

        }

        [HttpPost]
        [Route("UploadFileBytes")]
        public async Task<IActionResult> UploadFileBytes([FromHeader] string fileName)
        {
            _logger.LogDebug("UploadFileBytes method called");
            var stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            var byteArray = stream.ToArray();

            //Below commented code is not working
            //var byteArray = new byte[Request.ContentLength.Value];
            //await Request.Body.ReadAsync(byteArray);

            if (string.IsNullOrEmpty(fileName))
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File name is empty");
            }
            else if (Utilities.FileExist($"{_rootFolderPath}\\{fileName}"))
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File already exists");
            }
            else if (byteArray is null)
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File data is empty");
            }

            _logger.LogDebug("File upload started");
            bool uploaded = await _fileOperation.UploadFileByteArray($"{_rootFolderPath}\\{fileName}", byteArray);
            IActionResult processResult = ProcessResult(uploaded);
            _logger.LogDebug("UploadFileBytes method call completed");
            return processResult;
            
        }

        [HttpPost]
        [Route("UploadFileBytesJson")]
        public async Task<IActionResult> UploadFileBytesJson([FromBody] JsonFileModel jsonFileModel)
        {
            _logger.LogDebug("UploadFileBytesJson method called");

            if (string.IsNullOrEmpty(jsonFileModel.fileName))
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File name is empty");
            }
            else if(Utilities.FileExist($"{_rootFolderPath}\\{jsonFileModel.fileName}"))
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File already exists");
            }
            else if (jsonFileModel is null || string.IsNullOrWhiteSpace(jsonFileModel.fileByteArray))
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "File data is empty");
            }
                            
            byte[] byteArray = Utilities.DecodeFromBase64String(jsonFileModel.fileByteArray);
            if (byteArray == null)
            {
                return CreateLogResult(LogLevel.Warning, StatusCodes.Status400BadRequest, "BadRequest", "Bad data received");
            }

            _logger.LogDebug("File upload started");
            bool uploaded = await _fileOperation.UploadFileByteArray($"{_rootFolderPath}\\{jsonFileModel.fileName}", byteArray);
            IActionResult processResult = ProcessResult(uploaded);
            _logger.LogDebug("UploadFileBytesJson method call completed");
            return processResult;

        }

        private IActionResult ProcessResult(bool uploaded)
        {
            if (uploaded)
            {
                return CreateLogResult(LogLevel.Information, StatusCodes.Status200OK, "Ok", "File upload completed");
            }
            else
            {
                return CreateLogResult(LogLevel.Error, StatusCodes.Status500InternalServerError, "Error", "Erro in file upload");
            }
        }

        private IActionResult CreateLogResult(LogLevel loglevel,int statusCode, string status, string message)
        {
            _logger.Log(loglevel, message);
            return StatusCode(statusCode, new { status = status, message = message });
        }

        [HttpGet]
        [Route("CallUploadFileUsingWebClient")]
        public string CallUploadFileUsingWebClient(string filePath, string url)
        {
            string responseText;
            try
            {
                using (WebClient client = new WebClient())
                {
                    //WebClient throws error if response status is other than 200, strange
                    byte[] response = client.UploadFile(url, filePath);
                    //To create stream from bytes
                    using (var memoryStream = new MemoryStream(response))
                    {   //To Read text from stream
                        using (var reader = new StreamReader(memoryStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException exception)
            {
                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
            }
            return responseText;
        }

        [HttpGet]
        [Route("CallUploadFileBytesUsingHttpClient")]
        public async Task<IActionResult> CallUploadFileBytesUsingHttpClient(string filePath, string url)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //For checking purpose enable below
            //await System.IO.File.WriteAllBytesAsync("C:\\Temp\\" + fileInfo.Name, fileBytes);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("fileName", fileInfo.Name);
            client.BaseAddress = new Uri(url);
            HttpContent content = new ByteArrayContent(fileBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            HttpResponseMessage httpResponseMessage = await client.PostAsync(url, content);          
            return Ok();
        }

        [HttpGet]
        [Route("CallUploadFileBytesJsonUsingHttpClient")]
        public async Task<IActionResult> CallUploadFileBytesJsonUsingHttpClient(string filePath, string url)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            JsonFileModel fileJson = new JsonFileModel();
            fileJson.fileName = fileInfo.Name;
            fileJson.fileByteArray = Convert.ToBase64String(fileBytes);
            string fileJsonString=JsonSerializer.Serialize<JsonFileModel>(fileJson);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpContent content = new StringContent(fileJsonString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
                return Ok();
            else
                return BadRequest();
        }
    }
}
