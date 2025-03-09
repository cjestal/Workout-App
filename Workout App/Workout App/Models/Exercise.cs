using System;
using System.Collections.Generic;
using System.Text;

namespace Workout_App.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } // optional maybe?
        public string Target { get; set; } // arms, chest, etc
    }
}
