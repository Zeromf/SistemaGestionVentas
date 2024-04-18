using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicacion.Migrations
{
    public partial class migra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
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
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                columns: new[] { "ProductId", "CategoryId", "Descripcion", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("29f94189-f059-454a-9bf0-a4f4410094f7"), 1, "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_818355-MLU74163648935_012024-F.webp", "Lavadora de carga frontal", 579999m },
                    { new Guid("8512eebe-7703-4b26-8f56-cb531647bd2e"), 5, "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", 24, "https://http2.mlstatic.com/D_NQ_NP_999356-MLU74959566341_032024-O.webp", "Cepillo de dientes eléctrico recargable", 92369m },
                    { new Guid("0cf56d2e-faa7-4f4d-8ce5-476967e165d2"), 5, "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", 60, "https://http2.mlstatic.com/D_NQ_NP_2X_864195-MLU75358350003_032024-F.webp", "Kit de manicura y pedicura", 4799m },
                    { new Guid("d0da5f05-8916-4e57-b0b5-5def8d0b39b5"), 6, "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", 15, "https://http2.mlstatic.com/D_NQ_NP_2X_819576-MLU75591901591_042024-F.webp", "Bicicleta de montaña todo terreno", 283226m },
                    { new Guid("7bc2be2f-dd0b-4e23-8e71-10934a1bc2b8"), 6, "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_853020-MLU74646955786_022024-F.webp", "Tienda de campaña para 4 personas", 150000m },
                    { new Guid("38b68a00-e8bd-46a6-a0e9-de44df0f4735"), 6, "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_674284-MLU74132469460_012024-F.webp", "Raquetas de tenis de alta gama", 246900m },
                    { new Guid("02b0b5a1-4761-426c-8509-9d83d44f69ab"), 6, "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", 0, "https://http2.mlstatic.com/D_NQ_NP_981675-MLU75436946294_042024-O.webp", "Balón de fútbol oficial", 62200m },
                    { new Guid("1bd91115-266f-46aa-82aa-9e47cb74ee82"), 7, "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", 0, "https://http2.mlstatic.com/D_NQ_NP_688616-MLA70719693003_072023-O.webp", "Set de construcción de bloques de LEGO", 59900m },
                    { new Guid("f80660c9-1bb0-48f4-ad77-65971d02963f"), 5, "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", 0, "https://http2.mlstatic.com/D_NQ_NP_918096-MLA74134687068_012024-O.webp", "Serum facial rejuvenecedor", 18290m },
                    { new Guid("3dfb6722-5ca7-413d-92a0-ed5e792511f8"), 7, "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", 0, "https://http2.mlstatic.com/D_NQ_NP_825422-MLA48732174078_012022-O.webp", "Muñeca interactiva con funciones inteligentes", 47491m },
                    { new Guid("d1feb028-a5f3-409d-8be7-d9cc35723985"), 7, "Juego de mesa estratégico con tablero plegable y fichas de madera.", 0, "https://http2.mlstatic.com/D_NQ_NP_818301-MLU72732448659_112023-O.webp", "Juego de mesa de Ajedrez", 34400m },
                    { new Guid("b61ca699-1cba-417c-ba2b-1af3ebdbccf6"), 8, "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_756320-MLU70634026054_072023-F.webp", "Caja de vinos seleccionados", 187800m },
                    { new Guid("9ac2cea9-81f1-4015-a11d-c6a53a05ff84"), 8, "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", 17, "https://http2.mlstatic.com/D_NQ_NP_890748-MLA73914321216_012024-O.webp", "Cesta de frutas frescas de temporada", 29682m },
                    { new Guid("3838de78-e8a3-424b-98ce-7eac9f9f80ac"), 8, "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", 0, "https://http2.mlstatic.com/D_NQ_NP_745130-MLA51091920365_082022-O.webp", "Set de gourmet de chocolates belgas", 4360m },
                    { new Guid("91cde0d5-9990-4b91-acc0-354a80db106e"), 8, "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", 7, "https://http2.mlstatic.com/D_NQ_NP_773299-MLU72576428368_112023-O.webp", "Cafetera espresso automática", 241590m },
                    { new Guid("18b914f4-5177-4090-910c-7acf1900ff74"), 9, "Bestseller del New York Times en formato papel o digital.", 0, "https://http2.mlstatic.com/D_NQ_NP_737839-MLA52392671527_112022-O.webp", "Bestseller del New York Times", 15822m },
                    { new Guid("5fad3be9-e114-4e91-8ce0-12dcaafe5513"), 9, "Colección de clásicos de la literatura mundial en edición especial.", 6, "https://http2.mlstatic.com/D_NQ_NP_869243-MLU74994926858_032024-O.webp", "Colección de clásicos de la literatura mundial", 17000m },
                    { new Guid("8bf5b3d5-7164-4042-9b20-d4ea01a8f18f"), 7, "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", 0, "https://http2.mlstatic.com/D_NQ_NP_681463-MLU72607866767_102023-O.webp", "Rompecabezas de 1000 piezas", 29989m },
                    { new Guid("34464048-0f32-4572-9ce3-2e11cece1cfe"), 5, "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", 0, "https://http2.mlstatic.com/D_NQ_NP_870569-MLA74827280389_022024-O.webp", "Máquina de afeitar eléctrica de precisión", 36827m },
                    { new Guid("8fda0834-4f1c-4e23-a3ca-7fc3f9c25827"), 5, "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", 28, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Set de maquillaje profesional", 39528m },
                    { new Guid("ebde990a-d05e-450f-9b89-df9114965f74"), 4, "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", 5, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Juego de cuchillos de cocina de alta calidad", 35983m },
                    { new Guid("561ceb17-81a5-4ee2-8380-1f186128ecdd"), 1, "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", 61, "https://http2.mlstatic.com/D_NQ_NP_745773-MLA47575105862_092021-O.webp", "Licuadora de alta potencia", 42500m },
                    { new Guid("bfa8b8be-ae45-4cb4-bbe7-9c0efeaf805b"), 1, "Horno eléctrico de convección con capacidad de XX litros y control digital.", 9, "https://http2.mlstatic.com/D_NQ_NP_700777-MLU75436781292_042024-O.webp", "Horno eléctrico de convección", 169999m },
                    { new Guid("952765eb-1c5a-487e-a60b-181e742c6c6d"), 1, "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", 43, "https://http2.mlstatic.com/D_NQ_NP_678901-MLU75358482641_032024-O.webp", "Aspiradora robotizada", 70705m },
                    { new Guid("45b897b1-2120-4056-b1a1-7c33dbad9b79"), 2, "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", 0, "https://http2.mlstatic.com/D_NQ_NP_816025-MLU72748491987_112023-O.webp", "Smartphone de última generación", 1900000m },
                    { new Guid("08dbd388-3c71-4637-a628-ba666ea61fb1"), 2, "Inflador De Neumáticos Portátil X8", 0, "https://http2.mlstatic.com/D_NQ_NP_667807-MLU72649504918_112023-O.webp", "Inflador Portátil ultraligero", 400000m },
                    { new Guid("68408c62-18fd-4726-918e-c5ac951948dc"), 2, "Camara Digital Mirrorless Sony Alpha A6100 4k Wifi Sel1650.", 0, "https://http2.mlstatic.com/D_NQ_NP_659460-MLU72646998907_112023-O.webp", "Cámara digital réflex Sony", 1069000m },
                    { new Guid("32a3de0d-8847-452a-ae8a-0e8749e124cd"), 2, "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_796079-MLU75556122361_042024-F.webp", "Smart TV de 55 pulgadas", 734999m },
                    { new Guid("2f8c0398-1214-4440-8a65-8da6f7da3352"), 2, "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", 0, "https://http2.mlstatic.com/D_NQ_NP_938092-MLA45480677826_042021-O.webp", "Auriculares inalámbricos con cancelación de ruido", 6000m },
                    { new Guid("5ae5bfa7-78d6-47ef-bbc4-42a7288bcd17"), 2, "Sony PlayStation 5 825GB God of War Ragnarok Bundle color blanco y negro.", 11, "https://http2.mlstatic.com/D_NQ_NP_700033-MLA69689802995_052023-O.webp", "Sony Playstation 5", 1199999m },
                    { new Guid("42087386-c097-430d-b151-f8aa89e45fcb"), 3, "Acolchado edredón 2 plazas y 1/2 (2 plazas y media) liso reversible Abrigado invierno.", 7, "https://http2.mlstatic.com/D_NQ_NP_748192-MLA53582903699_022023-O.webp", "Acolchados Lisos 2 1/2 Plazas Reversible", 31243m },
                    { new Guid("7af2c6a7-e6e0-4d22-a32e-eeaddfcc267a"), 3, "Cartera Cuero Genuino Reptil Bolso Mochila Mujer Cierre.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_869901-MLA54619063288_032023-F.webp", "Bolso de cuero genuino", 95000m },
                    { new Guid("bdb312da-59f8-407a-82ea-e50be13fc4a4"), 3, "Anteojos de sol polarizados Vulk Reporter en color sblk/s10.", 20, "https://http2.mlstatic.com/D_NQ_NP_604456-MLA48170692330_112021-O.webp", "Lente De Sol Vulk", 64800m },
                    { new Guid("7f33e887-3ad6-4174-8d9e-68331fef34c1"), 3, "Smartwatch Reloj Inteligente Dt N0.1 Dt3 Mate Doble Malla.", 13, "https://http2.mlstatic.com/D_NQ_NP_2X_748519-MLA72356877039_102023-F.webp", "Reloj inteligente elegante", 75950m },
                    { new Guid("8c33fcbe-ca6c-4fd9-a145-908fd889a0b5"), 3, "Zapatillas Puma Caven 2.0 Blanca", 0, "https://http2.mlstatic.com/D_NQ_NP_994477-MLA74957384571_032024-O.webp", "Zapatillas deportivas de moda", 84999m },
                    { new Guid("a9f2643a-4ce8-402a-96b1-e3153899a3bd"), 4, "Juego De Sabanas Queen 400hilos 100% Algodon.", 25, "https://http2.mlstatic.com/D_NQ_NP_829765-MLA73477087898_122023-O.webp", "Juego de sábanas de algodón egipcio", 85265m },
                    { new Guid("f4ebb123-a7c2-49fc-93f4-43e09d68dc37"), 4, "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", 5, "https://http2.mlstatic.com/D_NQ_NP_814774-MLA73709732208_012024-O.webp", "Jarrón de cerámica artesanal", 27550m },
                    { new Guid("46b0ab0d-b3a2-4881-a56a-7f6af27638f6"), 4, "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_929599-MLA54852993202_042023-F.webp", "Lámpara de pie moderna", 85050m },
                    { new Guid("560d8764-7055-4433-90f3-6291ebd173ee"), 9, "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", 0, "https://http2.mlstatic.com/D_NQ_NP_789389-MLA42259351508_062020-O.webp", "Atlas geográfico interactivo", 16980m },
                    { new Guid("d5ac628d-d666-4cd4-a885-3aec5b117ff5"), 9, "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_924058-MLA50987231299_082022-F.webp", "Kit de experimentos científicos para niños", 27900m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId",
                table: "SaleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId",
                table: "SaleProduct",
                column: "SaleId");
        }

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
