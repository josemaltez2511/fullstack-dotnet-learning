using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellingClothesBackend.Models.Products.Product
{
    public abstract class Product //this class represents a product and its properties 
    {
        [Key] // Primary key for the product
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate the ID
        public Guid ProductId { get; set; } = Guid.NewGuid(); // Unique identifier for the product

        public required string ProductName { get; set; } // Name of the product
        public required string ProductBrand { get; set; } // Brand of the product
        public required string ProductColor { get; set; } // Color of the product
        public required string ProductDescription { get; set; } // Description of the product
        public required string ProductImageUrl { get; set; } // URL of the product image



        [Column(TypeName = "decimal(18,2)")] // Specify precision and scale for the decimal type
        public decimal ProductPrice { get; set; } // Price of the product. Use decimal for currency values   
        public int ProductStock { get; set; } // Stock quantity of the product

        public required DateTime ProductCreatedAt { get; set; } // Date and time when the product was created
        public required DateTime ProductUpdatedAt { get; set; } // Date and time when the
        public required string ProductCategory { get; set; } // Category of the product, e.g., "Clothing", "Footwear", etc.
        public required string ProductGender { get; set; } //Gender for which the product is intended
        public required string ProductCondition { get; set; } // Condition of the product, e.g., "New", "Used", etc.

        public List<string> ProductShippingOptions { get; set; } = new List<string>();
        public required string ProductReturnPolicy { get; set; }
        public required string ProductWarranty { get; set; }
        public required string ProductTags { get; set; }
        public required string ProductDiscount { get; set; }
        public required string ProductShippingCost { get; set; } // Shipping cost for the product
        public required string ProductShippingTime { get; set; } // Estimated shipping time for the product

        public required DateTime ProductDiscountStartDate { get; set; } = DateTime.UtcNow; // Start date of the discount
        public required DateTime ProductDiscountEndDate { get; set; } = DateTime.UtcNow;// End date of the discount
    }
}