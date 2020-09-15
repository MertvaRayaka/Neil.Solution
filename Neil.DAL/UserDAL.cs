using Neil.IDAL;
using Neil.Model;
using System.Collections.Generic;

namespace Neil.DAL
{
    public class UserDAL : IUserDAL
    {
        public UserModel GetUserModel() =>
            new UserModel { Id = 1001, Name = "Amber", Hobbies = new List<string> { "篮球", "足球", "健身" } };
    }
}
