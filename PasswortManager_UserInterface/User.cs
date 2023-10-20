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
        public List<Password> Mypasswords { get; set; }
        public List<PasswordGroup> MyGroups { get; set; }

        public User(string username, string masterpassword)
        {
            this.Username = username;
            this.Masterpassword = masterpassword;
        }
        public User()
        {
            Mypasswords = new List<Password>();
            MyGroups = new List<PasswordGroup>();
        }
    }
}
