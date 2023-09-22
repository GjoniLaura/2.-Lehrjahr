using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Masterpasswort Verifizierung
            string Masterpassword = "abc";
            int MaxAttemps = 2;
            int Attemps = 0;

            while (Attemps < MaxAttemps)

                Console.Write("Geben Sie das Masterpasswort ein: ");
            string Password = Console.ReadLine();
            if (Password == Masterpassword)
            {
                Console.WriteLine("Übersicht Ihrer Passwörter: ");
                Masterpassword = Convert.ToString(Console.ReadLine());
                // Passworteinträge anzeigen
                // URl 
                // Username und Passwort speichern
            }
            else
            {
                Attemps = Attemps + 1;

                Console.WriteLine("Falsche Passworteingabe, versuchen Sie es erneut: ");
            }
            Console.WriteLine("Falsche Passworteingabe, der Zugriff wird nicht Gewährt");
            Console.ReadLine();
        }
    }

    }
}
