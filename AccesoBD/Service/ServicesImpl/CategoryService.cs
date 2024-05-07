using SistemaGestionVentas.Contexto;
using SistemaGestionVentasTP1.Model;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionVentas.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IContextDB _contextoDB;

        public CategoryService()
        {
        }
        public CategoryService(IContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }


        public void AddCategory(Category category)
        {
            _contextoDB.Category.Add(category);

            _contextoDB.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _contextoDB.Category.Select(x => x).ToList();

        }


    }
}
