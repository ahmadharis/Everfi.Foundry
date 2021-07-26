using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryUserRegistration
    {
        [JsonPropertyName("rule_set")]
        public string RuleSet { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("sso_id")]
        public string SsoId { get; set; }

        [JsonPropertyName("employee_id")]
        public string EmployeeId { get; set; }

        [JsonPropertyName("location_id")]
        public string LocationId { get; set; }

        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonPropertyName("category_labels")]
        public List<string> CategoryLabels { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
