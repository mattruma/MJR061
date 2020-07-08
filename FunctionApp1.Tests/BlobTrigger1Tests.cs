using System.IO;
using System.Text;
using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger1Tests : BaseTests
    {
        [Fact]
        public async void Run()
        {
            // Arrange

            var myBlob = new MemoryStream(
                Encoding.ASCII.GetBytes(_body));

            // Act

            await BlobTrigger1.Run(myBlob, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
