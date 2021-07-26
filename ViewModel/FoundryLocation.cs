using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryLocation
    {
        [JsonPropertyName("data")]
        public FoundryBaseData Data { get; set; }
    }
}
