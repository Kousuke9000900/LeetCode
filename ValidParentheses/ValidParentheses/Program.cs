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
            string testArgment = "{[]}";
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
        public bool IsValid(string s)
        {
            // 強制的にfalseのパターン→1.最初が閉じ 2.1文字のみ 3.開きが存在しない 4.閉じが存在しない
            string currentParenthesis = String.Empty;
            string subStringS = s;

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
            }

            // 対応する括弧か確認
            for (int i = 0; i < s.Length; i++)
            {
                // 括弧抽出
                currentParenthesis = subStringS.Substring(i, 1);
                string firstParenthesis;                

                // 括弧が閉じか確認
                switch (currentParenthesis)
                {
                    case ")":                        
                        firstParenthesis = subStringS.Substring(i - 1, 1);  // 最も内側の括弧開き
                        if (firstParenthesis != "(")
                        {
                            return false;
                        }
                        else
                        {
                            subStringS = subStringS.Substring(i - 1, 2); // 確認後の括弧を削除
                        }
                        break;

                    case "]":
                        firstParenthesis = subStringS.Substring(i - 1, 1);  // 最も内側の括弧開き
                        if (firstParenthesis != "[")
                        {
                            return false;
                        }
                        else
                        {
                            subStringS =  subStringS.Substring(i - 1, 2); // 確認後の括弧を削除
                        }
                        break;

                    case "}":
                        firstParenthesis = subStringS.Substring(i - 1, 1);  // 最も内側の括弧開き
                        if (firstParenthesis != "{")
                        {
                            return false;
                        }
                        else
                        {
                            subStringS =  subStringS.Substring(i - 1, 2); // 確認後の括弧を削除
                        }
                        break;
                }                

            }

            return true;
        }
    }
}
