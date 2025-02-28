using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Workout_App.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName { get; set; } = "User Name"; // Example data
        public string Email { get; set; } = "user@example.com"; // Example data
        public string Password { get; set; } = "password"; // Example data

        public ICommand SaveChangesCommand { get; }
        public ICommand SupportCommand { get; }
        public ICommand TermsOfServiceCommand { get; }

        public SettingsViewModel()
        {
            SaveChangesCommand = new Command(async () => await SaveChanges());
            SupportCommand = new Command(async () => await Support());
            TermsOfServiceCommand = new Command(async () => await TermsOfService());
        }

        private async Task SaveChanges()
        {
            // Implement save changes logic here
            await Application.Current.MainPage.DisplayAlert("Saved", "Your changes have been saved.", "OK");
        }

        private async Task Support()
        {
            // Implement support logic here (e.g., open email or website)
            await Application.Current.MainPage.DisplayAlert("Support", "Contact support at support@example.com", "OK");
        }

        private async Task TermsOfService()
        {
            // Implement terms of service logic here (e.g., open web browser)
            await Application.Current.MainPage.DisplayAlert("Terms of Service", "Terms of Service content here.", "OK");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}