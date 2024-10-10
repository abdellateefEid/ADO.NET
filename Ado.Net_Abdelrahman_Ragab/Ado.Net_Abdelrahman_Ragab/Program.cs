using Microsoft.Data.SqlClient;

namespace Ado.Net_Abdelrahman_Ragab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new SqlConnection object to connect to the SQL Server database
            SqlConnection sqlConnection = new SqlConnection();

            // Set the connection string for the SqlConnection object
            // Data Source specifies the server, 
            // Initial Catalog specifies the database,
            // and Integrated Security uses Windows authentication to connect.
            sqlConnection.ConnectionString = "Data Source = .;" +
                                             "Initial Catalog = ITI;" +
                                             "Integrated Security = true; " +
                                             "Encrypt=true;" +
                                             "TrustServerCertificate=true;";

            // Open the SQL connection to the database
            sqlConnection.Open();

            // display the connection state in the console (if needed)
            Console.WriteLine(sqlConnection.State);

            // Close the SQL connection after the operation is done
            sqlConnection.Close();

        }
    }
}
