using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.Categorys
{
    public class CategoryServices
    {
        private ApplicationDbContext _context;
        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category FindById(int id)
        {
            return _context.Category.Where(x => x.CategoryID == id).FirstOrDefault();
        }
        public IEnumerable<Category> ViewAll()
        {
            return _context.Category.ToList();
        }
        public async Task CreateAsSync(Category Category)
        {
            _context.Add(Category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
            var Category = FindById(id);
            _context.Update(Category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(Category Category)
        {
            _context.Update(Category);
            await _context.SaveChangesAsync();
        }
    }
}
}
