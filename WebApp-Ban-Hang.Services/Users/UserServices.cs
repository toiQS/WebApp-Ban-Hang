using WebApp_Ban_Hang.Presistence;
using WebApp_Ban_Hang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Ban_Hang.Services.Users
{
    public class UserServices : IUserServices
    {
        public ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> ViewAll()
        {
            return _context.User.ToList();
        }
        public User FindById(int id)
        {
            return _context.User.Where(x => x.IdUser == id).FirstOrDefault() ?? null;
        }
        public async Task CreateAsSync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsSync(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
            var user = FindById(id);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
