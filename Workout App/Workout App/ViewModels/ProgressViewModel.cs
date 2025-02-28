using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using Workout_App.Models;

namespace Workout_App.ViewModels
{
    public class ProgressViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Workout> ProgressData { get; set; } = new ObservableCollection<Workout>();

        private DateTime _startDate = DateTime.Now.AddDays(-7);
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                LoadProgressData();
            }
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                LoadProgressData();
            }
        }

        public ProgressViewModel()
        {
            LoadProgressData();
        }

        private void LoadProgressData()
        {
            ProgressData.Clear();
            var workouts = App.Database.GetWorkoutsByDateRange(StartDate, EndDate);
            foreach (var workout in workouts)
            {
                ProgressData.Add(workout);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}