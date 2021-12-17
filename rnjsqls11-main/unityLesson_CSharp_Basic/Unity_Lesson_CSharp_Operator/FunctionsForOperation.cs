using System;

namespace Unity_Lesson_CSharp_Operator
{
    class FunctionsForOperation
    {
        // 산술 연산

        // 덧샘
        static public int 더하기(int a, int b)
        {
            return a + b;
        }
        // 뺄샘
        static public int 빼기(int a, int b)
        {
            return a - b;
        }
        // 곱하기
        static public int 곱하기(int a, int b)
        {
            return a * b;
        }
        // 나누기
        static public int 나누기(int a, int b)
        {
            return a / b;
        }
        // 나머지
        static public int 나머지(int a, int b)
        {
            return a % b;
        }

        // 증감 연산

        static public int Increase(int a)
        {
            return a++;
        }
        static public int Decrease(int a)
        {
            return a--;
        }

        // 관계연산

        static public bool IsDiffrent(bool a, bool b)
        {
            return a == b;
        }
    }
}
