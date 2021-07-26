using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{


    public class FoundryUserAttributes
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("administrative_area")]
        public FoundryOrgAdministrativeArea AdministrativeArea { get; set; }

        [JsonPropertyName("bounced_email")]
        public bool BouncedEmail { get; set; }

        [JsonPropertyName("business_lines")]
        public List<string> BusinessLines { get; set; }

        [JsonPropertyName("managed_business_lines")]
        public List<object> ManagedBusinessLines { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("current_sign_in_at")]
        public object CurrentSignInAt { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public object Username { get; set; }

        [JsonPropertyName("employee_id")]
        public string EmployeeId { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("home_address_formatted")]
        public object HomeAddressFormatted { get; set; }

        [JsonPropertyName("home_address_room")]
        public object HomeAddressRoom { get; set; }

        [JsonPropertyName("is_executive?")]
        public bool IsExecutive { get; set; }

        [JsonPropertyName("is_learner?")]
        public bool IsLearner { get; set; }

        [JsonPropertyName("is_manager?")]
        public bool IsManager { get; set; }

        [JsonPropertyName("is_scorm_manager?")]
        public bool IsScormManager { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("last_sign_in_at")]
        public object LastSignInAt { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("organization_active?")]
        public bool OrganizationActive { get; set; }

        [JsonPropertyName("organization_logo_url")]
        public object OrganizationLogoUrl { get; set; }

        [JsonPropertyName("organization_name")]
        public string OrganizationName { get; set; }

        [JsonPropertyName("organization_demo")]
        public bool OrganizationDemo { get; set; }

        [JsonPropertyName("organization_slug")]
        public string OrganizationSlug { get; set; }

        [JsonPropertyName("organization_uuid")]
        public string OrganizationUuid { get; set; }

        [JsonPropertyName("parent_email")]
        public object ParentEmail { get; set; }

        [JsonPropertyName("primary_managed_business_lines")]
        public List<object> PrimaryManagedBusinessLines { get; set; }

        [JsonPropertyName("secondary_managed_business_lines")]
        public List<object> SecondaryManagedBusinessLines { get; set; }

        [JsonPropertyName("sign_in_count")]
        public int SignInCount { get; set; }

        [JsonPropertyName("sso_id")]
        public string SsoId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("student_id")]
        public object StudentId { get; set; }

        [JsonPropertyName("suppress_invites")]
        public object SuppressInvites { get; set; }

        [JsonPropertyName("suppress_reminders")]
        public object SuppressReminders { get; set; }

        [JsonPropertyName("under_13")]
        public object Under13 { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("user_rule_set_roles")]
        public List<object> UserRuleSetRoles { get; set; }

        [JsonPropertyName("work_address_formatted")]
        public string WorkAddressFormatted { get; set; }

        [JsonPropertyName("work_address_room")]
        public string WorkAddressRoom { get; set; }

        [JsonPropertyName("all_managed_business_lines")]
        public List<object> AllManagedBusinessLines { get; set; }
    }
}
