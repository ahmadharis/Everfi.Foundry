using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryUserResponseRootData : FoundryBaseData
    {
        [JsonPropertyName("attributes")]
        public FoundryUserAttributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public FoundryUserRelationships Relationships { get; set; }
    }
}
