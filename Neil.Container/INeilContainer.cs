using System;
using System.Collections.Generic;
using System.Text;

namespace Neil.Container
{
    public interface INeilContainer
    {
        void Register<TFrom, TTo>() where TTo : TFrom;
        TFrom CreateObject<TFrom>();
        object CreateObject(Type abstactType);
    }
}
