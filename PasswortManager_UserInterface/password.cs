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
    }
}
