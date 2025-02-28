using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Workout_App.Models;
using Xamarin.Forms;

namespace Workout_App.ViewModels
{
    public class WorkoutLogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Workout _workout;
        public Workout Workout
        {
            get => _workout;
            set
            {
                _workout = value;
                OnPropertyChanged(nameof(Workout));
            }
        }

        public ICommand SaveWorkoutCommand { get; }
        public ICommand AddPhotoCommand { get; }

        public WorkoutLogViewModel(Workout workout = null)
        {
            Workout = workout ?? new Workout();
            SaveWorkoutCommand = new Command(async () => await SaveWorkout());
            AddPhotoCommand = new Command(async () => await AddPhoto());
        }

        private async Task SaveWorkout()
        {
            App.Database.SaveWorkout(Workout);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task AddPhoto()
        {
            // Implement photo picking logic here (using Xamarin.Essentials or a plugin)
            // Example Placeholder:
            // string photoPath = await MediaPicker.CapturePhotoAsync();
            // Workout.ImagePath = photoPath;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
