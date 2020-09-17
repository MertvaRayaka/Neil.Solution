using Neil.Container;
using Neil.IBLL;
using Neil.IDAL;
using Neil.IService;
using Neil.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neil.BLL
{
    public class UserBLL :IFuncManager, IUserBLL
    {
        IUserDAL _userDAL;

        IServiceA _serviceA;
        IServiceB _serviceB;

        public IServiceC ServiceC { get; set; }

        
        public UserBLL(IServiceA serviceA, IServiceB serviceB)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
        }

        [NeilFlagCtor]
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
            for (int i = 111; i <= 115; i++)
            {
                if (!IFuncManager.TaskFlag) break;
                await Task.Delay(1000);
                IFuncManager.TransAction(0,i.ToString());
            }
        }
    }
}
