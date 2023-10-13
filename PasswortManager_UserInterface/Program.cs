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
            PasswordManager.users = PasswordManager.ReadUsers();

            //Login or create new account method
            PasswordManager.LoOrRe();
        }
    }   
}
        
   

