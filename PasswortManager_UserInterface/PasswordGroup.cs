using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswortManager_UserInterface
{
    internal class PasswordGroup
    {
        public string GroupName { get; set; }
        public List<Password> Passwords { get; set; }

        public PasswordGroup(string groupName)
        {
            this.GroupName = groupName;
            this.Passwords = new List<Password>();
        }

        public void AddPassword(Password password)
        {
            this.Passwords.Add(password);
        }

    }
}
