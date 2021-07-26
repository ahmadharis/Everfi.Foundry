using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Everfi.Foundry.ViewModel
{
    public class FoundryBaseData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
