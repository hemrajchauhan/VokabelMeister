using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using VokabelMeister.Models;
using VokabelMeister.Services;
using VokabelMeister.Helpers;

namespace VokabelMeister.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new();
        private string _inputText = string.Empty;
        private string _result = string.Empty;

        public string InputText
        {
            get => _inputText;
            set { _inputText = value; OnPropertyChanged(); }
        }

        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(); }
        }

        private FormattedString _highlightedResult = new();
        public FormattedString HighlightedResult
        {
            get => _highlightedResult;
            set { _highlightedResult = value; OnPropertyChanged(); }
        }

        public ICommand CheckGrammarCommand { get; }

        public MainPageViewModel()
        {
            CheckGrammarCommand = new Command(async () => await CheckGrammarAsync());
        }

        public async Task CheckGrammarAsync()
        {
            if (!string.IsNullOrWhiteSpace(InputText))
            {
                var grammarResult = await _apiService.CheckGrammarAsync(InputText);

                if (grammarResult?.Matches != null && grammarResult.Matches.Any())
                {
                    HighlightedResult = TextHighlighter.HighlightMistakes(InputText, grammarResult.Matches);
                }
                else
                {
                    HighlightedResult = new FormattedString { Spans = { new Span { Text = "No grammar mistakes found!" } } };
                }
            }
            else
            {
                Result = "Please enter a sentence.";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
