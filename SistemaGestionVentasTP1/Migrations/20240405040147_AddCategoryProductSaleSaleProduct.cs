using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestionVentas.Migrations
{
    public partial class AddCategoryProductSaleSaleProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
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
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProducts",
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
                    table.PrimaryKey("PK_SaleProducts", x => x.ShoppingCardId);
                    table.ForeignKey(
                        name: "FK_SaleProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProducts_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
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
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Descripcion", "Discount", "Name", "Price", "Url" },
                values: new object[,]
                {
                    { new Guid("67ba7298-586d-4b44-b01e-f6be54eafe83"), 1, "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", 0, "Lavadora de carga frontal", 8999m, "https://www.ejemplo.com/lavadora-de-carga-frontal" },
                    { new Guid("cb8571c1-2fe7-4aff-a34f-3b2d86a856d0"), 5, "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", 50, "Cepillo de dientes eléctrico recargable", 699m, "https://www.ejemplo.com/cepillo-de-dientes-electrico" },
                    { new Guid("45342839-5d97-4a9f-8835-b30468fe5b81"), 5, "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", 0, "Kit de manicura y pedicura", 499m, "https://www.ejemplo.com/kit-de-manicura-y-pedicura" },
                    { new Guid("c53f1139-3408-4423-997b-2ad0a9b71b64"), 6, "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", 0, "Bicicleta de montaña todo terreno", 6999m, "https://www.ejemplo.com/bicicleta-de-montana" },
                    { new Guid("827e4de1-c500-44d6-a32f-094f3a848f8d"), 6, "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", 60, "Tienda de campaña para 4 personas", 1999m, "https://www.ejemplo.com/tienda-de-campana" },
                    { new Guid("573b83db-ec27-4694-893c-fc22a24a3cb6"), 6, "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", 0, "Raquetas de tenis de alta gama", 2999m, "https://www.ejemplo.com/raquetas-de-tenis" },
                    { new Guid("2dd7682b-f6b6-4d68-9355-b5e72dafafd8"), 6, "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", 50, "Balón de fútbol oficial", 799m, "https://www.ejemplo.com/balon-de-futbol-oficial" },
                    { new Guid("9152d0f4-a8ec-4737-9e72-0a70fbc9dfbd"), 7, "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", 40, "Set de construcción de bloques de LEGO", 1499m, "https://www.ejemplo.com/set-de-construccion-de-lego" },
                    { new Guid("181b3b36-e800-44c4-b468-f65554deb83d"), 5, "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", 0, "Serum facial rejuvenecedor", 799m, "https://www.ejemplo.com/serum-facial-rejuvenecedor" },
                    { new Guid("9b0c5347-966e-4b44-8cc9-71e8a80e493a"), 7, "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", 0, "Muñeca interactiva con funciones inteligentes", 1999m, "https://www.ejemplo.com/muneca-interactiva" },
                    { new Guid("76e793ce-1a9d-4cba-8cd9-195db89cc06c"), 7, "Juego de mesa estratégico con tablero plegable y fichas numeradas.", 0, "Juego de mesa estratégico", 1499m, "https://www.ejemplo.com/juego-de-mesa-estrategico" },
                    { new Guid("eee12635-5f72-402e-bd78-6281bc7cdcf7"), 8, "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", 0, "Caja de vinos seleccionados", 2999m, "https://www.ejemplo.com/caja-de-vinos-seleccionados" },
                    { new Guid("a4182d21-ba9b-4ef3-9755-95eac5bd0e7c"), 8, "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", 20, "Cesta de frutas frescas de temporada", 799m, "https://www.ejemplo.com/cesta-de-frutas-frescas" },
                    { new Guid("4f3d8527-adf4-42d8-8f03-ebde390cdc0b"), 8, "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", 0, "Set de gourmet de chocolates belgas", 1499m, "https://www.ejemplo.com/set-de-chocolates-belgas" },
                    { new Guid("731a2ea3-bd8a-48de-8130-55b0d56858a2"), 8, "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", 10, "Cafetera espresso automática", 3999m, "https://www.ejemplo.com/cafetera-espresso-automatica" },
                    { new Guid("59907b68-cdd4-4f71-af6d-a947481d8f8d"), 9, "Bestseller del New York Times en formato papel o digital.", 0, "Bestseller del New York Times", 599m, "https://www.ejemplo.com/bestseller-del-new-york-times" },
                    { new Guid("9279d841-9222-46b2-be71-bc95944dce92"), 9, "Colección de clásicos de la literatura mundial en edición especial.", 6, "Colección de clásicos de la literatura mundial", 1999m, "https://www.ejemplo.com/coleccion-de-clasicos-literarios" },
                    { new Guid("e88130af-1a8e-40f6-8633-e8c96bd78c28"), 7, "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", 50, "Rompecabezas de 1000 piezas", 999m, "https://www.ejemplo.com/rompecabezas-de-1000-piezas" },
                    { new Guid("91db14be-94a3-48e8-a184-d023ce51ab27"), 5, "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", 100, "Máquina de afeitar eléctrica de precisión", 1499m, "https://www.ejemplo.com/maquina-de-afeitar-electrica" },
                    { new Guid("bff20e49-83a8-47ea-becb-8fe42c011ad1"), 5, "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", 0, "Set de maquillaje profesional", 1999m, "https://www.ejemplo.com/set-de-maquillaje-profesional" },
                    { new Guid("471cab60-4cfd-4d0e-aff6-e067ed06d451"), 4, "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", 100, "Juego de cuchillos de cocina de alta calidad", 2499m, "https://www.ejemplo.com/juego-de-cuchillos-de-cocina" },
                    { new Guid("fea71356-a6ce-4ce7-b549-2dfc7208c96e"), 1, "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", 50, "Licuadora de alta potencia", 1499m, "https://www.ejemplo.com/licuadora-de-alta-potencia" },
                    { new Guid("0c5c4f44-eea7-4396-978e-06b18fc2157f"), 1, "Horno eléctrico de convección con capacidad de XX litros y control digital.", 100, "Horno eléctrico de convección", 3999m, "https://www.ejemplo.com/horno-electrico-de-conveccion" },
                    { new Guid("705c788f-b400-4c3a-bc3b-f9123689ae86"), 1, "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", 0, "Aspiradora robotizada", 2999m, "https://www.ejemplo.com/aspiradora-robotizada" },
                    { new Guid("96aad6f6-8bfb-4689-8150-b4d464b2e883"), 2, "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", 20, "Smartphone de última generación", 12999m, "https://www.ejemplo.com/smartphone-de-ultima-generacion" },
                    { new Guid("e3c71253-a6b0-4df5-9113-3b52df052ca0"), 2, "Portátil ultraligero con procesador XXX y memoria RAM de XXGB.", 200, "Portátil ultraligero", 8999m, "https://www.ejemplo.com/portatil-ultraligero" },
                    { new Guid("9c316c8b-c249-40a7-a511-caaee1d5001d"), 2, "Cámara digital réflex con sensor de XXMP y grabación de video en XXX.", 0, "Cámara digital réflex", 4999m, "https://www.ejemplo.com/camara-digital-reflex" },
                    { new Guid("a3ec467e-0912-4997-b47b-13dc98583179"), 2, "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", 70, "Smart TV de 55 pulgadas", 18999m, "https://www.ejemplo.com/smart-tv-de-55-pulgadas" },
                    { new Guid("e9e9869d-48df-4fe7-a05f-585edfc535a5"), 2, "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", 0, "Auriculares inalámbricos con cancelación de ruido", 2499m, "https://www.ejemplo.com/auriculares-inalambricos" },
                    { new Guid("4b82a44a-1123-4ef5-91d2-222971fd363e"), 2, "Consola de videojuegos de nueva generación con procesador XXX y gráficos de alta calidad.", 1500, "Consola de videojuegos de nueva generación", 21999m, "https://www.ejemplo.com/consola-de-videojuegos" },
                    { new Guid("7e3321cb-5648-462e-9d19-5b2200128238"), 3, "Abrigo de invierno acolchado con capucha y bolsillos con cierre.", 0, "Abrigo de invierno acolchado", 3999m, "https://www.ejemplo.com/abrigo-de-invierno-acolchado" },
                    { new Guid("16f6745e-1bc7-4b52-b696-eb8513e20ad2"), 3, "Bolso de cuero genuino con compartimentos interiores y correa ajustable.", 0, "Bolso de cuero genuino", 2999m, "https://www.ejemplo.com/bolso-de-cuero-genuino" },
                    { new Guid("f6eea3e0-64de-4223-8436-def8e0dcfd26"), 3, "Gafas de sol de diseño con montura de metal y lentes polarizadas.", 100, "Gafas de sol de diseño", 1499m, "https://www.ejemplo.com/gafas-de-sol-de-diseno" },
                    { new Guid("1bd67f66-98ec-4fd5-89fc-010a453b4a6a"), 3, "Reloj inteligente elegante con pantalla táctil y seguimiento de actividad.", 0, "Reloj inteligente elegante", 2499m, "https://www.ejemplo.com/reloj-inteligente-elegante" },
                    { new Guid("615c84fb-86a3-4afa-8afe-3cfb6d8e0ea3"), 3, "Zapatillas deportivas de moda con suela de goma antideslizante y diseño ergonómico.", 150, "Zapatillas deportivas de moda", 1999m, "https://www.ejemplo.com/zapatillas-deportivas-de-moda" },
                    { new Guid("d18df0b0-5e4a-41fc-b9f4-c99dd5a27e5c"), 4, "Juego de sábanas de algodón egipcio con funda de almohada y sábana bajera.", 0, "Juego de sábanas de algodón egipcio", 1599m, "https://www.ejemplo.com/juego-de-sabanas-de-algodon-egipcio" },
                    { new Guid("da4a5e4e-cbec-4525-85e0-53626123a6fe"), 4, "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", 5, "Jarrón de cerámica artesanal", 899m, "https://www.ejemplo.com/jarron-de-ceramica-artesanal" },
                    { new Guid("0a1c6348-c2e3-4bb7-9b3a-86af2e0a1831"), 4, "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", 8, "Lámpara de pie moderna", 2999m, "https://www.ejemplo.com/lampara-de-pie-moderna" },
                    { new Guid("fc8c8d04-5cae-41ac-8428-7a91b2be0352"), 9, "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", 0, "Atlas geográfico interactivo", 999m, "https://www.ejemplo.com/atlas-geografico-interactivo" },
                    { new Guid("a8c48524-c08a-4863-bf00-eb7e69611ea0"), 9, "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", 90, "Kit de experimentos científicos para niños", 799m, "https://www.ejemplo.com/kit-de-experimentos-cientificos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_ProductId",
                table: "SaleProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_SaleId",
                table: "SaleProducts",
                column: "SaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
