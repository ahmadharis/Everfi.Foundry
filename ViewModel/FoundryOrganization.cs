using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryOrganization
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("level_1")]
        public string Level1 { get; set; }

        [JsonPropertyName("level_2")]
        public object Level2 { get; set; }

        [JsonPropertyName("state_iso_code")]
        public string StateIsoCode { get; set; }

        [JsonPropertyName("country_iso_code")]
        public string CountryIsoCode { get; set; }

    }

}
