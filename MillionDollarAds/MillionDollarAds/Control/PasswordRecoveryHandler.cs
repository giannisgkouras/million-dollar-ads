using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds.Control
{

    public class PasswordRecoveryHandler
    {
        public String username { set; get; }
        public String email { set; get; }
        public PasswordRecoveryHandler(string username, string email)
        {
            this.username = username;
            this.email = email;
        }

        public bool checkAccount()
        {
            return Database.checkIfUserExistsByEmail(username, email);
        }

    }   
}
