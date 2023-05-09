using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Users
{
    public interface IUserServices
    {
        IEnumerable<User> ViewAll();
        User FindById(int id);
        Task CreateAsSync(User user);
        Task UpdateAsSync(User user);
        Task DeleteAsSync(int id);
        Task UpdateById(int id);
    }
}
