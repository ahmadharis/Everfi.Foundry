using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryLocationAttributes
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalID { get; set; }

        [JsonPropertyName("address_country_iso_code")]
        public string CountryISOCode { get; set; }

        [JsonPropertyName("address_state_iso_code")]
        public string StateISOCode { get; set; }

    }
}
