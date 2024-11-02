using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class AdminUser : User
    {
        // Konstruktor för att skapa en ny administratörsanvändare
        // Anropar basklassens (User) konstruktor för att initiera gemensamma användaregenskaper
        public AdminUser(string username, string password, string country, string securityQuestion, string securityAnswer)
        : base(username, password, country, securityQuestion, securityAnswer) 
        {
        }

        public void ManageAllWorkouts()
        {
            // Logic for managing workouts ............

        }
    }
}
