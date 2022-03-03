using FileOperations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FileOperations.Common;
using FileOperations.Common.Constants;

namespace FileOperations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFileOperation _fileOperation;
        private readonly string _rootFolderPath;
        public FileController(ILogger logger, IFileOperation fileOperation,IConfiguration configuration)
        {
            _logger = logger;
            _rootFolderPath = configuration.GetValue<string>(ConfigKeys.RootFolderPath);
            _fileOperation = fileOperation;
        }

        [HttpGet]
        [Route("DownloadFile/{fileName}")]
        public async Task<IActionResult> Get(string fileName)
        {
            var filePath = $"{_rootFolderPath}\\{fileName}";
            var bytes = await _fileOperation.DownloadFile(filePath);
            if (bytes != null)
            {
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(filePath, out var contentType))
                {
                    contentType = "application/octet-stream";
                }
                return File(bytes, contentType, fileName);
            }
            else
                return Ok(new { message = "File doesn't exist" });
        }

        [HttpGet]
        [Route("GetFiles")]
        public async Task<IActionResult> GetFiles()
        {
            string[] filePaths = await _fileOperation.GetFiles(_rootFolderPath);
            return Ok(new { Result = filePaths });
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string filePath = $"{_rootFolderPath}\\{file.FileName}";
            await _fileOperation.UploadFile(filePath, file);
            return Ok(new { message = "Done" });
        }

        [HttpDelete]
        [Route("DeleteFile")]
        public async Task<ActionResult<string>> Delete(string filename)
        {
            string filePath = $"{_rootFolderPath}\\{filename}";
            var isDeleted = await _fileOperation.DeleteFile(filePath);
            if (isDeleted)
                return Ok(new { message = "File deleted successfully" });
            else
                return Ok(new { message = "File doesn't exist" });
        }

        [HttpDelete]
        [Route("DeleteFolder")]
        public async Task<ActionResult<string>> DeleteFolder(string folderPath)
        {
            var isDeleted = await _fileOperation.DeleteFolder(folderPath);
            if (isDeleted)
                return Ok(new { message = "Directory deleted successfully" });
            else
                return Ok(new { message = "Directory doesn't exist" });
        }
    }
}
