using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            // 試行用のプログラム
            string[] testArgment = new string[2] {"aa","ab"};
            Console.WriteLine("抽出した文字列は" + LongestCommonPrefix(testArgment) + "でした");
            Console.ReadKey();
        }

        /// <summary>
        /// 配列内の要素で共通する接頭語を取り出す
        /// </summary>
        /// <param name="strs">対象の配列</param>
        /// <returns>取り出した共通の接頭語</returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            int leastWordCount = 0;         // 配列内で最も少ない文字数
            string commonPrefix = "";       // 共通する接頭語          
            int currentCharacterNumber = 0; // 比較する文字列目

            // 空文字確認（空文字が含まれていれば共通の接頭語は存在しない）
            foreach (string str in strs)
            {
                if (str == "")
                {
                    return commonPrefix;
                }
            }

            // 接頭語の文字数を算出
            for (int i = 0; i < strs.Length; i++)
            {
                // 最小値を算出（最初のみ強制代入）
                if (leastWordCount == 0 || leastWordCount > strs[i].Length)
                {
                    leastWordCount = strs[i].Length;   // 文字数
                }                
            }            

            // 接頭語取り出し（最低限最小値分試行が必要）
            for (int i = 0; i < leastWordCount; i++)
            {
                string firsrCharacter;
                firsrCharacter = strs[0].Substring(i, 1);

                // 比較
                for(int j = 0; j < strs.Length; j++)
                {
                    string compareStr;
                    compareStr = strs[j].Substring(currentCharacterNumber, 1);  // 比較する文字列を取得

                    if (compareStr.IndexOf(firsrCharacter) == -1)  // 該当しない場合は-1
                    {
                        return commonPrefix;    // 終了時点で返す
                    }

                }
                commonPrefix += firsrCharacter; // 共通する1文字
                currentCharacterNumber++;
            }
            return commonPrefix;
        }
    }
}
