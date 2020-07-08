using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger3Tests : BaseTests
    {
        [Fact]
        public void Run()
        {
            // Arrange

            var myBlob = _body;

            // Act

            BlobTrigger3.Run(myBlob, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
