using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryAttributes
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_modified_by_id")]
        public string LastModifiedById { get; set; }

        [JsonPropertyName("last_modified_by_type")]
        public string LastModifiedByType { get; set; }

        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("users_count")]
        public int UsersCount { get; set; }

    }
}
