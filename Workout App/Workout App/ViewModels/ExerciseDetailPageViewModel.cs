using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> TargetNames { get; set; } = new ObservableCollection<string>();

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

        private string _selectedTargetName;
        public string SelectedTargetName
        {
            get => _selectedTargetName;
            set
            {
                _selectedTargetName = value;
                OnPropertyChanged(nameof(SelectedTargetName));
            }
        }

        public ICommand SaveExerciseCommand { get; }

        public ExerciseDetailPageViewModel(Exercise exercise = null)
        {
            Exercise = exercise ?? new Exercise();
            SaveExerciseCommand = new Command(async () => await SaveExercise());
            LoadTargetNames();
        }

        private async Task SaveExercise()
        {
            App.Database.SaveExercise(Exercise);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void LoadTargetNames()
        {
            TargetNames.Clear();
            // TODO fetch from db
            //var exercises = App.Database.GetExercises();
            //foreach (var exercise in exercises)
            //{
            //    ExerciseNames.Add(exercise.Name);
            //}

            TargetNames.Add("Abs");
            TargetNames.Add("Back");
            TargetNames.Add("Biceps");
            TargetNames.Add("Chest");
            TargetNames.Add("Triceps");

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
