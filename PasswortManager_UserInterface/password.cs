using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class password
    {
        public string _titel { get; set; }
        public string _password { get; set; }
        public string _place { get; set; }
        public string _user_name { get; set; }

        public password(string _titel, string _password, string _place, string _User_Name)
        {
            this._titel = _titel;
            this._password = _password;
            this._place = _place;
            this._user_name = _User_Name;
        }

        public static string Passwordgenerator(int len)
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
