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


            #region retrieve the data using SqlDataReader

            // Create a new SqlCommand object to execute SQL queries
            SqlCommand sqlCommand = new SqlCommand();

            // Open the SQL connection to the database
            sqlConnection.Open();

            // display the connection state in the console (if needed)
            // Console.WriteLine(sqlConnection.State);

            // Set the SQL command text to select Top_Id and Top_Name columns from the Topic table
            sqlCommand.CommandText = "SELECT Top_Id, Top_Name FROM Topic;";

            // Assign the open SqlConnection to the SqlCommand
            sqlCommand.Connection = sqlConnection;

            // Execute the SQL query and retrieve the data using SqlDataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Iterate through the retrieved rows
            while (sqlDataReader.Read())
            {
                // Output the Top_Id and Top_Name columns of each row to the console
                Console.WriteLine($"Top_Id: {sqlDataReader["Top_Id"]}\t Top_Name: {sqlDataReader["Top_Name"]}");
            }

            // Close the SQL connection after the operation is done
            sqlConnection.Close();

            #endregion

        }
    }
}
