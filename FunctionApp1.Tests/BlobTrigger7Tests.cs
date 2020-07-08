using Microsoft.Azure.Storage.Blob;
using Moq;
using System;
using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger7Tests : BaseTests
    {
        [Fact]
        public async void Run()
        {
            // Arrange

            var myBlob =
                new Mock<CloudBlockBlob>(new Uri("http://tempuri.org/blob"));

            myBlob
                .Setup(m => m.ExistsAsync())
                .ReturnsAsync(true);
            myBlob
                .Setup(m => m.DownloadTextAsync())
                .ReturnsAsync(_body);

            // Act

            await BlobTrigger7.Run(myBlob.Object, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
