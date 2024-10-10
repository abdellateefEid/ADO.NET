﻿using Microsoft.Data.SqlClient;
using System.Data;

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
                                             "Encrypt = true;" +
                                             "TrustServerCertificate = true;";

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

            #region retrieve the data using SqlDataReader
            /*
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
            */
            #endregion

            #region retrieve the data using SqlDataAdaptor

            // Create a SqlDataAdapter object to act as a bridge between the SQL command and the DataTable.
            // The SqlDataAdapter will execute the SQL command and populate the DataTable with the results.
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            // Create a new DataTable object to store the results of the SQL query in-memory.
            DataTable dataTable = new DataTable();

            // Fill the DataTable with the data retrieved by the SqlDataAdapter from the database.
            // The Fill method executes the SQL query and loads the result into the DataTable.
            adapter.Fill(dataTable);

            // Iterate over each row in the DataTable.
            // The Rows collection contains all rows retrieved from the SQL query.
            foreach (DataRow row in dataTable.Rows)
            {
                // Access and print the values of the "Top_Id" and "Top_Name" columns for each row.
                // The row["ColumnName"] syntax retrieves the value from the specified column in the current row.
                Console.WriteLine($"Top_Id: {row["Top_Id"]}\t Top_Name: {row["Top_Name"]}");
            }

            #endregion

        }
    }
}
