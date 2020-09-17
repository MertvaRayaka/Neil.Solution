using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neil.IBLL
{
    public enum TransType
    {
        TopText,
        LabelText
    }
    public abstract class IFuncManager
    {
        public static Action<TransType, string> TransAction;
        public static bool TaskFlag = true;
        public List<Func<Task>> FuncList = new List<Func<Task>>();

        public void Addfunc(Func<Task> func)
        {
            lock (FuncList)
                FuncList.Add(func);
        }
        public void Removefunc(Func<Task> func)
        {
            lock (FuncList)
            {
                if (FuncList.Contains(func))
                    FuncList.Remove(func);
            }
        }

        public void Run()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1);
                    TransAction(TransType.LabelText, FuncList.Count.ToString());
                    if (TaskFlag)
                    {
                        foreach (var func in FuncList.ToArray())
                        {
                            await func();
                        }

                    }
                }
            });
        }

    }
}
