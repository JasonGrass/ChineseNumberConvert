using System.Collections;

namespace ChineseNumberConvert.Handlers
{
    public class ChineseNumberConverter
    {
        public long Convert(string str)
        {
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

    }
}
