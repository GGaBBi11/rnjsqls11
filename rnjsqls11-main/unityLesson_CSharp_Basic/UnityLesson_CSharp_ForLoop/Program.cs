using System;

namespace UnityLesson_CSharp_ForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            // for 문
            // 기본 형태

            /* for ( 인덱스용 변수 선언 및 초기화; for 문을 실행할 조건; 루프가 한번 실행 될때마다 실행할 문구
              int i = 0; i < length; i++)
            {

            }*/
            string[] arr_PersonName = new string[6];
            arr_PersonName[0] = "김아무개";
            arr_PersonName[1] = "이아무개";
            arr_PersonName[2] = "김아무개";
            arr_PersonName[3] = "이아무개";
            arr_PersonName[4] = "김아무개";
            arr_PersonName[5] = "이아무개";

            int length = arr_PersonName.Length;

            /* for (int i = 0; i < length; i++)
             {
                 Console.WriteLine(arr_PersonName[i]);
             }*/

            // ex ) 김아무개만 출력하고 싶다.
            // if 문으로 출력한 예제

            for (int i = 0; i < length; i++)
            {
                if (arr_PersonName[i] == "김아무개")
                {
                    Console.WriteLine(arr_PersonName[i]);
                }

            }

            // ex2) 2n (n은 양의정수) 마다 김아무개 라는 규칙을 활용 예제

            for (int i = 0; i < length; i+=2)
            {
                Console.WriteLine(arr_PersonName[i]);
            }
        }
    }
}
