using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Workout_App.DTO;
using Workout_App.DTOs;

namespace Workout_App.Services
{
    public class ApiDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7128/"; // Replace with your API's URL

        public ApiDataService()
        {
            _httpClient = new HttpClient();
        }

        // Workouts
        public async Task<List<WorkoutDto>> GetWorkoutsAsync(int? userId = null)
        {
            string url = $"{_baseUrl}/api/Workouts";
            if (userId != null)
            {
                url += $"?userId={userId}";
            }

            try
            {
                return await _httpClient.GetFromJsonAsync<List<WorkoutDto>>(url);
            }
            catch (HttpRequestException ex)
            {
                // Handle network errors, API errors, etc.
                Console.WriteLine($"Error getting workouts: {ex.Message}");
                return null; // or throw an exception, depending on your error handling strategy
            }
        }

        public async Task<WorkoutDto> GetWorkoutAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<WorkoutDto>($"{_baseUrl}/api/Workouts/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting workout: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddWorkoutAsync(WorkoutDto workout)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Workouts", workout);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding workout: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateWorkoutAsync(WorkoutDto workout)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Workouts/{workout.Id}", workout);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error updating workout: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Workouts/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting workout: {ex.Message}");
                return false;
            }
        }

        // Exercises
        public async Task<List<ExerciseDto>> GetExercisesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ExerciseDto>>($"{_baseUrl}/api/Exercises");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting exercises: {ex.Message}");
                return null;
            }
        }

        public async Task<ExerciseDto> GetExerciseAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ExerciseDto>($"{_baseUrl}/api/Exercises/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting exercise: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddExerciseAsync(ExerciseDto exercise)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Exercises", exercise);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding exercise: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateExerciseAsync(ExerciseDto exercise)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Exercises/{exercise.Id}", exercise);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error updating exercise: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteExerciseAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Exercises/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting exercise: {ex.Message}");
                return false;
            }
        }

        // Users
        public async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<UserDto>>($"{_baseUrl}/api/Users");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting users: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<UserDto>($"{_baseUrl}/api/Users/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting user: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddUserAsync(UserDto user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Users", user);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Users/{user.Id}", user);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Users/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }
    }
}
