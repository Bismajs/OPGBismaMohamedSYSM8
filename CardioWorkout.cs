using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class CardioWorkout : Workout
    {
        //EGENSKAP
        public int Distance { get; set; }
        //METOD
        public override int CalculateCaloriesBurned()
        {
            // Beräkningslogik för konditionsträning
            return Distance * 10; // förbränning per distansenhet
        }
    }
    }
