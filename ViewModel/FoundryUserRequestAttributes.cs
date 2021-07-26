using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryUserRequestAttributes
    {
        [JsonPropertyName("registrations")]
        public List<FoundryUserRegistration> Registrations { get; set; }
    }
}
