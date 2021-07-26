using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryLabels
    {
        [JsonPropertyName("data")]
        public List<FoundryBaseData> Data { get; set; }
    }
}
