using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswortManager_UserInterface
{
    internal class Menu
    {
        public static string titel = "Passwortmanager\n" +
                           "-----------------------------------------------";
        public static void mainmenu()
        {
            User founduser = PasswordManager.users.FirstOrDefault(u => u.Username == PasswordManager.angemeldet);
            Console.Clear();
            int dec;
          
            do
            {
                Console.WriteLine(titel);
                Console.WriteLine("Was möchtest du tun?");
                Console.WriteLine("1.Alle meine Passwörter anzeigen lassen");
                Console.WriteLine("2.Ein neues Passwort hinzufügen");
                Console.WriteLine("3.Ein Passwort Löschen");
                Console.WriteLine("4.Passwort Gruppen");
                Console.WriteLine("5.Passwort generieren lassen");
                Console.WriteLine("6.Passwort mit url/webseitename suchen");
                Console.WriteLine("7.Benutzer Account Löschen");
                Console.WriteLine("8.Exit");
                Console.Write("\nEingabe:");

                if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 8)
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
                    ShowAllPasswords(founduser);
                    break;
               case 2:
                    addpassword(founduser);
                    break;
               case 3:
                    deletepassword(founduser);
                    break;
               case 4:
                    PasswordGroupSet(founduser);
                    break;
                case 5:
                    GeneratePassword(founduser);
                    break;

            }
        }


        //Passwörter ausgeben
        //-------------------------------------------------------------------
        static void ShowAllPasswords(User founduser)
        {
            Console.Clear();
            Console.WriteLine(titel);
            Console.WriteLine("Schreibe exit um zum menu zurück zu kommen");
            Console.WriteLine("\nPasswörter in Gruppen:\n");

            HashSet<string> displayedPasswordsTitles = new HashSet<string>();

            foreach (var group in founduser.MyGroups)
            {
                Console.WriteLine($"Gruppe: {group.GroupName}\n");

                foreach (var password in group.Passwords)
                {
                    DisplayPassword(password);
                    displayedPasswordsTitles.Add(password.Titel);
                }

                Console.WriteLine("-----------------------------");
            }

            Console.WriteLine("\nRestliche Passwörter:\n");

            foreach (var password in founduser.Mypasswords)
            {
                if (!displayedPasswordsTitles.Contains(password.Titel))
                {
                    DisplayPassword(password);
                }
            }

            string eingabe;
            do
            {
                Console.Write("Eingabe: ");
                eingabe = Console.ReadLine();
                if(eingabe.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }while (true);
            mainmenu();
        }
        static void DisplayPassword(Password password)
        {
            Console.WriteLine($"Titel: {password.Titel}");
            Console.WriteLine($"Passwort: {password.PasswordInput}");
            Console.WriteLine($"Ort: {password.Place}");
            Console.WriteLine($"Benutzername: {password.User_name}");
            Console.WriteLine("-----------------------------");
        }

        //Passwörter hinzufügen
        //-------------------------------------------------------------------
        static void addpassword(User founduser)
        {
            string password_titel = "";
            string password = "";
            string place = "";
            string username = "";
            string confirmPassword = "";

            Console.Clear();
            Console.WriteLine(titel);
            Console.WriteLine("Neues Passwort hinzufügen\n");

            do
            {
                password_titel = GetInput("Titel des Passworteintrags: ");

                if (founduser.Mypasswords.Any(p => p.Titel.Equals(password_titel, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Ein Passwort mit diesem Titel existiert bereits. Bitte geben Sie einen anderen Titel ein.");
                }

            } while (founduser.Mypasswords.Any(p => p.Titel.Equals(password_titel, StringComparison.OrdinalIgnoreCase)));

            place = GetInput("Namen oder Url der Webseite vom Passwort: ");
            username = GetInput("Username der mit dem Passwort benutzt wird: ");

            do
            {
                Console.Write("Gebe das passwort das sie speichern möchten ein: ");
                password = Console.ReadLine();

                Console.Write("Wiederhole es nochmals zur bestätigung: ");
                confirmPassword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password) || password != confirmPassword)
                {
                    Console.WriteLine("Passwörter stimmen nicht überein oder sind leer. Bitte versuchen Sie es erneut.\n");
                }
            } while (string.IsNullOrWhiteSpace(password) || password != confirmPassword);

            founduser.Mypasswords.Add(new Password(password_titel, password, place, username));
            PasswordManager.SaveUsers(PasswordManager.users);
            mainmenu();
        }

        static string GetInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Eingabe darf nicht leer sein. Bitte versuchen Sie es erneut.\n");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
        //Passwörter Löschen
        //-------------------------------------------------------------------
        static void deletepassword(User founduser)
        {
            Console.Clear();
            Console.WriteLine(titel);
            Console.WriteLine("Passwort löschen\n");


            do
            {
                Console.Write("Geben Sie den Titel des Passworts ein, das Sie löschen möchten: ");
                string passwordTitleToDelete = Console.ReadLine();



                Password passwordToDelete = founduser.Mypasswords.FirstOrDefault(p => p.Titel.Equals(passwordTitleToDelete, StringComparison.OrdinalIgnoreCase));
                if (passwordToDelete != null)
                {
                    Console.WriteLine("Sind Sie sicher, dass Sie das Passwort löschen möchten? (Ja/Nein): ");
                    string confirmation = Console.ReadLine();



                    if (confirmation.Equals("Ja", StringComparison.OrdinalIgnoreCase))
                    {
                        founduser.Mypasswords.Remove(passwordToDelete);
                        PasswordManager.SaveUsers(PasswordManager.users);
                        Console.WriteLine("Passwort wurde erfolgreich gelöscht.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Passwort wurde nicht gelöscht.");
                    }
                }
                else
                {
                    Console.WriteLine("Das angegebene Passwort wurde nicht gefunden.");
                }

            } while (true);

            Console.WriteLine("Drücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
            mainmenu();
        }

        //Password Generieren
        //-------------------------------------------------------------------------------------
        static void GeneratePassword(User user)
        {

        }

        //Password Gruppen
        //-------------------------------------------------------------------------------------
        static void PasswordGroupSet(User founduser)
        {
            int eingabe;
            Console.Clear();
            do
            {
                Console.WriteLine(titel);
                Console.WriteLine("Was möchtest du machen?");
                Console.WriteLine("1.Neue Gruppe erstellen");
                Console.WriteLine("2.Passwörter einer Gruppe hinzufügen");
                Console.WriteLine("3.Passwörter aus einer Gruppe Löschen");
                Console.WriteLine("4.Gruppe Löschen");
                Console.WriteLine("5.Back to Menu");
                Console.Write("\nEingabe:");

                if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 5)
                {
                    eingabe = input;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 1 und 7 ein.\n");
                }
            } while (true);

            switch (eingabe)
            {
                case 1:
                    addgroup(founduser);
                    break;
                case 2:
                    AddpasswordToGroup(founduser);
                    break;
                case 3:
                    deletpasswordfromGroup(founduser);
                    break;
                case 4:
                    deletgroup(founduser);
                    break;
                case 5:
                    PasswordManager.SaveUsers(PasswordManager.users);
                    mainmenu();
                    break;

            }
        }
    static void addgroup(User User)
        {
            string name = "";
            Console.Clear();
            Console.WriteLine(titel);

            do
            {
                Console.Write("\nName der Gruppe: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Der Gruppenname darf nicht leer sein. Bitte versuchen Sie es erneut.");
                    continue;
                }

                if (User.MyGroups.Any(g => g.GroupName.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Eine Gruppe mit diesem Namen existiert bereits. Bitte geben Sie einen anderen Namen ein.");
                    continue;
                }

                break;

            } while (true);

            User.MyGroups.Add(new PasswordGroup(name));
            PasswordManager.SaveUsers(PasswordManager.users);

            Console.WriteLine("\nGruppe {0} wurde erfolgreich hinzugefügt", name);
            Console.WriteLine("Drücke irgendeine Taste um zurück zu gehen.");
            Console.ReadKey();
            PasswordGroupSet(User);
        }
    static void deletgroup(User User)
        {
            string groupname;
            Console.Clear();
            Console.WriteLine(titel);
            do
            {
                Console.Write("\nName der Gruppe: ");
                groupname = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(groupname))
                {
                    Console.WriteLine("Der Gruppenname darf nicht leer sein. Bitte versuchen Sie es erneut.");
                    continue;
                }

                if (!User.MyGroups.Any(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Eine Gruppe mit diesem Namen existiert nicht. Bitte geben Sie einen anderen Namen ein.");
                    continue;
                }

                break;
            } while (true);
            var targetGroup = User.MyGroups.First(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase));
            User.MyGroups.Remove(targetGroup);
            PasswordManager.SaveUsers(PasswordManager.users);

            Console.WriteLine("\nGruppe wurde entfernt.");
            Console.WriteLine("Drücke irgend eine Taste um zum Menu zurück zu kommen");
            Console.ReadKey();
            PasswordGroupSet(User);
        }
        static void AddpasswordToGroup(User User)
        {
            string groupname = "";
            string passwordtitel = "";
            Console.Clear();
            Console.WriteLine(titel);

            do
            {
                Console.Write("Gib den Namen der Gruppe ein der du was Hinzufügen willst:");
                groupname = Console.ReadLine();

                if (!User.MyGroups.Any(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Es existiert keine Gruppe mit diesem Namen. Bitte versuchen Sie es erneut.");
                }

            } while (!User.MyGroups.Any(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase)));

            do
            {
                Console.Write("Gib den titel des Passwortes ein das zu Hinzufügen willst: ");
                passwordtitel = Console.ReadLine();

                if (!User.Mypasswords.Any(p => p.Titel.Equals(passwordtitel, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Es existiert kein Passwort mit diesem Titel. Bitte versuchen Sie es erneut.");
                }

            } while (!User.Mypasswords.Any(p => p.Titel.Equals(passwordtitel, StringComparison.OrdinalIgnoreCase)));

            var targetGroup = User.MyGroups.First(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase));

            var targetPassword = User.Mypasswords.First(p => p.Titel.Equals(passwordtitel, StringComparison.OrdinalIgnoreCase));

            targetGroup.AddPassword(targetPassword);
            PasswordManager.SaveUsers(PasswordManager.users);
            Console.WriteLine("Passwort wurde erfolgreich hinzugefügt");
            Console.WriteLine("Drücke irgendeine Taste um zurück zum Menu zu kommen.");
            Console.ReadKey();
            PasswordGroupSet(User);
        }

        static void deletpasswordfromGroup(User User)
        {
            {
                string groupname = "";
                string passwordtitel = "";
                Console.Clear();
                Console.WriteLine(titel);

                do
                {
                    Console.Write("Gib den Namen der Gruppe ein von der du ein Passwort Löschen willts: ");
                    groupname = Console.ReadLine();

                    if (!User.MyGroups.Any(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("Es existiert keine Gruppe mit diesem Namen. Bitte versuchen Sie es erneut.");
                    }

                } while (!User.MyGroups.Any(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase)));

                var targetGroup = User.MyGroups.First(g => g.GroupName.Equals(groupname, StringComparison.OrdinalIgnoreCase));
                do
                {
                    Console.Write("Gib den titel des Passwortes ein das du Löschen willst: ");
                    passwordtitel = Console.ReadLine();

                    if (!targetGroup.Passwords.Any(p => p.Titel.Equals(passwordtitel, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("Es existiert kein Passwort mit diesem Titel in diese Gruppe. Bitte versuchen Sie es erneut.");
                    }

                } while (!User.Mypasswords.Any(p => p.Titel.Equals(passwordtitel, StringComparison.OrdinalIgnoreCase)));


                var targetPassword = User.Mypasswords.First(p => p.Titel.Equals(passwordtitel, StringComparison.OrdinalIgnoreCase));
                targetGroup.RemovePassword(targetPassword);
                PasswordManager.SaveUsers(PasswordManager.users);

                Console.WriteLine("\nPasswort wurde entfernt von der Gruppe.");
                Console.WriteLine("Drücke irgend eine Taste um zurück zu gehen.");
                Console.ReadKey();

                PasswordGroupSet(User);
            }
        }
    }
}
