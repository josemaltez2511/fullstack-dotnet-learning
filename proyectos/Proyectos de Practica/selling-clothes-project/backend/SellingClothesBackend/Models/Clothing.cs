using System;

namespace SellingClothesBackend.Models.Clothing
{
    //this class represents a clothing product and inherits from the Product class
    //It can have additional properties or methods specific to clothing items
    //use the : to indicate inheritance
    public class ClothingProduct : Product.Product
    {
        public List<string> ClothingSizes { get; set; } // Sizes available for the clothing product, e.g., "S", "M", "L", "XL"
        public string ClothingMaterial { get; set; } // Material of the clothing product, e
        public List<string> TypesOfClothing { get; set; } // Types of clothing, e.g., "Shirt", "Pants", "Dress"
        public string MeasurementUnit { get; set; } // Unit of measurement for sizes, e.g., "cm", "inches"
        public string ClothingCareInstructions { get; set; } // Care instructions for the clothing product
        public string ClothingFit { get; set; } // Fit type of the clothing product, e.g., "Regular", "Slim", "Loose"
        public string ClothingPattern { get; set; } // Pattern of the clothing product, e
        public string ClothingNeckline { get; set; } // Neckline style of the clothing product, e.g., "V-neck", "Round neck"
        public string ClothingSleeveType { get; set; } // Sleeve type of the clothing
        public string ClothingLength { get; set; } // Length of the clothing product, e.g., "Short", "Long"
    }
}