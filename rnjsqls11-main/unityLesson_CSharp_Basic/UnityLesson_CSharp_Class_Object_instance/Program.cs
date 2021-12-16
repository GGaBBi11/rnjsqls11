using System;

namespace UnityLesson_CSharp_Class_Object_instance
{
    class Program
    {
        static void Main(string[] args)
        {
            // 객체 생성
            // New 키워드
            new AA(); // 클래스 이름과 똑같은 함수 . 객체를 생성함

            // 인스턴스 화
            // 메모리 공간에 객체를 할당 시킨다.
            // AA타입의 변수 a에 new AA() 로 생성된 객체가 할당 되었다.
            // 이제 new AA()로 생성된 객체가 필요할때마다
            // 변수 a 를 통해서 new AA() 로 생성된 객체로 접근할수 있게되었다.
            // 그리고 이렇게 되었을때 new AA() 로 생성된 객체를 인스턴스 라고 한다.
            // 

            AA a = new AA();
        }
    }
    // 클래스 (설계도)
    public class AA
    { 
        // 생성자
        AA()
        {

        }
        //소멸자
        ~AA()
        {
        
        }

    }
}
