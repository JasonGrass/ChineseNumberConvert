using System.Collections;
using System.Collections.Generic;

namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 万
    /// </summary>
    public class WanExpression : ChineseNumberConvertExpression
    {
        public const string Postfix = "万";


        private IList<ChineseNumberConvertExpression> SubExpressionTree { get; }

        public WanExpression()
        {
            SubExpressionTree = new List<ChineseNumberConvertExpression>()
            {
                new GeExpression(),
                new ShiExpression(),
                new BaiExpression(),
                new QianExpression()
            };
        }

        public override void Interpret(ChineseNumberConvertContext context)
        {
            if (context.Statement.Length == 0)
            {
                return;
            }

            foreach (string key in NumberTable.Keys)
            {
                if (context.Statement.EndsWith(key + this.GetPostfix(), System.StringComparison.Ordinal))
                {
                    long temp = context.Data;
                    context.Data = 0;

                    context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);

                    foreach (var exp in SubExpressionTree)
                    {
                        exp.Interpret(context);
                    }

                    context.Data = temp + this.Multiplier() * context.Data;
                }
            }

        }

        public override string GetPostfix()
        {
            return Postfix;
        }

        public override long Multiplier()
        {
            return 10000;
        }
    }
}