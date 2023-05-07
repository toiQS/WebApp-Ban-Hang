using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.Products
{
    public class ProductServices : IProductServices
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
        public async Task DeleteById(string id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public Product FindById(string id)
        {
            return _context.Product.Where(x => x.Product_Line == id).FirstOrDefault();
        }
        public async Task UpdateAsSync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(string id)
        {
            var product = FindById(id);
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
