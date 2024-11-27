using MiProyectoSOAP.Contrato;
using MiProyectoEntities;
using System.Collections.Generic;
using System.Linq;
using MiProyectoVDL.Data;

namespace MiProyectoSOAP.VDL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.categoryid == id);
        }

        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category UpdateCategory(int id, Category category)
        {
            var existingCategory = _context.Categories.Find(id);
            if (existingCategory == null) return null;

            existingCategory.categoryname = category.categoryname;
            existingCategory.description = category.description;

            _context.SaveChanges();
            return existingCategory;
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}