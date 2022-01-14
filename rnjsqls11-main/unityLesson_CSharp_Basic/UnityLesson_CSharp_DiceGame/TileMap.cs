using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_DiceGame1
{
    internal class TileMap  
    {
        public Dictionary<int, TileInfo> dic_tile = new Dictionary<int, TileInfo>();    // 칸 번호, 칸 정보 를 저장할 사전

        public void MapSetup(int maxTileNum)        // maxTileNum 만큼 칸을 생성하는 함수
        {
            for (int i = 1; i <= maxTileNum; i++)    // 
            {
                if (i%5 == 0)
                {
                    // 샛별칸 생성
                    TileInfo tileinfo_Star = new TileInfo_Star(); // 원래는 Tileinfo_Star로 인스턴스화 시켜야하지만
                                                                  // 상속을 받앗기 때문에 Tileinfo로 인스턴스화 시킴
                    tileinfo_Star.index = i;                      // 샛별칸을 i로 초기화
                    tileinfo_Star.name = "Star";                  // 샛별칸 이름
                    tileinfo_Star.discription = "This is star tile, you'll get star and star amout on this tile increase 1"; // 샛별칸으로 갈시 설명
                    dic_tile.Add(i, tileinfo_Star); // 샛별 증가
                }
                else
                {
                    // 일반칸 생성
                    TileInfo tileinfo_Dummy = new TileInfo();   
                    tileinfo_Dummy.index = i;
                    tileinfo_Dummy.name = "Dummy";
                    tileinfo_Dummy.discription = "This is Dummy Tile";
                    dic_tile.Add(i, tileinfo_Dummy);
                }
            }
            Console.WriteLine($"Map setup complete. Maximum tile number is {maxTileNum}"); // 맵이 생성되었다는 출력해주는 함수
        }
    }
}
