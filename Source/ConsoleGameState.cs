using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chances
{
    //class for change a console color to make interface looks nicer and understandable
    static class ConsoleGameState
    {
        //return color to default console color
        public static void DefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        //when picked up notwin ball it will be red(label of a ball)
        public static void LoseColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        //yellow color for extra
        public static void ExtraColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        //green color for win ball
        public static void WinColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }

}
