﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionDollarAds
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string email, string password, string cpassword, int lastId)
        {
            Username = username;
            Email = email;
            Password = password;
            CPassword = cpassword;
            LastId = lastId;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public int LastId { get; set; }

        private static string error = "Κάτι πήγε στραβά.";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static string getUsername(string username)
        {
            return username;
        }

        public static bool IsEqual( User user1, User user2)
        {
            if (user2 == null) 
            {
                error = "whattt";
                return false;
            }
            if ( user1 == null)
            {
                error = "second wrong";
                return false;
            }
            if(user1.Username != user2.Username)
            {
                error = "Ο χρήστης "+ user1.Username + " δεν υπάρχει!";
                return false;
            }
            else if (user1.Password != user2.Password)
            {
                error = "Το όνομα χρήστη δεν ταιριάζει με τον κωδικό!";
                return false;
            }
            return true;
        }
    }
}
