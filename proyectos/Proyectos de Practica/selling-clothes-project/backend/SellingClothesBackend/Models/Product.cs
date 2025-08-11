using System;

namespace SellingClothesBackend.Models.Product
{
    public abstract class Product //this class represents a product and its properties 
    {
        public Guid ProductId { get; set; } // Unique identifier for the product
        public string ProductName { get; set; } // Name of the product
        public string ProductBrand { get; set; } // Brand of the product
        public string ProductColor { get; set; } // Color of the product
        public string ProductDescription { get; set; } // Description of the product
        public decimal ProductPrice { get; set; } // Price of the product. Use decimal for currency values   
        public string ProductImageUrl { get; set; } // URL of the product image
        public DateTime ProductCreatedAt { get; set; } // Date and time when the product was created
        public DateTime ProductUpdatedAt { get; set; } // Date and time when the
        public int ProductStock { get; set; } // Stock quantity of the product
        public string ProductCategory { get; set; } // Category of the product, e.g., "Clothing", "Footwear", etc.
        public string ProductGender { get; set; } //Gender for which the product is intended
        public string ProductCondition { get; set; } // Condition of the product, e.g., "New", "Used", etc.

        public List<string> ProductShippingOptions { get; set; } // Shipping options available for the product
        public string ProductReturnPolicy { get; set; } // Return policy for the product
        public string ProductWarranty { get; set; } // Warranty information for the product
        public string ProductTags { get; set; } // Tags associated with the product for better searchability
        public string ProductDiscount { get; set; } // Discount information, if any, e.g., "10% off"
        public DateTime ProductDiscountStartDate { get; set; } // Start date of the discount
        public DateTime ProductDiscountEndDate { get; set; } // End date of the discount
        public string ProductShippingCost { get; set; } // Shipping cost for the product
        public string ProductShippingTime { get; set; } // Estimated shipping time for the product
    
    }
}