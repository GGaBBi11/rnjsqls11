using System;


namespace UnityLesson_CSharp_Array
{
    class Program
    {
        // array
        // 형태 : 자료형[]
        // 배열이란 - 자료형이 정적으로 나열되어있는 형태 , 즉 한번 크기를 정해놓으면 바꿀수 없다.

        static int[] arr_testint = new int[5];
        static float[] arr_testFloat = new float[3];
        static float[] arr_testFloat2 = { 1.0f, 2.0f, 3.0f, 4.0f };
        static string[] arr_testString = new string[3];
        static void Main(string[] args)
        {
            arr_testint[0] = 1;
            arr_testint[1] = 1;
            arr_testint[2] = 0;
            arr_testint[3] = 8;
            arr_testint[4] = 8;

            Console.WriteLine(arr_testint[0]);
            Console.WriteLine(arr_testint[1]);
            Console.WriteLine(arr_testint[2]);
            Console.WriteLine(arr_testint[3]);
            Console.WriteLine(arr_testint[4]);

            arr_testFloat[0] = 2.1f;
            arr_testFloat[1] = 4.2f;
            arr_testFloat[2] = 6.2f;

            Console.WriteLine(arr_testFloat[0]);
            Console.WriteLine(arr_testFloat[1]);
            Console.WriteLine(arr_testFloat[2]);

            arr_testString[0] = "김아무개";
            arr_testString[1] = "이아무개";
            arr_testString[2] = "박아무개";

            Console.WriteLine(arr_testString[0]);
            Console.WriteLine(arr_testString[1]);
            Console.WriteLine(arr_testString[2]);

        }
    }
}
