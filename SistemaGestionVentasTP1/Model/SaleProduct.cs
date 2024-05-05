using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionVentasTP1.Model
{
    public class SaleProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingCardId { get; set; }
        public int SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public virtual Sale Sale { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }

    }
}
