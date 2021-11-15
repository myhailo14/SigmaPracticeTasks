using System;
using System.Collections.Generic;

namespace Task2.GiftParts
{
    public class Wishes
    {
        public readonly string BadChildWish = "Be more polite next year";
        public readonly List<string> WishesList;

        public Wishes()
        {
            WishesList = new List<string>
            {
                "Be happy",
                "Be healthy",
                "Have a nice year"
            };
        }

        public string GetRandomWish()
        {
            return WishesList[new Random().Next(WishesList.Count)];
        }

        public void AddNewWish(string wish)
        {
            WishesList.Add(wish);
        }
    }
}