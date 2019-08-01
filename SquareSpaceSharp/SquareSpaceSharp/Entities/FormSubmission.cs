using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class FormSubmission
    {
        [JsonProperty("label")] public string Label { get; set; }

        [JsonProperty("value")] public string Value { get; set; }
    }
}