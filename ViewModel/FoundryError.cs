using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Everfi.Foundry.ViewModel
{
    public class FoundryError
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
