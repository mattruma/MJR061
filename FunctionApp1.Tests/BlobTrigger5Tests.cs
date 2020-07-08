using Newtonsoft.Json;
using Xunit;

namespace FunctionApp1.Tests
{
    public class BlobTrigger5Tests : BaseTests
    {
        [Fact]
        public void Run()
        {
            // Arrange

            var myBlob = JsonConvert.DeserializeObject<BlobTriggerOptions>(_body);

            // Act

            BlobTrigger5.Run(myBlob, "BlobTriggerOptions", _logger);

            // Assert
        }
    }
}
