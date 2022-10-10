using Microsoft.Data.SqlClient;

namespace MyLogin.Data
{
    public class LoginClass
    {
        private string username;
        private string password;
        public LoginClass(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=192.168.2.2;Initial Catalog=MyLoginSql;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

            SqlCommand command = new SqlCommand(
                "Select UserName, [Password] from MyLogin WHERE UserName = @userlogin", conn);
            //    "Select LoginUser from [Table] where LoginUser=@userlogin", conn);
            command.Parameters.AddWithValue("@userlogin", username);
            command.Parameters.AddWithValue("@passwordlogin", password);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (username == reader.GetString(0) && password == reader.GetString(1))
                    {
                        Console.WriteLine("Username & Password is Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Username & Password is Incorrect!");
                    }

                    Console.WriteLine(String.Format("{0}", reader["UserName"]));
                }
            }

            conn.Close();
        }

    }
}
