using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryAddress
    {
        [JsonPropertyName("data")]
        public FoundryUserAddressData Data { get; set; }
    }
}
