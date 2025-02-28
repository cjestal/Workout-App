using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Workout_App.ViewModels
{
    public class ExerciseLibraryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Exercise> Exercises { get; set; } = new ObservableCollection<Exercise>(); // Replace Exercise with your model

        public ExerciseLibraryViewModel()
        {
            LoadExercises();
        }

        private void LoadExercises()
        {
            // Example data (replace with your actual exercise data)
            Exercises.Add(new Exercise { Name = "Push-ups", Image = "pushups.png" });
            Exercises.Add(new Exercise { Name = "Squats", Image = "squats.png" });
            // ... Add more exercises
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Example Exercise Model (Add this to your Models folder)
    public class Exercise
    {
        public string Name { get; set; }
        public string Image { get; set; }
        // Add other exercise properties as needed
    }
}