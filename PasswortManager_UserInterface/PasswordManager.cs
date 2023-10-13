using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using BCrypt.Net;
using System.Net.Http.Headers;

namespace PasswortManager_UserInterface
{
    internal class PasswordManager
    {
         string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\Textdokument.jason";

        public static List<User> users = new List<User>();


        public static void LoOrRe()
        {
            int dec = 0;

            while (dec != 1 && dec != 2)
            {
                Console.WriteLine("Passwortmanager\n" +
                                   "-----------------------------------------------------");
                Console.WriteLine("Möchtest du dich anmelden oder Registrieren?");
                Console.WriteLine("1. Für anmelden drücke 1");
                Console.WriteLine("2. Für Registrieren drücke 2");

                
                if (!int.TryParse(Console.ReadLine(), out dec) || (dec != 1 && dec != 2))
                {
                    Console.Clear();
                    Console.WriteLine("\nBitte eine gültige Zahl (1 oder 2) eingeben. \n");
                }
            }

            switch (dec)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
            }
        }

        public static void Register() {
            string titel = "Registrieren\n----------------------------------------------------------------";
            string username;
            string masterpassword;

            Console.Clear();
            Console.WriteLine(titel);

            do
            {
                Console.Write("Gib deinen Benutzernamen ein: ");
                username = Console.ReadLine();

                if (users.Any(u => u.username == username))
                {
                    Console.Clear();
                    Console.WriteLine(titel);
                    Console.WriteLine("Dieser Benutzername ist bereits vergeben. Bitte wählen Sie einen anderen.\n");
                }
            } while (users.Any(u => u.username == username));

            do
            {
                Console.Write("Gib ein sicheres Passwort ein mit mindestens 15 Zeichen: ");
                masterpassword = Console.ReadLine();

                if (masterpassword.Length < 15)
                {
                    Console.WriteLine("\nDas Passwort ist zu kurz.");
                }
            } while (masterpassword.Length < 15);

            masterpassword = HashPasswordBCrypt(masterpassword);

            users.Add(new User{ username = username, masterpassword = masterpassword });
            SaveUsers(users);
            Console.WriteLine("--------------------------------------------------------------------------------" +
                             "\nAccount wurde erfolgreich erstellt.Drücke eine Taste um zum Login zu gelangen.");
            Console.ReadKey();
            Login();
        }
        public static void Login()
        {
            Console.Clear();
            string username;
            string masterpassword;
            string titel = "Login\n----------------------------------------------------------";
            int counter = 0;
            int anztry = 3;

            Console.WriteLine(titel);
            do
            {
                Console.Write("Benutzernamen: ");
                username = Console.ReadLine();

                if (!users.Any(u => u.username == username))
                {
                    Console.Clear();
                    Console.WriteLine(titel);
                    Console.WriteLine("Dieser Benutzer Existiert nicht.\n");
                }
            } while (!users.Any(u => u.username == username));
            User founduser = users.FirstOrDefault(u => u.username == username);
            do
            {
                Console.Write("Passwort: ");
                masterpassword = Console.ReadLine();
                if (ValidatePassword(masterpassword, founduser.masterpassword))
                {
                    Menu.mainmenu();
                }
                else
                {
                    if(counter == 3)
                        Environment.Exit(0);
                    Console.WriteLine("\nPasswort ist falsch du hast noch {0} Versuche", anztry - counter);
                }
                counter++;
            } while (counter <= anztry);
        }

        public static string HashPasswordBCrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ValidatePassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }




        //Json save and read
        public static void SaveUsers(object obj)
        {
            string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\Textdokument.json";
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(path, json);
        }

        public static List<User> ReadUsers()
        {
            string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\Textdokument.json";
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<User>>(json);
        }
    }
}