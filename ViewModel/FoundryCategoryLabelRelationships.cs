using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryLabelRelationships
    {
        [JsonPropertyName("category")]
        public FoundryCategory Category { get; set; }
    }
}
