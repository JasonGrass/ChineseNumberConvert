namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 个
    /// </summary>
    public class GeExpression : ChineseNumberConvertExpression
    {
        public override string GetPostfix()
        {
            return "";
        }

        public override long Multiplier()
        {
            return 1;
        }

        public override int GetLength()
        {
            return 1;
        }
    }
}