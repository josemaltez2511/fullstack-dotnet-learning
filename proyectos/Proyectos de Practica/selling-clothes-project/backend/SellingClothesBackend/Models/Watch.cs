using System;

namespace SellingClothesBackend.Models.Watch
{
    public class WatchProduct : Product.Product
        {
            public string WatchType { get; set; } // Tipo de reloj: "Analógico", "Digital", "Smartwatch"
            public string WatchMovementType { get; set; } // Movimiento del reloj: "Cuarzo", "Automático", "Mecánico"
            public string WatchCaseMaterial { get; set; } // Material de la caja: "Acero inoxidable", "Titanio", etc.
            public string WatchBandMaterial { get; set; } // Material de la correa: "Cuero", "Metal", "Silicona"
            public string WatchBandColor { get; set; } // Color de la correa
            public string WatchDialColor { get; set; } // Color de la esfera
            public string WatchGlassType { get; set; } // Tipo de cristal: "Zafiro", "Mineral", etc.
            public string WatchFeatures { get; set; } // Características adicionales: cronómetro, GPS, alarma, resistencia al agua, etc.
            public string WatchWaterResistance { get; set; } // Resistencia al agua: "50 metros", "100 metros"
            public string WatchSize { get; set; } // Tamaño de la caja en mm
            public string WatchShape { get; set; } // Forma de la caja: "Redonda", "Cuadrada", etc.
            public string WatchCareInstructions { get; set; } // Instrucciones de cuidado especiales para relojes
        }
}