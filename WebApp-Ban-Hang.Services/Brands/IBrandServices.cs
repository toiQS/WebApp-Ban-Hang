using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Brands
{
    public interface IBrandServices
    {
        IEnumerable<Brand> ViewAll();
        Brand FindByName(string id);
        Task CreateAsSync(Brand brand);
        Task UpdateAsSync(Brand brand);
        Task DeleteById(string id);
        Task CreateById(string id);
    }
}
