using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Task2.GiftParts
{
    public enum AgeCategory { Child = 10, Scholar = 15, Teen = 18 }

    public class Toys
    {
        public readonly string BadChildToy = "Rizka";
        public readonly List<string> BoyToys;
        public readonly List<string> GirlToys;

        public readonly Dictionary<AgeCategory, List<string>> BoyToysCategorized;
        public readonly Dictionary<AgeCategory, List<string>> GirlToysCategorized;

        public Toys()
        {
            BoyToysCategorized = new Dictionary<AgeCategory, List<string>>
            {
                {
                    AgeCategory.Child, new List<string>
                    {
                        "Toy car", 
                        "Ball",
                        "Lego",
                        "Plasticine"
                    }

                },
                {
                    AgeCategory.Scholar, new List<string>
                    {
                        "Tool set",
                        "Football ball" ,
                        "Basketball ball",
                        "Book"
                    }
                },
                {
                    AgeCategory.Teen, new List<string>
                    {

                        "Tool set",
                        "Watch",
                        "Book",
                        "T-shirt"
                    }
                }
            };

            GirlToysCategorized = new Dictionary<AgeCategory, List<string>>
            {
                {
                    AgeCategory.Child, new List<string>
                    {
                        "Doll",
                        "Lego",
                        "Plasticine",
                        "Pencils"
                    }
                },
                {
                    AgeCategory.Scholar, new List<string>
                    {
                        "Makeup set",
                        "Book" ,
                        "Hat",
                        "Gloves"
                    }
                },
                {
                    AgeCategory.Teen, new List<string>
                    {
                        "Book",
                        "Gloves",
                        "Makeup set",
                        "Dress"
                    }
                }
            };

            BoyToys = new List<string>
            {
                "Toy car",
                "Ball",
                "Lego",
                "Plasticine",
                "Tool set",
                "Football ball",
                "Basketball ball",
                "Book",
                "Watch",
                "T-shirt"
            };
            GirlToys = new List<string>
            {
                "Doll",
                "Lego",
                "Plasticine",
                "Pencils",
                "Makeup set",
                "Book",
                "Hat",
                "Gloves",
                "Dress"
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

        public string GetRandomAgedBoyToy(int age)
        {
            AgeCategory ageCategory = age switch
            {
                > 0 and <= 10 => AgeCategory.Child,
                > 10 and <= 15 => AgeCategory.Scholar,
                > 15 and <= 18 => AgeCategory.Teen,
                _ => AgeCategory.Teen
            };
            return BoyToysCategorized[ageCategory][new Random().Next(BoyToysCategorized[ageCategory].Count)];
        }
        public string GetRandomAgedGirlToy(int age)
        {
            AgeCategory ageCategory = age switch
            {
                > 0 and <= 10 => AgeCategory.Child,
                > 10 and <= 15 => AgeCategory.Scholar,
                > 15 and <= 18 => AgeCategory.Teen,
                _ => AgeCategory.Teen
            };
          
            return GirlToysCategorized[ageCategory][new Random().Next(GirlToysCategorized[ageCategory].Count)];
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