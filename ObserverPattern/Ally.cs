using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Ally
    {
        public event Action<IObserver> OnAttacted;
        public Dictionary<string, List<IObserver>> AllyDic { get; set; } = new Dictionary<string, List<IObserver>>();

        public void CreateAlly(string allyName, List<IObserver> players)
        {
            AllyDic.Add(allyName, players);
            Console.WriteLine($"{allyName}被创建！");
            foreach (var player in players)
            {
                Console.WriteLine($"   成员-{player.Name}");
            }
            Console.WriteLine("*************************");
        }

        public void PlayerBeAttacked(IObserver player)
        {
            if (player != null)
            {
                player.BeAttacked();
                OnAttacted(player);
            }
            else
            {
                Console.WriteLine("此联盟无此人！");
            }
        }
    }
}
