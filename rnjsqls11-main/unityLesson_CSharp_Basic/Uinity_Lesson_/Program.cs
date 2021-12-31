using System;
using System.Collections.Generic;


namespace Uinity_Lesson_CSharp_ClassInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Creature creature = new Creature();
            creature.Breath();

            Person person = new Person();
            person.Breath();

            Dog dog = new Dog();
            dog.Breath();

            YellowMan yellowMan1 = new YellowMan();
            BlackMan blackMan1 = new BlackMan();
            WhiteMan whiteMan1 = new WhiteMan();

            yellowMan1.TwoLeegedWalker();
            blackMan1.TwoLeegedWalker();
            whiteMan1.TwoLeegedWalker();

            iTwoLeggedWalker yellowMan1_iTwoLeggedWalker = yellowMan1;
            iTwoLeggedWalker blackMan1_iTwoLeggedWalker = blackMan1;
            iTwoLeggedWalker whiteMan1_iTwoLeggedWalker = whiteMan1;

            List<iTwoLeggedWalker> list_TwoLeggedWalker = new List<iTwoLeggedWalker>();
            list_TwoLeggedWalker.Add(yellowMan1_iTwoLeggedWalker);
            list_TwoLeggedWalker.Add(blackMan1_iTwoLeggedWalker);
            list_TwoLeggedWalker.Add(whiteMan1_iTwoLeggedWalker);

            foreach (iTwoLeggedWalker twoLeggedWalker in list_TwoLeggedWalker)
            {
                twoLeggedWalker.TwoLeegedWalker();
            }
        }
    }
}
