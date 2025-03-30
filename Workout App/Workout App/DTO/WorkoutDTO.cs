using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workout_App.DTO
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; } = "";
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double WeightLifted { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Notes { get; set; } = "";
        public int UserId { get; set; }
    }
}
