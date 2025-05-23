using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VokabelMeister.Services;

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

        public ICommand CheckGrammarCommand { get; }

        public MainPageViewModel()
        {
            CheckGrammarCommand = new Command(async () => await CheckGrammarAsync());
        }

        public async Task CheckGrammarAsync()
        {
            if (!string.IsNullOrWhiteSpace(InputText))
                Result = await _apiService.CheckGrammarAsync(InputText);
            else
                Result = "Please enter a sentence.";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
