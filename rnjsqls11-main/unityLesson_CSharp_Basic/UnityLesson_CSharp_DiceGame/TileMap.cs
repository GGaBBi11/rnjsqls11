using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_DiceGame1
{
    internal class TileMap
    {
        public Dictionary<int, Tileinfo> Dic_Tile = new Dictionary<int, Tileinfo>();    // 칸 번호, 칸 정보 를 저장할 사전

        public void MapSetup(int maxTileNum)    // maxTileNum 만큼 칸을 생성하는 함수
        {
            for (int i = 0; i < maxTileNum; i++)
            {
                if (i%5 == 0)
                {
                    // 샛별칸 생성
                    Tileinfo tileinfo_Star = new Tileinfo_Star(); // 원래는 Tileinfo_Star로 인스턴스화 시켜야하지만
                                                                  // 상속을 받앗기 때문에 Tileinfo로 인스턴스화 시킴
                    tileinfo_Star.index = i;                      // 샛별칸을 i로 초기화
                    tileinfo_Star.name = "Star";                  // 샛별칸 이름
                    tileinfo_Star.discription = "This is star tile, you'll get star and star amout on this tile increase 1"; // 샛별칸으로 갈시 설명
                    Dic_Tile.Add(i, tileinfo_Star); // 샛별 증가
                }
                else
                {
                    // 일반칸 생성
                    Tileinfo tileinfo_Dummy = new Tileinfo();   
                    tileinfo_Dummy.index = i;
                    tileinfo_Dummy.name = "Dummy";
                    tileinfo_Dummy.discription = "This is Dummy Tile";
                    Dic_Tile.Add(i, tileinfo_Dummy);
                }
            }
            Console.WriteLine($"Map setup complete. Maximum tile number is {maxTileNum}");
        }
    }
}
