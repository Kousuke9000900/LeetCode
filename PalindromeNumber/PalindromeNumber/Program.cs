using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            bool answer;

            Console.WriteLine("整数を入力して下さい");
            x = int.Parse(Console.ReadLine());
            Program program = new Program();
            answer = program.IsParindromeString(x);
            Console.WriteLine("結果は" + answer + "でした。処理を終了します。");
            Console.ReadKey();
        }

        /// <summary>
        /// 整数が回文かチェック
        /// </summary>
        /// <param name="x">対象の整数</param>
        /// <returns>true:回文 false:回文ではない</returns>
        public bool IsPalindrome(int x)
        {
            int xOriginal = x;  // 元の整数
            long xReversed = 0; // 逆になった整数
            int xDigit = 1;     // 引数の桁数

            // 計算の必要が無い数
            if (x == 0)
            {
                return true;
            }
            else if(x < 0)
            {
                return false;
            }

            // 引数の桁数を算出
            for (long i = Math.Abs((long)x); i >= 10; i /= 10)   // 10で除算した回数で調査（絶対値）
            {
                xDigit++;
            }

            // 桁数分、各数値の入れ替え
            for (int i = xDigit; i > 0; i--)
            {
                xReversed += x % 10 * (long)Math.Pow(10, i - 1); // （各数値 * 桁を確定する数値（2桁なら10））
                x = x / 10; // 桁をずらす

            }

            // 元の数と逆を比較
            if (xOriginal == xReversed)
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 整数が回文かチェック（文字列に変換してチェック）
        /// </summary>
        /// <param name="x">対象の整数</param>
        /// <returns>true:回文 false:回文ではない</returns>
        public bool IsParindromeString(int x)
        {
            String xString = x.ToString();                              // 元の整数
            String xReverseString = String.Concat(xString.Reverse());   // 反転した整数

            // 負の数は回文にならない
            if (x < 0)
            {
                return false;
            }

            // 元の数と逆を比較
            if (xString == xReverseString)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
