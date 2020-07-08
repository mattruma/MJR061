using System.IO;
using System.Text;
using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger2Tests : BaseTests
    {
        [Fact]
        public async void Run()
        {
            // Arrange

            var ms = new MemoryStream(
                Encoding.ASCII.GetBytes(_body));

            var myBlob = new StreamReader(ms);

            // Act

            await BlobTrigger2.Run(myBlob, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
