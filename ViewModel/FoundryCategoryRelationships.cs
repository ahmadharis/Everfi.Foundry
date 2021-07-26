using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryRelationships
    {
        [JsonPropertyName("category_labels")]
        public FoundryCategoryLabels CategoryLabels { get; set; }

    }
}
