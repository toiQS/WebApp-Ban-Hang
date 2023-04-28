using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.UserOrders
{
    public class UserOrderServices
    {
        private ApplicationDbContext _context;
        public UserOrderServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<UserOrder> ViewAll()
        {
            return _context.UserOrder.ToList();
        }
        public UserOrder FindById(int id)
        {
            return _context.UserOrder.Where(x => x.OrderID == id).FirstOrDefault();
        }
        public async Task CreateAsSync(UserOrder userOrder)
        {
            _context.Add(userOrder);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsSync(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(UserOrder userOrder)
        {
            _context.Update(userOrder);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
            var userOrder = FindById(id);
            _context.Update(userOrder);
            await _context.SaveChangesAsync();
        }
    }
}
