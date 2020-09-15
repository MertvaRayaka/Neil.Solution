using System;
using Neil.IBLL;
using Neil.IDAL;
using Neil.BLL;
using Neil.DAL;
using Neil.IService;
using Neil.Container;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;

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

            AddFunc(userBLL.Running);
            AddFunc(userBLLV2.Running);

            Task.Run(async()=>
            {
                while (FuncList.Count>0)
                {
                    foreach (var func in FuncList)
                    {
                        await func();
                    }
                }
            });

            RemoveFunc(userBLLV2.Running);

            Console.ReadLine();
        }

        public static void AddFunc(Func<Task> action)
        {
            lock(action)
                FuncList.Add(action);
        }

        public static void RemoveFunc(Func<Task> action)
        {
            lock (action)
                FuncList.Remove(action);
        }
    }
}
