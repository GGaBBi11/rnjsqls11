using System;

namespace Uinity_Lesson_CSharp_ClassInheritance
{
    class Creature
    {
        public string DNA;
        public int lifeTime;
        public float weight;
        
        // 함수 오버라이딩 ( override )
        // 함수를 재정의 하는 기능
        // virtual 키워드 : 해당 함수를 오버라이딩 가능하도록 해준다.
        // 부모클래스 함수라고 해서 전부 virtual 붙이는게 아니라,
        // 자식클래스가 해당 함수를 재정의 해야할 때만 virtual 을 붙여준다.
        virtual public void Breath()
        {
            lifeTime++;
        }


    }
}
