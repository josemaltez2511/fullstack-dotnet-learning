using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Product> products = await _productRepo.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _productRepo.AddProductAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Product productToEdit = await _productRepo.GetProductByIdAsync(id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            } 

            return View(productToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                await _productRepo.EditProductAsync(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}