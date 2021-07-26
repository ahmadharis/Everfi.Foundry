using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    /// <summary>
    /// Used for Get Categories Response from Foundry API
    /// </summary>
    public class FoundryGetCategoriesResponse
    {
        [JsonPropertyName("data")]
        public List<FoundryCategoryRootData> Data { get; set; }

        [JsonPropertyName("included")]
        public List<FoundryCategoryIncludedData> Included { get; set; }

        [JsonPropertyName("meta")]
        public FoundryMeta Meta { get; set; }


    }

}
