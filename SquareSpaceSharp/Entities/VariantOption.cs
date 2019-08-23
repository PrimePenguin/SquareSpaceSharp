using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class VariantOption
    {
        [JsonProperty("value")] public string Value { get; set; }

        [JsonProperty("optionName")] public string OptionName { get; set; }
    }
}