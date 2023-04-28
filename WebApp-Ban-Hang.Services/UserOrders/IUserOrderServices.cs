﻿using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.UserOrders
{
    public interface IUserOrderServices
    {
        IEnumerable<UserOrder> ViewAll();
        UserOrder FindById(int id);
        Task CreateAsSync(UserOrder userOrder);
        Task UpdateAsSync(UserOrder userOrder);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);

    }
}
