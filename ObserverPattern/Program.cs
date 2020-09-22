using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Ally MyAlly = new Ally();

            MyAlly.CreateAlly("四人联盟", new List<IObserver>
            {
                new Player(MyAlly,"Lun"),
                new Player(MyAlly,"Jun"),
                new Player(MyAlly,"Yu"),
                new Player(MyAlly,"Xiang")
            });

            MyAlly.CreateAlly("五人联盟", new List<IObserver>
            {
                new Player(MyAlly,"Xiao"),
                new Player(MyAlly,"Gan"),
                new Player(MyAlly,"Wang"),
                new Player(MyAlly,"Zheng"),
                new Player(MyAlly,"Bin"),
            });

            MyAlly.PlayerBeAttacked(MyAlly.AllyDic.FirstOrDefault(p => p.Key == "四人联盟").Value.FirstOrDefault(player => player.Name == "Yu"));

            Console.ReadLine();
        }
    }
}
