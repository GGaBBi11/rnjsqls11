using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_HorseRacing
{
    class Horse
    {
        public string name;         // 이름 생성
        public int distance;        // 달린 거리 생성
        public bool dontMove;       // 움직이지말라는 명령체계 생성

        public void Run(int moveDistance) // moveDistance 만큼 달린 거리를 증가시켜주는 함수
        {
            if (dontMove) return;         // return <- 함수를 끝낸다는 선언
            distance += moveDistance;     // 누적 시키는 연산
        }
    }
}
