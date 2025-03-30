namespace Workout_API.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Image { get; set; }
        public string Target { get; set; } = "";
    }
}
