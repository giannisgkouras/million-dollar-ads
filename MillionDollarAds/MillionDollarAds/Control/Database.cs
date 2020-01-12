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

        // About User
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

        public static bool checkIfUserExistsByEmail(string username, string email)
        {
            Initialize();
            string query = "SELECT * FROM User WHERE username = '" + username +
                "' AND email = '" + email + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {                   
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

       /* public ListView getListViewOfLoggedUser()
        {
            Initialize();
            string query = "select idUser,idAd from viewhistory where idUser = " + Arxikh.user.Id;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();
            Product product = null;
            List<Category> categories = new List<Category>();
            Category category = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    category = new Category(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                    categories.Add(category);
                }
                dataReader.NextResult();
            }

            dataReader.Close();
            CloseConnection();

            return categories;
        }*/



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

        MySqlCommand cmd = null;
        public static bool checkIfOldPasswordIsCorrect(string username, string email, string oldPassword)
        {
            Initialize();
            string query = "SELECT * FROM User WHERE username = '" + username +
                "' AND email = '" + email + "' AND password ='"+ oldPassword+"'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
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
        public static void changeUserPassoword(string username, string email,string oldPassword, string newPassword)
        {
            Initialize();
            //if(checkIfOldPasswordIsCorrect(username, email, oldPassword))
          //  {
                string query = "update user set password = '" +newPassword + "' where username = @username";

                MySqlCommand msc = new MySqlCommand(query, connection);
                msc.Parameters.AddWithValue("@username", username);

                msc.Prepare();

                msc.ExecuteNonQuery();
                
          //  }
           
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
                    categories.Add(category);
                }
                dataReader.NextResult();
            }

            dataReader.Close();
            CloseConnection();
            
            return categories;
        }

        public static List<Category> getSubCategoriesByFather(int fathersId)
        {
            Initialize();
            string query = "select * from category where hasFather="+fathersId;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Category> subCategories = new List<Category>();
            Category subCategory = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    subCategory = new Category(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                    subCategories.Add(subCategory);
                }
                dataReader.NextResult();
            }

            dataReader.Close();
            CloseConnection();

            return subCategories;
        }

        public static List<Product> getAllProducts()
        {
            Initialize();
            string query = "select * from ad inner join user on user.idUser = ad.idUser";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Product> allProducts = new List<Product>();
            Product product = null;
            User cuser = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cuser = new User()  
                    {
                        Id = dataReader.GetInt32(8),
                        Username = dataReader.GetString(9),
                        Password = dataReader.GetString(10),
                        Phone = dataReader.GetInt32(11),
                        Email = dataReader.GetString(12)
                    };
                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        Title = dataReader.GetString(1),
                        Desc = dataReader.GetString(2),
                        Price = dataReader.GetString(3),
                        Type = dataReader.GetString(4),
                        Date = dataReader.GetString(5),
                        CategoryId = dataReader.GetInt32(7),
                        Owner = cuser
                
                
                    /*Owner = new User()
                    {
                        Id = dataReader.GetInt32(8),
                        Username = dataReader.GetString(9),
                        Phone = dataReader.GetInt32(11),
                        Email = dataReader.GetString(12)
                    }*/
                    };

                    allProducts.Add(product);
                }
                    dataReader.NextResult();
            }
            

            dataReader.Close();
            CloseConnection();

            return allProducts;
        }

        public static void clearViewHistory()
        {
            Initialize();
            string query = "delete from viewhistory where idUser = @idUser";
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Parameters.AddWithValue("@idUser", Arxikh.user.Id);

            msc.Prepare();

            msc.ExecuteNonQuery();
        }
        public static List<Product> getProductsInViewHistoryOfLoggedUser()
        {
            Initialize();
            string query = "select * from viewhistory inner join ad on ad.idAd = viewhistory.idAd  " +
                "inner join user on viewhistory.idUser = user.idUser " +
                "where viewhistory.idUser = " + Arxikh.user.Id + " order by viewhistory.dateSeen DESC";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Product> productsinViewHistory = new List<Product>();
            Product product = null;
            User cuser = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cuser = new User()
                    {
                        Id = dataReader.GetInt32(11),
                        Username = dataReader.GetString(12),
                        Password = dataReader.GetString(13),
                        Phone = dataReader.GetInt32(14),
                        Email = dataReader.GetString(15)
                    };
                    product = new Product()
                    {
                        Id = dataReader.GetInt32(3),
                        Title = dataReader.GetString(4),
                        Desc = dataReader.GetString(5),
                        Price = dataReader.GetString(6),
                        Type = dataReader.GetString(7),
                        Date = dataReader.GetString(8),
                        CategoryId = dataReader.GetInt32(10),
                        Owner = cuser


                        /*Owner = new User()
                        {
                            Id = dataReader.GetInt32(8),
                            Username = dataReader.GetString(9),
                            Phone = dataReader.GetInt32(11),
                            Email = dataReader.GetString(12)
                        }*/
                    };

                    productsinViewHistory.Add(product);
                }
                dataReader.NextResult();
            }


            dataReader.Close();
            CloseConnection();

            return productsinViewHistory;
        }

        public static bool checkIfEntryInViewHistoryExists(Product product)
        {
            Initialize();
            string query = "select * from viewhistory where idUser =" + Arxikh.user.Id + " AND idAd= " + product.Id;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                
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

        public static void updateEntryInViewHistory(Product product)
        {
            Initialize();
            string query = "UPDATE viewhistory SET dateSeen = @dateSeen where viewhistory.idUser = " + Arxikh.user.Id + " and viewhistory.idAd = " + product.Id;
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Parameters.AddWithValue("@dateSeen", DateTime.Now);
            msc.Prepare();

            msc.ExecuteNonQuery();
        }

        public static List<Product> getAllProductsByCategory(int fathersId)
        {
            Initialize();
            string query = "select * from ad inner join user on user.idUser = ad.idUser inner join category on category.idCategory = ad.idCategory and category.hasFather =" + fathersId;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Product> allProducts = new List<Product>();
            Product product = null;
            User cuser = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cuser = new User()
                    {
                        Id = dataReader.GetInt32(8),
                        Username = dataReader.GetString(9),
                        Password = dataReader.GetString(10),
                        Phone = dataReader.GetInt32(11),
                        Email = dataReader.GetString(12)
                    };

                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        Title = dataReader.GetString(1),
                        Desc = dataReader.GetString(2),
                        Price = dataReader.GetString(3),
                        Type = dataReader.GetString(4),
                        Date = dataReader.GetString(5),
                        CategoryId = dataReader.GetInt32(7),
                        Owner = cuser,

                        /*Owner = new User()
                        {
                            Id = dataReader.GetInt32(8),
                            Username = dataReader.GetString(9),
                            Phone = dataReader.GetInt32(11),
                            Email = dataReader.GetString(12)
                        }*/
                    };

                    allProducts.Add(product);
                }
                dataReader.NextResult();
            }


            dataReader.Close();
            CloseConnection();

            return allProducts;
        }

        public static List<Product> getAllProductsBySubCategory(int categoryId)
        {
            Initialize();
            string query = "select * from ad inner join user on user.idUser = ad.idUser and ad.idCategory=" + categoryId;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Product> allProducts = new List<Product>();
            Product product = null;
            User cuser = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cuser = new User()
                    {
                        Id = dataReader.GetInt32(8),
                        Username = dataReader.GetString(9),
                        Password = dataReader.GetString(10),
                        Phone = dataReader.GetInt32(11),
                        Email = dataReader.GetString(12)
                    };

                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        Title = dataReader.GetString(1),
                        Desc = dataReader.GetString(2),
                        Price = dataReader.GetString(3),
                        Type = dataReader.GetString(4),
                        Date = dataReader.GetString(5),
                        CategoryId = dataReader.GetInt32(7),
                        Owner = cuser,

                        /*Owner = new User()
                        {
                            Id = dataReader.GetInt32(8),
                            Username = dataReader.GetString(9),
                            Phone = dataReader.GetInt32(11),
                            Email = dataReader.GetString(12)
                        }*/
                    };

                    allProducts.Add(product);
                }
                dataReader.NextResult();
            }


            dataReader.Close();
            CloseConnection();

            return allProducts;
        }

        public static List<Product> getAllProductsByUser(int userId)
        {
            Initialize();
            string query = "select * from ad inner join user on user.idUser = ad.idUser and ad.idUser="+userId;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Product> allProducts = new List<Product>();
            Product product = null;
            User cuser = null;

            while (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    cuser = new User()
                    {
                        Id = dataReader.GetInt32(8),
                        Username = dataReader.GetString(9),
                        Password = dataReader.GetString(10),
                        Phone = dataReader.GetInt32(11),
                        Email = dataReader.GetString(12)
                    };

                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        Title = dataReader.GetString(1),
                        Desc = dataReader.GetString(2),
                        Price = dataReader.GetString(3),
                        Type = dataReader.GetString(4),
                        Date = dataReader.GetString(5),
                        CategoryId = dataReader.GetInt32(7),
                        Owner = cuser,

                        /*Owner = new User()
                        {
                            Id = dataReader.GetInt32(8),
                            Username = dataReader.GetString(9),
                            Phone = dataReader.GetInt32(11),
                            Email = dataReader.GetString(12)
                        }*/
                    };

                    allProducts.Add(product);
                }
                dataReader.NextResult();
            }


            dataReader.Close();
            CloseConnection();

            return allProducts;
        }

        public static int getCategoryIdByName(string title)
        {
            Initialize();
            string query = "select idCategory from category where title = '" + title + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                CloseConnection();
                return id;
            }
            else
            {
                dataReader.Close();
                CloseConnection();
                return 0;
            }

        }

        public static string getCategoryNameById(int id)
        {
            Initialize();
            string query = "select title from category where idCategory = " + id;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                string title = dataReader.GetString(0);
                dataReader.Close();
                CloseConnection();
                return title;
            }
            else
            {
                dataReader.Close();
                CloseConnection();
                return "N/A";
            }

        }

        public static Product getAdbyId(string id)
        {
            Initialize();
            string query = "select * from ad inner join user on user.idUser = ad.idUser where ad.idAd = " + id;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            Product product = null;
            User cuser = null;

            if  (dataReader.HasRows)
            {
                dataReader.Read();
                cuser = new User()
                    {
                        Id = dataReader.GetInt32(8),
                        Username = dataReader.GetString(9),
                        Password = dataReader.GetString(10),
                        Phone = dataReader.GetInt32(11),
                        Email = dataReader.GetString(12)
                    };
                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        Title = dataReader.GetString(1),
                        Desc = dataReader.GetString(2),
                        Price = dataReader.GetString(3),
                        Type = dataReader.GetString(4),
                        Date = dataReader.GetString(5),
                        CategoryId = dataReader.GetInt32(7),
                        Owner = cuser

                        /*Owner = new User()
                        {
                            Id = dataReader.GetInt32(8),
                            Username = dataReader.GetString(9),
                            Phone = dataReader.GetInt32(11),
                            Email = dataReader.GetString(12)
                        }*/
                    };
                    
            }


            dataReader.Close();
            CloseConnection();

            return product;
        }
        public static void insertAd(Product product)
        {
            Initialize();
            string query = "insert into ad(title,description,price,property,creationDate,idUser,idCategory) values (@title,@description, @price,@property,@creationDate ,@idUser,@idCategory)";
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Parameters.AddWithValue("@title", product.Title);
            msc.Parameters.AddWithValue("@description", product.Desc);
            msc.Parameters.AddWithValue("@price", product.Price);
            msc.Parameters.AddWithValue("@property", product.Type);
            msc.Parameters.AddWithValue("@creationDate", product.Date);
            msc.Parameters.AddWithValue("@idUser", product.Owner.Id);
            msc.Parameters.AddWithValue("@idCategory", product.CategoryId);
            
            msc.Prepare();

            msc.ExecuteNonQuery();
        }

        public static void updateAd(Product product, int productId)
        {
            Initialize();
            string query = "update ad set title = '"+ product.Title+ "', " +
                "description ='" + product.Desc + "', " +
                "price = '" + product.Price + "', " +
                "property = '" + product.Type + "' " +
                "where idAd =" + productId;


            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Prepare();

            msc.ExecuteNonQuery();
        }

        public static void deleteteAd(int productId)
        {
            Initialize();
            string query = "delete from ad where idAd =" + productId;
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Prepare();

            msc.ExecuteNonQuery();
        }

        public static void deleteteAdInViewHistory(int productId)
        {
            Initialize();
            string query = "delete from viewhistory where idAd =" + productId;
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Prepare();

            msc.ExecuteNonQuery();
        }
        public static void createNewEntryInViewHistory(Product product)
        {
            Initialize();
            string query = "insert into viewhistory(idUser,idAD,dateSeen) values (@idUser,@idAd,@dateSeen);";
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Parameters.AddWithValue("@idUser", Arxikh.user.Id);
            msc.Parameters.AddWithValue("@idAd", product.Id);
            msc.Parameters.AddWithValue("dateSeen", DateTime.Now);

            msc.Prepare();

            msc.ExecuteNonQuery();
        }

        public static void removeEntryFromViewHistroy(Product product)
        {
            Initialize();
            string query = "delete from viewhistory where idUser = @idUser and idAd = @idAd";
            MySqlCommand msc = new MySqlCommand(query, connection);

            msc.Parameters.AddWithValue("@idUser", Arxikh.user.Id);
            msc.Parameters.AddWithValue("@idAd", product.Id);

            msc.Prepare();

            msc.ExecuteNonQuery();
        }
    }
}
