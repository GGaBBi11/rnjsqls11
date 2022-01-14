using System;
using System.Collections.Generic;
/*
엔터키 입력으로 주사위를 굴립니다.
주사위를 굴리면 플레이어가 전진하고, 샛별칸에 도착하거나 지나갈 시 샛별에 대한 이벤트가 발생합니다.
총 칸은 1에서 20까지 있으며, 20을 넘어가면 다시 1부터 전진을 계속합니다.
5배수 칸은 샛별칸이고, 이 칸을 지나거나 도착하면 샛별을 획득할 수 있습니다.
5배수 칸에 도착할 때에는 샛별 획득 개수가 영구적으로 1 증가합니다.
샛별을 획득할 시 , 새로 얻은 샛별 수와 총 획득한 샛별 수를 보여줍니다.

콘솔 출력 :
주사위를 돌려서 어떤 칸에 도착하면,
해당 칸의 번호 (1~20 중 하나 ), 해당 칸이 어떤칸인지 (그냥 일반인지 샛별인지 ),
현재 샛별수는 몇개인지 , 남은 주사위 수는 몇개인지 콘솔창에 출력해주고
다시 주사위를 굴리라고 콘솔창에 출력해줌.
주사위를 다쓰면 모은 샛별 수를 출력해주고 게임을 종료함. (초기 주사위 갯수 20개)

### - Hint

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
Console.WriteLine("└───────────┘");
*/
namespace UnityLesson_CSharp_DiceGame1
{
    internal class Program
    {
        static private int totalTile = 20; // 칸의 갯수
        static private int currentStarPoint = 0; // 샛별 갯수
        static private int totalDiceNumber = 20; // 주사위 갯수
        static private int previousTileIndex = 0; // 이전 칸의 번호 ( 플레이어가 샛별칸을 지나는지 비교하기위함 )
        static private int currentTileIndex = 0; // 현재 칸의 번호
        static private Random random; // 난수 생성용 변수
        static void Main(string[] args)
        {
            TileMap map = new TileMap(); // 맵 클래스 인스턴스화
            map.MapSetup(totalTile); // 맵 생성 (20칸)

            int currentDiceNumber = totalDiceNumber; // 현재 주사위 갯수 초기값은 최대 주사위 갯수
            while (currentDiceNumber > 0)
            {
                int diceValue = RollADice(); // 주사위 굴려서 나온 눈금
                currentDiceNumber--; // 주사위 굴렸으니까 남은 주사위갯수 차감
                currentTileIndex += diceValue; // 주사위 눈금만큼 플레이어 전진

                // 플레이어가 샛별칸을 지날때 (5의 배수칸을 지날때)
                if (previousTileIndex / 5 < currentTileIndex / 5)
                {
                    int passedStartTileIndex = CalcPassedStarTileIndex(currentTileIndex); // 지나온 샛별칸 번호 계산
                    TileInfo passedStarTileInfo = map.dic_tile.GetValueOrDefault(passedStartTileIndex); // 지나온 샛별칸의 TileInfo 가져오기
                    TileInfo_Star passedStarTileInfo_Star = passedStarTileInfo as TileInfo_Star; // TileInfo 타입을 TileInfo_Star 로 인식하겠다.
                    if (passedStarTileInfo_Star != null) // 샛별칸의 TileInfo 정보를 가져오는데 성공했으면
                    {
                        currentStarPoint += passedStarTileInfo_Star.starValue; // 샛별점수 누적
                    }
                }

                if (currentTileIndex > totalTile) // 현재칸이 최대칸을 넘어가 버렸을때
                {
                    currentTileIndex -= totalTile; // 현재칸에다가 최대칸 을 뺀다.
                }

                TileInfo info = map.dic_tile.GetValueOrDefault(currentTileIndex); // map 에서 현재칸의 TileInfo 를 가져옴.
                if (info == null) // 현재칸의 TileInfo 를 가져오지 못했을때는 프로그램을 강제종료한다.
                {
                    Console.WriteLine($"failed to get TileInfo number {currentTileIndex}");
                    return;
                }
                // ================== Override 함수의 성질을 이용한 경우 ==========================
                // TileInfo_Star 로 인식할 필요가 없는 이유:
                // 자식 클래스를 객체화 시킨후에
                // 부모 클래스타입으로 인스턴스화 시키고
                // 해당 인스턴스의 함수를 호출할 때
                // 그 함수가 override 되어있으면,
                // 부모 클래스의 함수가 아닌, 자식클래스의 override 된 함수를 호출한다.
                info.TileEvent();
                
                // ================= Override 를 쓰지않은 경우 (하나하나씩 출력해줘야줘서 불편하다.)====================
/*                string tileMapName = info.name; // 현재 칸의 이름
                switch (tileMapName) // 현재칸의 이름에 따른 분기문
                {
                    case "Dummy": 
                        info.TileEvent(); // 해당 칸의 이벤트 실행
                        break;
                    case "Star":
                        TileInfo_Star infoStar = info as TileInfo_Star; // star tile info 로 인식
                        if (infoStar != null) // 인식에 성공하면
                        {
                            infoStar.TileEvent(); // 해당 칸의 이벤트 실행
                        }
                        else // 실패하면                                                                               0
                        {
                            Console.WriteLine("Map has an error. Exit game"); // 문구출력
                            return; // 강제종료
                        }
                        break;
                    default:
                        return;
                }*/

                previousTileIndex = currentTileIndex;
                Console.WriteLine($"Current Star Point : {currentStarPoint}");
                Console.WriteLine($"Remain Dice number : {currentDiceNumber}");
            }

            Console.WriteLine($"\nFinished! You Got total {currentStarPoint} stars ");

        }

        static private int RollADice()
        {
            string userInput = "Default";
            while (userInput != "")
            {
                Console.WriteLine("Roll a dice ! Press Enter");
                userInput = Console.ReadLine();
            }
            random = new Random(); // 난수 생성용 인스턴스
            int diceValue = random.Next(1, 6 + 1); // 1~6 중 랜덤한 정수
            Console.WriteLine($"Dice Value : {diceValue}");
            DisplayDice(diceValue);
            return diceValue;
        }
        static void DisplayDice(int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("└───────────┘");
                    break;
                case 2:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 3:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 4:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");

                    break;
                case 5:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 6:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                default:
                    break;
            }

        }

        // 현재 칸의 번호를 넣어주면 지나온 샛별칸의 번호를 반환해주는 함수
        static public int CalcPassedStarTileIndex(int currentTileIndex)
        {
            int index = currentTileIndex / 5 * 5;
            return index;
        }
    }
}