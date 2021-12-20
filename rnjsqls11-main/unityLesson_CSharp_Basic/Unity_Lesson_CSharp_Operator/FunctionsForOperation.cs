using System;

namespace Unity_Lesson_CSharp_Operator
{
    class FunctionsForOperation
    {
        // 산술 연산

        // 덧샘
        static public int Sum(int a, int b)
        {
            return a + b;
        }
        // 뺄샘
        static public int Sub(int a, int b)
        {
            return a - b;
        }
        // 곱하기
        static public int Mul(int a, int b)
        {
            return a * b;
        }
        // 나누기
        static public int Div(int a, int b)
        {
            return a / b;
        }
        // 나머지
        static public int Mod(int a, int b)
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

        static public bool IsSame(int a, int b)
        {
            return a == b;

            /*bool isSame = false;
            if (a==b)
                isSame = true;
                return isSame;*/
        }
        static public bool isDifferent(int a, int b)
        {
            return a != b;
            /*bool isDifferent = false;
             if (a != b )
                isDifferent = true;
            return isDifferent;*/
        }
        static public bool IsBigger(int a, int b)
        {
            return (a > b);
            /*bool isBigger = false;
             if (a > b)
                isBigger = true;
            dreturen isBigger;*/
        }
        static public bool isSmaller(int a, int b)
        {
            return (a < b);
            /*bool isSmaller = false;
             if (a < b)
                isSmaller = ture;
            return isSmaller;*/
        }
        static public bool IsBiggerOrSame(int a , int b)
        {
            return a >= b;
            /*bool isBiggerOrSame = false;
             if (a > = b)
                isBiggerOrsame = ture;
            return isBiggerOrsame;*/
        }
        static public bool IsSmallerOrSame(int a, int b)
        {
            return a <= b;
            /*bool isSmallerOrSame = false;
             if (a > = b)
                isSmallerrOrsame = ture;
            return isSmallerOrsame;*/
        }

        // 대입 연산

        static public int BlusBToA(int a, int b)
        {
            a += b;
            return a;
        }
        static public int MinusBtoA(int a, int b)
        {
            a -= b;
            return a;
        }
        static public int MultiplyBToA(int a, int b)
        {
            a *= b;
            return a;
        }
        static public int DivdeBToA(int a, int b)
        {
            a /= b;
            return a;
        }
        static public int ModBToA(int a, int b)
        {
            a %= b;
            return a;
        }

        // 논리 연산
        // 양측의 피연산자들을 비교하여 연산 수행

        static public bool LogicOR(bool a, bool b)
        {
            return a | b;
        }
        static public bool LogicAND(bool a, bool b)
        {
            return a & !b;
        }
        static public bool LogicXOR(bool a, bool b)
        {
            return a ^ b;
        }
        static public bool LogicNOT(bool a)
        {
            return !a;
        }

        // 조건부 논리 연산
        // 왼쪽 피연산자 조건에 따라 오른쪽 피연산자와 비교 할지말지 평가후 연산을 진행

        static public bool CondditionaLogicOR(bool a, bool b)
        {
            return a || b;
            // a 가 true 일 경우, b 의 값에 상관없이 결과가 true 이므로 b 를 평가하지 않고 , true 를 리턴
        }
        static public bool CondditionLogicAND(bool a, bool b)
        {
            return a && b;
            // a가 false 일 경우, b 의 값에 상관없이 결과가 false 이므로, bf를 평가하지 않고 false를 리턴
        }

        // 비트 연산

        static public int BitLogicOR(int a, int b)
        {
            return a | b;
        }
        static public int BitLogicAND(int a, int b)
        {
            return a & b;
        }
        static public int BitLogicXOR(int a, int b)
        {
            return a ^ b;
        }
        static public int BitShiftLeft(int a, int howManyBitYouWantToShift)
        {
            return a << howManyBitYouWantToShift;
        }
        static public int BitShiftRight(int a, int howManyBityouWantToShift)
        {
            return a >> howManyBityouWantToShift;
        }
        static public int BitComplement(int a)
        {
            return ~a;
        }
    }
}
