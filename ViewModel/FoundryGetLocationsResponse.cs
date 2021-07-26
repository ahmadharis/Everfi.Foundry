using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    /// <summary>
    /// Handles response for Get Locations API
    /// </summary>
    public class FoundryGetLocationsResponse
    {
        [JsonPropertyName("data")]
        public List<FoundryLocationRootData> Data { get; set; }

 
        [JsonPropertyName("meta")]
        public FoundryMeta Meta { get; set; }
    }

}
