using System;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryCategoryLabelAttributes
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }

        [JsonPropertyName("users_count")]
        public int UsersCount { get; set; }
    }
}
