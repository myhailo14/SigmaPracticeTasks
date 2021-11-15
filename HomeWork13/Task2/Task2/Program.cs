using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

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
            IMykolai m = Mykolai.Instance;
            //foreach (var child in childList)
            //{
            //    child.AskForGift(m);
            //    Console.WriteLine(child.ToString());
            //}

            AgedGiftAdapter agb = new AgedGiftAdapter(m);
            //Console.WriteLine(
            //agb.CreateAgedGiftForAnyChild(childList[1], 7));
            m.SetGiftPolicy(false);
            childList[1].AskForGift(agb, 7);
            Console.WriteLine(childList[1]);
        }

        static void Main()
        {
            DemonstrateTask();
        }
    }
}
