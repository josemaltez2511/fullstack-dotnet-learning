using System;
using SellingClothesBackend.Models.Products.Product;

namespace SellingClothesBackend.Models.Products.Bags
{
    public class BagProduct : Product.Product
    {
        public required string BagType { get; set; }           // Tipo de bolso: "Mochila", "Bolso de mano", "Tote", "Clutch", etc.
        public required string BagMaterial { get; set; }       // Material: "Cuero", "Tela", "Sintético", etc.
        public required string BagSize { get; set; }           // Tamaño general o clasificación (pequeño, mediano, grande)
        public required string BagDimensions { get; set; }     // Medidas detalladas (alto x ancho x profundidad)
        public required string BagClosureType { get; set; }    // Tipo de cierre: "Cremallera", "Botón", "Hebilla", etc.
        public required string BagStrapType { get; set; }      // Tipo de asa o correa: "Ajustable", "Cadena", "Doble asa"
        public required int BagCompartments { get; set; }   // Descripción de bolsillos o compartimentos internos/exteriores
        public required string BagLiningMaterial { get; set; } // Material del forro interno
        public required string BagCareInstructions { get; set; } // Instrucciones para el cuidado del bolso
    }
}
