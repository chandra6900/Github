using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using FileOperations.Services;
using Microsoft.Extensions.Hosting;
using FileOperations.Common;
using Microsoft.Extensions.DependencyInjection;
using FileOperations.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using FileOperations.Models;
using System.Threading.Tasks;

namespace FileOperations.Test
{
    public class FileControllerTest
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<FileController> _logger;
        private readonly IFileOperation _fileOperation;

        public FileControllerTest()
        {
            var host = Program.CreateHostBuilder(new List<string> { }.ToArray()).Build();
            Assert.IsAssignableFrom<IHost>(Program.CreateHostBuilder(new List<string> { }.ToArray()).Build());
            _configuration = host.Services.GetService<IConfiguration>();
            _logger = host.Services.GetService<ILogger<FileController>>();
            _fileOperation = host.Services.GetService<IFileOperation>();          
        }

        [Fact]
        public void UploadFile()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "This is a test file";
            var fileName = "Test.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            var file = fileMock.Object;
            var controller = new FileController(_configuration,_logger, _fileOperation);
            var response = controller.UploadFile(file);
            var result = Assert.IsType<ObjectResult>(response.Result);
        }

        [Fact]
        public void UploadFileBytesJson()
        {
            var jsonFileModel= new JsonFileModel() { fileName = "Test.txt", fileByteArray = "MQ==" };
            var fileOperationMock = new Mock<IFileOperation>();
            fileOperationMock.Setup(x => x.FileExist(It.IsAny<string>()))
            .Returns(false);
            fileOperationMock.Setup(x => x.UploadFileByteArray(It.IsAny<string>(), It.IsAny<byte[]>()))
            .Returns(Task.FromResult(true));
            var controller = new FileController(_configuration, _logger, fileOperationMock.Object);
            var response = controller.UploadFileBytesJson(jsonFileModel);
            var result = Assert.IsType<ObjectResult>(response.Result);
        }
    }
}
