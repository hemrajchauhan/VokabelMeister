using System;

namespace VokabelMeister.Helpers
{
    public static class ApiConfig
    {
        // Base URL of your FastAPI backend
        public static string BaseUrl = "https://germanai-backend.fly.dev/";

        // Endpoints
        public static string CheckGrammar = "check-grammar";
        public static string TranslateWord = "translate-word";
        // Future endpoints:
        // public static string ExplainGrammar = "explain-grammar";
        // public static string WordList = "words";
        // public static string Quiz = "quiz";
    }
}
