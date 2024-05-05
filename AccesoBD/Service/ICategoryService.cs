using SistemaGestionVentasTP1.Model;
using System.Collections.Generic;

namespace SistemaGestionVentas.Service
{
    public interface ICategoryService
    {
        void AddCategory(Category Product);
        List<Category> GetAllCategories();
    }
}
