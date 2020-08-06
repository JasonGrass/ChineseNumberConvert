namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 十
    /// </summary>
    public class ShiExpression : ChineseNumberConvertExpression
    {
        public const string Postfix = "十";

        public override string GetPostfix()
        {
            return Postfix;
        }

        public override long Multiplier()
        {
            return 10;
        }
    }
}