using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chances
{
    static class Chances
    {

        //all results that we could have
        enum ChanceName
        {
            Win,
            NoWin,
            Extra
        }

        //play method that start our game with player p, and bet
        public static void Play(Player p, int bet)
        {
            //here we have data to calculate RTP
            double wonCredits = 0;
            double spentCredits = 0;

            //RTP calculation
            double RTP()
            {
                if (spentCredits != 0)
                {
                    double rtp = (wonCredits / spentCredits) * 100;

                    Console.WriteLine($"RTP -----> (won credits:{wonCredits}/spent credits:{spentCredits}) * 100 = {rtp} RTP");

                    return rtp;
                }
                else return 0;
            }

            //empty list which we will fill with a random data 
            List<ChanceName> chances;

            // starting a round
            do
            {
                //fill our empty list on every round with a static method which returns a randomized list with balls
                chances = new List<ChanceName>();
                chances = CreateChances();

                //check if user has enough credits to play
                if (p.Balance - bet < 0)
                    Console.WriteLine("You have no money");

                //else he has enough and we ask him to start a round
                else
                {
                    //show balance to user
                    p.Info();

                    //and ask him to start a round
                    Console.WriteLine("Bet: " + bet + "$");
                    Console.WriteLine("PICK ONE OF THE BALLS UNDER OR WRITE q TO EXIT");

                    //print all our balls that we have
                    for (int i = 0; i < chances.Count; i++)
                    {
                        Console.WriteLine($"O <------- write {i + 1} and press enter");
                    }

                    //ask him for one of the balls 1-20
                    int choise;
                    if (int.TryParse(Console.ReadLine(), out choise) && (choise > 0 && choise < 21))
                    {
                        for (int i = 0; i < chances.Count; i++)
                        {
                            //here we print all balls with results and colors so it is easy to understand which ball has which result
                            switch (chances[i])
                            {
                                case ChanceName.Win:
                                    ConsoleGameState.WinColor();
                                    break;
                                case ChanceName.NoWin:
                                    ConsoleGameState.LoseColor();
                                    break;
                                case ChanceName.Extra:
                                    ConsoleGameState.ExtraColor();
                                    break;
                            }

                            //and user's choice so he could see which he had chosen
                            if (choise - 1 == i)
                                Console.WriteLine(chances[i] + $"<({i + 1})> <----------- your choise");
                            else
                                Console.WriteLine(chances[i] + $"<({i + 1})>");

                            ConsoleGameState.DefaultColor();
                        }
                        //here we are computate user's choice
                        try
                        {
                            switch (chances[choise - 1])
                            {
                                //if he wins we give him 2x multiplier credits(if bet is 10 win will be 10*2 = 20) and calculate the RTP and then show his balance
                                case ChanceName.Win:

                                    p.Balance += bet * 2;

                                    wonCredits += bet * 2;
                                    spentCredits += bet;

                                    p.Info();

                                    break;

                                //if he loses, we will remove the bet from his balance, we will calculate the RTP, and then show his balance
                                case ChanceName.NoWin:

                                    p.Balance -= bet;
                                    spentCredits += bet;

                                    p.Info();

                                    break;

                                //if it was an extra ball we just continue our round and print user's balance
                                case ChanceName.Extra:
                                    Console.WriteLine("PICK ANOTHER ONE");

                                    //p.Balance += bet * 5;

                                    p.Info();

                                    continue;
                            }
                        }
                        catch { Console.WriteLine("Write number 1 - 20"); } //if it was wrong input
                    }
                }
                Console.WriteLine("WRITE q to EXIT OR PRESS ENTER TO CONTINUE");
            } while (Console.ReadLine() != "q");//player plays until he writes "q"

            //calculate RTP and print it to the console after his game
            RTP();

            //print of user's balance after he stoped to play
            p.Info();


            //method that construct list with a pseudorandom balls for one round
            List<ChanceName> CreateChances()
            { 
                List<ChanceName> names = new List<ChanceName>();

                //start to add all that we need ( 5 wins 14 nowin and 1 extra )
                names.Add(ChanceName.Extra);

                for (int i = 0; i < 5; i++)
                {
                    names.Add(ChanceName.Win);
                }


                for (int i = 0; i < 14; i++)
                {
                    names.Add(ChanceName.NoWin);
                }


                //then we shuffle it with pseudorandom numbers 
                Random r = new Random();

                for (int i = 0; i < names.Count; i++)
                {
                    int randomIndex = r.Next(names.Count - 1);

                    ChanceName chance = names[i];
                    names[i] = names[randomIndex];
                    names[randomIndex] = chance;
                }

                //then we return ranomized list
                return names;
            }
        }
    }
}
