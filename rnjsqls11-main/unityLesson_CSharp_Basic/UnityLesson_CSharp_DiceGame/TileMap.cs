using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_DiceGame
{
    internal class TileMap
    {
        public Dictionary<int, Tileinfo> Dic_Tile = new Dictionary<int, Tileinfo>();

        public void MapSetup(int maxTileNum)
        {
            for (int i = 0; i < maxTileNum; i++)
            {
                if (i%5 == 0)
                {
                    // 샛별칸 생성
                    Tileinfo tileinfo_Star = new Tileinfo_Star();       //
                    tileinfo_Star.index = i;
                    tileinfo_Star.name = "Star";
                    tileinfo_Star.discription = "This is star tile, you'll get star and star amout on this tile increase 1";
                    Dic_Tile.Add(i, tileinfo_Star);
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
                Console.WriteLine($"Map setup complete. Maximum tile number is {maxTileNum}");
            }
        }
    }
}
