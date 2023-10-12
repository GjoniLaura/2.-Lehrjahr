﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PasswortManager_UserInterface
{
    internal class PasswordManager
    {
         string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\Textdokument.jason";

        public static void LoOrRe()
        {
            int dec = 0;

            while (dec != 1 && dec != 2)
            {
                Console.WriteLine("Möchtest du dich anmelden oder Registrieren?");
                Console.WriteLine("1. Für anmelden drücke 1");
                Console.WriteLine("2. Für Registrieren drücke 2");

                // Verwende TryParse, um die Eingabe zu überprüfen
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
          
        }
        public static void Login() { }


        public string Passwordgenerator(int len)
        {
            int lenthOfPassword = len;
            string password = "";
            int count = 0;
            int currand = 0;

            string letters_Lowercase = "abcdefghijklmnopqrstuvwxyz";
            string letters_Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string symbols = @"!#$?*@\";

            Random ran = new Random();

            while (count < lenthOfPassword)
            {
                currand = ran.Next(0, 4);
                switch (currand)
                {
                    case 0:
                        password += letters_Lowercase[ran.Next(letters_Lowercase.Length)];
                        break;
                    case 1:
                        password += letters_Uppercase[ran.Next(letters_Uppercase.Length)];
                        break;
                    case 2:
                        password += symbols[ran.Next(symbols.Length)];
                        break;
                    case 3:
                        password += Convert.ToString(ran.Next(0, 9));
                        break;
                }
                count++;
            }
            return password;
        }

        //Json save and read
        public static void Savepasswords(object obj)
        {
            string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\Textdokument.json";
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(path, json);
        }

        public static List<password> ReadPasswords()
        {
            string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\Textdokument.json";
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<password>>(json);
        }
    }
}