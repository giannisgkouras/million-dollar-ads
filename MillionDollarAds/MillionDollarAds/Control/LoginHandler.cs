using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MillionDollarAds.Control
{
    public class LoginHandler
    {
        public String username { set; get; }
        public String password { set; get; }
        public LoginHandler(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool checkAccount()
        {
            return Database.checkIfUserExists(username, password);
        }
    }
}
