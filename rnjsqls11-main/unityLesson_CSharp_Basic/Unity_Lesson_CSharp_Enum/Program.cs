using System;
// enum ( enumerated type) 열거형
// enum 의 기본요소는 모두 int형.
enum e_PlayerState              //enum을 정의하는 기본 형태 .. 
{
    IDLE,       // ...00000000    이진법0                              
    ATTACK,     // ...00000001          1
    JUMP,       // ...00000010          2
    WALK,       // ...00000011          3
    RUN,        // ...00000100          4
    DASH,       // ...00000101          5
    HOME,       // ...00000110          6
          
}

// 비트 단위 열거형을 쓰는이유 : enum 은 요소간의 겹치지 않는것이 전제,
// 열거형은 필요하나 요소가늬 중복이 필요한 경우 비트 단위의 열거형을 씀.
// [Flags] : Flags attiribute (속성) enum 정의 요소자체에 영향을 끼치지 않음.
// 단지 ToString() 속성을 잠초할때 중복되는 요소들에 대해 모든 요소표현가능.
enum e_PlayerStateFlags
{
    IDLE   = 0,                  // ...00000000
    ATTACK = 1 << 0,             // ...00000001
    JUMP   = 1 << 1,             // ...00000010
    WALK   = 1 << 2,             // ...00000100
    RUN    = 1 << 3,             // ...00001000
    DASH   = 1 << 4,             // ...00010000
    HOME    = 1 << 5,            // ...00100000

    JUMP_ATTACK = JUMP | ATTACK, // ...00000011
}

namespace Unity_Lesson_CSharp_Enum
{
    class Program
    {
        static bool doAttack;
        static bool doJump;
        static bool doWalk;
        static bool doRun;
        static bool doDash;
        static bool doHome;

        

        static e_PlayerState creatMotion = e_PlayerState.DASH;



        static void Main(string[] args)
        {
            {
                // Switch - case 분기문
                // if처럼 참/거짓에 따라 분기하지않고 변수의 값에 따라 분기하는 분기문.
                
                // string case 예시
 /*               Console.Write("검색할 캐릭터의 이름을 입력하세요");
                string name = Console.ReadLine();
                switch (name)
                {
                    case "가렌":
                        Console.WriteLine($"{name}(은)는 챔피언입니다.");
                        break;
                    case "헤카림":
                        Console.WriteLine($"{name}(은)는 챔피언입니다.");
                        break;
                    case "티모":
                        Console.WriteLine($"{name}(은)는 챔피언입니다.");
                        break;
                    default:
                        Console.WriteLine($"{name}(은)는 플레이어입니다.");
                        break;
                }*/



                // 전사 생성과 동시에 특정 모션을 취하는 기능
                Warrior warrior1 = new Warrior();
                Console.Write("생성한 전사의 이름을 입력하세요.");
                warrior1.name = Console.ReadLine();

                // 동작 명령
                Console.Write("전사에게 명령을 내려주세요.");
                string motioninput = Console.ReadLine();              
                e_PlayerState motion =  (e_PlayerState)Enum.Parse(typeof(e_PlayerState),motioninput);

                switch (creatMotion)
                {
                    case e_PlayerState.IDLE:
                        break;
                    case e_PlayerState.ATTACK:
                        warrior1.Attack();
                        break;
                    case e_PlayerState.JUMP:
                        warrior1.Jump();
                        break;
                    case e_PlayerState.WALK:
                        warrior1.Walk();
                        break;
                    case e_PlayerState.RUN:
                        warrior1.Run();
                        break;
                    case e_PlayerState.DASH:
                        warrior1.Dash();
                        break;
                    case e_PlayerState.HOME:
                        break;
                    default:
                        Console.WriteLine("실행할수 없는 동작입니다.");
                        break;
                }

                switch (motion)
                    {
                        case e_PlayerState.IDLE:
                            break;
                        case e_PlayerState.ATTACK:
                            warrior1.Attack();
                            break;
                        case e_PlayerState.JUMP:
                            warrior1.Jump();
                            break;
                        case e_PlayerState.WALK:
                            warrior1.Walk();
                            break;
                        case e_PlayerState.RUN:
                            warrior1.Run();
                            break;
                        case e_PlayerState.DASH:
                            warrior1.Dash();
                            break;
                        case e_PlayerState.HOME:
                            break;
                        default:
                            Console.WriteLine("실행할수 없는 동작입니다.");
                            break;
                    }
            }
        }



         


        class Warrior
        {
            public string name;
            public void Attack()
            {
                Console.WriteLine($"{name}(이)가 공격함");
            }
            public void Jump()
            {
                Console.WriteLine($"{name}(이)가 점프함");
            }
            public void Walk()
            {
                Console.WriteLine($"{name}(이)가 걸음");
            }
            public void Run()
            {
                Console.WriteLine($"{name}(이)가 달림");
            }
            public void Dash()
            {
                Console.WriteLine($"{name}(이)가 돌진함");
            }
            public void Home()
            {
                Console.WriteLine($"{name}(이)가 공격함");
            }
        }

    }
}
