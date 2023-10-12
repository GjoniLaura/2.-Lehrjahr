using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class User
    {
        public string username {  get; set; }
        public string masterpassword { get; set; }
        public List<password>mypasswords { get; set; }

        public User(string username, string masterpassword)
        {
            this.username = username;
            this.masterpassword = masterpassword;
        }
        public User()
        {
            mypasswords = new List<password>();
        }
    }
}
