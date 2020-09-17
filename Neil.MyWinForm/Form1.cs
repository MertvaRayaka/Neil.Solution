using Neil.BLL;
using Neil.Container;
using Neil.DAL;
using Neil.IBLL;
using Neil.IDAL;
using Neil.IService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neil.MyWinForm
{
    public partial class Form1 : Form
    {
        private List<Func<Task>> funcs = new List<Func<Task>>();
        private IUserDAL userDAL;
        private IUserBLL userBLL;
        private IUserBLL userBLLV2;
        IFuncManager funcManager;

        public Form1()
        {
            InitializeComponent();
            ObjectRegister();
            UIOperator();
            TaskRun();
        }

        private void ObjectRegister()
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

            userDAL = container.CreateObject<IUserDAL>();
            userBLL = container.CreateObject<IUserBLL>();
            userBLLV2 = new UserBLLV2();
        }

        private void TaskRun()
        {
            funcManager = new UserBLLV2();
            funcManager.Addfunc(userBLL.Running);
            funcManager.Run();
        }

        private void UIOperator()
        {
            UIControlFunc();
            UIUpdate();

            void UIControlFunc()
            {
                this.btn_Add.Click += (s, e) => funcManager.Addfunc(userBLLV2.Running);
                this.btn_Delete.Click += (s, e) =>
                {
                    funcManager.Removefunc(userBLLV2.Running);
                    funcManager.Removefunc(userBLL.Running);
                };
                this.btn_Stop.Click += (s, e) => IFuncManager.TaskFlag = false;
                this.btn_Reset.Click += (s, e) =>
                  {
                      if (IFuncManager.TaskFlag == true) return;
                      IFuncManager.TaskFlag = true;
                      funcManager.Run();
                  }; 
            }

            void UIUpdate()
            {
                IFuncManager.TransAction = (transType, str) =>
              {
                  if (this.IsHandleCreated)
                  {
                      this.Invoke(new Action(() =>
                      {
                          switch (transType)
                          {
                              case TransType.TopText:
                                  this.Text = str;
                                  break;
                              case TransType.LabelText:
                                  this.label1.Text = str;
                                  break;
                          }
                      }));
                  }
              };
            }
        }
    }
}
