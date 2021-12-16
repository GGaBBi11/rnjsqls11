using System;

namespace Unity_Lesson_SSharp_Funcion
{
    class Program
    {
        static bool doprintHelloworld = false;
        static bool doPrintSomething = true;
        static void Main(string[] args)

        // 함수 호출시 함수이름(); 형태로 호출한다.
        {
            if (doprintHelloworld == true)
            {
                PrintHellowarld();
            }
             else
            {
                Console.WriteLine("do nothing");
            }

            // parameter : 함수 호출시 입력 변수
            string something = "Unity_Hola !";
            {
                PrintSomething(something);
            }
       

        }
    

        static void PrintHellowarld()
        {
            Console.WriteLine("Hello World!");
        }
        static void PrintSomething(string something)
        {

        }
   
    }
}
