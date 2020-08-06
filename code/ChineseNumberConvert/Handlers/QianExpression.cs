namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 千
    /// </summary>
    public class QianExpression : ChineseNumberConvertExpression
    {
        public const string Postfix = "千";

        public override string GetPostfix()
        {
            return Postfix;
        }

        public override long Multiplier()
        {
            return 1000;
        }
    }
}