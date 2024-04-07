using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentasTP1.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; } 
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Discount { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public IList<SaleProduct> product { get; set; }

    }
}
