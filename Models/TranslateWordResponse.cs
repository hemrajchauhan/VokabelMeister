using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VokabelMeister.Models
{
    public class TranslateWordResponse
    {
        public string Word { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;          // noun, verb, adjective, etc.
        public string Translation { get; set; } = string.Empty;   // English translation
        public List<string> Examples { get; set; } = new(); // Example sentences
    }
}
