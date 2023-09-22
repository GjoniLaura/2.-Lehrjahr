using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class Program
    {
       /* static void Main(string[] args)
        {
            // Masterpasswort Verifizierung
            string Masterpassword = "abc";
            int MaxAttemps = 2;
            int Attemps = 0;

            while (Attemps < MaxAttemps)
            {

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

                    Console.WriteLine("Falsche Passworteingabe, versuchen Sie es erneut ({0} von {1}): ", Attemps, MaxAttemps);
                }

            }

            if (Attemps == MaxAttemps)
            {
                Console.WriteLine("Falsche Passworteingabe, der Zugriff wird nicht Gewährt");
                Console.ReadLine();
            }
        }
        */

        static void Main()
        {
            string MasterPassword = "abc";
            int MaxAttempts = 2;
            int Attempts = 0;

            if (Attempts < MaxAttempts)
            {
                Console.Write("Bitte geben Sie das Passwort ein: ");
                string EnteredPassword = Console.ReadLine();

                if (EnteredPassword == MasterPassword)
                {
                    Console.WriteLine("Anmeldung erfolgreich!");
                }
                else
                {
                    Attempts++;
                    Console.WriteLine("Falsches Passwort. Versuch {0} von {1}", Attempts, MaxAttempts);
                }
            }

            if (Attempts == MaxAttempts)
            {
                Console.WriteLine("Anmeldung fehlgeschlagen. Sie haben alle Versuche aufgebraucht.");
            }
        }
    }


}

