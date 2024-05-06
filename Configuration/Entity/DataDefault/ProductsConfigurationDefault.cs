using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionVentasTP1.Model;
using System;

namespace SistemaGestionVentas.Entity
{
    class ProductsConfigurationDefault : IEntityTypeConfiguration<Product>
    {
        // Cargar productos
        public void Configure(EntityTypeBuilder<Product> entityBuilder)
        {

            // Cargar productos
            entityBuilder.HasData(
                               // Electrodomésticos
                               new Product { ProductId = Guid.NewGuid(), Name = "Lavadora de carga frontal", Descripcion = "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", Price = 579999, Category = 1, Discount = 25, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_818355-MLU74163648935_012024-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Licuadora de alta potencia", Descripcion = "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", Price = 42500, Category = 1, Discount = 61, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_745773-MLA47575105862_092021-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Horno eléctrico de convección", Descripcion = "Horno eléctrico de convección con capacidad de XX litros y control digital.", Price = 169999, Category = 1, Discount = 9, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_700777-MLU75436781292_042024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Aspiradora robotizada", Descripcion = "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", Price = 70705, Category = 1, Discount = 43, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_678901-MLU75358482641_032024-O.webp" },

                               // Product y Electrónica
                               new Product { ProductId = Guid.NewGuid(), Name = "Smartphone de última generación", Descripcion = "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", Price = 1900000, Category = 2, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_816025-MLU72748491987_112023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Inflador Portátil ultraligero", Descripcion = "Inflador De Neumáticos Portátil X8", Price = 400000, Category = 2, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_667807-MLU72649504918_112023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Cámara digital réflex Sony", Descripcion = "Camara Digital Mirrorless Sony Alpha A6100 4k Wifi Sel1650.", Price = 1069000, Category = 2, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_659460-MLU72646998907_112023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Smart TV de 55 pulgadas", Descripcion = "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", Price = 734999, Category = 2, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_796079-MLU75556122361_042024-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Auriculares inalámbricos con cancelación de ruido", Descripcion = "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", Price = 6000, Category = 2, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_938092-MLA45480677826_042021-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Sony Playstation 5", Descripcion = "Sony PlayStation 5 825GB God of War Ragnarok Bundle color blanco y negro.", Price = 1199999, Category = 2, Discount = 11, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_700033-MLA69689802995_052023-O.webp" },

                               // Moda y Accesorios
                               new Product { ProductId = Guid.NewGuid(), Name = "Acolchados Lisos 2 1/2 Plazas Reversible", Descripcion = "Acolchado edredón 2 plazas y 1/2 (2 plazas y media) liso reversible Abrigado invierno.", Price = 31243, Category = 3, Discount = 7, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_748192-MLA53582903699_022023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Bolso de cuero genuino", Descripcion = "Cartera Cuero Genuino Reptil Bolso Mochila Mujer Cierre.", Price = 95000, Category = 3, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_869901-MLA54619063288_032023-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Lente De Sol Vulk", Descripcion = "Anteojos de sol polarizados Vulk Reporter en color sblk/s10.", Price = 64800, Category = 3, Discount = 20, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_604456-MLA48170692330_112021-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Reloj inteligente elegante", Descripcion = "Smartwatch Reloj Inteligente Dt N0.1 Dt3 Mate Doble Malla.", Price = 75950, Category = 3, Discount = 13, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_748519-MLA72356877039_102023-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Zapatillas deportivas de moda", Descripcion = "Zapatillas Puma Caven 2.0 Blanca", Price = 84999, Category = 3, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_994477-MLA74957384571_032024-O.webp" },

                               // Hogar y Decoración
                               new Product { ProductId = Guid.NewGuid(), Name = "Juego de sábanas de algodón egipcio", Descripcion = "Juego De Sabanas Queen 400hilos 100% Algodon.", Price = 85265, Category = 4, Discount = 25, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_829765-MLA73477087898_122023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Jarrón de cerámica artesanal", Descripcion = "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", Price = 27550, Category = 4, Discount = 5, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_814774-MLA73709732208_012024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Lámpara de pie moderna", Descripcion = "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", Price = 85050, Category = 4, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_929599-MLA54852993202_042023-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Juego de cuchillos de cocina de alta calidad", Descripcion = "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", Price = 35983, Category = 4, Discount = 5, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp" },

                               // Salud y Belleza
                               new Product { ProductId = Guid.NewGuid(), Name = "Set de maquillaje profesional", Descripcion = "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", Price = 39528, Category = 5, Discount = 28, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_910185-MLA50009263187_052022-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Máquina de afeitar eléctrica de precisión", Descripcion = "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", Price = 36827, Category = 5, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_870569-MLA74827280389_022024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Serum facial rejuvenecedor", Descripcion = "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", Price = 18290, Category = 5, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_918096-MLA74134687068_012024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Cepillo de dientes eléctrico recargable", Descripcion = "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", Price = 92369, Category = 5, Discount = 24, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_999356-MLU74959566341_032024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Kit de manicura y pedicura", Descripcion = "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", Price = 4799, Category = 5, Discount = 60, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_864195-MLU75358350003_032024-F.webp" },

                               // Deportes y Ocio
                               new Product { ProductId = Guid.NewGuid(), Name = "Bicicleta de montaña todo terreno", Descripcion = "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", Price = 283226, Category = 6, Discount = 15, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_819576-MLU75591901591_042024-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Tienda de campaña para 4 personas", Descripcion = "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", Price = 150000, Category = 6, Discount = 25, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_853020-MLU74646955786_022024-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Raquetas de tenis de alta gama", Descripcion = "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", Price = 246900, Category = 6, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_674284-MLU74132469460_012024-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Balón de fútbol oficial", Descripcion = "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", Price = 62200, Category = 6, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_981675-MLU75436946294_042024-O.webp" },

                               // Juguetes y Juegos
                               new Product { ProductId = Guid.NewGuid(), Name = "Set de construcción de bloques de LEGO", Descripcion = "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", Price = 59900, Category = 7, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_688616-MLA70719693003_072023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Muñeca interactiva con funciones inteligentes", Descripcion = "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", Price = 47491, Category = 7, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_825422-MLA48732174078_012022-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Rompecabezas de 1000 piezas", Descripcion = "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", Price = 29989, Category = 7, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_681463-MLU72607866767_102023-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Juego de mesa de Ajedrez", Descripcion = "Juego de mesa estratégico con tablero plegable y fichas de madera.", Price = 34400, Category = 7, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_818301-MLU72732448659_112023-O.webp" },

                               // Alimentos y Bebidas
                               new Product { ProductId = Guid.NewGuid(), Name = "Caja de vinos seleccionados", Descripcion = "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", Price = 187800, Category = 8, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_756320-MLU70634026054_072023-F.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Cesta de frutas frescas de temporada", Descripcion = "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", Price = 29682, Category = 8, Discount = 17, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_890748-MLA73914321216_012024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Set de gourmet de chocolates belgas", Descripcion = "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", Price = 4360, Category = 8, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_745130-MLA51091920365_082022-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Cafetera espresso automática", Descripcion = "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", Price = 241590, Category = 8, Discount = 7, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_773299-MLU72576428368_112023-O.webp" },

                               // Libros y Material Educativo
                               new Product { ProductId = Guid.NewGuid(), Name = "Bestseller del New York Times", Descripcion = "Bestseller del New York Times en formato papel o digital.", Price = 15822, Category = 9, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_737839-MLA52392671527_112022-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Colección de clásicos de la literatura mundial", Descripcion = "Colección de clásicos de la literatura mundial en edición especial.", Price = 17000, Category = 9, Discount = 6, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_869243-MLU74994926858_032024-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Atlas geográfico interactivo", Descripcion = "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", Price = 16980, Category = 9, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_789389-MLA42259351508_062020-O.webp" },
                               new Product { ProductId = Guid.NewGuid(), Name = "Kit de experimentos científicos para niños", Descripcion = "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", Price = 27900, Category = 9, Discount = 0, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_924058-MLA50987231299_082022-F.webp" }
            );


        }

    }
}