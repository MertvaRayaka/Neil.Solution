using System;

namespace Neil.IService
{
    public class ServiceD : IServiceD
    {
        public void show()
        {
            Console.WriteLine($"这是{this.GetType().Name}具体实现类");
        }
    }
}
