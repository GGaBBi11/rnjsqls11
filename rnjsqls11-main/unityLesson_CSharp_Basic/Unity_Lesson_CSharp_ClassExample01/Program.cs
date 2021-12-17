using System;


namespace Unity_Lesson_CSharp_ClassExample01
{

    class Program // 오크 출력 프로그램
    {
        static void Main(string[] args) // 오크 출력 메인 함수
        {
            Orc orc1 = new Orc();

            orc1.name = "상급 오크"; //이름
            orc1.height = 240.4f;      //키
            orc1.weight = 200.1f;      //몸무게
            orc1.age = 140;         //나이
            orc1.genderChar = '남';        //성별 
            orc1.isResting = false;       //쉬고있는지?

            orc1.Information();


            Orc_02 orc2 = new Orc_02();

            orc2.name = "하급 오크";        //이름
            orc2.height = 200.4f;           //키 
            orc2.weight = 160.5f;           //몸무게
            orc2.age = 100;                 //나이
            orc2.genderChar = '여';         //성별
            orc2.isResting = true;          //쉬고있는지?

            orc2.Information();




            if (orc1.isResting) // 참과 거짓 조건 소스 코드
            {
                orc1.Smash();
            }
            else if (orc1.isResting)
            {
                orc1.Jump();
            }
            else
            {
                Console.WriteLine($"\n{orc1.name}은 바쁘다.");
            }
            if (orc2.isResting)
            {
                orc2.Smash();
            }
            else if (orc2.isResting)
            {
                orc2.Jump();
            }
            else
            {
                Console.WriteLine($"\n{orc2.name}(은)는 바쁘다.");
            }
        }
    }

    class Orc // 오크 클래스 설계도 프로그램
    {
        public string name;      // 이름
        public float height;     // 키
        public float weight;     // 몸무게
        public int age;          // 나이
        public char genderChar;  // 성별
        public bool isResting;   // 쉬고있는지?

        public void Information() // 오크 정보 출력 소스코드
        {
            이름();
            키();
            몸무게();
            나이();
            성별();
            쉬고있는지();
        }
        public void 이름()
        {
            Console.WriteLine($"이름\t:{name}");
        }
        public void 키()
        {
            Console.WriteLine($"키\t:{height}");
        }
        public void 몸무게()
        {
            Console.WriteLine($"몸무게\t:{weight}");
        }
        public void 나이()
        {
            Console.WriteLine($"나이\t:{age}");
        }
        public void 성별()
        {
            Console.WriteLine($"성별\t:{genderChar}");
        }
        public void 쉬고있는지()
        {
            Console.WriteLine($"쉬고있다:{isResting}");
        }
        public void Smash()
        {
            Console.WriteLine($"\n{name}(이)가 휘둘렀다.");
        }
        public void Jump()
        {
            Console.WriteLine($"{name}(이)가 점프했다.");
        }

    }

    class Orc_02 // 오크2 클래스 설계도
    {
        public string name;      // 이름
        public float height;     // 키
        public float weight;     // 몸무게
        public int age;          // 나이
        public char genderChar;  // 성별
        public bool isResting;   // 쉬고있는지?

        public void Information() // 오크2 정보 출력 소스코드
        {
            이름();
            키();
            몸무게();
            나이();
            성별();
            쉬고있는지();
        }
        public void 이름()
        {
            Console.WriteLine($"\n이름\t:{name}");
        }
        public void 키()
        {
            Console.WriteLine($"키\t:{height}");
        }
        public void 몸무게()
        {
            Console.WriteLine($"몸무게\t:{weight}");
        }
        public void 나이()
        {
            Console.WriteLine($"나이\t:{age}");
        }
        public void 성별()
        {
            Console.WriteLine($"성별\t:{genderChar}");
        }
        public void 쉬고있는지()
        {
            Console.WriteLine($"쉬고있다:{isResting}");
        }
        public void Smash()
        {
            Console.WriteLine($"{name}(이)가 휘둘렀다.");
        }
        public void Jump()
        {
            Console.WriteLine($"{name}(이)가 점프했다.");
        }
    }
}