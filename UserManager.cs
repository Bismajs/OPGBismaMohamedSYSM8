using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public static class UserManager
    {
        // Lista för att lagra användare
        private static List<User> users = new List<User>();

        // Registrera en ny användare
        public static bool RegisterUser(string username, string password, string country, string securityQuestion, string securityAnswer)
        {
            // Kontrollera om användarnamnet redan finns
            if (users.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // upptaget
            }

            // Skapa en ny användare och lägg till den i listan
            User newUser = new User(username, password, country, securityQuestion, securityAnswer);
            users.Add(newUser);
            return true; // lyckades
        }

        // Validera användarnamn och lösenord
        public static bool ValidateUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password)
                {
                    return true; // lyckades
                }
            }
            return false; // misslyckades
        }

        // Hantera lösenordsåterställning
        public static bool ResetPassword(string username, string securityAnswer, string newPassword)
        {
            var user = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user != null && user.SecurityAnswer.Equals(securityAnswer, StringComparison.OrdinalIgnoreCase))
            {
                user.Password = newPassword; 
                return true; // Lösenordet har återställts
            }
            return false; // Lösenordsåterställning misslyckades
        }

        //Metod för att hämta alla användare (admin tingz)
        public static List<User> GetAllUsers()
        {
            return users;
        }

        public static User GetUserByUsername(string username)
        {
            return users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        // Ny metod för att initiera standardanvändare
        public static void InitializeDefaultUsers()
        {
            // Kontrollera om användarna redan finns
            if (!users.Any(u => u.Username.Equals("admin", StringComparison.OrdinalIgnoreCase)))
            {
                // Lägg till en admin-användare
                AdminUser admin = new AdminUser(
                    "admin",
                    "admin123",
                    "Sweden",
                    "What is your favorite color?",
                    "Red"
                );
                users.Add(admin);
            }
            if (!users.Any(u => u.Username.Equals("user", StringComparison.OrdinalIgnoreCase)))
            {
                // Lägg till en vanlig användare
                User normalUser = new User(
                    "user",
                    "user123",
                    "Sweden",
                    "What is your pet's name?",
                    "Max"
                );

                // Lägg till två standardträningspass

                normalUser.Workouts.Add(new StrengthWorkout
                {
                    Date = DateTime.Now.AddDays(-1), // en dag sedan 
                    Duration = TimeSpan.FromMinutes(30),
                    CaloriesBurned = 150,
                    Notes = "Strength training for chest and shoulders.",
                    Type = "Strength",
                    Repetitions = 10
                });

                normalUser.Workouts.Add(new CardioWorkout
                {
                    Date = DateTime.Now.AddDays(-2), // För två dagar sedan
                    Duration = TimeSpan.FromMinutes(45),
                    CaloriesBurned = 300,
                    Notes = "Morning jog in the park.",
                    Type = "Cardio",
                    Distance = 5 
                });

                // Lägg till användaren till listan
                users.Add(normalUser);
            }
        }


    }
}

        
