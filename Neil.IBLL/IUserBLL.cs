using System;
using Neil.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Neil.IBLL
{
    public interface IUserBLL
    {
        UserModel Login(int Id);
        Task Running();
    }


}
