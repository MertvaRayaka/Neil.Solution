using System;

namespace Neil.IService
{
    public class ServiceA : IServiceA
    {
        private IServiceB _serviceB;
        private IServiceC _serviceC;
        public ServiceA(IServiceB serviceB,IServiceC serviceC)
        {
            _serviceB = serviceB;
            _serviceC = serviceC;
        }
        public void show()
        {
            Console.WriteLine($"这是{this.GetType().Name}具体实现类");
        }
    }
}
