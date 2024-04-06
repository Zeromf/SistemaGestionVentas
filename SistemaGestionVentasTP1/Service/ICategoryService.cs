using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Service
{
    interface ICategoryService
    {
        void AddCategory(Category Product);
        List<Category> GetAllCategories();
    }
}
