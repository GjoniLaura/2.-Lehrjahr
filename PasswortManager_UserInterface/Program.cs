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
        }

        static string Passwordgenerator(int len)
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
    }
}
