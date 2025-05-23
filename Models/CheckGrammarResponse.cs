using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VokabelMeister.Models
{
    public class CheckGrammarResponse
    {
        public List<Match> Matches { get; set; } = new();
        // Add other properties as per your backend response

        public class Match
        {
            public string Message { get; set; } = string.Empty;
            public int Offset { get; set; }
            public int Length { get; set; }
            public List<Replacement> Replacements { get; set; } = new();
            // ... other fields
        }

        public class Replacement
        {
            public string Value { get; set; } = string.Empty;
        }
    }
}
