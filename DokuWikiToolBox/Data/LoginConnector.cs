using System.Data.SqlClient;

namespace Data
{
    public class LoginConnector
    {
        public void Register(string userName, string email, string password)
        {
            SqlConnection connection = DataUtils.GetConnection();
            connection.Open();

            string query = "insert into Users (id, name, email, password) values (@id, @name, @email, @password)";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", GetNewId(ref connection));
            command.Parameters.AddWithValue("@name", userName);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int GetNewId(ref SqlConnection connection)
        {


            string query = "select max(id) from users";

            var command = new SqlCommand(query, connection);
            return (int)command.ExecuteScalar() + 1;
        }

        public void Login(string email, string password, ref bool canLogIn)
        {
            SqlConnection connection = DataUtils.GetConnection();
            connection.Open();

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
}
