using System;

namespace Uinity_Lesson_CSharp_ClassInheritance
{
    class BlackMan : Person
    {
        public override void Breath()
        {
            lifeTime++;
            height = 0.0001f;
            weight = 0.00005f;
        }
    }
}
