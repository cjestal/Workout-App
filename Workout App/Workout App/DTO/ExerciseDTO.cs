using System;
using System.Collections.Generic;
using System.Text;

namespace Workout_App.DTO
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Image { get; set; }
        public string Target { get; set; } = "";
    }

}

