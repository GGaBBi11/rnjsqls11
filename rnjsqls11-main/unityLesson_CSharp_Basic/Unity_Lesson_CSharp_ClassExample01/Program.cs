using System;

namespace Unity_Lesson_CSharp_ClassExample01
{
    class Program
    {

        static void Main(string[] args)
        {
            Orc orc1 = new Orc();
            orc1.name = "상급오크";
            orc1.height = 240.2f;
            orc1.weight = 200.0f;
            orc1.age = 140;
            orc1.genderChar = '남';
            orc1.isResting = false;

            Orc orc2 = new Orc();
            orc2.name = "하급오크";
            orc2.height = 140.4f;
            orc2.weight = 120.0f;
            orc2.age = 60;
            orc2.genderChar = '여';
            orc2.isResting = true;

            orc1.Jump();
            orc1.Smash();
            orc2.Jump();
            orc2.Smash();

            if (orc1.isResting)
            {
                orc1.Jump();
                orc1.Smash();
            }
            else 
            {
                Console.WriteLine($"{orc1.name}은 바쁘다");
            }
            if (orc2.isResting)
            {
                orc2.Jump();
                orc2.Smash();
            }
            else
            {
                Console.WriteLine($"{orc2.name}은 바쁘다");
            }
        }
    }
    class Orc
    {
        public string name;         //이름
        public float height;        //키
        public float weight;        //몸무게
        public int age;             //나이
        public char genderChar;     //성별
        public bool isResting;       //쉬고있는지?

        public void Smash() 
        {
            Console.WriteLine($"{name} (이)가 휘둘렀다.");
        }
        public void Jump() 
        {
            Console.WriteLine($"{name} 점프했다.");
        }
    }

    class orc2 
    {
        public string name;          //이름
        public float height;         //키
        public float weight;         //몸무게
        public int age;              //나이
        public char genderChar;      //성별
        public bool isFemale;        //쉬고있는지?

        public void Smash()
        {
            Console.WriteLine("");
        }
        public void Jump()
        {
            Console.WriteLine("");
        }
    }
}