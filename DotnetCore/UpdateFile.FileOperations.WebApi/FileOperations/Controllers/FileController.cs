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
            IActionResult processResult;

            if (file is null)
                processResult = BadRequestResult("File is empty");
            else
            {
                _logger.LogInformation($"Received file upload request for {file.FileName}");
                _logger.LogInformation($"File upload started for {file.FileName}");
                string response = await _fileOperation.UploadFile($"{_rootFolderPath}\\{file.FileName}", file);
                processResult = ProcessResult(response, file.FileName);
            }
            _logger.LogDebug("UploadFile method call completed");
            return processResult;
        }

        [HttpPost]
        [Route("UploadFileBytes")]
        public async Task<IActionResult> UploadFileBytes([FromHeader] string fileName)
        {
            _logger.LogDebug("UploadFileBytes method called");
            IActionResult processResult;

            var stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            var byteArray = stream.ToArray();

            //Below commented code is not working
            //var byteArray = new byte[Request.ContentLength.Value];
            //await Request.Body.ReadAsync(byteArray);

            if (string.IsNullOrEmpty(fileName))
                processResult = BadRequestResult("File name is empty");
            else
            {
                _logger.LogInformation($"Received file upload request for {fileName}");

                if (byteArray is null)
                    processResult = BadRequestResult("File data is empty");
                else
                {
                    _logger.LogInformation($"File upload started for {fileName}");
                    string response = await _fileOperation.UploadFileByteArray($"{_rootFolderPath}\\{fileName}",Convert.ToBase64String(byteArray));
                    processResult = ProcessResult(response, fileName);
                }
            }
            _logger.LogDebug("UploadFileBytes method call completed");
            return processResult;       
        }

        [HttpPost]
        [Route("UploadFileBytesJson")]
        public async Task<IActionResult> UploadFileBytesJson([FromBody] JsonFileModel jsonFileModel)
        {
            _logger.LogDebug("UploadFileBytesJson method called");
            IActionResult processResult;


            if (jsonFileModel is null)
                processResult = BadRequestResult("Received empty json input");
            else if (string.IsNullOrEmpty(jsonFileModel.fileName))
                processResult = BadRequestResult("File name is empty");
            else
            {
                _logger.LogInformation($"Received file upload request for {jsonFileModel.fileName}");

                if (jsonFileModel.fileName.Contains('.') == false || jsonFileModel.fileName.IndexOfAny(Path.GetInvalidFileNameChars()) > 0)
                    processResult = BadRequestResult("Invalid file name");
                else if (string.IsNullOrWhiteSpace(jsonFileModel.fileByteArray))
                    processResult = BadRequestResult("File data is empty");
                else
                {
                        _logger.LogInformation($"File upload started for {jsonFileModel.fileName}");
                        string response = await _fileOperation.UploadFileByteArray($"{_rootFolderPath}\\{jsonFileModel.fileName}", jsonFileModel.fileByteArray);
                        processResult = ProcessResult(response, jsonFileModel.fileName);
                }
            }

            _logger.LogDebug("UploadFileBytesJson method call completed");
            return processResult;
        }

        private IActionResult ProcessResult(string response,string fileName)
        {
            if (response=="Ok")
                return OkResult("File upload completed");
            else if(response=="FileExists")
                return BadRequestResult($"File {fileName} already exists"); 
            else if (response == "BadData")
                return BadRequestResult("Bad data received");
            else
                return ErrorResult("Internal Server Error");
        }

        private IActionResult OkResult(string message)
        {
            return CreateLogResult(LogLevel.Information, StatusCodes.Status200OK, "Ok", message);
        }

        private IActionResult BadRequestResult(string message)
        {
            return CreateLogResult(LogLevel.Error, StatusCodes.Status200OK, "Error", message);
        }

        private IActionResult ErrorResult(string message)
        {
            return CreateLogResult(LogLevel.Error, StatusCodes.Status500InternalServerError, "Error", message);
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
            var result = await client.PostAsync(url, content);          
            return Ok(result);
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
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
