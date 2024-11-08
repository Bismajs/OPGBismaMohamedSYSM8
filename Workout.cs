﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public abstract class Workout
    {
        //egenskaper
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }

        //metod
        public abstract int CalculateCaloriesBurned();
    }
}
