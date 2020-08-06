namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 十
    /// </summary>
    public class ShiExpression : ChineseNumberConvertExpression
    {
        public override string GetPostfix()
        {
            return ChineseNumberChar.Ten;
        }

        public override long Multiplier()
        {
            return 10;
        }
    }
}