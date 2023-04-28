using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.Products
{
    public class ProductServices
    {
        private ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> ViewAll()
        {
            return _context.Product.ToList();
        }
        public async Task CreateAsSync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsSync(string name)
        {
            _context.Remove(name);
            await _context.SaveChangesAsync();
        }
        public Product FindByName(string name)
        {
            return _context.Product.Where(x => x.Product_Line == name).FirstOrDefault();
        }
        public async Task UpdateAsSync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateByName(string name)
        {
            var product = FindByName(name);
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
