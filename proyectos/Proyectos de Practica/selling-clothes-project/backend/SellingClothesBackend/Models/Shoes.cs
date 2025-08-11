using System;

namespace SellingClothesBackend.Models.Shoes
{
    public class ShoesProduct : Product.Product
    {
        public List<string> ShoeSizes { get; set; } // Sizes available for the shoe product, e.g., "8", "9", "10"
        public string ShoeMaterial { get; set; } // Material of the shoe product, e.g., "Leather", "Canvas"
        public string ShoeType { get; set; } // Type of shoe, e.g., "Sneakers", "Boots", "Sandals"
        public string ShoeClosureType { get; set; } // Closure type of the shoe, e.g., "Laces", "Velcro", "Slip-on"
        public string ShoeSoleMaterial { get; set; } // Material of the shoe sole, e.g., "Rubber", "EVA"
        public string ShoeHeelHeight { get; set; } // Heel height of the shoe, if applicable, e.g., "2 inches"
        public string ShoeWidth { get; set; } // Width of the shoe, e.g., "Narrow", "Regular", "Wide"
        public string ShoeCareInstructions { get; set; } // Care instructions for the shoe product
    }
}