using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Workout_App.Models;

namespace Workout_App.Services
{
    public class DatabaseService
    {
        readonly SQLiteConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<WorkoutDTO>();
            _database.CreateTable<ExerciseDTO>();
        }

        // Workout CRUD Operations
        public List<WorkoutDTO> GetWorkouts()
        {
            return _database.Table<WorkoutDTO>().ToList();
        }

        public WorkoutDTO GetWorkout(int id)
        {
            return _database.Table<WorkoutDTO>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SaveWorkout(WorkoutDTO workout)
        {
            if (workout.Id != 0)
            {
                return _database.Update(workout);
            }
            else
            {
                return _database.Insert(workout);
            }
        }

        public int DeleteWorkout(WorkoutDTO workout)
        {
            return _database.Delete(workout);
        }

        public List<WorkoutDTO> GetWorkoutsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _database.Table<WorkoutDTO>().Where(w => w.Date >= startDate && w.Date <= endDate).ToList();
        }

        // Exercise CRUD Operations

        public List<ExerciseDTO> GetExercises()
        {
            return _database.Table<ExerciseDTO>().ToList();
        }

        public ExerciseDTO GetExercise(int id)
        {
            return _database.Table<ExerciseDTO>().Where(e => e.Id == id).FirstOrDefault();
        }

        public int SaveExercise(ExerciseDTO exercise)
        {
            if (exercise.Id != 0)
            {
                return _database.Update(exercise);
            }
            else
            {
                return _database.Insert(exercise);
            }
        }

        public int DeleteExercise(ExerciseDTO exercise)
        {
            return _database.Delete(exercise);
        }

        
    }
}
