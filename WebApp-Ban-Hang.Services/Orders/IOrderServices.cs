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
        
        Task DeleteAsSync(int id);
        Task UpdateAsSync(Order order);
        Task UpdateById(int id);
        Task CreateAsSync(Order order);
    }
}
