using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<int> EditProductAsync(Product product);
    }
}