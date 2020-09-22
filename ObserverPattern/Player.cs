using System;
using System.Linq;

namespace ObserverPattern
{
    class Player : IObserver
    {
        public string Name { get; set; }

        public Player(Ally ally, string name)
        {
            this.Name = name;
            ally.OnAttacted += (beAttackedPlayer) =>
            {
                if (!beAttackedPlayer.Name.Equals(this.Name) && ally.AllyDic.FirstOrDefault(p => p.Value.Contains(beAttackedPlayer)).Value.Contains(this))
                    Help();
            };
        }

        public void BeAttacked()
        {
            Console.WriteLine($"{this.Name}正在被攻击！");
        }

        public void Help()
        {
            Console.WriteLine($"{this.Name}去帮忙！");
        }
    }
}
