using Neil.BLL;
using Neil.Container;
using Neil.DAL;
using Neil.IBLL;
using Neil.IDAL;
using Neil.IService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neil.MyConsole
{
    class TestConsole
    {
        static List<Func<Task>> FuncList = new List<Func<Task>>();
        static void Main(string[] args)
        { 
            INeilContainer container = new NeilContainer();
            container.Register<IUserBLL, UserBLL>();
            container.Register<IUserDAL, UserDAL>();
            container.Register<IServiceA, ServiceA>();
            container.Register<IServiceB, ServiceB>();
            container.Register<IServiceC, ServiceC>();
            container.Register<IServiceD, ServiceD>();
            container.Register<IServiceE, ServiceE>();
            container.Register<IServiceF, ServiceF>();
            //container.Register<IUserBLL, UserBLLV2>();

            IUserDAL userDAL = container.CreateObject<IUserDAL>();
            IUserBLL userBLL = container.CreateObject<IUserBLL>();
            IUserBLL userBLLV2 = new UserBLLV2();

            Console.ReadLine();
        }
    }
}
