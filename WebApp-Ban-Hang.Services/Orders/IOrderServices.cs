using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Orders
{
    public interface IOrderServices
    {
        IEnumerable<Order> ViewAll();
        Order FindById(int id);
        Task CreataAsSync(User user);
        Task DeleteAsSync(int id);
        Task UpdateAsSync(User user);
        Task UpdateById(int id);
    }
}
