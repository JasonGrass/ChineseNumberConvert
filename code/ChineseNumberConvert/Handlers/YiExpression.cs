using System;
using System.Collections;
using System.Collections.Generic;

namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 亿
    /// </summary>
    public class YiExpression : ChineseNumberConvertExpression
    {
        private IList<ChineseNumberConvertExpression> SubExpressionTree { get; }

        public YiExpression()
        {
            SubExpressionTree = new List<ChineseNumberConvertExpression>()
            {
                new GeExpression(),
                new ShiExpression(),
                new BaiExpression(),
                new QianExpression(),
                new WanExpression()
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
                if (context.Statement.EndsWith(key + this.GetPostfix(), StringComparison.Ordinal))
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
            return ChineseNumberChar.Yi;
        }

        public override long Multiplier()
        {
            return 100000000;
        }
    }
}