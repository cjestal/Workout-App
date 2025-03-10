using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workout_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressPage : ContentPage
    {
        public ObservableCollection<ProgressItem> ProgressData { get; set; }
        public ProgressPage()
        {
            InitializeComponent();
            InitializeProgressData();
            BindingContext = this;
            //InitializeComponent();
            //BindingContext = new ProgressViewModel(); // Instantiate ViewModel
            //InitializeProgressData();
        }

        private void InitializeProgressData()
        {
            ProgressData = new ObservableCollection<ProgressItem>
            {
                new ProgressItem
                {
                    Date = DateTime.Now.ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Bench Press", Reps = 8, Sets = 3, Weight = "150 lbs", Notes = "Good form" },
                        new Workout { WorkoutName = "Incline Press", Reps = 10, Sets = 3, Weight = "100 lbs", Notes = "Felt it in upper chest" }
                    }
                },
                new ProgressItem
                {
                    Date = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Squats", Reps = 10, Sets = 4, Weight = "200 lbs", Notes = "Deep squats" },
                        new Workout { WorkoutName = "Deadlifts", Reps = 5, Sets = 2, Weight = "250 lbs", Notes = "Heavy day" }
                    }
                },
                new ProgressItem
                {
                    Date = DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Pull-ups", Reps = 6, Sets = 3, Weight = "Bodyweight", Notes = "Challenging workout" },
                        new Workout { WorkoutName = "Rows", Reps = 12, Sets = 3, Weight = "120 lbs", Notes = "Good back day" }
                    }
                },
                new ProgressItem
                {
                    Date = DateTime.Now.AddDays(-3).ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Shoulder Press", Reps = 8, Sets = 3, Weight = "80 lbs", Notes = "Controlled movements" },
                        new Workout { WorkoutName = "Lateral Raises", Reps = 15, Sets = 3, Weight = "20 lbs", Notes = "Burnout sets" }
                    }
                },
                new ProgressItem
                {
                    Date = DateTime.Now.AddDays(-4).ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Bicep Curls", Reps = 10, Sets = 3, Weight = "40 lbs", Notes = "Focused on contraction" },
                        new Workout { WorkoutName = "Tricep Extensions", Reps = 12, Sets = 3, Weight = "50 lbs", Notes = "Full range of motion" }
                    }
                },
                new ProgressItem
                {
                    Date = DateTime.Now.AddDays(-5).ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Leg Press", Reps = 12, Sets = 3, Weight = "300 lbs", Notes = "Heavy leg day" },
                        new Workout { WorkoutName = "Hamstring Curls", Reps = 15, Sets = 3, Weight = "70 lbs", Notes = "Felt the burn" }
                    }
                },
                new ProgressItem
                {
                    Date = DateTime.Now.AddDays(-6).ToString("MM/dd/yyyy"),
                    Workouts = new List<Workout>
                    {
                        new Workout { WorkoutName = "Chest Flyes", Reps = 10, Sets = 3, Weight = "30 lbs", Notes = "Slow and controlled" },
                        new Workout { WorkoutName = "Cable Crossovers", Reps = 12, Sets = 3, Weight = "25 lbs", Notes = "Targeted inner chest" }
                    }
                }
            };
        }

        public class ProgressItem
        {
            public string Date { get; set; }
            public List<Workout> Workouts { get; set; }
        }

        public class Workout
        {
            public string WorkoutName { get; set; }
            public int Reps { get; set; }
            public int Sets { get; set; }
            public string Weight { get; set; }
            public string Notes { get; set; }
        }

    }
}