using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Workout_App.Models;
using Xamarin.Forms;

namespace Workout_App.ViewModels
{
    public class ExerciseDetailPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Exercise _exercise;
        public Exercise Exercise
        {
            get => _exercise;
            set
            {
                _exercise = value;
                OnPropertyChanged(nameof(Exercise));
            }
        }

        public ICommand SaveExerciseCommand { get; }

        public ExerciseDetailPageViewModel(Exercise exercise = null)
        {
            Exercise = exercise ?? new Exercise();
            SaveExerciseCommand = new Command(async () => await SaveExercise());
        }

        private async Task SaveExercise()
        {
            App.Database.SaveExercise(Exercise);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
