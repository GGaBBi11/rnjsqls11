using System;

namespace 의사코드_세분화
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*1. 오브젝트 5개(경마 5마리)를 베열에 이름과 객체를 인스턴스화 한다.
            2. 각 5개 오브젝트는 난수를(Random 함수)포함시켜 랜덤하게 일정한 수(이동거리)를 증가시키도록 한다.
            3. 결승지점(100)을 int형으로 지정하고 들어온 오브젝트 순서대로 등수를 정해준다.
            4. 오브젝트의 이동거리를 최소값과 최대값을 int형으로 정해준다.
            5. 오브젝트가 결승지점까지 계속 달리게 해야하므로 for 문 또는 while 같은 반복문을 넣어준다.
            6. 오브젝트가 결승점을 넘었을경우 달리기(반복문)을 중단한다.
            7. 결승지점에 처음들어온 오브젝트 순서대로 1등 2등 3등 단상에 위치시켜준다.*/


         /*   GameObject 리스트에 GameObject 5개 대입
            GameObject 등수 리스트 생성
            Unity Update
            if(게임 진행중일시 반복실행)
            {
                forech 문(GameObject 리스트를 반복)
                {
                    GmaeObject.Position += 랜덤속도
                    if (GameObject.Position > 결승점)
                    {
                        등수 리스트.Add(GameObject)
                }

                }
                if (등수리스트.count > 5)
                {
                    게임 끝
                        등수리스트[0].Position = 1등 단상위치
                        등수리스트[1].Position = 2등 단상위치
                        등수리스트[2].Position = 3등 단상위치
                }
            }*/
            