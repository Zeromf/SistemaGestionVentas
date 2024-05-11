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
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true)
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
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.ShoppingCardId);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_Product",
                        column: x => x.Product,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_Sale",
                        column: x => x.Sale,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "ProductId", "Category", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0d18242c-9b24-42a4-9d71-9ffa3e8c958f"), 2, "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", 0, "https://http2.mlstatic.com/D_NQ_NP_938092-MLA45480677826_042021-O.webp", "Auriculares inalámbricos con cancelación de ruido", 6000m },
                    { new Guid("19817a03-b49a-48b4-9d68-ff0fac5bd8b2"), 1, "Horno eléctrico de convección con capacidad de XX litros y control digital.", 9, "https://http2.mlstatic.com/D_NQ_NP_700777-MLU75436781292_042024-O.webp", "Horno eléctrico de convección", 169999m },
                    { new Guid("1eaf09c6-ce84-4f6f-825e-fdcf70e7ebf0"), 2, "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_796079-MLU75556122361_042024-F.webp", "Smart TV de 55 pulgadas", 734999m },
                    { new Guid("2aa3918f-cfd7-4d49-9b80-340956b6ee47"), 9, "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", 0, "https://http2.mlstatic.com/D_NQ_NP_789389-MLA42259351508_062020-O.webp", "Atlas geográfico interactivo", 16980m },
                    { new Guid("2b12f33c-a11f-4692-8f1c-2f6800394b7a"), 3, "Acolchado edredón 2 plazas y 1/2 (2 plazas y media) liso reversible Abrigado invierno.", 7, "https://http2.mlstatic.com/D_NQ_NP_748192-MLA53582903699_022023-O.webp", "Acolchados Lisos 2 1/2 Plazas Reversible", 31243m },
                    { new Guid("33b4fc6c-f9b7-4038-ba05-25a54c06dc86"), 8, "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", 17, "https://http2.mlstatic.com/D_NQ_NP_890748-MLA73914321216_012024-O.webp", "Cesta de frutas frescas de temporada", 29682m },
                    { new Guid("3ce4aab8-835b-4eed-9141-e7b135ab44a5"), 6, "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", 15, "https://http2.mlstatic.com/D_NQ_NP_2X_819576-MLU75591901591_042024-F.webp", "Bicicleta de montaña todo terreno", 283226m },
                    { new Guid("3e0cafbc-6750-4e81-a0b6-e3737f97cddb"), 4, "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_929599-MLA54852993202_042023-F.webp", "Lámpara de pie moderna", 85050m },
                    { new Guid("3e6c6a49-fcab-49db-87e8-8a1f9bd1cbd6"), 9, "Bestseller del New York Times en formato papel o digital.", 0, "https://http2.mlstatic.com/D_NQ_NP_737839-MLA52392671527_112022-O.webp", "Bestseller del New York Times", 15822m },
                    { new Guid("45f00bf3-8a7b-4d0b-8a26-28a61aaeb59c"), 3, "Zapatillas Puma Caven 2.0 Blanca", 0, "https://http2.mlstatic.com/D_NQ_NP_994477-MLA74957384571_032024-O.webp", "Zapatillas deportivas de moda", 84999m },
                    { new Guid("4ab8a007-595c-44e5-b3b6-9c5c63fd04ae"), 6, "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", 0, "https://http2.mlstatic.com/D_NQ_NP_981675-MLU75436946294_042024-O.webp", "Balón de fútbol oficial", 62200m },
                    { new Guid("4d9f7a50-68c0-40d0-a72c-bb9cd99f1887"), 1, "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_818355-MLU74163648935_012024-F.webp", "Lavadora de carga frontal", 579999m },
                    { new Guid("6190334e-fb56-4403-a4f9-9d23981f556b"), 6, "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_674284-MLU74132469460_012024-F.webp", "Raquetas de tenis de alta gama", 246900m },
                    { new Guid("68da8533-c425-4e3e-8a0f-87f1ba5794c2"), 5, "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", 0, "https://http2.mlstatic.com/D_NQ_NP_918096-MLA74134687068_012024-O.webp", "Serum facial rejuvenecedor", 18290m },
                    { new Guid("6a4f86a1-d3b0-41bf-bc23-717d00a7a23f"), 7, "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", 0, "https://http2.mlstatic.com/D_NQ_NP_825422-MLA48732174078_012022-O.webp", "Muñeca interactiva con funciones inteligentes", 47491m },
                    { new Guid("6d9b5690-9a3b-4f72-9aab-375f49f71e8f"), 2, "Camara Digital Mirrorless Sony Alpha A6100 4k Wifi Sel1650.", 0, "https://http2.mlstatic.com/D_NQ_NP_659460-MLU72646998907_112023-O.webp", "Cámara digital réflex Sony", 1069000m },
                    { new Guid("798a1105-e44e-4b8c-ae88-4b9df0c0592f"), 4, "Juego De Sabanas Queen 400hilos 100% Algodon.", 25, "https://http2.mlstatic.com/D_NQ_NP_829765-MLA73477087898_122023-O.webp", "Juego de sábanas de algodón egipcio", 85265m },
                    { new Guid("7b714cd8-e52e-4e98-a51b-a19a1758f1fc"), 4, "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", 5, "https://http2.mlstatic.com/D_NQ_NP_814774-MLA73709732208_012024-O.webp", "Jarrón de cerámica artesanal", 27550m },
                    { new Guid("8250654d-da6c-4e18-80b0-ca85dec932ec"), 3, "Anteojos de sol polarizados Vulk Reporter en color sblk/s10.", 20, "https://http2.mlstatic.com/D_NQ_NP_604456-MLA48170692330_112021-O.webp", "Lente De Sol Vulk", 64800m },
                    { new Guid("8730ede2-0e2b-445e-b26e-09f532b691f1"), 8, "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", 0, "https://http2.mlstatic.com/D_NQ_NP_745130-MLA51091920365_082022-O.webp", "Set de gourmet de chocolates belgas", 4360m },
                    { new Guid("87a6abab-4575-429d-8301-e7053e2eae27"), 7, "Juego de mesa estratégico con tablero plegable y fichas de madera.", 0, "https://http2.mlstatic.com/D_NQ_NP_818301-MLU72732448659_112023-O.webp", "Juego de mesa de Ajedrez", 34400m },
                    { new Guid("8c1c3701-0780-482b-a1c8-307797746b6b"), 2, "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", 0, "https://http2.mlstatic.com/D_NQ_NP_816025-MLU72748491987_112023-O.webp", "Smartphone de última generación", 1900000m },
                    { new Guid("96704d21-f755-4c6e-8082-1835b5cdbfb3"), 1, "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", 61, "https://http2.mlstatic.com/D_NQ_NP_745773-MLA47575105862_092021-O.webp", "Licuadora de alta potencia", 42500m },
                    { new Guid("a2b372cc-2457-463d-a968-4060cc9caba0"), 4, "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", 5, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Juego de cuchillos de cocina de alta calidad", 35983m },
                    { new Guid("aa6d01b2-8a84-4cc1-aed5-ac41d689a670"), 5, "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", 0, "https://http2.mlstatic.com/D_NQ_NP_870569-MLA74827280389_022024-O.webp", "Máquina de afeitar eléctrica de precisión", 36827m },
                    { new Guid("ae9f275c-2af5-4d3c-a072-8938082eed5b"), 5, "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", 24, "https://http2.mlstatic.com/D_NQ_NP_999356-MLU74959566341_032024-O.webp", "Cepillo de dientes eléctrico recargable", 92369m },
                    { new Guid("b653e94a-e9f2-4cb8-95aa-5cbf71eed639"), 7, "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", 0, "https://http2.mlstatic.com/D_NQ_NP_681463-MLU72607866767_102023-O.webp", "Rompecabezas de 1000 piezas", 29989m },
                    { new Guid("bd8980ec-7d2e-49e9-bdbd-de96965bc641"), 9, "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_924058-MLA50987231299_082022-F.webp", "Kit de experimentos científicos para niños", 27900m },
                    { new Guid("c2e2f591-e363-4382-ae7a-d9645664a26e"), 1, "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", 43, "https://http2.mlstatic.com/D_NQ_NP_678901-MLU75358482641_032024-O.webp", "Aspiradora robotizada", 70705m },
                    { new Guid("c973afcb-7b99-420e-8187-dc7f761b53c6"), 3, "Cartera Cuero Genuino Reptil Bolso Mochila Mujer Cierre.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_869901-MLA54619063288_032023-F.webp", "Bolso de cuero genuino", 95000m },
                    { new Guid("cdd1b483-338c-46e3-823c-81307792bd7d"), 8, "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_756320-MLU70634026054_072023-F.webp", "Caja de vinos seleccionados", 187800m },
                    { new Guid("cde5fd6c-9ce5-4029-b9d0-48965c1ef1f8"), 7, "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", 0, "https://http2.mlstatic.com/D_NQ_NP_688616-MLA70719693003_072023-O.webp", "Set de construcción de bloques de LEGO", 59900m },
                    { new Guid("d29d7d1e-1b2b-43d6-bf23-a8ac57c02112"), 8, "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", 7, "https://http2.mlstatic.com/D_NQ_NP_773299-MLU72576428368_112023-O.webp", "Cafetera espresso automática", 241590m },
                    { new Guid("d32d73a8-4f6e-471f-875f-1b05e71d71e9"), 5, "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", 60, "https://http2.mlstatic.com/D_NQ_NP_2X_864195-MLU75358350003_032024-F.webp", "Kit de manicura y pedicura", 4799m },
                    { new Guid("e1e6fc9e-5d92-4a26-94ae-ef1af3af5d27"), 2, "Sony PlayStation 5 825GB God of War Ragnarok Bundle color blanco y negro.", 11, "https://http2.mlstatic.com/D_NQ_NP_700033-MLA69689802995_052023-O.webp", "Sony Playstation 5", 1199999m },
                    { new Guid("e6dc21d6-5d34-4246-87c0-31f7101fb40c"), 6, "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_853020-MLU74646955786_022024-F.webp", "Tienda de campaña para 4 personas", 150000m },
                    { new Guid("e9fb7c40-588e-42ea-92aa-0fd570ef25de"), 5, "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", 28, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Set de maquillaje profesional", 39528m },
                    { new Guid("ec549bc2-4a53-48cb-8f4c-103fdaea0fb1"), 9, "Colección de clásicos de la literatura mundial en edición especial.", 6, "https://http2.mlstatic.com/D_NQ_NP_869243-MLU74994926858_032024-O.webp", "Colección de clásicos de la literatura mundial", 17000m },
                    { new Guid("f4852e57-2935-4aa5-ad4f-222a310bfdfc"), 2, "Inflador De Neumáticos Portátil X8", 0, "https://http2.mlstatic.com/D_NQ_NP_667807-MLU72649504918_112023-O.webp", "Inflador Portátil ultraligero", 400000m },
                    { new Guid("faf39cc2-2c7e-42aa-b52a-96c71936b526"), 3, "Smartwatch Reloj Inteligente Dt N0.1 Dt3 Mate Doble Malla.", 13, "https://http2.mlstatic.com/D_NQ_NP_2X_748519-MLA72356877039_102023-F.webp", "Reloj inteligente elegante", 75950m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Product",
                table: "SaleProduct",
                column: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Sale",
                table: "SaleProduct",
                column: "Sale");
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
