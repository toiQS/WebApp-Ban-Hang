 using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Presistence;

namespace WebApp_Ban_Hang.Services.UserDetails
{
    public class UserDetailServices : IUserDetailsServices
    {
        private ApplicationDbContext _context;
        public UserDetailServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<UserDetail> ViewAll()
        {
            return _context.UserDetail.ToList();
        }
        public UserDetail FindById(int id)
        {
            return _context.UserDetail.Where(x => x.UserDetailId == id).FirstOrDefault();
        }
        public async Task CreateAsSync(UserDetail userDetail)
        {
            _context.Add(userDetail);
            await _context.SaveChangesAsync(); 
        }
        public async Task DeleteById(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsSync(UserDetail userDetail)
        {
            _context.Update(userDetail);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateById(int id)
        {
           var UserDetail = FindById(id);
            if (UserDetail != null)
            {
                _context.Update(UserDetail);
            }
            await _context.SaveChangesAsync();
        }
    }
}
