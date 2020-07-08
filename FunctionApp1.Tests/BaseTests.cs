using FunctionApp1.Tests.Helpers;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;

namespace FunctionApp1.Tests
{
    public class BaseTests
    {
        protected readonly ILogger _logger = LoggerHelper.CreateLogger(LoggerTypes.List);
        protected readonly string _body;

        public BaseTests()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FunctionApp1.Tests.BlobTriggerOptions.json";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            _body = reader.ReadToEnd();
        }
    }
}
