//using UnityEngine;
//using System.Data;
//using System.Data.;
//public class Database : MonoBehaviour
//{
//    void Start()
//    {
//        // Create a connection string
//        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//        builder.DataSource = "localhost";
//        builder.UserID = "username";
//        builder.Password = "password";
//        builder.InitialCatalog = "databaseName";
//
//        // Open a connection to the database
//        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//        {
//            connection.Open();
//
//            // Create a SQL command to select some data
//            SqlCommand command = new SqlCommand("SELECT * FROM tableName", connection);
//
//            // Execute the SQL command and get a data reader
//            SqlDataReader reader = command.ExecuteReader();
//
//            // Loop through the rows in the data reader and extract the data
//            while (reader.Read())
//            {
//                int id = reader.GetInt32(0);
//                string name = reader.GetString(1);
//                float value = reader.GetFloat(2);
//
//                // Do something with the data, such as adding it to an array or a List
//            }
//
//            // Close the data reader and the connection
//            reader.Close();
//            connection.Close();
//        }
//    }
//}
