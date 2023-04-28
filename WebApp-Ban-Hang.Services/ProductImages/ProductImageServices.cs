using Microsoft.AspNetCore.Mvc.Filters;
using WebApp_Ban_Hang.Presistence;
using WebApp_Ban_Hang.Entity;


namespace WebApp_Ban_Hang.Services.ProductImages
{
    public class ProductImageServices
    {
        private ApplicationDbContext _context;
        public ProductImageServices(ApplicationDbContext context)
        {
            _context = context;
        }
         public IEnumerable<ProductImage> ViewAll()
        {
            return _context.ProductImage.ToList();
        }
        public ProductImage FindById(int id)
        {
            return _context.ProductImage.Where(x => x.ImageID == id).FirstOrDefault();
        }
        public async Task CreateAsSync(ProductImage images)
        {
            _context.Add(images);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(ProductImage images)
        {
            _context.Update(images);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
            var images = FindById(id);
            _context.Update(images);
            await _context.SaveChangesAsync();
        }
    }
}
