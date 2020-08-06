using System;
using System.Collections;
using ChineseNumberConvert.Handlers;

namespace ChineseNumberConvert
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "三千六百亿四千七百二十万零二百二十二";

            var converter = new ChineseNumberConverter();
            long number = converter.Convert(str);

            Console.WriteLine("{0} = {1}", str, number);

            Console.ReadKey();

        }
    }
}
