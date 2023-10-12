using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class User
    {
        public string Username {  get; set; }
        public string Masterpassword { get; set; }
        public List<password>Mypasswords { get; set; }

        public User(string username, string masterpassword)
        {
            Username = username;
            Masterpassword = masterpassword;
        }
        public User()
        {
            Mypasswords = new List<password>();
        }
    }
}
