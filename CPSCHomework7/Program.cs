using System;
using System.Collections.Generic;
using System.Linq;

namespace CPSCHomework7
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = new Dictionary<string, int>()
            {
                { "penny", 1 },
                { "dine", 10 },
                { "nikkel", 5},
                { "quater", 25}
            };

            var names = new string[] { "penny", "dine", "nikkel", "quater" };

            //for(int i = 0; i < 50; i++)
            //{
            //    var list = GetChanges(coins, i);
            //    Console.WriteLine("best coin change: " + TotalCoins(list, names));
            //    Console.WriteLine(DisplayCoins(list, names, i));
            //}

            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine(CalculateChange(coins, names, i));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="names"></param>
        /// <param name="change"></param>
        /// <returns></returns>
        public static string CalculateChange(Dictionary<string, int> coins, string[]names, int change)
        {
            var calculateChange  = GetChanges(coins, change);
            var total = TotalCoins(calculateChange, names);
            var display = DisplayCoins(calculateChange, names, change);
            return "Total coin: "+ total +" " + display;
        }

        /// <summary>
        /// function to provide list of coins and change needed
        /// </summary>
        /// <param name="coins">list of available coins</param>
        /// <param name="change">required change</param>
        /// <returns></returns>
        public static Dictionary<string, int> GetChanges(Dictionary<string, int> coins, int change)
        {
            if (change != 0 && coins != null && coins.Count > 0)
            {
                //save possilbe change calculation
                var possibleChangeResults = new Dictionary<string, int>();
                //order the coin values decending values
                coins.OrderByDescending((value) => value.Value);
                //search through list of coins find possible changes amount
                foreach (var coin in coins.OrderByDescending((value) => value.Value))
                {
                    //update total coin needed for a change
                    int totalCoin = 0;
                    while (change >= coin.Value)
                    {
                        change = change - coin.Value;
                        totalCoin++;
                    }
                    possibleChangeResults.Add(coin.Key, totalCoin);
                }
                return possibleChangeResults;
            }
            else
            {
                return null;
            }           
        }

        /// <summary>
        /// list for total coins needed for a change 
        /// </summary>
        /// <param name="coins">list of coins</param>
        /// <param name="coinName"> list of coin names</param>
        /// <returns>total number of coins based on each type</returns>
        public static int TotalCoins(Dictionary<string, int> coins, string[] coinName)
        {
            if(coins != null && coinName != null)
            {
                int total = 0;
                for (int i = 0; i < coinName.Length; i++)
                {
                    string name = coinName[i];
                    total = total + coins[name];
                }
                return total;
            }
            else
            {
                return 0;
            }           
        }

        /// <summary>
        /// Display how many coins need of each type. 
        /// </summary>
        /// <param name="coins"> list of coins needed</param>
        /// <param name="coinName"> list of coin names</param>
        /// <param name="change">change amount required</param>
        /// <returns>String - display each coin type needed</returns>
        public static string DisplayCoins(Dictionary<string, int> coins, string[] coinName, int change)
        {
            if(coins != null && coins.Count > 0 && change > 0)
            {
                string totalCoin = "Change amount: " + change;
                for (int i = 0; i < coinName.Length; i++)
                {
                    string name = coinName[i];
                    totalCoin = totalCoin + " coin name: " + name + ":" + coins[name];
                }
                return totalCoin;
            }
            else
            {
                return null;
            }           
        }
    }
}
