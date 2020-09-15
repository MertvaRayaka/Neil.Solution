using Neil.Container;
using Neil.IBLL;
using Neil.IDAL;
using Neil.IService;
using Neil.Model;
using System;
using System.Threading.Tasks;

namespace Neil.BLL
{
    public class UserBLL : IUserBLL
    {
        IUserDAL _userDAL;

        IServiceA _serviceA;
        IServiceB _serviceB;

        public IServiceC ServiceC { get; set; }

        [NeilFlagCtor]
        public UserBLL(IServiceA serviceA, IServiceB serviceB)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
        }

        public UserBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public UserModel Login(int Id)
        {
            if (Id == _userDAL.GetUserModel().Id)
                return _userDAL.GetUserModel();
            else
                return null;
        }

        public async Task Running()
        {
            for (int i = 1111; i < 1115; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(i);
            }
        }
    }
}
