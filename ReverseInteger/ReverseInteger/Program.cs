using System;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int answer;

            Console.WriteLine("整数を入力して下さい");
            x = int.Parse(Console.ReadLine());
            Program program = new Program();
            answer = program.Reverse(x);
            Console.WriteLine("結果は" + answer + "でした。処理を終了します。");
            Console.ReadKey();
        }

        /// <summary>
        /// 引数を逆にして返す
        /// </summary>
        /// <param name="x">対象の整数</param>
        /// <returns>逆になった整数（例:123→321）</returns>
        /// <remarks>桁あふれは0を返す</remarks>
        public int Reverse(int x)
        {            
            long xAnswer = 0;   // 回答
            int xDigit = 1;     // 引数の桁数

            // 引数の桁数を算出
            for (long i = Math.Abs((long)x); i >= 10; i /= 10)   // 10で除算した回数で調査（絶対値）
            {
                xDigit++;
            }

            // 桁数分、各数値の入れ替え
            for (int i = xDigit; i > 0; i--)
            {
                xAnswer += x % 10 * (long)Math.Pow(10, i - 1); // （各数値 * 桁を確定する数値（2桁なら10））
                x = x / 10; // 桁をずらす

            }

            // 桁あふれ
            if (xAnswer > int.MaxValue || xAnswer < int.MinValue)
            {
                return 0;
            }

            return (int)xAnswer;
            
        }
    }
}
