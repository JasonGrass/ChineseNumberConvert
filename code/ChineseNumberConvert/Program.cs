using System;
using System.Collections;
using ChineseNumberConvert.Handlers;

namespace ChineseNumberConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 单位（亿，万，千，百，十）前面，必须有数字。
             * 一十一：合法
             * 一十：合法
             * 十：不合法
             * 十一：不合法
             */

            string str = "三千六百亿四千七百二十万零二百二十二";
            // string str = "一十一";

            var converter = new ChineseNumberConverter();
            long number = converter.Convert(str);

            Console.WriteLine("{0} = {1}", str, number);

            Console.ReadKey();

        }
    }
}
