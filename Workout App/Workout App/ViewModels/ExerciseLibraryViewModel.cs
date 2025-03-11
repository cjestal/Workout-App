using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Workout_App.Models;
using Workout_App.Views;
using Xamarin.Forms;

namespace Workout_App.ViewModels
{
    public class ExerciseLibraryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Thumbnail = "https://cdn-icons-png.freepik.com/256/3867/3867892.png";
        public ObservableCollection<Exercise> Exercises { get; set; } = new ObservableCollection<Exercise>();
        public ICommand AddExerciseCommand { get; }
        public ICommand EditExerciseCommand { get; }
        public ICommand DeleteExerciseCommand { get; }
        public ICommand LoadExercisesCommand { get; }
        private Exercise _selectedExercise;
        public Exercise SelectedExercise
        {
            get => _selectedExercise;
            set
            {
                _selectedExercise = value;
                OnPropertyChanged(nameof(SelectedExercise));
            }
        }

        //public ExerciseLibraryViewModel()
        //{
        //    LoadExercises();
        //}
        public ExerciseLibraryViewModel()
        {
            AddExerciseCommand = new Command(async () => await AddExercise());
            EditExerciseCommand = new Command(async () => await EditExercise());
            DeleteExerciseCommand = new Command(async () => await DeleteExercise());
            LoadExercisesCommand = new Command( () => LoadExercises());

            LoadExercisesCommand.Execute(null); //Load on construction.
        }

        private void LoadExercises()
        {
            //Exercises.Add(new Exercise { Name = "Push-ups", Image = "https://media.istockphoto.com/id/1225549108/vector/run-sport-exercise-vector-icon-illustration.jpg?s=2048x2048&w=is&k=20&c=LEVwLxYiDYhlBzrLuKmqBy3yN3UBQn-4i4yWPWHrOxQ=" });

            Exercises.Add(new Exercise { Name = "Push-ups", Image = Thumbnail, Target = "Chest" });
            Exercises.Add(new Exercise { Name = "Squats", Image = Thumbnail, Target = "Legs" });
            Exercises.Add(new Exercise { Name = "Lunges", Image = Thumbnail, Target = "Legs, Glutes" });
            Exercises.Add(new Exercise { Name = "Pull-ups", Image = Thumbnail, Target = "Back, Arms" });
            Exercises.Add(new Exercise { Name = "Bench Press", Image = Thumbnail, Target = "Chest" });
            Exercises.Add(new Exercise { Name = "Deadlifts", Image = Thumbnail, Target = "Back" });
            Exercises.Add(new Exercise { Name = "Overhead Press", Image = Thumbnail, Target = "Shoulders" });
            Exercises.Add(new Exercise { Name = "Rows", Image = Thumbnail, Target = "Back" });
            Exercises.Add(new Exercise { Name = "Barbell Curls", Image = Thumbnail, Target = "Biceps" });
            Exercises.Add(new Exercise { Name = "Triceps Dips", Image = Thumbnail, Target = "Triceps" });
            Exercises.Add(new Exercise { Name = "Planks", Image = Thumbnail, Target = "Core" });
            Exercises.Add(new Exercise { Name = "Crunches", Image = Thumbnail, Target = "Abs" });
            Exercises.Add(new Exercise { Name = "Leg Raises", Image = Thumbnail, Target = "Abs" });
            Exercises.Add(new Exercise { Name = "Burpees", Image = Thumbnail, Target = "Full" });
            Exercises.Add(new Exercise { Name = "Jumping Jacks", Image = Thumbnail, Target = "Cardio" });
            Exercises.Add(new Exercise { Name = "Mountain Climbers", Image = Thumbnail, Target = "Cardio" });
            Exercises.Add(new Exercise { Name = "Russian Twists", Image = Thumbnail, Target = "Obliques" });
            Exercises.Add(new Exercise { Name = "Bicep Curls", Image = Thumbnail, Target = "Biceps" });
            Exercises.Add(new Exercise { Name = "Tricep Extensions", Image = Thumbnail, Target = "Triceps" });
            Exercises.Add(new Exercise { Name = "Calf Raises", Image = Thumbnail, Target = "Calves" });
            Exercises.Add(new Exercise { Name = "Seated Rows", Image = Thumbnail, Target = "Back" });
            Exercises.Add(new Exercise { Name = "Shoulder Press", Image = Thumbnail, Target = "Shoulders" });
            Exercises.Add(new Exercise { Name = "Lateral Raises", Image = Thumbnail, Target = "Shoulders" });
            Exercises.Add(new Exercise { Name = "Front Raises", Image = Thumbnail, Target = "Shoulders" });
            Exercises.Add(new Exercise { Name = "Leg Press", Image = Thumbnail, Target = "Legs" });
            Exercises.Add(new Exercise { Name = "Chest Flys", Image = Thumbnail, Target = "Chest" });
            // ... Add more exercises
        }

        private async Task AddExercise()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ExerciseDetailPage());
        }

        private async Task EditExercise()
        {
            if (SelectedExercise != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ExerciseDetailPage(SelectedExercise));
            }
        }

        private async Task DeleteExercise()
        {
            if (SelectedExercise != null)
            {
                bool result = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to delete this exercise?", "Yes", "No");
                if (result)
                {
                    App.Database.DeleteExercise(SelectedExercise); // Assumes DeleteExercise in DatabaseService
                    LoadExercises();
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}