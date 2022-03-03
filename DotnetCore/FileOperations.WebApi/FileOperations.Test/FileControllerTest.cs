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

namespace FileOperations.Test
{
    public class FileControllerTest
    {
        private readonly ILogger _logger;
        private readonly IFileOperation _fileOperation;
        private readonly IConfiguration _configuration;
        public FileControllerTest()
        {
            var host = Program.CreateHostBuilder(new List<string> { }.ToArray()).Build();
            Assert.IsAssignableFrom<IHost>(Program.CreateHostBuilder(new List<string> { }.ToArray()).Build());
            Utilities.Configuration = (IConfiguration)host.Services.GetService(typeof(IConfiguration));
            _logger = host.Services.GetService<ILogger>();
            _fileOperation = host.Services.GetService<IFileOperation>();
            _configuration = host.Services.GetService<IConfiguration>();
        }

        [Fact]
        public void DownloadFile()
        {
            string fileName = "";
            var controller = new FileController(_logger, _fileOperation, _configuration);
            var result = controller.Get(fileName);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetFiles()
        {
            var controller = new FileController(_logger, _fileOperation, _configuration);
            var response = controller.GetFiles();
            var result = Assert.IsType<OkObjectResult>(response.Result);
            Assert.NotNull(result);
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
            var controller = new FileController(_logger, _fileOperation, _configuration);
            var response = controller.UploadFile(file);
            var result = Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void DeleteFile()
        {
            var controller = new FileController(_logger, _fileOperation, _configuration);
            var response = controller.Delete("Test.txt");
            var result = Assert.IsType<OkObjectResult>(response.Result.Result);
        }

        [Fact]
        public void DeleteFolder()
        {
            var controller = new FileController(_logger, _fileOperation, _configuration);
            var response = controller.DeleteFolder(@"C:\Test");
            var result = Assert.IsType<OkObjectResult>(response.Result.Result);
        }
    }
}
