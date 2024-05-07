using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionVentasTP1.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(100)]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { set; get; }


    }
}
