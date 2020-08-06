using System.Collections.Generic;

namespace ChineseNumberConvert.Handlers
{
    public abstract class ChineseNumberConvertExpression
    {
        protected IDictionary<string, int> NumberTable = new Dictionary<string, int>(System.StringComparer.Ordinal);

        protected ChineseNumberConvertExpression()
        {
            NumberTable.Add(ChineseNumberChar.One, 1);
            NumberTable.Add(ChineseNumberChar.Two, 2);
            NumberTable.Add(ChineseNumberChar.Three, 3);
            NumberTable.Add(ChineseNumberChar.Four, 4);
            NumberTable.Add(ChineseNumberChar.Five, 5);
            NumberTable.Add(ChineseNumberChar.Six, 6);
            NumberTable.Add(ChineseNumberChar.Seven, 7);
            NumberTable.Add(ChineseNumberChar.Eight, 8);
            NumberTable.Add(ChineseNumberChar.Nine, 9);
            NumberTable.Add(ChineseNumberChar.Ten, 10);
            NumberTable.Add(ChineseNumberChar.Hundred, 100);
            NumberTable.Add(ChineseNumberChar.Thousand, 1000);
            NumberTable.Add(ChineseNumberChar.Wan, 10000);
        }

        public virtual void Interpret(ChineseNumberConvertContext context)
        {
            if (context.Statement.Length == 0)
            {
                return;
            }

            foreach (string key in NumberTable.Keys)
            {
                if (string.Equals(key, ChineseNumberChar.Ten, System.StringComparison.Ordinal))
                {
                    break;
                }

                int value = NumberTable[key];
                if (context.Statement.EndsWith(key + GetPostfix(), System.StringComparison.Ordinal))
                {
                    context.Data += value * this.Multiplier();
                    context.Statement = context.Statement.Substring(0, context.Statement.Length - GetLength());
                }
                if (context.Statement.EndsWith(ChineseNumberChar.Zero, System.StringComparison.Ordinal))
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