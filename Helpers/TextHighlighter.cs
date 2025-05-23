using System.Collections.Generic;
using Microsoft.Maui.Controls;
using VokabelMeister.Models;

namespace VokabelMeister.Helpers
{
    public static class TextHighlighter
    {
        public static FormattedString HighlightMistakes(string inputText, List<CheckGrammarResponse.Match> matches)
        {
            var formatted = new FormattedString();
            int lastPos = 0;

            foreach (var match in matches.OrderBy(m => m.Offset))
            {
                // Add normal text
                if (match.Offset > lastPos)
                {
                    formatted.Spans.Add(new Span
                    {
                        Text = inputText.Substring(lastPos, match.Offset - lastPos)
                    });
                }

                // Add highlighted mistake
                formatted.Spans.Add(new Span
                {
                    Text = inputText.Substring(match.Offset, match.Length),
                    TextColor = Colors.Red,
                    FontAttributes = FontAttributes.Bold
                });

                lastPos = match.Offset + match.Length;
            }

            // Add remaining text
            if (lastPos < inputText.Length)
            {
                formatted.Spans.Add(new Span
                {
                    Text = inputText.Substring(lastPos)
                });
            }

            return formatted;
        }
    }
}
