using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;

namespace ProNatur_Biomarkt_GmbH
{
    public class ProductRepository
    {
        // Method to load all products from the database
        public static List<Product> LoadProducts()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetDatabaseConnection())
                {
                    string query = "SELECT * FROM Products";

                    // Dapper: Execute the SQL query and directly convert the result to a list of Products!
                    return (connection.Query<Product>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products:: " + ex.Message);
                return new List<Product>();
            }
        }

        // Method to save a new product
        public static void SaveProduct(Product product)
        {
            try
            {
                SqlConnection connection = DatabaseHelper.GetDatabaseConnection();

                string query = @"INSERT INTO Products (InventoryNumber, Name, Brand, Category, Price, Amount)
                         VALUES (@InventoryNumber, @Name, @Brand, @Category, @Price, @Amount)";

                product.InventoryNumber = GetNextInventoryNumber();
                connection.Execute(query, product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving product: " + ex.Message);
            }
        }

        // Method to edit an existing product
        public static void EditProduct(Product product)
        {
            try
            {
                SqlConnection connection = DatabaseHelper.GetDatabaseConnection(); // Verbindung offen lassen

                string query = @"UPDATE Products
                         SET Name = @Name, Brand = @Brand, Category = @Category,
                             Price = @Price, Amount = @Amount
                         WHERE ID = @ID";

                connection.Execute(query, product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        // Method to delete a product
        public static void DeleteProduct(int productId)
        {
            try
            {
                SqlConnection connection = DatabaseHelper.GetDatabaseConnection();

                string query = "DELETE FROM Products WHERE ID = @ID";

                // Execute the DELETE query and store the number of affected rows
                // If no rows were deleted display a message
                int rowsAffected = connection.Execute(query, new { ID = productId });

                if (rowsAffected == 0)
                {
                    MessageBox.Show("No product found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
        }

        // Method to get the next available inventory number
        private static int GetNextInventoryNumber()
        {
            SqlConnection connection = DatabaseHelper.GetDatabaseConnection();

            string query = "SELECT ISNULL(MAX(InventoryNumber), 0) + 1 FROM Products";

            return connection.ExecuteScalar<int>(query);
        }

        public static List<string> GetFilterValues(string filterType)
        {
            try
            {
                SqlConnection connection = DatabaseHelper.GetDatabaseConnection();

                string query = $"SELECT DISTINCT {filterType} FROM Products ORDER BY {filterType}";

                return connection.Query<string>(query).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Values: " + ex.Message);
                return new List<string>();
            }
        }

        public static List<Product> GetFilteredProducts(string filterType, string filterValue)
        {
            try
            {
                SqlConnection connection = DatabaseHelper.GetDatabaseConnection();

                string query = $"SELECT * FROM Products WHERE {filterType} = @FilterValue";

                return connection.Query<Product>(query, new { FilterValue = filterValue }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error laoding Products: " + ex.Message);
                return new List<Product>();
            }
        }
    }
}