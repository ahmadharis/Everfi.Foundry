using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryLocationRootData : FoundryBaseData
    {

        [JsonPropertyName("attributes")]
        public FoundryLocationAttributes Attributes { get; set; }

    }
}
