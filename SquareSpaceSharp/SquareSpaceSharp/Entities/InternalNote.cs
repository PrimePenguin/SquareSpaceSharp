using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class InternalNote
    {
        [JsonProperty("content")] public string Content { get; set; }
    }
}