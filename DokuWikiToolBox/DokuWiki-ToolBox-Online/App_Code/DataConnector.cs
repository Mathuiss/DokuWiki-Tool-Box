using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// This class connects to the database and can preform certain actions with it.
/// </summary>
public class DataConnector
{
    SqlConnection connection;

    public DataConnector(string conString)
    {
        connection = new SqlConnection(conString);
        connection.Open();
    }
    
    public void Register(string userName, string email, string password)
    {
        string query = "insert into Users (id, name, email, password) values (@id, @name, @email, @password)";

        var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", GetNewId());
        command.Parameters.AddWithValue("@name", userName);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();
        connection.Close();
    }

    public int GetNewId()
    {
        string query = "select count(id) from users";

        var command = new SqlCommand(query, connection);
        return (int)command.ExecuteScalar() + 1;
    }

    public void Login(string email, string password, ref bool canLogIn)
    {
        string query = "select password from Users where email = \'@email\'";
        query = query.Replace("@email", email);

        var command = new SqlCommand(query, connection);
        string passwordToCompare = (string)command.ExecuteScalar();
        connection.Close();

        if (password.Equals(passwordToCompare))
        {
            canLogIn = true;
        }
        else
        {
            canLogIn = false;
        }
    }
}