using System.Collections;

namespace ChineseNumberConvert.Handlers
{
    public class ChineseNumberConverter
    {
        public long Convert(string str)
        {
            str = PrePrecess(str);

            ChineseNumberConvertContext context = new ChineseNumberConvertContext(str);

            ArrayList tree = new ArrayList();
            tree.Add(new GeExpression());
            tree.Add(new ShiExpression());
            tree.Add(new BaiExpression());
            tree.Add(new QianExpression());
            tree.Add(new WanExpression());
            tree.Add(new YiExpression());

            foreach (ChineseNumberConvertExpression exp in tree)
            {
                exp.Interpret(context);
            }

            return context.Data;
        }

        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string PrePrecess(string str)
        {
            str = str.Trim();
            if (str.StartsWith(ShiExpression.Postfix, System.StringComparison.Ordinal)||
                str.StartsWith(BaiExpression.Postfix, System.StringComparison.Ordinal) ||
                str.StartsWith(QianExpression.Postfix, System.StringComparison.Ordinal) ||
                str.StartsWith(WanExpression.Postfix, System.StringComparison.Ordinal) ||
                str.StartsWith(YiExpression.Postfix, System.StringComparison.Ordinal))
            {
                // 在单位前面补充 “一”
                str = "一" + str;
            }
            return str;
        }

    }
}
