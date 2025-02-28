using System.ComponentModel;
using System.Windows.Input;
using Workout_App.Views;
using Xamarin.Forms;

namespace Workout_App.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName { get; set; } = "User Name"; // Example data
        public string ProfilePicture { get; set; } = "profile_placeholder.png"; // Example image
        public int WorkoutsCompleted { get; set; } = 10; // Example data
        public int CaloriesBurned { get; set; } = 5000; // Example data

        public ICommand LogWorkoutCommand { get; }
        public ICommand ViewProgressCommand { get; }

        public DashboardViewModel()
        {
            LogWorkoutCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new WorkoutLogPage()));
            ViewProgressCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new ProgressPage()));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}