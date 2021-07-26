using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryRootData : FoundryBaseData
    {

        [JsonPropertyName("attributes")]
        public FoundryCategoryAttributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public FoundryCategoryRelationships Relationships { get; set; }
    }
}
