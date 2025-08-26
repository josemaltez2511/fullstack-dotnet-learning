using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;


namespace WebApplication1.Repositories
{
    public class ProductRepo
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["ProductInventoryDB"].ConnectionString;

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = "SELECT Id, Name, Quantity, Price FROM Products";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string InsertQuery = "INSERT INTO Products (Name, Quantity, Price) VALUES (@name, @quantity, @price)";
                using (SqlCommand command = new SqlCommand(InsertQuery, conn))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}