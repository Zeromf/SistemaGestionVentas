using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructura.Migrations
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
                    { new Guid("045277c5-7864-4f7a-b288-6216bf3c9dc7"), 7, "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", 0, "https://http2.mlstatic.com/D_NQ_NP_688616-MLA70719693003_072023-O.webp", "Set de construcción de bloques de LEGO", 59900m },
                    { new Guid("0f36b6ce-219e-4988-a648-f529a5ed935c"), 4, "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_929599-MLA54852993202_042023-F.webp", "Lámpara de pie moderna", 85050m },
                    { new Guid("194cb7f0-cc75-4bc7-ae4a-dabf348a62a0"), 8, "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", 7, "https://http2.mlstatic.com/D_NQ_NP_773299-MLU72576428368_112023-O.webp", "Cafetera espresso automática", 241590m },
                    { new Guid("2950c60f-31a9-4f66-aadb-4db4fd006158"), 2, "Camara Digital Mirrorless Sony Alpha A6100 4k Wifi Sel1650.", 0, "https://http2.mlstatic.com/D_NQ_NP_659460-MLU72646998907_112023-O.webp", "Cámara digital réflex Sony", 1069000m },
                    { new Guid("2be8a358-68c8-4e0b-b125-251caa4a0718"), 5, "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", 28, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Set de maquillaje profesional", 39528m },
                    { new Guid("2bfb0b83-552e-41cb-b095-c57a58fe296e"), 6, "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_674284-MLU74132469460_012024-F.webp", "Raquetas de tenis de alta gama", 246900m },
                    { new Guid("2d4907ea-2384-4219-aaa0-45b756b5d682"), 2, "Sony PlayStation 5 825GB God of War Ragnarok Bundle color blanco y negro.", 11, "https://http2.mlstatic.com/D_NQ_NP_700033-MLA69689802995_052023-O.webp", "Sony Playstation 5", 1199999m },
                    { new Guid("2d673e79-3991-4a55-80d1-f4bd3988cef6"), 7, "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", 0, "https://http2.mlstatic.com/D_NQ_NP_681463-MLU72607866767_102023-O.webp", "Rompecabezas de 1000 piezas", 29989m },
                    { new Guid("2db9b3de-41cb-4f16-a292-10e2161b1f76"), 3, "Zapatillas Puma Caven 2.0 Blanca", 0, "https://http2.mlstatic.com/D_NQ_NP_994477-MLA74957384571_032024-O.webp", "Zapatillas deportivas de moda", 84999m },
                    { new Guid("3b056c7d-ead4-4513-8ee8-cb6e5fcb812a"), 9, "Colección de clásicos de la literatura mundial en edición especial.", 6, "https://http2.mlstatic.com/D_NQ_NP_869243-MLU74994926858_032024-O.webp", "Colección de clásicos de la literatura mundial", 17000m },
                    { new Guid("4a49dc52-7c1c-4835-8544-72eec788d8cc"), 9, "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_924058-MLA50987231299_082022-F.webp", "Kit de experimentos científicos para niños", 27900m },
                    { new Guid("4a6c87eb-1902-4f2b-a0eb-2bd7d1791985"), 6, "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", 0, "https://http2.mlstatic.com/D_NQ_NP_981675-MLU75436946294_042024-O.webp", "Balón de fútbol oficial", 62200m },
                    { new Guid("58d14fb5-5cba-447e-8f74-83f3e5f5f06b"), 2, "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_796079-MLU75556122361_042024-F.webp", "Smart TV de 55 pulgadas", 734999m },
                    { new Guid("5907afbd-5a19-4e5c-ac20-e1ab0f23cf1e"), 1, "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", 61, "https://http2.mlstatic.com/D_NQ_NP_745773-MLA47575105862_092021-O.webp", "Licuadora de alta potencia", 42500m },
                    { new Guid("621d1be7-b8b0-493b-980c-7af55bd852e5"), 5, "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", 0, "https://http2.mlstatic.com/D_NQ_NP_870569-MLA74827280389_022024-O.webp", "Máquina de afeitar eléctrica de precisión", 36827m },
                    { new Guid("62dd17f4-2b66-4cf3-ae05-6f54de7cef78"), 7, "Juego de mesa estratégico con tablero plegable y fichas de madera.", 0, "https://http2.mlstatic.com/D_NQ_NP_818301-MLU72732448659_112023-O.webp", "Juego de mesa de Ajedrez", 34400m },
                    { new Guid("6bdd82b3-e90d-4023-9364-d4619f98f5fa"), 9, "Bestseller del New York Times en formato papel o digital.", 0, "https://http2.mlstatic.com/D_NQ_NP_737839-MLA52392671527_112022-O.webp", "Bestseller del New York Times", 15822m },
                    { new Guid("870cb16e-68c2-4616-80ee-281b8ca8e463"), 3, "Acolchado edredón 2 plazas y 1/2 (2 plazas y media) liso reversible Abrigado invierno.", 7, "https://http2.mlstatic.com/D_NQ_NP_748192-MLA53582903699_022023-O.webp", "Acolchados Lisos 2 1/2 Plazas Reversible", 31243m },
                    { new Guid("87b03b8c-50c6-4fea-93d4-ed58ad21b3e3"), 1, "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_818355-MLU74163648935_012024-F.webp", "Lavadora de carga frontal", 579999m },
                    { new Guid("8a2b0893-57fc-438f-94ae-97155e721a7d"), 3, "Cartera Cuero Genuino Reptil Bolso Mochila Mujer Cierre.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_869901-MLA54619063288_032023-F.webp", "Bolso de cuero genuino", 95000m },
                    { new Guid("99e6f4ab-d849-4d57-9435-82b4aed8146f"), 8, "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", 0, "https://http2.mlstatic.com/D_NQ_NP_745130-MLA51091920365_082022-O.webp", "Set de gourmet de chocolates belgas", 4360m },
                    { new Guid("a04f70af-ab13-4513-83da-b16f05cf621d"), 7, "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", 0, "https://http2.mlstatic.com/D_NQ_NP_825422-MLA48732174078_012022-O.webp", "Muñeca interactiva con funciones inteligentes", 47491m },
                    { new Guid("a372f968-6ddd-47b4-a321-fc2a172d5ea6"), 3, "Smartwatch Reloj Inteligente Dt N0.1 Dt3 Mate Doble Malla.", 13, "https://http2.mlstatic.com/D_NQ_NP_2X_748519-MLA72356877039_102023-F.webp", "Reloj inteligente elegante", 75950m },
                    { new Guid("b5fca9e7-4ffd-4bc4-be4e-94ea30b39e72"), 2, "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", 0, "https://http2.mlstatic.com/D_NQ_NP_938092-MLA45480677826_042021-O.webp", "Auriculares inalámbricos con cancelación de ruido", 6000m },
                    { new Guid("c39ca82b-e3a8-43b9-b1b7-73d4f646e878"), 1, "Horno eléctrico de convección con capacidad de XX litros y control digital.", 9, "https://http2.mlstatic.com/D_NQ_NP_700777-MLU75436781292_042024-O.webp", "Horno eléctrico de convección", 169999m },
                    { new Guid("c5517268-bf05-4827-b838-8646e4e22445"), 5, "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", 60, "https://http2.mlstatic.com/D_NQ_NP_2X_864195-MLU75358350003_032024-F.webp", "Kit de manicura y pedicura", 4799m },
                    { new Guid("c781e7e5-26d1-4480-83f6-d37c4fad0a35"), 1, "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", 43, "https://http2.mlstatic.com/D_NQ_NP_678901-MLU75358482641_032024-O.webp", "Aspiradora robotizada", 70705m },
                    { new Guid("c96134dd-71f1-490b-86f3-d98142b074c4"), 4, "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", 5, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Juego de cuchillos de cocina de alta calidad", 35983m },
                    { new Guid("cc4bdfff-c059-4caf-9130-ed04b4bdc8a1"), 3, "Anteojos de sol polarizados Vulk Reporter en color sblk/s10.", 20, "https://http2.mlstatic.com/D_NQ_NP_604456-MLA48170692330_112021-O.webp", "Lente De Sol Vulk", 64800m },
                    { new Guid("cc872229-0c18-47db-842f-50d65ba3ab88"), 9, "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", 0, "https://http2.mlstatic.com/D_NQ_NP_789389-MLA42259351508_062020-O.webp", "Atlas geográfico interactivo", 16980m },
                    { new Guid("d93aa009-94d3-4db0-96d7-cd44a7da5b32"), 4, "Juego De Sabanas Queen 400hilos 100% Algodon.", 25, "https://http2.mlstatic.com/D_NQ_NP_829765-MLA73477087898_122023-O.webp", "Juego de sábanas de algodón egipcio", 85265m },
                    { new Guid("e468b6d7-d9b9-4b14-ac9f-a2b90fb07f31"), 8, "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", 17, "https://http2.mlstatic.com/D_NQ_NP_890748-MLA73914321216_012024-O.webp", "Cesta de frutas frescas de temporada", 29682m },
                    { new Guid("ea5a79ee-9723-40d4-915a-1696b7c70a82"), 2, "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", 0, "https://http2.mlstatic.com/D_NQ_NP_816025-MLU72748491987_112023-O.webp", "Smartphone de última generación", 1900000m },
                    { new Guid("ec154df9-3ac1-43b0-9444-c11fd177150c"), 4, "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", 5, "https://http2.mlstatic.com/D_NQ_NP_814774-MLA73709732208_012024-O.webp", "Jarrón de cerámica artesanal", 27550m },
                    { new Guid("edef87a4-abaa-417c-a838-07bab0655cb3"), 6, "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", 15, "https://http2.mlstatic.com/D_NQ_NP_2X_819576-MLU75591901591_042024-F.webp", "Bicicleta de montaña todo terreno", 283226m },
                    { new Guid("ee6d142b-557f-441a-acce-dd6cbd80a201"), 5, "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", 24, "https://http2.mlstatic.com/D_NQ_NP_999356-MLU74959566341_032024-O.webp", "Cepillo de dientes eléctrico recargable", 92369m },
                    { new Guid("f0f7cf7b-4603-4262-b198-4d0ceb4d154e"), 5, "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", 0, "https://http2.mlstatic.com/D_NQ_NP_918096-MLA74134687068_012024-O.webp", "Serum facial rejuvenecedor", 18290m },
                    { new Guid("f18bb132-6862-4de8-af5c-1a0ed04dc587"), 6, "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_853020-MLU74646955786_022024-F.webp", "Tienda de campaña para 4 personas", 150000m },
                    { new Guid("fed20ea0-c05c-40a3-9eac-fd8fe660fef7"), 8, "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_756320-MLU70634026054_072023-F.webp", "Caja de vinos seleccionados", 187800m },
                    { new Guid("ff9ff8f2-4b44-4737-b321-d9e93f1e5e5e"), 2, "Inflador De Neumáticos Portátil X8", 0, "https://http2.mlstatic.com/D_NQ_NP_667807-MLU72649504918_112023-O.webp", "Inflador Portátil ultraligero", 400000m }
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
