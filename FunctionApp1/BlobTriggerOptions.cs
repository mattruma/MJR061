using Newtonsoft.Json;

namespace FunctionApp1
{
    public class BlobTriggerOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
