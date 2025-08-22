using System;

namespace SellingClothesBackend.Models.Products.Jewelry
{
    public class JewelryProduct : Product.Product
    {
        public required string JewelryType { get; set; } // Tipo de joyería: "Anillo", "Collar", "Pulsera", "Aretes", etc.
        public required string Material { get; set; } // Material principal: "Oro", "Plata", "Acero inoxidable", "Plata de ley"
        public required string GemstoneType { get; set; } // Tipo de piedras preciosas o semipreciosas: "Diamante", "Rubí", "Zafiro", etc.
        public required string MetalPurity { get; set; } // Pureza del metal: "18K", "24K", etc.
        public required string JewelrySize { get; set; } // Tamaño, si es aplicable (por ejemplo, talla de anillo)
        public required string JewelryWeight { get; set; } // Peso de la pieza, puede ser útil para valor o envío
        public required string JewelryColor { get; set; } // Color específico de la joyería (puede ser diferente a la base ProductColor)
        public required string ClosureType { get; set; } // Tipo de cierre o mecanismo (para collares, pulseras)
        public required string JewelryCareInstructions { get; set; } // Instrucciones de cuidado específicas para joyería
        public required string JewelryWarranty { get; set; } // Información sobre garantía específica para joyería
        public required string Dimensions { get; set; } // Dimensiones de la joyería, como largo, ancho y alto, si aplica
    }
}