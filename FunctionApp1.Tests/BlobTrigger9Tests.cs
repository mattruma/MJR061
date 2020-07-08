using Microsoft.Azure.Storage.Blob;
using Moq;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger9Tests : BaseTests
    {
        [Fact]
        public async void Run()
        {
            // Arrange

            var ms = new MemoryStream(
                Encoding.ASCII.GetBytes(_body));

            var myBlob =
                new Mock<CloudAppendBlob>(new Uri("http://tempuri.org/blob"));

            myBlob
                .Setup(m => m.ExistsAsync())
                .ReturnsAsync(true);
            myBlob
                .Setup(m => m.DownloadToStreamAsync(It.IsAny<Stream>()))
                .Callback((Stream target) => ms.CopyTo(target))
                .Returns(Task.CompletedTask);

            // Act

            await BlobTrigger9.Run(myBlob.Object, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
