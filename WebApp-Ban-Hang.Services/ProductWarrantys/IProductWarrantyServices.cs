using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.ProductWarrantys
{
    public interface IProductWarrantyServices
    {
        IEnumerable<ProductWarranty> ViewAll();
        ProductWarranty FindByName(string name);
        Task CreateAsSync(ProductWarranty product);
        Task DeleteByName(string name);
        Task UpdateAsSync(ProductWarranty product);
    }
}
