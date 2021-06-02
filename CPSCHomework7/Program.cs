using System;
using System.Collections.Generic;
using System.Linq;

namespace CPSCHomework7
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = new Dictionary<string, int>();
            coins.Add("penny", 1);
            coins.Add("dine", 10);
            coins.Add("nikkel", 5);
            coins.Add("quater", 25);

            for(int i = 0; i < 100; i++)
            {
                var list = GetChanges(coins, i);

                Console.WriteLine("Change amount: " + i + " --coin name: Penny: " + list["penny"] + " coin name: Dine: " + list["dine"] + " coin name: Nikkel: " + list["nikkel"] + " coin name: Quater: " + list["quater"]);
            }
        }

        public static Dictionary<string, int> GetChanges(Dictionary<string, int> coins, int change)
        {
            //save possilbe change calculation
            var possibleChangeResults = new Dictionary<string, int>();
            //order the coin values decending values
            coins.OrderByDescending((value) => value.Value);

            //search through list of coins find possible changes amount
            foreach(var coin in coins.OrderByDescending((value) => value.Value))
            {
                //update total coin needed for a change
                int totalCoin = 0;
                while(change >= coin.Value)
                {
                    change = change - coin.Value;
                    totalCoin++;
                }
                possibleChangeResults.Add(coin.Key, totalCoin);
            }
            return possibleChangeResults;
        }
    }
}
