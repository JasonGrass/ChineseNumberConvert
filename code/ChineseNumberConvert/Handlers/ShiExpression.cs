namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 十
    /// </summary>
    public class ShiExpression : ChineseNumberConvertExpression
    {
        public override string GetPostfix()
        {
            return "十";
        }

        public override long Multiplier()
        {
            return 10;
        }
    }
}