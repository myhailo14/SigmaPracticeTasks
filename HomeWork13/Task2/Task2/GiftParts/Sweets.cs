using System;
using System.Collections.Generic;

namespace Task2.GiftParts
{
    public class Sweets
    {
        public readonly string BadChildSweet = "Nothing";
        public readonly List<string> SweetList;

        public Sweets()
        {
            SweetList = new List<string>
            {
                "Chocolate",
                "Bananas",
                "Tangerines",
                "Oranges",
                "Candy"
            };
        }

        public string GetRandomSweet()
        {
            return SweetList[new Random().Next(SweetList.Count)];
        }

        public void AddNewSweet(string sweet)
        {
            SweetList.Add(sweet);
        }
    }
}