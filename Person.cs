using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public abstract class Person
    {
        //Egenskaper
        public string Username { get; set; }
        public string Password { get; set; }

        //Ingen konstruktor

        //Metod

        public abstract void SignIn();

    }
}
