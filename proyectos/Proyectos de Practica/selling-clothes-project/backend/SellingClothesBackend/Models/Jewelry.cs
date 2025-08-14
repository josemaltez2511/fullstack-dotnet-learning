using System;

namespace SellingClothesBackend.Models.Jewelry
{
    public class AccessoriesProduct : Product.Product
    {
        public string JewelryType { get; set; } // Tipo de joyería: "Anillo", "Collar", "Pulsera", "Aretes", etc.
        public string Material { get; set; } // Material principal: "Oro", "Plata", "Acero inoxidable", "Plata de ley"
        public string GemstoneType { get; set; } // Tipo de piedras preciosas o semipreciosas: "Diamante", "Rubí", "Zafiro", etc.
        public string MetalPurity { get; set; } // Pureza del metal: "18K", "24K", etc.
        public string JewelrySize { get; set; } // Tamaño, si es aplicable (por ejemplo, talla de anillo)
        public string JewelryWeight { get; set; } // Peso de la pieza, puede ser útil para valor o envío
        public string JewelryColor { get; set; } // Color específico de la joyería (puede ser diferente a la base ProductColor)
        public string ClosureType { get; set; } // Tipo de cierre o mecanismo (para collares, pulseras)
        public string JewelryCareInstructions { get; set; } // Instrucciones de cuidado específicas para joyería
        public string JewelryWarranty { get; set; } // Información sobre garantía específica para joyería
        public string Dimensions { get; set; } // Dimensiones de la joyería, como largo, ancho y alto, si aplica
    }
}