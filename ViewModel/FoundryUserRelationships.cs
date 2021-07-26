using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryUserRelationships
    {
        [JsonPropertyName("location")]
        public FoundryLocation Location { get; set; }

        [JsonPropertyName("home_address")]
        public FoundryAddress HomeAddress { get; set; }

        [JsonPropertyName("work_address")]
        public FoundryAddress WorkAddress { get; set; }

        [JsonPropertyName("category_labels")]
        public FoundryCategoryLabels CategoryLabels { get; set; }

    }
}
