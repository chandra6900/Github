using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using FileOperations.Controllers;
using FileOperations.Models;
using FileOperations.Services;

namespace FileOperations.Tests
{
    [TestClass]
    public class FileControllerTest
    {
        [TestMethod]
        public void UploadFileBytesJson()
        {
            var jsonFileModel = new JsonFileModel() { fileName = "Test.txt", fileByteArray = "MQ==" };
            var fileOperationMock = new Mock<IFileOperation>();
            fileOperationMock.Setup(x => x.UploadFileByteArray(It.IsAny<string>(), It.IsAny<string>()))
            .Returns("Ok");
            var controller = new FileController();
            var response = controller.UploadFileBytesJson(jsonFileModel);
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
        }
    }
}
