namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 百
    /// </summary>
    public class BaiExpression : ChineseNumberConvertExpression
    {
        public const string Postfix = "百";

        public override string GetPostfix()
        {
            return Postfix;
        }

        public override long Multiplier()
        {
            return 100;
        }
    }
}