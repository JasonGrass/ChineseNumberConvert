namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 千
    /// </summary>
    public class QianExpression : ChineseNumberConvertExpression
    {
        public override string GetPostfix()
        {
            return ChineseNumberChar.Thousand;
        }

        public override long Multiplier()
        {
            return 1000;
        }
    }
}