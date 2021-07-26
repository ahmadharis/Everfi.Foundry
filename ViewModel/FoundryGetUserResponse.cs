using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{

    /// <summary>
    /// Used to handle a single Foundry User Object returned by API
    /// </summary>
    public class FoundryGetUserResponse
    {
        [JsonPropertyName("data")]
        public FoundryUserResponseRootData Data { get; set; }

        [JsonPropertyName("errors")]
        public List<FoundryError> Errors { get; set; }
    }


    /// <summary>
    /// Used to handle a collection of Foundry User Objects returned by APIs
    /// such as GetUsers
    /// </summary>
    public class FoundryGetUsersResponse
    {
        [JsonPropertyName("data")]
        public List<FoundryUserResponseRootData> Data { get; set; }
   
    }





}
