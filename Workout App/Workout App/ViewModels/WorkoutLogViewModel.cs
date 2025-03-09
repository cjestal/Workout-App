using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<string> ExerciseNames { get; set; } = new ObservableCollection<string>();


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

        private string _selectedExerciseName;
        public string SelectedExerciseName
        {
            get => _selectedExerciseName;
            set
            {
                _selectedExerciseName = value;
                OnPropertyChanged(nameof(SelectedExerciseName));
            }
        }

        public ICommand SaveWorkoutCommand { get; }
        public ICommand AddPhotoCommand { get; }

        public WorkoutLogViewModel(Workout workout = null)
        {
            Workout = workout ?? new Workout();
            SaveWorkoutCommand = new Command(async () => await SaveWorkout());
            LoadExerciseNames();
        }

        private async Task SaveWorkout()
        {
            App.Database.SaveWorkout(Workout);
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        private void LoadExerciseNames()
        {
            ExerciseNames.Clear();
            // TODO fetch from db
            //var exercises = App.Database.GetExercises();
            //foreach (var exercise in exercises)
            //{
            //    ExerciseNames.Add(exercise.Name);
            //}

            ExerciseNames.Add("Push-ups");
            ExerciseNames.Add("Sit-ups");
            ExerciseNames.Add("Crunches");

        }

        private void LoadSelectedExerciseName(int exerciseId)
        {
            var exercise = App.Database.GetExercise(exerciseId);
            if (exercise != null)
            {
                SelectedExerciseName = exercise.Name;
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
