using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;


namespace MillionDollarAds.Control
{
    public class DbHandler
    {
        private static IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "tLGlHxPJ5x9JSZSPoNKLnSCgmNake8kEP3KYZzta",
            BasePath = "https://ads1-d054d.firebaseio.com/"
        };

        static IFirebaseClient client;

        private static void openConnection()
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                
            }
        }
        public static bool validateLogIn(string username, string password)
        {
            openConnection();
            FirebaseResponse res = client.Get(@"Users/" + username);

            // database result
            User resUser = new User();
            resUser = res.ResultAs<User>();

            User currentUser = new User()
            {
                Username = username,
                Password = password
            };

            if (User.IsEqual(resUser, currentUser))
            {
                Arxikh.user = resUser;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
