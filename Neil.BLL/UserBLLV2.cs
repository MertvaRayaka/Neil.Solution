using Neil.IBLL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neil.BLL
{
    public class UserBLLV2 : IFuncManager, IUserBLL
    {
        public UserModel Login(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task Running()
        {
            for (int i = 1; i <= 5; i++)
            {
                if (!IFuncManager.TaskFlag) break;
                await Task.Delay(1000);
                IFuncManager.TransAction(0,i.ToString());
            }
        }
    }
}
