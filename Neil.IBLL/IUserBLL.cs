using System;
using Neil.Model;
using System.Threading.Tasks;

namespace Neil.IBLL
{
    public interface IUserBLL
    {
        UserModel Login(int Id);
        Task Running();
    }
}
