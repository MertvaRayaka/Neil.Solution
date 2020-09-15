using Neil.Container;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neil.Container
{
    public class NeilContainer : Neil.Container.INeilContainer
    {
        private Dictionary<string, Type> RegisterDic = new Dictionary<string, Type>();
        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            RegisterDic.Add(typeof(TFrom).FullName, typeof(TTo));
        }

        public TFrom CreateObject<TFrom>() => (TFrom)this.CreateObject(typeof(TFrom));

        public object CreateObject(Type abstactType)
        {
            var type = RegisterDic[abstactType.FullName];
            List<object> paraList = new List<object>();
            //用标记的构造函数
            var ctor = type.GetConstructors().Where(p => p.IsDefined(typeof(NeilFlagCtorAttribute), true)).FirstOrDefault();
            //如果没有被标记的构造函数，则使用参数最多的构造函数
            if (ctor == null) ctor = type.GetConstructors().OrderByDescending(p => p.GetParameters().Length).FirstOrDefault();

            foreach (var para in ctor.GetParameters())//获取此类的所有构造函数
                paraList.Add(CreateObject(para.ParameterType));
            return Activator.CreateInstance(type, paraList.ToArray());
        }
    }
}
