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
         
        Task CreateAsSync(Product product);
        Task DeleteByName(string name);
        Task UpdateAsSync(Product product);
        Task UpdateByName(string name);
    }
}
