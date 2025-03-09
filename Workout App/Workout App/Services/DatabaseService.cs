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
            _database.CreateTable<Workout>();
            _database.CreateTable<Exercise>();
        }

        // Workout CRUD Operations
        public List<Workout> GetWorkouts()
        {
            return _database.Table<Workout>().ToList();
        }

        public Workout GetWorkout(int id)
        {
            return _database.Table<Workout>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SaveWorkout(Workout workout)
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

        public int DeleteWorkout(Workout workout)
        {
            return _database.Delete(workout);
        }

        public List<Workout> GetWorkoutsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _database.Table<Workout>().Where(w => w.Date >= startDate && w.Date <= endDate).ToList();
        }

        // Exercise CRUD Operations

        public List<Exercise> GetExercises()
        {
            return _database.Table<Exercise>().ToList();
        }

        public Exercise GetExercise(int id)
        {
            return _database.Table<Exercise>().Where(e => e.Id == id).FirstOrDefault();
        }

        public int SaveExercise(Exercise exercise)
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

        public int DeleteExercise(Exercise exercise)
        {
            return _database.Delete(exercise);
        }

        
    }
}
