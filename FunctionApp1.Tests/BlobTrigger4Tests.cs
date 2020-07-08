using System.Text;
using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger4Tests : BaseTests
    {
        [Fact]
        public void Run()
        {
            // Arrange

            var myBlob = Encoding.ASCII.GetBytes(_body);

            // Act

            BlobTrigger4.Run(myBlob, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
