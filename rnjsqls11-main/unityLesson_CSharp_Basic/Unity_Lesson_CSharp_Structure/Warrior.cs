using System;


namespace Unity_Lesson_CSharp_Structure
{
    class Warrior
    {
        public Stats _stats;

        public void SetStats(int STR, int DEX, int CON ,int WIS, int INT, int REG)
        {
            _stats._STR = STR;
            _stats._DEX = DEX;
            _stats._CON = CON;
            _stats._WIS = WIS;
            _stats._INT = INT;
            _stats._REG = REG;
        }


    }


}
