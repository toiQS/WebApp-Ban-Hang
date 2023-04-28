using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Products
{
    public  interface IProductServices
    {
        IEnumerable<Product> ViewAll();
        Product FindById(string id);
        Task CreateAsSync(Product product);
        Task DeleteById(string id);
        Task UpdateAsSync(Product product);
        Task UpdateById(string id);
    }
}
