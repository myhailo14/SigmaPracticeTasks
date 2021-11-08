using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace Task2
{
    class Program
    {
        static void DemonstrateTask()
        {
            List<Child> childList = new List<Child>
            {
                new Child("Ivan",   true, 100, 20),
                new Child("Petro",  true, 10,  20),
                new Child("Bogdan", true, 100, 100),
                new Child("Oleg",   true, 100, 20),

                new Child("Sofia", false, 100, 20),
                new Child("Diana", false, 10,  20),
                new Child("Marta", false, 100, 100),
                new Child("Olya",  false, 100, 20)

            };

            Mykolai mykolai = Mykolai.Instance;

            Console.WriteLine("Gifts for 1st case");

            foreach (var child in childList)
            {
                child.AskForGift(mykolai);
                Console.WriteLine(child);
            }

            Console.WriteLine(new string('-', 100));

            //sets counters to start of gift parts lists
            mykolai.ResetGiftPartsCounter();
            //allows to claim gifts without considering bad actions
            mykolai.SetGiftPolicy(false);


            Console.WriteLine("Gifts for 2nd case");
            foreach (var child in childList)
            {
                child.AskForGift(mykolai);
                Console.WriteLine(child);
            }
            Console.WriteLine("Hello World!");
        }

        static void Main()
        {
            DemonstrateTask();
        }
    }
}
