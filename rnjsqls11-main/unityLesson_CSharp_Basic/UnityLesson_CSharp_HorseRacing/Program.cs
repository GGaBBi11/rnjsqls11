/*
프로그램 시작시
말 다섯마리를 만들고
각 다섯마리는 초당 10-20 (정수형) 범위 거리를 랜덤하게 움직임
각각의 말이 거리 200에 도달하면 말의 이름과 등수를 출력해줌

말은
이름, 달린거리 를 멤버변수로
달리기를 멤버 함수로 가짐.
달리기 멤버함수는 입력받은 거리를 달린거리에 더해 주어서 달린거리를 누적시키는 역할을 함.

매초 달릴 때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.

System.Threading samespace 에 있는 Thread,Sleep(1000); 를 사용하면 현재 프로그램을 1초 지연시킬수 있음
While 반복문에서 Thread.Sleep(1000); 을 추가하면 1초에 한번씩 반복문을 실행함.
*/
namespace UnityLesson_CSharp_HorseRacing
{

    class Program
    {
        static Random random;               // 말이 랜덤하게 움직일수있는 명령체계 설정(함수 선언)
        static int minSpeed = 10;           // 말의 최소 움직임
        static int maxSpeed = 20;           // 말의 쵀대 움직임
        static int finishDistance = 200;    // 결승점거리
        static bool isGameFinished = false; // 경주가 끝나면 말이 더이상 움직이 않도록 bool형식 변수 선언

        static void Main(string[] args)
        {
            Horse[] arr_Horse = new Horse[5];               // 인스턴스화 (말을 5마리를 배열로 생성)
            string[] arr_FinishedHorseName = new string[5]; // 경주가 끝난말 이름 인스턴스화 (배열로 생성)
            int currentGrade = 1;                           // 등수

            int length = arr_Horse.Length;    // 말들이 저장된 배열의 길이 ,Length 를 직접넣는건 좋지않다.
            for (int i = 0; i < length; i++)  // 말들을 인스턴스화 시키고, 말들의 이름을 초기화 하는 for문
            {
                arr_Horse[i] = new Horse();       // 말 인스턴스화
                arr_Horse[i].name = "경주마" + i; // 말의 이름 쵝화
            }
            Console.WriteLine("경주 시작!");      
            int count = 0;                          // while문이 돈 횟수.
            while (isGameFinished == false)         // while의 조건 게임 끝날때까지 반복하는 조건(false)
            {
                Console.WriteLine($" ================ {count}초 ================ ");    // 1초에 1씩 올라감.
              // 1초에 1씩 올라가는 이유 : while문 마지막 Thread.Sleep(1000) 으로 1초 지연 명령문이 있기 떄문.

                for (int i = 0; i < length; i++)        // 랜덤한 속도로 말을 달리게하는 반복문
                {
                    if (arr_Horse[i].dontMove == false) // i 번째 말이 말이 움직일수 있으면
                    {
                        random = new Random();          // 난수용 인스턴스화
                        int tmpMoveDistance = random.Next(minSpeed, maxSpeed + 1); // minSpeed부터 maxSpeed 까지 범위내의 난수생성
                        arr_Horse[i].Run(tmpMoveDistance);                         // i 번째 말을 tmpMoveDistance(10~20사이 정수)만큼 달림.
                        Console.WriteLine($"{arr_Horse[i].name}가 달린거리 : {arr_Horse[i].distance}"); // i 번째 말 이름 가 달린거리 i 번째 말이 달린거리 출력
                        if (arr_Horse[i].distance >= finishDistance) // if문 조건: i 번째 말이 결승점거리보다 같거나 클때(i 번째 말이 결승점에 통과했다는 해석)                        
                        {
                            arr_Horse[i].dontMove = true;                                   // i 번째 말이 달리지 않도록 멈춤 (true로 인한 조건문 탈출)
                            arr_FinishedHorseName[currentGrade - 1] = arr_Horse[i].name;    // 결승점에 도착한 말의 이름을 현재 등수 -1 번째 자리에 저장 
                                                                                            // -1 을 해주는 이유 : 현재등수는 1로 초기화 했기때문
                            currentGrade++;                                                 // 현재 등수를 1씩 증가
                        }
                    }
                }
                if (currentGrade > 5)                   // 현재 등수가 5보다 크면 즉, 1에서 5등까지 전부 결승점에 들어왔으면 발생하는 조건문
                {                                       // (게임이 끝났다는 해석)
                    isGameFinished = true;              // true문으로 인한 반복문 탈출
                    Console.WriteLine("경주 종료!");
                    break;                              // while문 탈출
                }

                Thread.Sleep(1000);         // 1000 ms = 1 sec 1초 지연
                count++;                    // 1초의 1씩 증감연산 (while문이 돌은 횟수 증가)
            }

            Console.WriteLine("=====결과 발표=====");
            for (int i = 0; i < length+1; i++)                                  // 경주가 끝난 말의 이름을 등수대로 출력해주는 반복문
            {
                Console.WriteLine($"{i + 1} 등 : {arr_FinishedHorseName[i]}");  // 
            }
        }

    }
}
  