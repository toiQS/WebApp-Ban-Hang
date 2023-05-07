using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.UserDetails
{
    public interface IUserDetailsServices
    {
        IEnumerable<UserDetail> ViewAll();
        UserDetail FindById(int id);
        Task CreateAsSync (UserDetail userDetail);
        Task DeleteById(int id);
        Task UpdateAsSync (UserDetail userDetail);
        Task UpdateById(int id);
    }
}
