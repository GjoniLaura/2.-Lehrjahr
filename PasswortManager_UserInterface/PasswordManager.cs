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
using System.Security.Cryptography;

namespace PasswortManager_UserInterface
{
    internal class PasswordManager
    {
         static readonly string path = "C:\\Users\\xbloc\\OneDrive\\Bilder\\UbisoftConnect\\values.json";
        // static string passwordforkey = Environment.GetEnvironmentVariable("secretPass");
        static string passwordforkey = "qyTY3wE2ureUy4cCb6r3ymL2F2R3bWqrnhEykwrU2YraQKR80X6UEoJ8LdAraCVZmutgXnW3Pg7VetEN0ryCMWGPeTsYF4XP9sRd"; //Ist so nicht sicher und wird nur wegen test zwecken gebraucht.

        public static List<User> users = new List<User>(); 
        static public string angemeldet = "";

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
                Console.Write("\nEingabe:");

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

                if (users.Any(u => u.Username == username))
                {
                    Console.Clear();
                    Console.WriteLine(titel);
                    Console.WriteLine("Dieser Benutzername ist bereits vergeben. Bitte wählen Sie einen anderen.\n");
                }
            } while (users.Any(u => u.Username == username));

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

            users.Add(new User{ Username = username, Masterpassword = masterpassword });
            SaveUsers(users);
            Console.WriteLine("--------------------------------------------------------------------------------" +
                             "\nAccount wurde erfolgreich erstellt.Drücke eine Taste um zum Login zu gelangen.");
            Console.ReadKey();
            Login();
        }
        public static void Login()
        {
            angemeldet = "";
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

                if (!users.Any(u => u.Username == username))
                {
                    Console.Clear();
                    Console.WriteLine(titel);
                    Console.WriteLine("Dieser Benutzer Existiert nicht.\n");
                }
            } while (!users.Any(u => u.Username == username));
            User founduser = users.FirstOrDefault(u => u.Username == username);
            angemeldet = founduser.Username;
            do
            {
                Console.Write("Passwort: ");
                masterpassword = Console.ReadLine();
                if (ValidatePassword(masterpassword, founduser.Masterpassword))
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
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(obj, options);
            byte[] encryptedData = EncryptStringToBytes_Aes(json, passwordforkey);
            File.WriteAllBytes(path, encryptedData);
        }



        public static List<User> ReadUsers()
        {
            if (File.Exists(path))
            {
                byte[] encryptedData = File.ReadAllBytes(path);
                string decryptedData = DecryptStringFromBytes_Aes(encryptedData, passwordforkey);
                return JsonSerializer.Deserialize<List<User>>(decryptedData);
            }
            else
            {
                return new List<User>();
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, string password)
        {
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                byte[] salt = new byte[16]; 
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                aesAlg.Key = DeriveKeyFromPassword(password, salt);
                aesAlg.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(salt, 0, salt.Length); 
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length); 

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }

            return encrypted;
        }

        public static byte[] DeriveKeyFromPassword(string password, byte[] salt, int iterations = 10000, int keyLength = 32) 
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return rfc2898.GetBytes(keyLength);
            }
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, string password)
        {
            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                byte[] salt = cipherText.Take(16).ToArray(); 
                aesAlg.Key = DeriveKeyFromPassword(password, salt);
                aesAlg.IV = cipherText.Skip(16).Take(16).ToArray(); 

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText.Skip(32).ToArray())) 
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    plaintext = srDecrypt.ReadToEnd();
                }
            }

            return plaintext;
        }

    }
}