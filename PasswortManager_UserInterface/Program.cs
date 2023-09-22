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

            Console.Write("Geben Sie das Masterpasswort ein: ");
            string Password = Console.ReadLine();

            if (Attemps < MaxAttemps && Password == Masterpassword)
            {
                Console.WriteLine("Übersicht Ihrer Passwörter: ");
                Masterpassword = Convert.ToString(Console.ReadLine());
                // Passworteinträge anzeigen
                // URl 
                // Username und Passwort speichern
            }
            else
            {
                if (Attemps < MaxAttemps && Password != Masterpassword) {
                    Console.WriteLine("Falsche Passworteingabe, versuchen Sie es erneut (1/2) ");
                }

            }

            }

            if (Attemps == MaxAttemps)
            {
                Console.WriteLine("Falsche Passworteingabe, der Zugriff wird nicht Gewährt");
                Console.ReadLine();
            }
        }
        
    }


}

