using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class Menu
    {
        public static string titel = "Passwortmanager\n" +
                           "-----------------------------------------------";
        public static void mainmenu()
        {
            Console.Clear();
            int dec;

            do
            {
                Console.WriteLine(titel);
                Console.WriteLine("Was möchtest du tun?");
                Console.WriteLine("1.Alle meine Passwörter anzeigen lassen");
                Console.WriteLine("2.Ein neues Passwort hinzufügen");
                Console.WriteLine("3.Ein Passwort Löschen");
                Console.WriteLine("4.Passwort generieren lassen");
                Console.WriteLine("5.Passwort mit url/webseitename suchen");
                Console.WriteLine("6.Benutzer Account Löschen");
                Console.WriteLine("7.Exit");
                Console.Write("\nEingabe:");

                if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 7)
                {
                    dec = input;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 1 und 7 ein.\n");
                }
            } while (true);

            switch (dec) 
            {
               case 1:
                    showpasswords();
                    break;
               case 2:
                    addpassword();
                    break;

            }
        }

        static void showpasswords()
        {

        }

        static void addpassword()
        {
            string password_titel = "";
            string password = "";
            string place = "";
            string username = "";

            Console.Clear();
            Console.WriteLine(titel);
            Console.WriteLine("Neues Passwort hinzufügen\n");

            Console.Write("Titel des Passworteintrags: ");
            password_titel = Console.ReadLine();

            Console.WriteLine("");


        }
    }
}
