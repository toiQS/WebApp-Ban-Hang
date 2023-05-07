using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.ProductInfos
{
    public class ProductInfoServices : IProductInfoServices
    {
        private ApplicationDbContext _context;
        public ProductInfoServices(ApplicationDbContext context)
        {
              _context = context;
        }
        public IEnumerable<ProductInfo> ViewAll()
        {
            return _context.ProductInfo.ToList();
        }
        public ProductInfo FindById(int id)
        {
            return _context.ProductInfo.Where(x => x.Info_ID == id).FirstOrDefault();
        }
        public async Task CreateAsSync(ProductInfo info)
        {
            _context.Add(info);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(ProductInfo info)
        {
            _context.Update(info);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
            var info = FindById(id);
            _context.Update(info);
            await _context.SaveChangesAsync();
        }
    }
}
