using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Sum
{
    class Program
    {
        /// <summary>
        /// 配列の2要素を加算し、特定の数値になる組合せのインデックスを返す
        /// </summary>
        /// <param name="nums">加算する配列</param>
        /// <param name="target">特定の数値</param>
        /// <returns>特定の数値になる配列の組合せ（インデックス）</returns>
        public static int[] TwoSum(int[] nums, int target)
        {            
            int AugendIndex = 0;    // 加算される数を確定する添え字
            int AddendIndex = 0;    // 加算する数を確定する添え字
            int[] CurrentCombination = new int[2];  // targetになる配列の要素のインデックス
            int NumberOfTrials = (nums.Length * (nums.Length - 1)) / 2;   // 配列の加算回数（組合せ）

            for (int i = 0; i < NumberOfTrials; i++)   // 組合せの数だけ実行
            {

                // 加算する数字を確定
                AddendIndex = ++AddendIndex;                
                if (AddendIndex > nums.Length - 1)
                {
                    AugendIndex = ++AugendIndex;
                    AddendIndex = AugendIndex + 1;
                }

                // 配列の2要素を加算
                if(nums[AugendIndex] + nums[AddendIndex] == target)
                {
                    CurrentCombination[0] = AugendIndex;
                    CurrentCombination[1] = AddendIndex;
                    break;
                }

            }

            return CurrentCombination;

        }
    }
}
