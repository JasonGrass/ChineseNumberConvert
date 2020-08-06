namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 百
    /// </summary>
    public class BaiExpression : ChineseNumberConvertExpression
    {
        public override string GetPostfix()
        {
            return ChineseNumberChar.Hundred;
        }

        public override long Multiplier()
        {
            return 100;
        }
    }
}