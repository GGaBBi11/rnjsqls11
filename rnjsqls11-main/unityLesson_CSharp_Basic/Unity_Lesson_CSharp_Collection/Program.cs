using System;
using System.Collections.Generic;       // Generic < 타입의 상관없이 데이터를 넣을수 있는

namespace Unity_Lesson_CSharp_Collection
{
    class Program
    {
        // Collection << 동적 데이터

        // 동적 데이터의 종류 : List , Dictionary, stack , Queue
        static void Main(string[] args)
        {
            Console.WriteLine("list");

            List<int> _list = new List<int>();      // <> 안의 t는 Generic을 말함. 
            _list.Add(3);                           // Add < int 타입 추가
            _list.Add(2);
            _list.Add(1);
            _list.Add(0);
            _list.Add(3);
            _list.Add(4);

            // 0번째 인덱스부터 탐색하고 , 첫번째로 인자와 같은 요소를 발견하면 삭제.
            // 삭제 성공시 true 반환, 인자와 같은 요소를 못찾으면서 false 반환.
            // Remove 라는 함수는 맨처음 삭제할것을 탐색을 하면 그다음것은 삭제를 안한다.
            _list.Remove(3);
            _list.Remove(1);
            int lenght = _list.Count;
            for (int i = 0; i < lenght; i++)
            {
                int tmpNumber = _list[i];
                Console.WriteLine(tmpNumber);
            }
                Console.WriteLine("\nforeach");
            foreach (var num in _list)
            {
                Console.WriteLine(num);
            }

            // Dictionnary
            Console.WriteLine("\nDictionary");

            // 선언하면 각아이템의 대한 정의를 설명해준다.
            Dictionary<string, string> _dic = new Dictionary<string, string>();
            _dic.Add("검사", "양손대검을 사용하여 물리공격을 하는 클래스.");
            _dic.Add("마법사", "지팡이를 사용하여 마법공격을 하는 클래스.");
            _dic.Add("수호자", "창과 방패를 사용하여 물리공격및 방어 위주의 클래스.");
            // ContanisKey dic에 선언한것들중 참과 거짓을 판별함.
            // true면 출력을 해줌

            bool isSwordMasterExist = _dic.ContainsKey("검사");
            bool magiction = _dic.ContainsKey("메지션");
            if (isSwordMasterExist)
            {
                string tmpValue = _dic["검사"];
                Console.WriteLine($"검사 : {tmpValue}");
            }
            else
            {
                Console.WriteLine("검사를 찾을수 없습니다.");
            }
            if (magiction)
            {
                string tmpValue = _dic["메지션"];
                Console.WriteLine($"메지션 : {tmpValue}");
            }
            else
            {
                Console.WriteLine("메지션을 찾을수 없습니다.");
            }

            Console.WriteLine("\nAll Class");
            foreach (string sub in _dic.Keys)         // 모든 키워드를 불러옴
            {
                string tmpValue = _dic[sub];
                Console.WriteLine($"{sub}: {tmpValue}");
            }

            foreach (string sub in _dic.Values)
            {
                Console.WriteLine(sub);
            }

            foreach (var item in _dic)  // var < 모든 타입을 선언할수있음. 단 명확하게 알기 힘들기 떄문에 일반적으로 안쓰임
            {

            }

            foreach (KeyValuePair<string, string> sub in _dic)
            {
                string tmpKey = sub.Key;
                string tmpValue = sub.Value;
                Console.WriteLine($"{tmpKey} : {tmpValue}");
            }



            // _dic.Remove("검사"); // dic_Remove key와 그의 대한 정의 까지 탐색해 삭제해준다.
            //=================================================================================
            // Queue // (List와 비슷하나, FIFO (Firest Input, First Ouput) 체계이다)
            //=================================================================================

            Console.WriteLine("\nQueue");

            Queue<int> _queue = new Queue<int>();

            _queue.Enqueue(10); 
            _queue.Enqueue(20);
            _queue.Enqueue(30);

            Console.WriteLine(_queue.Peek());       // 가장 첫번째에 있는 값을 반환
            Console.WriteLine(_queue.Dequeue());    // 가장 첫번째에 있는 값을 제거하고 반환
            Console.WriteLine(_queue.Dequeue());
            Console.WriteLine(_queue.Dequeue());

            //=================================================================================
            // Stack (List와 비슷하나 , LIFO(Last Input, First Output 체계이다.))
            //=================================================================================

            Console.WriteLine("\nStack");
            Stack<int> _stack = new Stack<int>();

            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);
         
            Console.WriteLine(_stack.Peek());   // 가장 마지막에 있는 값을 반환 (Queue의 반대)
            Console.WriteLine(_stack.Pop());
            Console.WriteLine(_stack.Pop());
            Console.WriteLine(_stack.Pop());
        }
    }
}
