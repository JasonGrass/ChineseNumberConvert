using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
翻个文件中包含所有的代码，待整理；
设计模式-解释器模式 练习例子
*/

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "三千六百亿四千七百二十万零二百二十二";

            Context context = new Context(str);

            ArrayList tree = new ArrayList();
            tree.Add(new GeExp());
            tree.Add(new ShiExp());
            tree.Add(new BaiExp());
            tree.Add(new QianExp());
            tree.Add(new WanExp());
            tree.Add(new YiExp());

            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine("{0} = {1}", str, context.Data);

            Console.ReadKey();
        }
    }
}

public class Context
{
    public string Statement { get; set; }
    public long Data { get; set; }

    public Context(string statement)
    {
        this.Statement = statement;
    }
}

public abstract class Expression
{
    protected Dictionary<string, int> table = new Dictionary<string, int>(9);

    protected Expression()
    {
        table.Add("一", 1);
        table.Add("二", 2);
        table.Add("三", 3);
        table.Add("四", 4);
        table.Add("五", 5);
        table.Add("六", 6);
        table.Add("七", 7);
        table.Add("八", 8);
        table.Add("九", 9);
        table.Add("十", 10);
        table.Add("百", 100);
        table.Add("千", 1000); 
        table.Add("万", 10000);
    }

    public virtual void Interpret(Context context)
    {
        if (context.Statement.Length == 0)
        {
            return;
        }

        foreach (string key in table.Keys)
        {
            if (key == "十")
            {
                break;
            }

            int value = table[key];
            if (context.Statement.EndsWith(key + GetPostfix()))
            {
                context.Data += value * this.Multiplier();
                context.Statement = context.Statement.Substring(0, context.Statement.Length - GetLength());
            }
            if (context.Statement.EndsWith("零"))
            {
                context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);
            }
        }
    }

    public abstract string GetPostfix();
    public abstract long Multiplier();

    public virtual int GetLength()
    {
        return this.GetPostfix().Length + 1;
    }
}

public class YiExp : Expression
{
    public override void Interpret(Context context)
    {
        if (context.Statement.Length == 0)
        {
            return;
        }

        ArrayList tree = new ArrayList();
        tree.Add(new GeExp());
        tree.Add(new ShiExp());
        tree.Add(new BaiExp());
        tree.Add(new QianExp());
        tree.Add(new WanExp());

        foreach (string key in table.Keys)
        {
            if (context.Statement.EndsWith(key + this.GetPostfix()))
            {
                long temp = context.Data;
                context.Data = 0;

                context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);

                foreach (Expression exp in tree)
                {
                    exp.Interpret(context);
                }

                context.Data = temp + this.Multiplier()*context.Data;
            }
            
        }

    }

    public override string GetPostfix()
    {
        return "亿";
    }

    public override long Multiplier()
    {
        return 100000000;
    }
}

public class WanExp : Expression
{
    public override void Interpret(Context context)
    {
        if (context.Statement.Length == 0)
        {
            return;
        }

        ArrayList tree = new ArrayList();
        tree.Add(new GeExp());
        tree.Add(new ShiExp());
        tree.Add(new BaiExp());
        tree.Add(new QianExp());

        foreach (string key in table.Keys)
        {
            if (context.Statement.EndsWith(key + this.GetPostfix()))
            {
                long temp = context.Data;
                context.Data = 0;

                context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);

                foreach (Expression exp in tree)
                {
                    exp.Interpret(context);
                }

                context.Data = temp + this.Multiplier() * context.Data;
            }
        }

    }

    public override string GetPostfix()
    {
        return "万";
    }

    public override long Multiplier()
    {
        return 10000;
    }
}

public class QianExp : Expression
{
    public override string GetPostfix()
    {
        return "千";
    }

    public override long Multiplier()
    {
        return 1000;
    }
}

public class BaiExp : Expression
{
    public override string GetPostfix()
    {
        return "百";
    }

    public override long Multiplier()
    {
        return 100;
    }
}

public class ShiExp : Expression
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

public class GeExp : Expression
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




