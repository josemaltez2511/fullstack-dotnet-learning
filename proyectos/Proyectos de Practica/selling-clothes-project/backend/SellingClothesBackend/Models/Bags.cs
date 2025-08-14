using System;

namespace SellingClothesBackend.Models.Bags
{
    public class BagProduct : Product.Product
    {
        public string BagType { get; set; }           // Tipo de bolso: "Mochila", "Bolso de mano", "Tote", "Clutch", etc.
        public string BagMaterial { get; set; }       // Material: "Cuero", "Tela", "Sintético", etc.
        public string BagSize { get; set; }           // Tamaño general o clasificación (pequeño, mediano, grande)
        public string BagDimensions { get; set; }     // Medidas detalladas (alto x ancho x profundidad)
        public string BagClosureType { get; set; }    // Tipo de cierre: "Cremallera", "Botón", "Hebilla", etc.
        public string BagStrapType { get; set; }      // Tipo de asa o correa: "Ajustable", "Cadena", "Doble asa"
        public string BagCompartments { get; set; }   // Descripción de bolsillos o compartimentos internos/exteriores
        public string BagLiningMaterial { get; set; } // Material del forro interno
        public string BagCareInstructions { get; set; } // Instrucciones para el cuidado del bolso
    }
}
