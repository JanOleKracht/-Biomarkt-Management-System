using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public class DatabaseHelper
    {
        private static SqlConnection databaseConnection;

        // Method to get the database connection
        public static SqlConnection GetDatabaseConnection()
        {
            // Check if the connection is already open and return it if true
            if (databaseConnection != null && databaseConnection.State == ConnectionState.Open)
            {
                return databaseConnection;
            }

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProNatur-BiomarktTable.mdf");

            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found: " + dbPath);
                return null;
            }

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";

            try
            {
                // Create a new SqlConnection object using the connection string
                databaseConnection = new SqlConnection(connectionString);
                databaseConnection.Open();
                return databaseConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
                return null;
            }
        }

        public static void EnsureDatabaseConnection()
        {
            if (databaseConnection == null || databaseConnection.State != ConnectionState.Open)
            {
                databaseConnection = GetDatabaseConnection();
            }
        }

        public static void CloseDatabaseConnection()
        {
            if (databaseConnection != null && databaseConnection.State == ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }
    }
}