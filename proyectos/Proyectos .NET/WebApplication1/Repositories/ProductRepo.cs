using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Linq;
using System.Data;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;

namespace WebApplication1.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ProductInventoryDB"].ConnectionString;

        public async Task<List<Product>> GetAllProductsAsync()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT Id, Name, Quantity, Price FROM Products";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
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

        public async Task AddProductAsync(Product product)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();

                string InsertQuery = "INSERT INTO Products (Name, Quantity, Price) VALUES (@name, @quantity, @price)";
                using (SqlCommand command = new SqlCommand(InsertQuery, conn))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@price", product.Price);
                    await command.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                string IdQuery = "SELECT Id, Name, Quantity, Price " +
                    "FROM Products WHERE Id = @Id;";
                using (SqlCommand command =  new SqlCommand(IdQuery, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader =  await command.ExecuteReaderAsync())
                    {
                        if(reader.Read())
                        {
                            product = new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                            };
                        }
                    }
                }
            }
            return product;
        }

        public async Task<int> EditProductAsync(Product product)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                
                string UpdateQuery = "UPDATE Products " +
                    "SET Name = @Name, " +
                    "Quantity = @Quantity, " +
                    "Price = @Price " +
                    "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(UpdateQuery, conn))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Id", product.Id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected;
                }
            }
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                string DeleteQuery = "DELETE FROM Products WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(DeleteQuery, conn))
                {
                    command.Parameters.AddWithValue("@Id",id);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected;
                }
            } 
        }
    }
}