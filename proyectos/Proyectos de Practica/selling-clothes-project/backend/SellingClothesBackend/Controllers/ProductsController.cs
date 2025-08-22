using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellingClothesBackend.Data; // Assuming this is the namespace for your DbContex
using SellingClothesBackend.Models.Products.Product;

//Controller for managing products
//Controller Attributes
[Route("api/[controller]")] // Route for the controller
[ApiController] // Indicates that this is an API controller, adding features like automatic model validation
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Products
    //Cualquier usuario puede ver los productos
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    //GET: api/Products/5
    //Cualquier usuario puede ver los productos
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    //POST: api/Products POST MALONE
    //ONLY SELLERS CAN CREATE PRODUCTS
    [HttpPost]
    [Authorize(Roles = "Seller")]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
    }

    //PUT: api/Products/5
    //ONLY SELLERS CAN UPDATE PRODUCTS
    [HttpPut("{id}")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> PutProduct(Guid id, Product product)
    {
        // Check if the product ID in the URL matches the product ID in the object
         if (id != product.ProductId)
        {
            return BadRequest("Product ID in URL does not match object ID.");
        }

        // Check if the product exists in the database
        if (!ProductExist(id))
        {
            return NotFound("Product not found with id: " + id);
        }

        _context.Entry(product).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(e => e.ProductId == id))
            {
                return NotFound("Product not found");
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }


    //DELETE: api/Products/5
    //ONLY SELLERS CAN DELETE PRODUCTS
    [HttpDelete("{id}")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        // Check if the product exists in the database
        if (!ProductExist(id))
        {
            return NotFound("Product not found with id: " + id);
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound("Product not found with id: " + id);
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ProductExist(Guid id)
    {
        return _context.Products.Any(e => e.ProductId == id);
    }
}