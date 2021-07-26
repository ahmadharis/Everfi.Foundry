using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryUserRequestRootData : FoundryBaseData
    {
        [JsonPropertyName("attributes")]
        public FoundryUserRequestAttributes Attributes { get; set; }
    }
}
