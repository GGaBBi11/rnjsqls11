using System;

namespace Unity_Lesson_CSharp_Operator
{
    class Program
    {
        static int a = 14;
        static int b = 5;
        static int c;
        static void Main(string[] args)
        {
            // 산술 연산
            // 더하기(+), 빼기(-), 나누기(/), 곱하기(*), 나머지
            Console.WriteLine("산술 연산");

            c = FunctionsForOperation.Sum(a, b);            //더하기
            Console.WriteLine(c);
            c = FunctionsForOperation.Sub(a, b);              //빼기
            Console.WriteLine(c);
            c = FunctionsForOperation.Mul(a, b);            //나누기
            Console.WriteLine(c);
            c = FunctionsForOperation.Div(a, b);            //곱하기
            Console.WriteLine(c);
            c = FunctionsForOperation.Mod(a, b);            //나머지
            Console.WriteLine(c);

            // 증감 연산
            // 증가 연산자, 감소 연산자
            // =====================================================================================================================
            Console.WriteLine("\n증감 연산");

            c++; // 증가 연산 /  c = c + 1 ;
            Console.WriteLine(c);
            c--; // 감소 연산 / c = c - 1
            Console.WriteLine(c);

            // 관계 연산
            // 같음 , 다름 , 크기 비교 연산
            // 관계 연산의 결과가 참이면 ture, 거짓이면 false 를 반환.
            // =====================================================================================================================
            
            Console.WriteLine (a == b); // 같음 비교 부호 (==)

            Console.WriteLine(a != b); // 다른 비교 부호 (!=)
            // 크기 비교 부호 (> , <)
            Console.WriteLine(a > b); // a 가 b 보다 크다

            Console.WriteLine(a < b); // a 가 b 보다 작다

            Console.WriteLine(a >= b); // a 가 b 보다 작거나 크다

            Console.WriteLine(a <= b); // a 가 b 보다 작거나 크다

            // 대입 연산
            // 더해서, 빼서, 나누어서, 곱해서 대입
            // =====================================================================================================================
            c = 20;
            Console.WriteLine("\n대입 연산");

            Console.WriteLine($"Last C value : {c}");

            c += b; // c = c + b;
            Console.WriteLine(c);
            c -= b; // c = c - b;
            Console.WriteLine(c);
            c /= b; // c = c / b;
            Console.WriteLine(c);
            c *= b; // c = c *b;
            Console.WriteLine(c);
            c %= b; // c = c % b;
            Console.WriteLine(c);

            // 논리 연산
            // 양측의 피연산자들을 비교해서 연산 수행
            // or , and , xor , not
            // =====================================================================================================================
            Console.WriteLine("\n논리 연산");

            bool A = true;
            bool B = false;

            // or
            Console.WriteLine(A | B);   // a 와 b 둘중하나라도 true 이면 ture 반환 나머지 경우 false 반환
            // and
            Console.WriteLine(A & B);   // a와 b둘다 ture 일때만 ture 반환 나머지 경우 false 반환
            // xor (x+or)
            Console.WriteLine(A ^ B);   // a 와 b 둘중에 하나만 true 일때 ture 반환 나머지 경우 false 반환
            // not
            Console.WriteLine(!A);      // a의 반대 부호 반환 ( ture 이면 false, false이면 true 반환)

            // 조건부 논리연산
            // 왼쪽 피연산자 조건에 따라서 오른쪽 피연산자와 비교할지 말지 평가 후에 연산한다.
            // =====================================================================================================================
            
            Console.WriteLine(A || B); // or 조건부 논리연산
            // 만약 A 가 true 이면 B 의 값에 관계없이 결과값이 true 이므로 연산을 하지 않고 A값을 반환함.
            Console.WriteLine(A && B); // and 조건부 논리연산
            // 만약 A 가 false 이면 B 의 값에 관계없이 결과값이 false 이므로 연산을 하지않고 A 값을 반환함.

            // 비트 연산
            // 비트연산 하는 이유 : 데이터를 효율적으로 관리하기 위함
            // or, and, xor, not shift-left, shift-right
            // =====================================================================================================================
            Console.WriteLine("\n비트 연산");

            int HowManyBitYouWantToShift = 1;

            Console.WriteLine(A | B);   //or
            Console.WriteLine(A & B);   //and
            Console.WriteLine(A ^ B);   //xor
            Console.WriteLine(~a);      //nox
            // Shift - left
            Console.WriteLine(a << HowManyBitYouWantToShift);
            // Shift - right
            Console.WriteLine(a >> HowManyBitYouWantToShift);
        }
    }

    [Flags]
    // FSM Finite State Machine 유한 상태머신 (상태의 개수가 정해진 머신)
    // 클래스의 상태에 따라 다른동작을 하기 위해 사용.
    // ex) 플레이어가 idle 상태면 마을로 귀환이 가능하고, 피격당한상태와 공격중인 상태일때
    // 귀환이 불가능하게설정하고 싶으면,
    // 플레이어의 FSM 을 만들어서 상태를 나누고 귀환이 가능한 조건을 FSM 으로 구분한다.
    // 즉 사용자가 귀환 버튼을 눌렀을때, IDLE 상태면 귀환 모션이 실행되면서 귀환을 시전하지만
    // 몬스터에게 피격당하거나 공격중인 상태일때 귀환 버튼을 누르면 FSM 조건에 따라 귀환이 불가능하게 된다.
    public enum e_FSM
    {
        IDLE = 0,
        피격당한상태_1 = 1 << 0,
        공격중인상태_2 = 1 << 1,
        STATE_3 = 1 << 0,
        STATE_4 = 1 << 0,
    }
}
