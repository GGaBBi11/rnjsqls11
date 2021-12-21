using System;

// Orc 객체를 10마리 만들고 오크들의 인스턴스는 Orc타입 배열에 넣어준다.
// 각 오크들의 이름은 "오크0", "오크1", ........... "오크9"
// 각 오크에게 isResting 의 값을 아무거나 넣어준다 (true 나 false 중 아무거나)
// 각 오크가 쉬고있는지 확인해서 쉬고있다면 점프하도록 한다.
namespace UnityLesson_CSharp_ForLoopExample
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Orc[] arr_Orc = new Orc[10];

            int lenght = arr_Orc.Length;
            for (int i = 0; i < lenght; i++)
            {
                arr_Orc[i] = new Orc();
                arr_Orc[i].name = $"오크{i}";
            }
            arr_Orc[0].isResting = true;
            arr_Orc[1].isResting = true;
            arr_Orc[2].isResting = true;
            arr_Orc[3].isResting = true;
            arr_Orc[4].isResting = true;
            arr_Orc[5].isResting = true;
            arr_Orc[6].isResting = false;
            arr_Orc[7].isResting = true;
            arr_Orc[8].isResting = true;
            arr_Orc[9].isResting = false;
            
            for (int i = 0; i < length; i++)
            {
                if (arr_Orc[i].isResting)
                {
                    arr_Orc[i].Jump();
                }
            }

        }
    }




    class Orc

    {

        public string name;

        public float height;

        public float weight;

        public int age;

        public char genderChar;

        public bool isResting;



        public void Smash()

        {

            Console.WriteLine($"{name} (이)가 휘둘렀다!");

        }

        public void Jump()

        {

            Console.WriteLine($"{name} (이)가 점프했다!");

        }



        public void Dash()

        {

            Console.WriteLine($"{name} (이)가 돌진했다");

        }



        public void CheckIsRestingAndDash()

        {

            if (isResting)

            {

                Dash();

            }

            else

            {

                Console.WriteLine($"{name} (이)는 바빠서 돌진을 할 수가 없다");

            }

        }



    }

} 

}
