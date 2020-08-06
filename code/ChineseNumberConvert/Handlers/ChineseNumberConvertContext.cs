namespace ChineseNumberConvert.Handlers
{
    /// <summary>
    /// 中文数字转换的上下文信息
    /// </summary>
    public class ChineseNumberConvertContext
    {
        /// <summary>
        /// 原始字符串
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// 转换数字
        /// </summary>
        public long Data { get; set; }

        public ChineseNumberConvertContext(string statement)
        {
            this.Statement = statement;
        }
    }
}