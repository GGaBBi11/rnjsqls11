using System;

namespace Unity_Lesson_CSharp_ClassincludingVarableFuncion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    // Camel case
    // class, function, namespace 등은 대문자로 시작한다.
    // 변수는 소문자로 시작한다.
    // 단어가 바뀔때(단어에서 다음 단어로 넘어갈때) 첫 문자는 대문자로 한다.
    // 줄임말은 되도록 사용을하면 안된다.
    // 이름을 보았을때 어떤 기능이나 목적인지 알수있도록 선정한다.
    // 애매하거나 복잡한내용이 있으면 주석을 달아준다.

    // 사람 클래스다.
    class Person
    {

        // bit = 한자리 이진수 ( 0과 1, 정보처리의 최소단위 )
        // 1 byte = 8 bit, cpu 데이터 처리 최소단위 
        // 4 byte = 8 bit * 4 = 32 bit
        // 4 bye로 표현할수 있는 숫자의 범위 -> 2^32
        int age; // 정수형 , 4byte -2147483648 ~ 2147483648
        float height; // 실수형 , 4byte
        bool isFemale; // 논리형 (참과 거짓) , 1byte
        char genderChar; // 문자형 , 2byte
        string name; // 문자열 , 문자갯수 * 2byte


        // 입력 -> 함수기능 -> 출력
        /*
         * 클래스화 (설계도 제작)
         * 추상화에서 각 특징과 요소들의 형태를 정의
         * 변수 "나이"는 정수형이다.
         * 변수 "키"는 실수형이다.
         * 변수 "성별"은 논리형이다.
         * 변수 "성별문자"는 문자형이다.
         * 변수 "이름"은 문자열형이다.
         * 
         * 객체화:(설계도로 객체를 만든다 찍어낸다.)
         * 객체: 클래스로 만들어진 사물/개념
         * 
         * 인스턴스화:(클래스로 생성한 개체를 메모리로 할당해준다.)
         * 
         */

        // 이 사람에 대한 모든 정보를 말한다.
        void SayAllinfo()
        {
            SayAge();
            SayHeight();
            SayIsFemale();
            SayGenderChar();
            SayName();
        }
        void SayAge()
        {
            Console.WriteLine(age);
        }

        void SayHeight()
        {
            Console.WriteLine(height);
        }

        void SayIsFemale()
        {
            Console.WriteLine(isFemale);
        }
        void SayGenderChar()
        {
            Console.WriteLine(genderChar);
        }
        void SayName()
        {
            Console.WriteLine(name);
        }
    }


}
