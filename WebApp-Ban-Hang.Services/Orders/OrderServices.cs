using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.Orders
{
    public class OrderServices : IOrderServices
    {
        private ApplicationDbContext _context;
        public OrderServices(ApplicationDbContext context)
        {
               _context= context;   
        }
        public IEnumerable<Order> ViewAll()
        {
            return _context.Order.ToList();
        }
        public Order FindById(int id)
        {
            return _context.Order.Where(x => x.IdUser == id).FirstOrDefault();
        }
        public async Task CreateAsSync(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsSync(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
            var order = FindById(id);
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
