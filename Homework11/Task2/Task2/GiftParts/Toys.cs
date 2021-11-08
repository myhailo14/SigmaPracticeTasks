using System;
using System.Collections.Generic;

namespace Task2.GiftParts
{
    class Toys
    {
        public readonly string BadChildToy = "Rizka";
        public readonly List<string> BoyToys;
        public readonly List<string> GirlToys;
        public Toys()
        {
            BoyToys = new List<string>
            {
                "Toys car",
                "Tool set",
                "Football ball",
                "Basketball ball",
                "Book",
                "T-shirt"
            };
            GirlToys = new List<string>
            {
                "Makeup set",
                "Doll",
                "Tails book",
                "Dress",
                "Color pencils"
            };
        }
        public string GetRandomBoyToy()
        {
            return BoyToys[new Random().Next(BoyToys.Count)];
        }
        public string GetRandomGirlToy()
        {
            return BoyToys[new Random().Next(0, BoyToys.Count)];
        }

        public void AddNewToy(string toy, bool forBoy)
        {
            if (forBoy == true)
                BoyToys.Add(toy);
            else
                GirlToys.Add(toy);
        }
    }
}