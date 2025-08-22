using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellingClothesBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductStock = table.Column<int>(type: "int", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductShippingOptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductReturnPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductWarranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDiscountStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDiscountEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductShippingCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductShippingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    BagType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagDimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagClosureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagStrapType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagCompartments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagLiningMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagCareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingSizes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypesOfClothing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingCareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingFit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingNeckline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingSleeveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothingLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GemstoneType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetalPurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelrySize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelryWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelryCareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelryWarranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeSizes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeClosureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeSoleMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeHeelHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeCareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchMovementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchCaseMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchBandMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchBandColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchDialColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchGlassType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchWaterResistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchShape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchCareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
