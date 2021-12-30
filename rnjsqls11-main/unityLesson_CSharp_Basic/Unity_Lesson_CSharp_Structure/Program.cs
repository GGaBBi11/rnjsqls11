using System;
// structure (자료형)
// 변수들의 집합을 하나의 자료형으로 표현
// 변수들을 여러가지를 써야하는데, 해당 변수를 사용한 곳이 많거나 변수 집한의 요소가 너무많아,
// 묶어서 따로 분리해야 가독성과 관리가 편할것 같을때 사용한다.
// 구조는 클래스에서 함수가 빠진것과 같다.

namespace Unity_Lesson_CSharp_Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            // 객체의 구조체 멤버변수의 멤버를 초기화
            Warrior warrior = new Warrior();
            warrior._stats._STR = 10;           // 객체._맴버변수_.맴버변수 = 10의값을 부여.
            warrior._stats._DEX = 20;
            warrior._stats._CON = 30;
            warrior._stats._WIS = 40;
            warrior._stats._INT = 50;
            warrior._stats._REG = 60;

            // 객체의 구조체 멤버 변수를 초기화
            Stats stats_Warrior = new Stats();
            stats_Warrior._STR = 100;
            stats_Warrior._DEX = 200;
            stats_Warrior._CON = 300;
            stats_Warrior._WIS = 400;
            stats_Warrior._INT = 500;
            stats_Warrior._REG = 600;

            Warrior[] arr_Warrior = new Warrior[1];
            int length = arr_Warrior.Length;
            for (int i = 0; i < length; i++)
            {
                arr_Warrior[i] = new Warrior();
                arr_Warrior[i]._stats = stats_Warrior;
            }

            for (int i = 0; i < length; i++)
            {
                arr_Warrior[i].SetStats(100,200,300,400,500,600);
            }

            Equipment equipment = new Equipment();
            equipment._equipmentAbility._ATK = 100;

            
        }
        
    }
}
