using System;

namespace SellingClothesBackend.Models.Products.Clothing
{
    //this class represents a clothing product and inherits from the Product class
    //It can have additional properties or methods specific to clothing items
    //use the : to indicate inheritance
    public class ClothingProduct : Product.Product
    {
        public List<string> ClothingSizes { get; set; } = new List<string>(); // Sizes available for the clothing product, e.g., "S", "M", "L", "XL"
        public List<string> TypesOfClothing { get; set; } = new List<string>();// Types of clothing, e.g., "Shirt", "Pants", "Dress"

        public required string ClothingMaterial { get; set; } // Material of the clothing product, e
        public required string MeasurementUnit { get; set; } // Unit of measurement for sizes, e.g., "cm", "inches"
        public required string ClothingCareInstructions { get; set; } // Care instructions for the clothing product
        public required string ClothingFit { get; set; } // Fit type of the clothing product, e.g., "Regular", "Slim", "Loose"
        public required string ClothingPattern { get; set; } // Pattern of the clothing product, e
        public required string ClothingNeckline { get; set; } // Neckline style of the clothing product, e.g., "V-neck", "Round neck"
        public required string ClothingSleeveType { get; set; } // Sleeve type of the clothing
        public required string ClothingLength { get; set; } // Length of the clothing product, e.g., "Short", "Long"
    }
}