using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPSCHomework7;
using System.Collections.Generic;

namespace MainTestProject
{
    [TestClass]
    public class Main
    {
        //global set of coins and names
        Dictionary<string, int> coins = new Dictionary<string, int>()
        {
                { "Penny", 1 },
                { "Dime", 10 },
                { "Nickel", 5},
                { "Quarter", 25},
                { "Half Dollar", 50}
        };

        //global set of coins and names
        Dictionary<string, int> coins_short_list = new Dictionary<string, int>()
        {
                { "Penny", 1 },
                { "Dime", 10 }                
        };

        string[] names = new string[] { "Penny", "Dime", "Nickel", "Quarter", "Half Dollar" };
        string[] names_shortlist = new string[] { "Penny", "Dime", "Quarter"};

        [TestMethod]
        public void HappyPath_FullSetOfCoins_with_real_change_amount()
        {
            string expected = "Total coin: 8 Change amount: 99 coin name: Penny:4 coin name: Dime:2 coin name: Nickel:0 coin name: Quarter:1 coin name: Half Dollar:1";
            Program program = new Program();
            string test = program.CalculateChanges(coins, names, 99);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void FullSetOfCoins_Change_amount_is_0()
        {
            string expected = "Total coin: 0 ";
            Program program = new Program();
            string test = program.CalculateChanges(coins, names, 0);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void FullSetOfCoins_Change_amount_is_negative_number()
        {
            string expected = "Total coin: 0 ";
            Program program = new Program();
            string test = program.CalculateChanges(coins, names, -1);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void FullSetOfCoins_Change_amount_is_101()
        {
            string expected = "Total coin: 3 Change amount: 101 coin name: Penny:1 coin name: Dime:0 coin name: Nickel:0 coin name: Quarter:0 coin name: Half Dollar:2";
            Program program = new Program();
            string test = program.CalculateChanges(coins, names, 101);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void FullSetOfCoins_is_null_Change_amount_is_50()
        {
            string expected = "Total coin: 0 ";
            Program program = new Program();
            string test = program.CalculateChanges(null, names, 50);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void SetOfCoins_is_null_And_CoinNames_is_null_Change_amount_is_50()
        {
            string expected = "Total coin: 0 ";
            Program program = new Program();
            string test = program.CalculateChanges(null, null, 50);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void SetOfCoins_is_null_And_CoinNames_is_null_Change_amount_is_negative()
        {
            string expected = "Total coin: 0 ";
            Program program = new Program();
            string test = program.CalculateChanges(null, null, -1);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void SetOfCoins_is_null_And_CoinNames_is_null_Change_amount_is_0()
        {
            string expected = "Total coin: 0 ";
            Program program = new Program();
            string test = program.CalculateChanges(null, null, 0);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void SetOfCoins_with_missing_coins_And_CoinNames_is_full_Change_amount_is_75()
        {
            string expected = "Total coin: 12 Change amount: 75 coin name: Penny:5 coin name: Dime:7";
            Program program = new Program();
            string test = program.CalculateChanges(coins_short_list, names, 75);
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void SetOfCoins_And_CoinNameswith_with_missing_coinsName_Change_amount_is_75()
        {
            string expected = "Total coin: 1 Change amount: 75 coin name: Penny:0 coin name: Dime:0 coin name: Quarter:1";
            Program program = new Program();
            string test = program.CalculateChanges(coins, names_shortlist, 75);
            Assert.AreEqual(expected, test);
        }
    }
}


