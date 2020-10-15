using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            // 試行用のプログラム
            string testArgment = "(){}}{";
            Program program = new Program();
            Console.WriteLine("試行結果は" + program.IsValid(testArgment) + "でした");
            Console.ReadKey();
        }

        /// <summary>
        /// 括弧が正しい組合せか確認
        /// </summary>
        /// <param name="s">括弧の組合せ</param>
        /// <returns>true:正しい括弧の組合せ false:不正な括弧の組合せ</returns>
        /// <remarks>例→():true ([)]→false: (]→false</remarks>
        /// <remarks>leetcode内のテストケースを694msで通過（相当遅い）</remarks>
        public bool IsValid(string s)
        {
            // 強制的にfalseのパターン→1.最初が閉じ 2.1文字のみ 3.開きが存在しない 4.閉じが存在しない 5.開きと閉じの個数が一致しない
            string currentParenthesis = String.Empty;   // 現在の括弧一文字
            string subStringS = s;                      // 検証する括弧（検証時に切り取る）
            int currentWordCount = 0;                   // 現在の文字数

            currentParenthesis = s.Substring(0,1);
            if (currentParenthesis == ")" || currentParenthesis == "]" || currentParenthesis == "}")
            {
                return false;
            } else if (s.Length == 1)
            {
                return false;
            } else if (s.IndexOf("(") == -1 && s.IndexOf("[") == -1 && s.IndexOf("{") == -1)
            {
                return false;
            } else if (s.IndexOf(")") == -1 && s.IndexOf("]") == -1 && s.IndexOf("}") == -1)
            {
                return false;
            } else if (s.Replace("(","").Length + s.Replace("[", "").Length + s.Replace("{", "").Length != s.Replace(")", "").Length + s.Replace("]", "").Length + s.Replace("}", "").Length)
            {
                return false;
            }

            // 対応する括弧か確認（確認した括弧は削除）
                for (int i = 0; i < subStringS.Length; i++) // 括弧が全て削除されるまで実行
            {
                // 括弧抽出
                currentParenthesis = subStringS.Substring(currentWordCount, 1);
                string firstParenthesis;                

                // 括弧が閉じか確認
                switch (currentParenthesis)
                {
                    case ")":
                        if (currentWordCount == 0)  // 最初が閉じ→対応する開きは存在しない
                        {
                            return false;
                        }

                        // 最も内側の括弧開きを確認
                        firstParenthesis = subStringS.Substring(currentWordCount - 1, 1);
                        if (firstParenthesis != "(")
                        {
                            return false;
                        }
                        else
                        {
                            subStringS = subStringS.Remove(currentWordCount - 1, 2); // ()を削除
                            // 初期化
                            currentWordCount = 0;
                            i = -1; // i = 0で再度処理する為
                        }
                        break;

                    case "]":
                        if (currentWordCount == 0)  // 最初が閉じ→対応する開きは存在しない
                        {
                            return false;
                        }

                        // 最も内側の括弧開きを確認
                        firstParenthesis = subStringS.Substring(currentWordCount - 1, 1);
                        if (firstParenthesis != "[")
                        {
                            return false;
                        }
                        else
                        {
                            subStringS = subStringS.Remove(currentWordCount - 1, 2); // []を削除
                            // 初期化
                            currentWordCount = 0;
                            i = -1; // i = 0で再度処理する為
                        }
                        break;

                    case "}":
                        if (currentWordCount == 0)  // 最初が閉じ→対応する開きは存在しない
                        {
                            return false;
                        }

                        // 最も内側の括弧開きを確認
                        firstParenthesis = subStringS.Substring(currentWordCount - 1, 1);  
                        if (firstParenthesis != "{")
                        {
                            return false;
                        }
                        else
                        {
                            subStringS = subStringS.Remove(currentWordCount - 1, 2); // {}を削除
                            // 初期化
                            currentWordCount = 0;
                            i = -1; // i = 0で再度処理する為
                        }
                        break;

                    default:
                        currentWordCount++;
                        break;
                }                     
            }
            return true;

            // 最も多い解答例
            //Stack<char> stack = new Stack<char>();    スタックを使用

            //foreach (char c in s.ToCharArray())   sから一文字ずつ取り出す
            //{
            //    if (c == '(' || c == '{' || c == '[') 開きの場合スタックに格納
            //    {
            //        stack.Push(c);
            //    }
            //    else if (c == ')' && stack.Count != 0 && stack.Peek() == '(') 閉じでかつスタック内のデータ数が0ではない（開きが既にある）かつ中のデータが閉じに対応する開き→スタックから取り出す
            //    {
            //        stack.Pop();
            //    }
            //    else if (c == '}' && stack.Count != 0 && stack.Peek() == '{')
            //    {
            //        stack.Pop();
            //    }
            //    else if (c == ']' && stack.Count != 0 && stack.Peek() == '[')
            //    {
            //        stack.Pop();
            //    }
            //    else
            //    {
            //        return false;
            //    }


            //}

            //return stack.Count == 0;  全て対応しているなら、スタック内のデータ数は0になっている
        }
    }
}
