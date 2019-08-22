using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class InternalNote
    {
        /// <summary>
        /// The content of the note.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}