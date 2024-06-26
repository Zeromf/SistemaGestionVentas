﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aplicacion.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    ShoppingCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.ShoppingCardId);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electrodomésticos" },
                    { 2, "Tecnología y Electrónica" },
                    { 3, "Moda y Accesorios" },
                    { 4, "Hogar y Decoración" },
                    { 5, "Salud y Belleza" },
                    { 6, "Deportes y Ocio" },
                    { 7, "Juguetes y Juegos" },
                    { 8, "Alimentos y Bebidas" },
                    { 9, "Libros y Material Educativo" },
                    { 10, "Jardinería y Bricolaje" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Category", "Descripcion", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("017600de-c7da-41f8-9352-8511bf1a2aa7"), 6, "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_674284-MLU74132469460_012024-F.webp", "Raquetas de tenis de alta gama", 246900m },
                    { new Guid("1f018129-d4c4-4f60-9030-8db0d703eafa"), 9, "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", 0, "https://http2.mlstatic.com/D_NQ_NP_789389-MLA42259351508_062020-O.webp", "Atlas geográfico interactivo", 16980m },
                    { new Guid("1faaa577-f24b-408d-981d-1da0455c55d1"), 5, "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", 0, "https://http2.mlstatic.com/D_NQ_NP_870569-MLA74827280389_022024-O.webp", "Máquina de afeitar eléctrica de precisión", 36827m },
                    { new Guid("244d221d-5d89-4fd4-b23f-1af62b754a7c"), 1, "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", 43, "https://http2.mlstatic.com/D_NQ_NP_678901-MLU75358482641_032024-O.webp", "Aspiradora robotizada", 70705m },
                    { new Guid("24d0c8c5-9158-4c52-aa40-4af237ac8864"), 2, "Sony PlayStation 5 825GB God of War Ragnarok Bundle color blanco y negro.", 11, "https://http2.mlstatic.com/D_NQ_NP_700033-MLA69689802995_052023-O.webp", "Sony Playstation 5", 1199999m },
                    { new Guid("27d7ec7d-1127-45ed-a8b8-ecd182c2e827"), 2, "Inflador De Neumáticos Portátil X8", 0, "https://http2.mlstatic.com/D_NQ_NP_667807-MLU72649504918_112023-O.webp", "Inflador Portátil ultraligero", 400000m },
                    { new Guid("3184ccb6-58c1-4a80-b3f2-5e52ab489d14"), 9, "Colección de clásicos de la literatura mundial en edición especial.", 6, "https://http2.mlstatic.com/D_NQ_NP_869243-MLU74994926858_032024-O.webp", "Colección de clásicos de la literatura mundial", 17000m },
                    { new Guid("36b22fc7-a46a-461a-97c1-a70859f1baa3"), 5, "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", 24, "https://http2.mlstatic.com/D_NQ_NP_999356-MLU74959566341_032024-O.webp", "Cepillo de dientes eléctrico recargable", 92369m },
                    { new Guid("37b29a1f-5229-4d8e-85dc-68d2229c5cc4"), 7, "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", 0, "https://http2.mlstatic.com/D_NQ_NP_825422-MLA48732174078_012022-O.webp", "Muñeca interactiva con funciones inteligentes", 47491m },
                    { new Guid("42f84ce2-e29a-4990-a10e-028ee129f0b5"), 7, "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", 0, "https://http2.mlstatic.com/D_NQ_NP_688616-MLA70719693003_072023-O.webp", "Set de construcción de bloques de LEGO", 59900m },
                    { new Guid("44fcbc6c-fbaf-498f-a0b2-ce6fe1d9c9a6"), 3, "Acolchado edredón 2 plazas y 1/2 (2 plazas y media) liso reversible Abrigado invierno.", 7, "https://http2.mlstatic.com/D_NQ_NP_748192-MLA53582903699_022023-O.webp", "Acolchados Lisos 2 1/2 Plazas Reversible", 31243m },
                    { new Guid("451a370c-0c08-4d1e-8622-85f254608c28"), 3, "Cartera Cuero Genuino Reptil Bolso Mochila Mujer Cierre.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_869901-MLA54619063288_032023-F.webp", "Bolso de cuero genuino", 95000m },
                    { new Guid("4ead1861-83ad-4b11-b52b-de06a20990eb"), 9, "Bestseller del New York Times en formato papel o digital.", 0, "https://http2.mlstatic.com/D_NQ_NP_737839-MLA52392671527_112022-O.webp", "Bestseller del New York Times", 15822m },
                    { new Guid("4f2fd766-bc40-4f7d-a04b-adb1dab9f266"), 5, "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", 60, "https://http2.mlstatic.com/D_NQ_NP_2X_864195-MLU75358350003_032024-F.webp", "Kit de manicura y pedicura", 4799m },
                    { new Guid("52d318f2-8534-4667-9fd6-b0324aadea74"), 8, "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_756320-MLU70634026054_072023-F.webp", "Caja de vinos seleccionados", 187800m },
                    { new Guid("58707f3d-2c84-4e77-b10b-dac2d4bc5104"), 3, "Anteojos de sol polarizados Vulk Reporter en color sblk/s10.", 20, "https://http2.mlstatic.com/D_NQ_NP_604456-MLA48170692330_112021-O.webp", "Lente De Sol Vulk", 64800m },
                    { new Guid("5a144705-8cdf-45ae-a1c4-e8741a870f98"), 4, "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", 5, "https://http2.mlstatic.com/D_NQ_NP_814774-MLA73709732208_012024-O.webp", "Jarrón de cerámica artesanal", 27550m },
                    { new Guid("5c085131-ebfb-4f9e-b5bb-631e81341073"), 1, "Horno eléctrico de convección con capacidad de XX litros y control digital.", 9, "https://http2.mlstatic.com/D_NQ_NP_700777-MLU75436781292_042024-O.webp", "Horno eléctrico de convección", 169999m },
                    { new Guid("650c8256-88b9-493c-ad62-fb01899f57a9"), 6, "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_853020-MLU74646955786_022024-F.webp", "Tienda de campaña para 4 personas", 150000m },
                    { new Guid("738fff89-5871-473f-8125-fd50b6146084"), 2, "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", 0, "https://http2.mlstatic.com/D_NQ_NP_938092-MLA45480677826_042021-O.webp", "Auriculares inalámbricos con cancelación de ruido", 6000m },
                    { new Guid("765fcf9c-6ac6-4efa-8411-206d8490fe5a"), 2, "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", 0, "https://http2.mlstatic.com/D_NQ_NP_816025-MLU72748491987_112023-O.webp", "Smartphone de última generación", 1900000m },
                    { new Guid("7f3a5c62-e476-43ae-bd60-096b20097209"), 4, "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", 5, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Juego de cuchillos de cocina de alta calidad", 35983m },
                    { new Guid("84b318e5-0d67-4776-8e49-c57ad998142f"), 7, "Juego de mesa estratégico con tablero plegable y fichas de madera.", 0, "https://http2.mlstatic.com/D_NQ_NP_818301-MLU72732448659_112023-O.webp", "Juego de mesa de Ajedrez", 34400m },
                    { new Guid("8ed5af07-27bf-4c29-bd6d-7bf90d6034e1"), 1, "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", 61, "https://http2.mlstatic.com/D_NQ_NP_745773-MLA47575105862_092021-O.webp", "Licuadora de alta potencia", 42500m },
                    { new Guid("960c7357-4cbf-46f3-801a-e35701abf028"), 7, "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", 0, "https://http2.mlstatic.com/D_NQ_NP_681463-MLU72607866767_102023-O.webp", "Rompecabezas de 1000 piezas", 29989m },
                    { new Guid("a4fef914-10c8-4e81-af6b-61db4a389b32"), 6, "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", 0, "https://http2.mlstatic.com/D_NQ_NP_981675-MLU75436946294_042024-O.webp", "Balón de fútbol oficial", 62200m },
                    { new Guid("a5cb40a8-d947-4a7a-9ff3-bfa134450499"), 3, "Smartwatch Reloj Inteligente Dt N0.1 Dt3 Mate Doble Malla.", 13, "https://http2.mlstatic.com/D_NQ_NP_2X_748519-MLA72356877039_102023-F.webp", "Reloj inteligente elegante", 75950m },
                    { new Guid("ae65a894-d527-49c7-bdd1-3d650486063a"), 4, "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_929599-MLA54852993202_042023-F.webp", "Lámpara de pie moderna", 85050m },
                    { new Guid("b3b2aa62-5918-4302-b697-39311ca59c72"), 4, "Juego De Sabanas Queen 400hilos 100% Algodon.", 25, "https://http2.mlstatic.com/D_NQ_NP_829765-MLA73477087898_122023-O.webp", "Juego de sábanas de algodón egipcio", 85265m },
                    { new Guid("b4c525ad-2210-4c0d-b2ae-4592dac56028"), 8, "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", 17, "https://http2.mlstatic.com/D_NQ_NP_890748-MLA73914321216_012024-O.webp", "Cesta de frutas frescas de temporada", 29682m },
                    { new Guid("c5314553-d220-46ab-ac3b-20455086816b"), 3, "Zapatillas Puma Caven 2.0 Blanca", 0, "https://http2.mlstatic.com/D_NQ_NP_994477-MLA74957384571_032024-O.webp", "Zapatillas deportivas de moda", 84999m },
                    { new Guid("c768cbab-fe30-4654-9914-4e4aaaf14011"), 9, "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_924058-MLA50987231299_082022-F.webp", "Kit de experimentos científicos para niños", 27900m },
                    { new Guid("d01dd81d-e111-416b-b4ff-43809ab62bb1"), 2, "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_796079-MLU75556122361_042024-F.webp", "Smart TV de 55 pulgadas", 734999m },
                    { new Guid("d25c8e4a-4685-472d-87cf-5601362a6a39"), 5, "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", 0, "https://http2.mlstatic.com/D_NQ_NP_918096-MLA74134687068_012024-O.webp", "Serum facial rejuvenecedor", 18290m },
                    { new Guid("dbe2c41b-4f69-44e5-a030-9b1d85de53af"), 2, "Camara Digital Mirrorless Sony Alpha A6100 4k Wifi Sel1650.", 0, "https://http2.mlstatic.com/D_NQ_NP_659460-MLU72646998907_112023-O.webp", "Cámara digital réflex Sony", 1069000m },
                    { new Guid("e257fac8-a105-4c70-bf9e-7acbca8a4eb0"), 6, "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", 15, "https://http2.mlstatic.com/D_NQ_NP_2X_819576-MLU75591901591_042024-F.webp", "Bicicleta de montaña todo terreno", 283226m },
                    { new Guid("e957fdc1-0349-4b72-8227-02c16fb739b9"), 1, "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_818355-MLU74163648935_012024-F.webp", "Lavadora de carga frontal", 579999m },
                    { new Guid("ec525cfe-1958-443f-a12f-2ade7619e048"), 5, "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", 28, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Set de maquillaje profesional", 39528m },
                    { new Guid("fb9fd0c7-59e7-4b5e-92e4-759eaa2674df"), 8, "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", 0, "https://http2.mlstatic.com/D_NQ_NP_745130-MLA51091920365_082022-O.webp", "Set de gourmet de chocolates belgas", 4360m },
                    { new Guid("fd0ccd0a-393e-4a34-88b9-cb775b7a63b1"), 8, "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", 7, "https://http2.mlstatic.com/D_NQ_NP_773299-MLU72576428368_112023-O.webp", "Cafetera espresso automática", 241590m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId",
                table: "SaleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId",
                table: "SaleProduct",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
