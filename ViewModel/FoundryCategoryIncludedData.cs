using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryIncludedData : FoundryBaseData
    {
        [JsonPropertyName("attributes")]
        public FoundryCategoryLabelAttributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public FoundryCategoryLabelRelationships Relationships { get; set; }
    }
}
