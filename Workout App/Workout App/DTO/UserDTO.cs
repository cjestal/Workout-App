﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Workout_App.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
