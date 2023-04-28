using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.Brands
{
    public class BrandServices
    {
        private ApplicationDbContext _context;
        public BrandServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Brand FindById(string id)
        {
            return _context.Brand.Where(x => x.BrandId == id).FirstOrDefault();
        }
        public IEnumerable<Brand> ViewAll()
        {
            return _context.Brand.ToList();
        }
        public async Task CreateAsSync(Brand brand)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(string id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(string id)
        {
            var brand = FindById(id);
            _context.Update(brand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(Brand brand)
        {
            _context.Update(brand);
            await _context.SaveChangesAsync();
        }
    }
}
