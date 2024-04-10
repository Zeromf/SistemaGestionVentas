using SistemaGestionVentas.Contexto;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Service
{
    public class CategoryService: ICategoryService
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
            _contextoDB.Categories.Add(category);

            _contextoDB.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _contextoDB.Categories.Select(x => x).ToList();

        }


    }
}
