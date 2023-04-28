using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.ProductImages
{
    public interface IProductImageServices
    {
        IEnumerable<ProductImage> ViewAll();
        ProductImage FindById(int id);
        Task CreateAsSync(ProductImage image);
        Task DeleteById(int id);
        Task UpdateAsSync(ProductImage image);
        Task UpdateById(int id);
        
    }
}
