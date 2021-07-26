using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{


    public class FoundryUserAddressData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("address_type")]
        public string AddressType { get; set; }

        [JsonPropertyName("street_number")]
        public object StreetNumber { get; set; }

        [JsonPropertyName("route")]
        public object Route { get; set; }

        [JsonPropertyName("neighborhood")]
        public object Neighborhood { get; set; }

        [JsonPropertyName("locality")]
        public object Locality { get; set; }

        [JsonPropertyName("administrative_area_level_2")]
        public object AdministrativeAreaLevel2 { get; set; }

        [JsonPropertyName("administrative_area_level_1")]
        public string AdministrativeAreaLevel1 { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postal_code")]
        public object PostalCode { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("name")]
        public object Name { get; set; }

        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("county_name")]
        public object CountyName { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("country_iso_code")]
        public string CountryIsoCode { get; set; }

        [JsonPropertyName("state_iso_code")]
        public string StateIsoCode { get; set; }

    }
}
