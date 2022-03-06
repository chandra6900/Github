using FileOperations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FileOperations.Common;
using FileOperations.Common.Constants;
using System.IO;
using System.Net;
using System.Net.Http;
using System;

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
            _logger.LogInformation("UploadFile method called");
            if (file is null)
            {
                _logger.LogWarning("File is empty");
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "BadRequest", message = "File is empty" });
            }
            _logger.LogInformation("File upload started for the file:{0}", file.FileName);
            string filePath = $"{_rootFolderPath}\\{file.FileName}";
            bool fileExist = _fileOperation.FileExist(filePath);

            if (fileExist)
            {
                _logger.LogWarning("File '{0}' already exists", file.FileName);
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "BadRequest", message = "File already exists" });
            }
            else
            {
                bool uploaded = await _fileOperation.UploadFile(filePath, file);
                if (uploaded)
                {
                    _logger.LogInformation("File upload completed for the file:{0}", file.FileName);
                    return StatusCode(StatusCodes.Status200OK, new { status = "Ok", message = "File upload completed" });
                }
                else
                {
                    _logger.LogError("Erro in file upload for the file:{0}", file.FileName);
                    return StatusCode(StatusCodes.Status500InternalServerError, new { status = "Error", message = "Internal server error" });
                }
            }
        }

        [HttpPost]
        [Route("UploadFileBytes")]
        public async Task<IActionResult> UploadFileBytes([FromHeader] string fileName)
        {
            _logger.LogInformation("UploadFileBytes method called");
            var stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            var byteArray = stream.ToArray();
            //Below commented code is not working
            //var byteArray = new byte[Request.ContentLength.Value];
            //await Request.Body.ReadAsync(byteArray);
            if (string.IsNullOrEmpty(fileName))
            {
                _logger.LogWarning("File name is empty");
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "BadRequest", message = "File name is empty" });
            }

            if (byteArray is null)
            {
                _logger.LogWarning("File data is empty");
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "BadRequest", message = "File data is empty" });
            }

            _logger.LogInformation("File upload started for the file:{0}", fileName);
            string filePath = $"{_rootFolderPath}\\{fileName}";
            bool fileExist = _fileOperation.FileExist(filePath);

            if (fileExist)
            {
                _logger.LogWarning("File '{0}' already exists", fileName);
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "BadRequest", message = "File already exists" });
            }
            else
            {
                bool uploaded = await _fileOperation.UploadFileByteArray(byteArray, filePath);
                if (uploaded)
                {
                    _logger.LogInformation("File upload completed for the file:{0}", fileName);
                    return StatusCode(StatusCodes.Status200OK, new { status = "Ok", message = "File upload completed" });
                }
                else
                {
                    _logger.LogError("Erro in file upload for the file:{0}", fileName);
                    return StatusCode(StatusCodes.Status500InternalServerError, new { status = "Error", message = "Internal server error" });
                }
            }
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
            return Ok();
        }
    }
}
