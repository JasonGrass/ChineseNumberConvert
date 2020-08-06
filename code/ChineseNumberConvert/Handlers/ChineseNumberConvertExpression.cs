using System.Collections.Generic;

namespace ChineseNumberConvert.Handlers
{
    public abstract class ChineseNumberConvertExpression
    {
        protected IDictionary<string, int> NumberTable = new Dictionary<string, int>(System.StringComparer.Ordinal);

        protected ChineseNumberConvertExpression()
        {
            NumberTable.Add("一", 1);
            NumberTable.Add("二", 2);
            NumberTable.Add("三", 3);
            NumberTable.Add("四", 4);
            NumberTable.Add("五", 5);
            NumberTable.Add("六", 6);
            NumberTable.Add("七", 7);
            NumberTable.Add("八", 8);
            NumberTable.Add("九", 9);
            NumberTable.Add("十", 10);
            NumberTable.Add("百", 100);
            NumberTable.Add("千", 1000);
            NumberTable.Add("万", 10000);
        }

        public virtual void Interpret(ChineseNumberConvertContext context)
        {
            if (context.Statement.Length == 0)
            {
                return;
            }

            foreach (string key in NumberTable.Keys)
            {
                if (string.Equals(key, "十", System.StringComparison.Ordinal))
                {
                    break;
                }

                int value = NumberTable[key];
                if (context.Statement.EndsWith(key + GetPostfix(), System.StringComparison.Ordinal))
                {
                    context.Data += value * this.Multiplier();
                    context.Statement = context.Statement.Substring(0, context.Statement.Length - GetLength());
                }
                if (context.Statement.EndsWith("零", System.StringComparison.Ordinal))
                {
                    context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);
                }
            }
        }

        /// <summary>
        /// 获取单位的后缀
        /// </summary>
        /// <returns></returns>
        public abstract string GetPostfix();

        /// <summary>
        /// 获取单位对应的倍数
        /// </summary>
        /// <returns></returns>
        public abstract long Multiplier();

        /// <summary>
        /// 最小数字单元的长度，
        /// 如 一百二十三，有三个数字单元：“一百” “一十” “一”，对应的长度就是 2 2 1
        /// </summary>
        /// <returns></returns>
        public virtual int GetLength()
        {
            return this.GetPostfix().Length + 1;
        }
    }
}