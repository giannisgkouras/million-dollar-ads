using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;


namespace MillionDollarAds.Control
{
    class Database
    {
        public static MySqlConnection connection;
        public static string server;
        public static string database;
        public static string uid;
        public static string password;


        public static void Initialize()
        {
            server = "127.0.0.1";
            database = "addatabase";
            uid = "aris";
            password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            OpenConnection();
        }

        //open connection to database
        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("All good");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact Admin");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public static bool checkIfUserExists(string username, string password)
        {
            Initialize();
            string query = "SELECT idUser,username,password,contactNumber,email FROM User WHERE username = '" + username +
                "' AND password = '" + password + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEE   " + dataReader.GetString(0));
                    Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEE   " + dataReader.GetString(1));
                    Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEE   " + dataReader.GetString(2));
                    Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEE   " + dataReader.GetString(3));
                    Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEE   " + dataReader.GetString(4));
                    Arxikh.user = new User()
                    {
                        Id = dataReader.GetInt32(0),
                        Username = dataReader.GetString(1),
                        Password = dataReader.GetString(2),
                        Phone = dataReader.GetInt32(3),
                        Email = dataReader.GetString(4)
                    };
                }
            }
            else
            {
                dataReader.Close();
                CloseConnection();
                return false;
            }

            dataReader.Close();
            CloseConnection();
            return true;
        }

        //During SignUp checks if the given username already exists
        public static bool checkIfUsernameIsDuplicate(string username)
        {
            Initialize();
            string query = "select username from user where username = '" + username + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Close();
                CloseConnection();
                return true;
            }
            else
            {
                dataReader.Close();
                CloseConnection();
                return false;
            }
        }

        //This method is called from the SignUpPage when an user is registered
        public static void createNewUser(User newUser)
        {
            Initialize();
            string query = "insert into user(username,password,contactNumber,email) values (@username,@password,@contactNumber,@email)";
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Parameters.AddWithValue("@username",newUser.Username);
            msc.Parameters.AddWithValue("@password", newUser.Password);
            msc.Parameters.AddWithValue("@contactNumber", newUser.Phone);
            msc.Parameters.AddWithValue("@email", newUser.Email);
            msc.Prepare();

            msc.ExecuteNonQuery();
        }

        public static List<Category> getAllCategories()
        {
            Initialize();
            string query = "select * from category";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Category> categories = new List<Category>();
            Category category = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    category = new Category(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                    Console.WriteLine(dataReader.GetInt32(0) + "  "+dataReader.GetString(1) + "  " + dataReader.GetInt32(2));
                    categories.Add(category);
                }
                dataReader.NextResult();
            }

            dataReader.Close();
            CloseConnection();
            
            return categories;
        }
    }
}
