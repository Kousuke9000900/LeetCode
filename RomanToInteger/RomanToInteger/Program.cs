using System;
using System.Collections.Generic;

namespace RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            int answer;

            Console.WriteLine("ローマ数字を入力して下さい");
            s = Console.ReadLine();
            Program program = new Program();
            answer = program.RomanToInt(s);
            Console.WriteLine("結果は" + answer + "でした。処理を終了します。");
            Console.ReadKey();
        }

        /// <summary>
        /// ローマ数字を算用数字に変換
        /// </summary>
        /// <param name='s'>ローマ数字</param>
        /// <returns>算用数字</returns>
        public int RomanToInt(string s)
        {
            int answer = 0; // 変換結果
            
            // 変換用のリストを作成（辞書型）
            Dictionary<char, int> RomanToIntList = new Dictionary<char, int>();
            RomanToIntList.Add('I', 1);
            RomanToIntList.Add('V', 5);
            RomanToIntList.Add('X', 10);
            RomanToIntList.Add('L', 50);
            RomanToIntList.Add('C', 100);
            RomanToIntList.Add('D', 500);
            RomanToIntList.Add('M', 1000);

            // 引数を一文字ずつに分解
            List<char> Roman = new List<char>();
            foreach (char c in s)
            {
                Roman.Add(c);
            }

            // 1文字のみは計算不要
            if (Roman.Count == 1)
            {
                answer = RomanToIntList[Roman[0]];
                return answer;
            }

            // 加算（Iの次がVかX,Xの次がLかC,Cの次がDかMなら、符号を反転）
            for (int i = 0; i < Roman.Count; i++)
            {                
                if(i != Roman.Count - 1)    // リストの最後か否か
                {
                    if (Roman[i].Equals('I') && (Roman[i + 1].Equals('V') || Roman[i + 1].Equals('X')))

                        answer += RomanToIntList[Roman[i]] * -1;    // 符号反転

                    else if (Roman[i].Equals('X') && (Roman[i + 1].Equals('L') || Roman[i + 1].Equals('C')))
                    {
                        answer += RomanToIntList[Roman[i]] * -1;
                    }

                    else if (Roman[i].Equals('C') && (Roman[i + 1].Equals('D') || Roman[i + 1].Equals('M')))
                    {
                        answer += RomanToIntList[Roman[i]] * -1;
                    }

                    else
                    {
                        answer += RomanToIntList[Roman[i]];
                    }
                }
                else
                {
                    answer += RomanToIntList[Roman[i]];
                }
            }

            return answer;

        }

    }
}
