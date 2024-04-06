using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            new Product { ProductId = Guid.NewGuid(), Name = "Lavadora de carga frontal", Descripcion = "Lavadora de carga frontal con capacidad XX kg y múltiples programas de lavado.", Price = 8999, CategoryId = 1, Discount = 0, Url = "https://www.ejemplo.com/lavadora-de-carga-frontal" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Licuadora de alta potencia", Descripcion = "Licuadora de alta potencia con motor de XXXW y cuchillas de acero inoxidable.", Price = 1499, CategoryId = 1, Discount = 50, Url = "https://www.ejemplo.com/licuadora-de-alta-potencia" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Horno eléctrico de convección", Descripcion = "Horno eléctrico de convección con capacidad de XX litros y control digital.", Price = 3999, CategoryId = 1, Discount = 100, Url = "https://www.ejemplo.com/horno-electrico-de-conveccion" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Aspiradora robotizada", Descripcion = "Aspiradora robotizada con sistema de mapeo inteligente y succión potente.", Price = 2999, CategoryId = 1, Discount = 0, Url = "https://www.ejemplo.com/aspiradora-robotizada" },

                            // Product y Electrónica
                            new Product { ProductId = Guid.NewGuid(), Name = "Smartphone de última generación", Descripcion = "Smartphone de última generación con pantalla XX pulgadas y cámara de XXMP.", Price = 12999, CategoryId = 2, Discount = 20, Url = "https://www.ejemplo.com/smartphone-de-ultima-generacion" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Portátil ultraligero", Descripcion = "Portátil ultraligero con procesador XXX y memoria RAM de XXGB.", Price = 8999, CategoryId = 2, Discount = 200, Url = "https://www.ejemplo.com/portatil-ultraligero" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Cámara digital réflex", Descripcion = "Cámara digital réflex con sensor de XXMP y grabación de video en XXX.", Price = 4999, CategoryId = 2, Discount = 0, Url = "https://www.ejemplo.com/camara-digital-reflex" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Smart TV de 55 pulgadas", Descripcion = "Smart TV de 55 pulgadas con resolución 4K y sistema operativo XXX.", Price = 18999, CategoryId = 2, Discount = 70, Url = "https://www.ejemplo.com/smart-tv-de-55-pulgadas" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Auriculares inalámbricos con cancelación de ruido", Descripcion = "Auriculares inalámbricos con cancelación de ruido y batería de larga duración.", Price = 2499, CategoryId = 2, Discount = 0, Url = "https://www.ejemplo.com/auriculares-inalambricos" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Consola de videojuegos de nueva generación", Descripcion = "Consola de videojuegos de nueva generación con procesador XXX y gráficos de alta calidad.", Price = 21999, CategoryId = 2, Discount = 1500, Url = "https://www.ejemplo.com/consola-de-videojuegos" },

                            // Moda y Accesorios
                            new Product { ProductId = Guid.NewGuid(), Name = "Abrigo de invierno acolchado", Descripcion = "Abrigo de invierno acolchado con capucha y bolsillos con cierre.", Price = 3999, CategoryId = 3, Discount = 0, Url = "https://www.ejemplo.com/abrigo-de-invierno-acolchado" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Bolso de cuero genuino", Descripcion = "Bolso de cuero genuino con compartimentos interiores y correa ajustable.", Price = 2999, CategoryId = 3, Discount = 0, Url = "https://www.ejemplo.com/bolso-de-cuero-genuino" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Gafas de sol de diseño", Descripcion = "Gafas de sol de diseño con montura de metal y lentes polarizadas.", Price = 1499, CategoryId = 3, Discount = 100, Url = "https://www.ejemplo.com/gafas-de-sol-de-diseno" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Reloj inteligente elegante", Descripcion = "Reloj inteligente elegante con pantalla táctil y seguimiento de actividad.", Price = 2499, CategoryId = 3, Discount = 0, Url = "https://www.ejemplo.com/reloj-inteligente-elegante" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Zapatillas deportivas de moda", Descripcion = "Zapatillas deportivas de moda con suela de goma antideslizante y diseño ergonómico.", Price = 1999, CategoryId = 3, Discount = 150, Url = "https://www.ejemplo.com/zapatillas-deportivas-de-moda" },

                            // Hogar y Decoración
                            new Product { ProductId = Guid.NewGuid(), Name = "Juego de sábanas de algodón egipcio", Descripcion = "Juego de sábanas de algodón egipcio con funda de almohada y sábana bajera.", Price = 1599, CategoryId = 4, Discount = 0, Url = "https://www.ejemplo.com/juego-de-sabanas-de-algodon-egipcio" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Jarrón de cerámica artesanal", Descripcion = "Jarrón de cerámica artesanal con acabado brillante y diseño moderno.", Price = 899, CategoryId = 4, Discount = 5, Url = "https://www.ejemplo.com/jarron-de-ceramica-artesanal" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Lámpara de pie moderna", Descripcion = "Lámpara de pie moderna con base de acero inoxidable y pantalla ajustable.", Price = 2999, CategoryId = 4, Discount = 8, Url = "https://www.ejemplo.com/lampara-de-pie-moderna" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Juego de cuchillos de cocina de alta calidad", Descripcion = "Juego de cuchillos de cocina de alta calidad con mango ergonómico y hoja de acero inoxidable.", Price = 2499, CategoryId = 4, Discount = 100, Url = "https://www.ejemplo.com/juego-de-cuchillos-de-cocina" },

                            // Salud y Belleza
                            new Product { ProductId = Guid.NewGuid(), Name = "Set de maquillaje profesional", Descripcion = "Set de maquillaje profesional con paleta de sombras, labiales y brochas.", Price = 1999, CategoryId = 5, Discount = 0, Url = "https://www.ejemplo.com/set-de-maquillaje-profesional" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Máquina de afeitar eléctrica de precisión", Descripcion = "Máquina de afeitar eléctrica de precisión con cabezales flotantes y recortador de precisión.", Price = 1499, CategoryId = 5, Discount = 100, Url = "https://www.ejemplo.com/maquina-de-afeitar-electrica" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Serum facial rejuvenecedor", Descripcion = "Serum facial rejuvenecedor con ácido hialurónico y vitaminas antioxidantes.", Price = 799, CategoryId = 5, Discount = 0, Url = "https://www.ejemplo.com/serum-facial-rejuvenecedor" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Cepillo de dientes eléctrico recargable", Descripcion = "Cepillo de dientes eléctrico recargable con temporizador y cabezales intercambiables.", Price = 699, CategoryId = 5, Discount = 50, Url = "https://www.ejemplo.com/cepillo-de-dientes-electrico" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Kit de manicura y pedicura", Descripcion = "Kit de manicura y pedicura con lima, cortaúñas y herramientas de precisión.", Price = 499, CategoryId = 5, Discount = 0, Url = "https://www.ejemplo.com/kit-de-manicura-y-pedicura" },

                            // Deportes y Ocio
                            new Product { ProductId = Guid.NewGuid(), Name = "Bicicleta de montaña todo terreno", Descripcion = "Bicicleta de montaña todo terreno con cuadro de aluminio y cambios Shimano.", Price = 6999, CategoryId = 6, Discount = 0, Url = "https://www.ejemplo.com/bicicleta-de-montana" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Tienda de campaña para 4 personas", Descripcion = "Tienda de campaña para 4 personas con doble techo y sistema de ventilación.", Price = 1999, CategoryId = 6, Discount = 60, Url = "https://www.ejemplo.com/tienda-de-campana" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Raquetas de tenis de alta gama", Descripcion = "Raquetas de tenis de alta gama con tecnología de absorción de impactos y empuñadura ergonómica.", Price = 2999, CategoryId = 6, Discount = 0, Url = "https://www.ejemplo.com/raquetas-de-tenis" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Balón de fútbol oficial", Descripcion = "Balón de fútbol oficial con diseño aerodinámico y cubierta de cuero sintético.", Price = 799, CategoryId = 6, Discount = 50, Url = "https://www.ejemplo.com/balon-de-futbol-oficial" },

                            // Juguetes y Juegos
                            new Product { ProductId = Guid.NewGuid(), Name = "Set de construcción de bloques de LEGO", Descripcion = "Set de construcción de bloques de LEGO con XX piezas y figuras coleccionables.", Price = 1499, CategoryId = 7, Discount = 40, Url = "https://www.ejemplo.com/set-de-construccion-de-lego" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Muñeca interactiva con funciones inteligentes", Descripcion = "Muñeca interactiva con funciones inteligentes y accesorios intercambiables.", Price = 1999, CategoryId = 7, Discount = 0, Url = "https://www.ejemplo.com/muneca-interactiva" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Rompecabezas de 1000 piezas", Descripcion = "Rompecabezas de 1000 piezas con imagen de paisaje panorámico.", Price = 999, CategoryId = 7, Discount = 50, Url = "https://www.ejemplo.com/rompecabezas-de-1000-piezas" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Juego de mesa estratégico", Descripcion = "Juego de mesa estratégico con tablero plegable y fichas numeradas.", Price = 1499, CategoryId = 7, Discount = 0, Url = "https://www.ejemplo.com/juego-de-mesa-estrategico" },

                            // Alimentos y Bebidas
                            new Product { ProductId = Guid.NewGuid(), Name = "Caja de vinos seleccionados", Descripcion = "Caja de vinos seleccionados con variedad de cepas y añejamiento mínimo de X años.", Price = 2999, CategoryId = 8, Discount = 0, Url = "https://www.ejemplo.com/caja-de-vinos-seleccionados" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Cesta de frutas frescas de temporada", Descripcion = "Cesta de frutas frescas de temporada con selección de frutas maduras y jugosas.", Price = 799, CategoryId = 8, Discount = 20, Url = "https://www.ejemplo.com/cesta-de-frutas-frescas" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Set de gourmet de chocolates belgas", Descripcion = "Set de gourmet de chocolates belgas con variedad de sabores y presentación elegante.", Price = 1499, CategoryId = 8, Discount = 0, Url = "https://www.ejemplo.com/set-de-chocolates-belgas" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Cafetera espresso automática", Descripcion = "Cafetera espresso automática con sistema de preparación rápida y vaporizador integrado.", Price = 3999, CategoryId = 8, Discount = 10, Url = "https://www.ejemplo.com/cafetera-espresso-automatica" },

                            // Libros y Material Educativo
                            new Product { ProductId = Guid.NewGuid(), Name = "Bestseller del New York Times", Descripcion = "Bestseller del New York Times en formato papel o digital.", Price = 599, CategoryId = 9, Discount = 0, Url = "https://www.ejemplo.com/bestseller-del-new-york-times" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Colección de clásicos de la literatura mundial", Descripcion = "Colección de clásicos de la literatura mundial en edición especial.", Price = 1999, CategoryId = 9, Discount = 6, Url = "https://www.ejemplo.com/coleccion-de-clasicos-literarios" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Atlas geográfico interactivo", Descripcion = "Atlas geográfico interactivo con mapas detallados y funciones multimedia.", Price = 999, CategoryId = 9, Discount = 0, Url = "https://www.ejemplo.com/atlas-geografico-interactivo" },
                            new Product { ProductId = Guid.NewGuid(), Name = "Kit de experimentos científicos para niños", Descripcion = "Kit de experimentos científicos para niños con materiales seguros y guía de actividades.", Price = 799, CategoryId = 9, Discount = 90, Url = "https://www.ejemplo.com/kit-de-experimentos-cientificos" }
         );


        }

    }
}