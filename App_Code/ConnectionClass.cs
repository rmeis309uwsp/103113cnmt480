using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;

    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }

    public static ArrayList GetInventoryByType(string inventoryType)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM items WHERE type LIKE '{0}'", inventoryType);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string category = reader.GetString(2);
                string description = reader.GetString(3);
                string image = reader.GetString(4);
                bool avalaible = reader.GetBoolean(5);
                bool staff = reader.GetBoolean(6);


                Items items = new Items(id, name, category, description, image, avalaible, staff);
                list.Add(items);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

 /*   public static void AddInventory(Items items)
    {
        string query = string.Format(
            @"INSERT INTO items VALUES ('{0}', '{1}', '{2}', '{3}')",
            items.name, items.categoryname, items.description, items.imagepath, items.available, item.staffonly);
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@prices", items.description));
        try
        {
            conn.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }*/

  /*  public static User LoginUser(string login, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM CNMTInventory.dbo.users2 WHERE name = '{0}'", login);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers2 = (int)command.ExecuteScalar();

            if (amountOfUsers2 == 1)
            {
                //User exists, check if the passwords match
                query = string.Format("SELECT password FROM users2 WHERE name = '{0}'", login);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    query = string.Format("SELECT email, user_type FROM users2 WHERE name = '{0}'", login);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string type = reader.GetString(1);

                        user = new User(login, password, email, type);
                    }
                    return user;
                }
                else
                {
                    //Passwords do not match
                    return null;
                }
            }
            else
            {
                //User does not exist
                return null;
            }
        }
        finally
        {

            conn.Close();
        }
    }*/

    /*public static string RegisterUser(User user)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users2 WHERE name = '{0}'", user.Login);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                //User does not exist, create a new user
                query = string.Format("INSERT INTO users2 VALUES ('{0}', '{1}', '{2}', '{3}')", user.Login, user.Password,
                                      user.Email, user.Type);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "User registered!";
            }
            else
            {
                //User exists
                return "A user with this name already exists";
            }
        }
        finally
        {
            conn.Close();
        }
    }*/
}