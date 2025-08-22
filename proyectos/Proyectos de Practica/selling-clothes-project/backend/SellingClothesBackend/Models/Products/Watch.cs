using System;

namespace SellingClothesBackend.Models.Products.Watch
{
    public class WatchProduct : Product.Product
        {
            public required string WatchType { get; set; } // Tipo de reloj: "Analógico", "Digital", "Smartwatch"
            public required string WatchMovementType { get; set; } // Movimiento del reloj: "Cuarzo", "Automático", "Mecánico"
            public required string WatchCaseMaterial { get; set; } // Material de la caja: "Acero inoxidable", "Titanio", etc.
            public required string WatchBandMaterial { get; set; } // Material de la correa: "Cuero", "Metal", "Silicona"
            public required string WatchBandColor { get; set; } // Color de la correa
            public required string WatchDialColor { get; set; } // Color de la esfera
            public required string WatchGlassType { get; set; } // Tipo de cristal: "Zafiro", "Mineral", etc.
            public required string WatchFeatures { get; set; } // Características adicionales: cronómetro, GPS, alarma, resistencia al agua, etc.
            public required string WatchWaterResistance { get; set; } // Resistencia al agua: "50 metros", "100 metros"
            public required string WatchSize { get; set; } // Tamaño de la caja en mm
            public required string WatchShape { get; set; } // Forma de la caja: "Redonda", "Cuadrada", etc.
            public required string WatchCareInstructions { get; set; } // Instrucciones de cuidado especiales para relojes
        }
}