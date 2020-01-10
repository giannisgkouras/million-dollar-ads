using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds.Control
{
    public class SignUpHandler
    {

        public int completeRegistration(string username, string password, string confirmPass, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(username)
                || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(confirmPass)
                || string.IsNullOrWhiteSpace(phone)
                || string.IsNullOrWhiteSpace(email) )
            {
                return 0;
            }

            int phoneNumber = Convert.ToInt32(phone);

            if ( !password.Equals(confirmPass))
            {
                return 1;
            }

            bool duplicateUser = Database.checkIfUsernameIsDuplicate(username);

            if (duplicateUser)
            {
                return 2;
            }

            User newUser = new User()
            {
                Username = username,
                Password = password,
                Phone = phoneNumber,
                Email = email
            };

            Database.createNewUser(newUser);
            Arxikh.user = newUser;
            
            

            return 5;
        }
    }
}
