using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedLists
{
    /// <summary>
    /// 単一リンクリストの定義
    /// </summary>
    public class ListNode
    {
        public int val;         // プロパティ
        public ListNode next;   // プロパティ→nextとは？

        // コンストラクタ？
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
       
        /// <summary>
        /// 異なる二つのリストを一つのリストに昇順にして返す
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>結合したリスト</returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            List<int> MergedList = new List<int>(); // 結合されたリスト
            ListNode listNode1 = new ListNode();
            listNode1 = l1;
            foreach (int i in listNode1.val)
            {

            }
        }
    }
}
