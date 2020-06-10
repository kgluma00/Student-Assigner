using SA.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SA.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(User user);
    }
}
