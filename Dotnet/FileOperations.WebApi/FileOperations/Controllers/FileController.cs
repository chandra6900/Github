using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using System.Net.Http.Formatting;
using FileOperations.Models;
using FileOperations.Services;

namespace FileOperations.Controllers
{
    [RoutePrefix("File")]
    public class FileController : ApiController
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        [Route("UploadFileBytesJson")]
        public HttpResponseMessage UploadFileBytesJson([FromBody] JsonFileModel jsonFileModel)
        {

            _logger.Debug("UploadFileBytesJson method called");
            var _rootFolderPath = System.Configuration.ConfigurationManager.AppSettings["UploadFilePath"];
            IFileOperation _fileOperation = new FileOperation();
            HttpResponseMessage processResult;

            if (jsonFileModel is null)
                processResult = BadRequestResult("Received empty json input");
            else if (string.IsNullOrEmpty(jsonFileModel.fileName))
                processResult = BadRequestResult("File name is empty");
            else
            {
                _logger.Info($"Received file upload request for {jsonFileModel.fileName}");

                if (jsonFileModel.fileName.Contains('.') == false || jsonFileModel.fileName.IndexOfAny(Path.GetInvalidFileNameChars()) > 0)
                    processResult = BadRequestResult("Invalid file name");
                else if (string.IsNullOrWhiteSpace(jsonFileModel.fileByteArray))
                    processResult = BadRequestResult("File data is empty");
                else
                {
                    _logger.Info($"File upload started for {jsonFileModel.fileName}");
                    string response = _fileOperation.UploadFileByteArray($"{_rootFolderPath}\\{jsonFileModel.fileName}", jsonFileModel.fileByteArray);
                    processResult = ProcessResult(response, jsonFileModel.fileName);
                }
            }

            _logger.Debug("UploadFileBytesJson method call completed");
            return processResult;
        }

        private HttpResponseMessage ProcessResult(string response, string fileName)
        {
            if (response == "Ok")
                return OkResult("File upload completed");
            else if (response == "FileExists")
                return BadRequestResult($"File {fileName} already exists");
            else if (response == "BadData")
                return BadRequestResult("Bad data received");
            else
                return ErrorResult("Internal Server Error");
        }

        private HttpResponseMessage OkResult(string message)
        {
            return CreateLogResult(LogLevel.Info, HttpStatusCode.OK, "Ok", message);
        }

        private HttpResponseMessage BadRequestResult(string message)
        {
            return CreateLogResult(LogLevel.Error, HttpStatusCode.OK, "Error", message);
        }

        private HttpResponseMessage ErrorResult(string message)
        {
            return CreateLogResult(LogLevel.Error, HttpStatusCode.InternalServerError, "Error", message);
        }

        private HttpResponseMessage CreateLogResult(LogLevel loglevel, HttpStatusCode statusCode, string status, string message)
        {
            _logger.Log(loglevel, message);
            //return Request.CreateResponse(statusCode, new { status = status, message = message }, Configuration.Formatters.JsonFormatter);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new ObjectContent(typeof(object), new { status = status, message = message }, new JsonMediaTypeFormatter());
            return response;
        }
    }
}
