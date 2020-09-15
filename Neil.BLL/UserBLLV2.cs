using Neil.IBLL;
using Neil.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neil.BLL
{
    public class UserBLLV2 : IUserBLL
    {
        public UserModel Login(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task Running()
        {
            for (int i = 1; i < 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(i+1);
            }
        }
    }
}
