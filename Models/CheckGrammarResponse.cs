using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VokabelMeister.Models
{
    public class CheckGrammarResponse
    {
        [JsonPropertyName("matches")]
        public List<Match> Matches { get; set; } = new();
        // Add other properties as per your backend response

        public class Match
        {
            [JsonPropertyName("message")]
            public string Message { get; set; } = string.Empty;

            [JsonPropertyName("shortMessage")]
            public string ShortMessage { get; set; } = string.Empty;

            [JsonPropertyName("offset")]
            public int Offset { get; set; }

            [JsonPropertyName("length")]
            public int Length { get; set; }

            [JsonPropertyName("replacements")]
            public List<Replacement> Replacements { get; set; } = new();
            // ... other fields
        }

        public class Replacement
        {
            [JsonPropertyName("value")]
            public string Value { get; set; } = string.Empty;
        }
    }
}
