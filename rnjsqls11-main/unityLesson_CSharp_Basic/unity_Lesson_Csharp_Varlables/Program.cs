using System;

namespace unity_Lesson_Csharp_Varlables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Person
    {
        // bit = 한자리 이진수 ( 0과 1, 정보처리의 최소단위 )
        // 1 byte = 8 bit, cpu 데이터 처리 최소단위 
        // 4 byte = 8 bit * 4 = 32 bit
        // 4 bye로 표현할수 있는 숫자의 범위 -> 2^32
        int age; // 정수형 , 4byte
        float height; // 실수형 , 4byte
        bool isFemale; // 논리형 (참과 거짓) , 1byte
        char genderChar; // 문자형 , 2byte
        string name; // 문자열 , 문자갯수 * 2byte
    }
 
}
