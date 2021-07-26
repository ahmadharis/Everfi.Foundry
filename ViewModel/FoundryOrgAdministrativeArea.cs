using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{

    public class FoundryOrgAdministrativeArea
    {
        [JsonPropertyName("organization")]
        public FoundryOrganization Organization { get; set; }

    }
}
