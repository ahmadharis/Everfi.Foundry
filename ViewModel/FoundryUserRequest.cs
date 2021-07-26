using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    /// <summary>
    /// User Request Object for Create/Update/Delete APIs
    /// </summary>
    public class FoundryUserRequest
    {
        [JsonPropertyName("data")]
        public FoundryUserRequestRootData Data { get; set; }

        public FoundryUserRequest()
        {
            Data = new FoundryUserRequestRootData
            {
                Attributes = new FoundryUserRequestAttributes
                {
                    Registrations = new List<FoundryUserRegistration>()
                }
            };
        }
    }


}
