using System;


namespace Uinity_Lesson_CSharp_ClassInheritance
{
    class Dog : Creature , iFourLeegedWalker
    {
        public float tailLength;

        public void FourLeegedWalker()
        {
            Console.WriteLine("네발로 걷는다");
        }

    }
}
