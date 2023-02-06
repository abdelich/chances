using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chances
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate player with balance 100
            Player player = new Player(100);

            //start to play with bet 10 as "player"
            Chances.Play(player, 10);

            Console.ReadKey();
        }
    }
}
