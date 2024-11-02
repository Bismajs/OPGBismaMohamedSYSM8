using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{

    public class User : Person
    {
        //egenskaper
        public string Country { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        // Lista för att lagra användare 
        private static List<User> users = new List<User>();

        // Konstruktor
        public User(string username, string password, string country, string securityQuestion, string securityAnswer)
        {
            Username = username;
            Password = password; 
            Country = country;
            SecurityQuestion = securityQuestion;
            SecurityAnswer = securityAnswer;
        }

        //metod för inloggning
        public override void SignIn()
        {
            
            //Console.WriteLine("SignIn method called.");
        }

        //metod för att authenticate användare med namn och lösen
        public static bool Authenticate(string username, string password)
        {
            foreach (var user in users) //loopar igenom registrerade användare
            {
                //ser ttill att namn och lösen matchar
                if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password)
                {
                    return true; //lyckades
                }
            }
            return false; // misslyckades rip
        }

        //metod för att återställa lösen
        public void ResetPassword(string securityAnswer, string newPassword)
        {
            //kontrollerar svar på säkerhetsfrågan är rätt
            if (this.SecurityAnswer.Equals(securityAnswer, StringComparison.OrdinalIgnoreCase))
            {
                Password = newPassword; // Tilldela det nya lösenordet
                Console.WriteLine("Password has been reset successfully.");
            }
            else
            {
                Console.WriteLine("Security answer is incorrect."); //FEL
            }
        }

        //Metod som registrerar ny användare
        public static void RegisterUser(User newUser)
        {
            users.Add(newUser); // Lägger till användaren i listan
        }
    }

}