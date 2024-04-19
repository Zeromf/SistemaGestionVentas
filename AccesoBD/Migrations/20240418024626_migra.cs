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
                    { new Guid("ee95bf81-25db-4ad7-9896-87734628318c"), 1, "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_818355-MLU74163648935_012024-F.webp", "Lavadora de carga frontal", 579999m },
                    { new Guid("f9c0c674-84ab-42fb-8e7f-c7c64e624857"), 5, "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", 24, "https://http2.mlstatic.com/D_NQ_NP_999356-MLU74959566341_032024-O.webp", "Cepillo de dientes eléctrico recargable", 92369m },
                    { new Guid("5d386339-d5a8-4673-a1a3-d31066844093"), 5, "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", 60, "https://http2.mlstatic.com/D_NQ_NP_2X_864195-MLU75358350003_032024-F.webp", "Kit de manicura y pedicura", 4799m },
                    { new Guid("1766f2b1-75be-4103-bab3-efb0b3191c14"), 6, "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", 15, "https://http2.mlstatic.com/D_NQ_NP_2X_819576-MLU75591901591_042024-F.webp", "Bicicleta de montaña todo terreno", 283226m },
                    { new Guid("b07d5b1e-695a-401f-bba9-df00e8d525c2"), 6, "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", 25, "https://http2.mlstatic.com/D_NQ_NP_2X_853020-MLU74646955786_022024-F.webp", "Tienda de campaña para 4 personas", 150000m },
                    { new Guid("c28ccc5f-5c4d-4453-8119-a9989e3e078f"), 6, "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_674284-MLU74132469460_012024-F.webp", "Raquetas de tenis de alta gama", 246900m },
                    { new Guid("2e645ead-656d-4ed0-8d4b-357277129ec3"), 6, "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", 0, "https://http2.mlstatic.com/D_NQ_NP_981675-MLU75436946294_042024-O.webp", "Balón de fútbol oficial", 62200m },
                    { new Guid("8ae75ae6-63d3-418c-9d3e-f1b632e21281"), 7, "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", 0, "https://http2.mlstatic.com/D_NQ_NP_688616-MLA70719693003_072023-O.webp", "Set de construcción de bloques de LEGO", 59900m },
                    { new Guid("6374796e-015d-4ca0-b149-543ecab3fab9"), 5, "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", 0, "https://http2.mlstatic.com/D_NQ_NP_918096-MLA74134687068_012024-O.webp", "Serum facial rejuvenecedor", 18290m },
                    { new Guid("cea30e0b-5bab-4023-85c0-7f63be46f457"), 7, "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", 0, "https://http2.mlstatic.com/D_NQ_NP_825422-MLA48732174078_012022-O.webp", "Muñeca interactiva con funciones inteligentes", 47491m },
                    { new Guid("c8fb4cc8-5ef0-4ac2-98b9-b3c76a1217f5"), 7, "Juego de mesa estratégico con tablero plegable y fichas de madera.", 0, "https://http2.mlstatic.com/D_NQ_NP_818301-MLU72732448659_112023-O.webp", "Juego de mesa de Ajedrez", 34400m },
                    { new Guid("582ba12d-3251-479a-8033-174606613b4b"), 8, "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_756320-MLU70634026054_072023-F.webp", "Caja de vinos seleccionados", 187800m },
                    { new Guid("b08b20d7-420b-4795-8033-e159a95ec1d0"), 8, "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", 17, "https://http2.mlstatic.com/D_NQ_NP_890748-MLA73914321216_012024-O.webp", "Cesta de frutas frescas de temporada", 29682m },
                    { new Guid("60fe661f-c4a2-4c9b-aff4-9640bfcdf83a"), 8, "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", 0, "https://http2.mlstatic.com/D_NQ_NP_745130-MLA51091920365_082022-O.webp", "Set de gourmet de chocolates belgas", 4360m },
                    { new Guid("64161d03-8eb7-457a-a2b7-2dde19b05fae"), 8, "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", 7, "https://http2.mlstatic.com/D_NQ_NP_773299-MLU72576428368_112023-O.webp", "Cafetera espresso automática", 241590m },
                    { new Guid("3213612f-44cd-4858-8943-0ab15be56220"), 9, "Bestseller del New York Times en formato papel o digital.", 0, "https://http2.mlstatic.com/D_NQ_NP_737839-MLA52392671527_112022-O.webp", "Bestseller del New York Times", 15822m },
                    { new Guid("d495ee08-91f8-4293-9ecb-b7037bf18d79"), 9, "Colección de clásicos de la literatura mundial en edición especial.", 6, "https://http2.mlstatic.com/D_NQ_NP_869243-MLU74994926858_032024-O.webp", "Colección de clásicos de la literatura mundial", 17000m },
                    { new Guid("48630c2c-6936-4057-a0d3-d6ac00502f7b"), 7, "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", 0, "https://http2.mlstatic.com/D_NQ_NP_681463-MLU72607866767_102023-O.webp", "Rompecabezas de 1000 piezas", 29989m },
                    { new Guid("fcc6e3ed-3f2f-4c53-a109-d3d207455cbd"), 5, "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", 0, "https://http2.mlstatic.com/D_NQ_NP_870569-MLA74827280389_022024-O.webp", "Máquina de afeitar eléctrica de precisión", 36827m },
                    { new Guid("071d1a12-bfd8-49f2-bb35-95eef198f7e3"), 5, "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", 28, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Set de maquillaje profesional", 39528m },
                    { new Guid("d7f3a4ad-f41d-45b1-97c1-e51901ec3f45"), 4, "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", 5, "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp", "Juego de cuchillos de cocina de alta calidad", 35983m },
                    { new Guid("dc27eb9a-8ff4-4417-bbdf-9da805030158"), 1, "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", 61, "https://http2.mlstatic.com/D_NQ_NP_745773-MLA47575105862_092021-O.webp", "Licuadora de alta potencia", 42500m },
                    { new Guid("a4cd6443-fd58-4e72-85e4-8b949c0d5632"), 1, "Horno eléctrico de convección con capacidad de XX litros y control digital.", 9, "https://http2.mlstatic.com/D_NQ_NP_700777-MLU75436781292_042024-O.webp", "Horno eléctrico de convección", 169999m },
                    { new Guid("89141ddc-7b52-4b61-a506-06116a9a19df"), 1, "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", 43, "https://http2.mlstatic.com/D_NQ_NP_678901-MLU75358482641_032024-O.webp", "Aspiradora robotizada", 70705m },
                    { new Guid("1c82243f-1515-44a8-bb00-126356b7c33d"), 2, "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", 0, "https://http2.mlstatic.com/D_NQ_NP_816025-MLU72748491987_112023-O.webp", "Smartphone de última generación", 1900000m },
                    { new Guid("c0459735-00b5-42e8-82f8-c152bc18267a"), 2, "Inflador De Neumáticos Portátil X8", 0, "https://http2.mlstatic.com/D_NQ_NP_667807-MLU72649504918_112023-O.webp", "Inflador Portátil ultraligero", 400000m },
                    { new Guid("8fe8a9b0-fcdc-41ea-86f4-cb6a40111c8f"), 2, "Camara Digital Mirrorless Sony Alpha A6100 4k Wifi Sel1650.", 0, "https://http2.mlstatic.com/D_NQ_NP_659460-MLU72646998907_112023-O.webp", "Cámara digital réflex Sony", 1069000m },
                    { new Guid("149007c9-c929-46f7-8d96-e428478c7dd9"), 2, "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_796079-MLU75556122361_042024-F.webp", "Smart TV de 55 pulgadas", 734999m },
                    { new Guid("f3ff2551-4fe4-491f-bd03-80386f901169"), 2, "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", 0, "https://http2.mlstatic.com/D_NQ_NP_938092-MLA45480677826_042021-O.webp", "Auriculares inalámbricos con cancelación de ruido", 6000m },
                    { new Guid("3f1ad266-6e92-486a-94ed-5b7298e4b6b7"), 2, "Sony PlayStation 5 825GB God of War Ragnarok Bundle color blanco y negro.", 11, "https://http2.mlstatic.com/D_NQ_NP_700033-MLA69689802995_052023-O.webp", "Sony Playstation 5", 1199999m },
                    { new Guid("8f07ebeb-34b2-4b5c-9cb1-e8a70d763703"), 3, "Acolchado edredón 2 plazas y 1/2 (2 plazas y media) liso reversible Abrigado invierno.", 7, "https://http2.mlstatic.com/D_NQ_NP_748192-MLA53582903699_022023-O.webp", "Acolchados Lisos 2 1/2 Plazas Reversible", 31243m },
                    { new Guid("73fb8c48-b1d5-46cb-a189-0ed93742de8d"), 3, "Cartera Cuero Genuino Reptil Bolso Mochila Mujer Cierre.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_869901-MLA54619063288_032023-F.webp", "Bolso de cuero genuino", 95000m },
                    { new Guid("cb945498-8f0f-4bd7-9c41-86f2560b6bcd"), 3, "Anteojos de sol polarizados Vulk Reporter en color sblk/s10.", 20, "https://http2.mlstatic.com/D_NQ_NP_604456-MLA48170692330_112021-O.webp", "Lente De Sol Vulk", 64800m },
                    { new Guid("92e22039-4e36-4885-b501-017892cad354"), 3, "Smartwatch Reloj Inteligente Dt N0.1 Dt3 Mate Doble Malla.", 13, "https://http2.mlstatic.com/D_NQ_NP_2X_748519-MLA72356877039_102023-F.webp", "Reloj inteligente elegante", 75950m },
                    { new Guid("d70b5144-7020-45f4-b973-868162580773"), 3, "Zapatillas Puma Caven 2.0 Blanca", 0, "https://http2.mlstatic.com/D_NQ_NP_994477-MLA74957384571_032024-O.webp", "Zapatillas deportivas de moda", 84999m },
                    { new Guid("2aef7a24-99e4-4484-ac11-1af23295eef5"), 4, "Juego De Sabanas Queen 400hilos 100% Algodon.", 25, "https://http2.mlstatic.com/D_NQ_NP_829765-MLA73477087898_122023-O.webp", "Juego de sábanas de algodón egipcio", 85265m },
                    { new Guid("bbd83a7d-17ad-4f57-a4cc-44c94aa63a48"), 4, "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", 5, "https://http2.mlstatic.com/D_NQ_NP_814774-MLA73709732208_012024-O.webp", "Jarrón de cerámica artesanal", 27550m },
                    { new Guid("d25f8def-9da1-4e7e-b9e9-b529d0f42ade"), 4, "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_929599-MLA54852993202_042023-F.webp", "Lámpara de pie moderna", 85050m },
                    { new Guid("7a7cc0a3-9ab7-4d32-9871-f878d897d422"), 9, "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", 0, "https://http2.mlstatic.com/D_NQ_NP_789389-MLA42259351508_062020-O.webp", "Atlas geográfico interactivo", 16980m },
                    { new Guid("ec796883-ce2e-4176-8343-764c0172c373"), 9, "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_924058-MLA50987231299_082022-F.webp", "Kit de experimentos científicos para niños", 27900m }
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
