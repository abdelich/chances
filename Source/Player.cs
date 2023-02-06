using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chances
{
    //class that implement player as a class and has all that player needs
    class Player
    {
        int balance;

        //propertie to control balance if it < 0 and incapsulate player`s real balance
        public int Balance
        {
            get { return balance; }
            set
            {
                if (value < 0) balance = 0;
                else balance = value;
            }
        }

        //constructor to instantiate player with some balance "balance"
        public Player(int balance)
        {
            Balance = balance;
        }

        //additional method to out player`s balance
        public void Info()
        {
            Console.WriteLine($"Balance: {balance}$");
        }
    }
}
