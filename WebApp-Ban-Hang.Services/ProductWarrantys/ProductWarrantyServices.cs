using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.ProductWarrantys
{
    public class ProductWarrantyServices : IProductWarrantyServices
    {
        private ApplicationDbContext _context;
        public ProductWarrantyServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductWarranty> ViewAll()
        {
            return _context.ProductWarranty.ToList();
        }
        public ProductWarranty FindById(string id)
        {
            return _context.ProductWarranty.Where(x => x.Product_ID == id).FirstOrDefault();
        }
        public async Task CreateAsSync(ProductWarranty product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(string id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(ProductWarranty product)
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
