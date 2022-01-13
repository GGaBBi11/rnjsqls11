/*
엔터키 입력으로 주사위를 굴립니다.
주사위를 굴리면 플레이어가 전진하고, 샛별칸에 도착하거나 지나갈 시 샛별에 대한 이벤트가 발생합니다.
총 칸은 1에서 20까지 있으며, 20을 넘어가면 다시 1부터 전진을 계속합니다.
5배수 칸은 샛별칸이고, 이 칸을 지나거나 도착하면 샛별을 획득할 수 있습니다.
5배수 칸에 도착할 때에는 샛별 획득 개수가 영구적으로 1 증가합니다.
샛별을 획득할 시 , 새로 얻은 샛별 수와 총 획득한 샛별 수를 보여줍니다.
총 샛별을 30개 획득하면 게임이 종료되고, 사용한 총 주사위 수를 보여줍니다.

콘솔 출력 :
주사위를 돌려서 어떤 칸에 도착하면,
해당 칸의 번호 (1~20 중 하나 ), 해당 칸이 어떤칸인지 (그냥 일반인지 샛별인지 ),
현재 샛별수는 몇개인지 , 남은 주사위 수는 몇개인지 콘솔창에 출력해주고
다시 주사위를 굴리라고 콘솔창에 출력해줌.
주사위를 다쓰면 모은 샛별 수를 출력해주고 게임을 종료함.*/
/*### - Hint

만들어야 하는 클래스 :
TileMap(맵을 세팅하고 맵에대한 정보를 가지고 있을 클래스)
TileInfo(각 칸들의 정보를 멤버로 가지는 클래스)
TileInfo_Star(샛별칸을 위한 클래스.TileInfo 를 상속받고 샛별칸에 대한 특수 정보를 멤버로 추가함)
주사위는 아래처럼 콘솔창에 찍어서 보여주면 됨.
Console.WriteLine("┌───────────┐");
Console.WriteLine("│ ●      ●│");
Console.WriteLine("│           │");
Console.WriteLine("│     ●    │");
Console.WriteLine("│           │");
Console.WriteLine("│ ●      ●│");
Console.WriteLine("└───────────┘");*/
using System;
using System.Collections.Generic;

namespace UnityLesson_CSharp_DiceGame1
{
    internal class Program
    {
        static private int totalTile = 20;          // 칸의 갯수
        static private int currentStarPoint = 0;    // 샛별 갯수
        static private int totalDiceNumber = 20;    // 총 주사위 갯수
        static private int previousTileIndex = 0;   // 이전 칸의 번호 (플레이어가 샛별칸을 지나는지 비교하기 위한 변수 선언)
        static private int currentTileIndex = 0;    // 현재 칸의 번호
        static private Random random;               // 난수 생성용 변수
        static void Main(string[] args)
        {
            TileMap map = new TileMap();             // 맵 클래스 인스턴스화 
            map.MapSetup(totalTile);                 // 맵 생성 

            int currentDiceNumber = totalDiceNumber;  // 현재 주사위 갯수 초기값은 최대 주사위 갯수
            while (currentDiceNumber > 0)             // 주사위를 굴리도록 하는 반복문 생성
            {
                int diceValue = RollaDice();    
                currentDiceNumber--;            // 주사위를 굴릴때 마다 주사위횟수 차감
                currentTileIndex += diceValue;
                // 플레이어가 샛별칸을 지날때
                if (previousTileIndex/5 < currentTileIndex/5)
                {
                    int passsedStarTileIndex = CalcPasssedSTarTileIndex(currentTileIndex);  // 지나온 샛별칸 번호 계산
                    Tileinfo passedStarTileInfo = map.Dic_Tile.GetValueOrDefault(passsedStarTileIndex);    // 지나온 샛별칸의 TIleInfo 가져오기
                    Tileinfo_Star passsedTileinfo_Star = passedStarTileInfo as Tileinfo_Star;     // TileInfo 타입을 TileInfo_Star 로 인식하겠다.
                    if (passsedTileinfo_Star != null)    // TileInfo 정보를 가져오는데 성공했으면 발생하는 조건문
                    {
                        currentStarPoint += passsedTileinfo_Star.starValue;
                    }
                }
                if (currentTileIndex > totalTile)       // 현재칸이 최대칸을 넘어가버렸을때.
                {
                    currentTileIndex -= totalTile;
                }

                Tileinfo info = map.Dic_Tile.GetValueOrDefault(currentTileIndex);
                if (info != null)   // 현재칸의  TileInfo 를 가져오지 못했을때는 프로그램을 강제종료.
                    return;
                Console.WriteLine($"Tile Index : {currentTileIndex}");      // 현재 칸의 번호 출력
                string tileMapName = info.name; // 현재 칸의 이름

                switch (tileMapName)            // 현재칸의 이름에 따른 분기문
                {
                    case "Dummy":
                        break;
                    case "Star":
                        break;
                    default:
                        return;
                }
            }
        }

        static private int RollaDice()          // 주사위를 굴렸을때 눈금값을 넣어주는 함수 선언
        {
            string userInput = "default";             // 주사위 동작값 생성 (엔터키)
            while (userInput != "")                   // 
            {
                Console.WriteLine("Roll a dilce Press Enter");       // 주사위를 굴리라는 출력문 선언
                userInput = Console.ReadLine();                      // 엔터키를 누르면 주사위를 발생하도록 ConsoleReadLine으로 명령체계 선언
            }
            random = new Random();                                    // 난수 생성용 인스턴스화
            int diceValue = random.Next(1, 6 + 1);
            return diceValue;                                         // 초기화
        }

        // 현재 칸의 번호를 넣어주면 지나온 샛별칸의 번호를 반환해주는 함수
        static public int CalcPasssedSTarTileIndex(int cerrentTileIndex)
        {
            int index = cerrentTileIndex / 5 * 5;
            return index;
        }
    }
}
