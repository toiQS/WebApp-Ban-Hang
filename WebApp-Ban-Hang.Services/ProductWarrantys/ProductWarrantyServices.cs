using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.ProductWarrantys
{
    public class ProductWarrantyServices
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
    }
}
