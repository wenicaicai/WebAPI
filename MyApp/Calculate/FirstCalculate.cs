using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MyApp.Calculate
{
    public static class Symbol
    {
        public static string Add { get { return "+"; } }

        public static string Sub { get { return "-"; } }

        public static string Mul { get { return "*"; } }

        public static string Div { get { return "/"; } }

    }

    //设计一个计算器
    public class FirstCalculator
    {
        public void Calculate()
        {
            WriteLine("请输入一个数字");
            var firstNum = ReadLine();
            WriteLine("请输入一个四则运算符号");
            var symbol = ReadLine();
            WriteLine("请输入另外一个数字");
            var secondNum = ReadLine();

            var result = 0.00;
            if (symbol == Symbol.Add)
            {
                result = Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum);
            }
            if (symbol == Symbol.Sub)
            {
                result = Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum);
            }
            if (symbol == Symbol.Mul)
            {
                result = Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum);
            }
            if (symbol == Symbol.Div)
            {
                result = Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum);
            }

            WriteLine($"结果为:{result}");
        }

        //作者（程杰）指出了三项错误
        /*
         1.命名规范问题
         2.判断分支，做了三次无用功（什么意思？）
         3.如果用户输入的不是数字该如何处理
         4.面对“0”作为除数时，该如何处理
         */
    }

    public class SecondCalculator
    {

        public void Calculate()
        {
            WriteLine("请输入一个数字");
            var firstNum = ReadLine();
            WriteLine("请输入一个四则运算符号(+ 、-、*、/):");
            var symbol = ReadLine();
            WriteLine("请输入另外一个数字");
            var secondNum = ReadLine();

            var result = 0.00;
            switch (symbol)
            {
                case "+":
                    {
                        result = Convert.ToDouble(firstNum) + Convert.ToDouble(secondNum);
                    }
                    break;
                case "-":
                    {
                        result = Convert.ToDouble(firstNum) - Convert.ToDouble(secondNum);
                    }
                    break;
                case "*":
                    {
                        result = Convert.ToDouble(firstNum) * Convert.ToDouble(secondNum);
                    }
                    break;
                case "/":
                    {
                        if (secondNum == "0")
                        {
                            WriteLine($"运用除法时，第二个数字不可为0");
                        }
                        else
                        {
                            result = Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum);
                        }
                    }
                    break;
            }

            WriteLine($"结果为:{result}");
        }

        //程杰 指出 该实现方式没有使用面向对象
        /*
        直接写出了以计算机能理解的方式来实现功能
        会是功能有局限性
        后期难以维护
        不容易复用
        后续扩展
         */
    }

    //程杰 借用 曹操 引出活字印刷术
    /**
     * 1.“喝酒唱歌”
     * 2.“对酒当歌”
     * 3.“对酒当歌，人生几何？”
    **/

    /**
     * 工匠已经哭了
     * **/

    /**
    * 引申活字印刷
    * 它是唯一中国古四大发明中，以思想的开放而获取成功
    * 
    * now
    * 想想 计算器哪些是与控制台无关
    * 哪些只是与计算器相关
    * **/

    /**
     * 将程序的输入部分 输出部分 区分开来
     * 用户界面
     * 业务逻辑
     * **/

    public class ThirdCalculator
    {
        //用户界面 1/2
        public void Calculate()
        {
            WriteLine("请输入一个数字");
            var firstNum = ReadLine();
            WriteLine("请输入一个四则运算符号(+ 、-、*、/):");
            var symbol = ReadLine();
            WriteLine("请输入另外一个数字");
            var secondNum = ReadLine();

            var result = FirstOperation.Calculate(Convert.ToDouble(firstNum),
                Convert.ToDouble(secondNum), symbol);

            WriteLine($"结果为:{result}");
        }
    }

    //业务逻辑 2/2
    public class FirstOperation
    {
        public static double Calculate(double firstNum, double secondNum, string symbol)
        {
            var result = 0.00;
            switch (symbol)
            {
                case "+":
                    {
                        result = firstNum + secondNum;
                    }
                    break;
                case "-":
                    {
                        result = firstNum - secondNum;
                    }
                    break;
                case "*":
                    {
                        result = firstNum * secondNum;
                    }
                    break;
                case "/":
                    {
                        if (secondNum != 0)
                        {
                            result = firstNum / secondNum;
                        }
                    }
                    break;
            }
            return result;
        }

    }

    /**
     * 如何利用多态 继承等
     * 
     * 提问：如果现在遇到了{平方}，该如何修改？--2019.11.28
     * 
     * 答：直接添加 {switch} 但这样会让原来的加减乘除也参与了新的代码编译了，
     * 有个原则 {对修改闭合，对扩展开放}
     * 
     * **/

    /**
     * 运用工厂类进行实现
     * **/
    public class FourthCalculator
    {
        public void Calculate()
        {
            WriteLine("请输入一个数字");
            var firstNum = ReadLine();
            WriteLine("请输入一个四则运算符号(+ 、-、*、/):");
            var symbol = ReadLine();
            WriteLine("请输入另外一个数字");
            var secondNum = ReadLine();

            SecondOperation operation = OperationFactory.CreateOperate(symbol);

            operation.FirstNum = 1;
            operation.SecondNum = 2;

            var result = operation.Calculate();

            WriteLine($"结果为:{result}");
        }
    }

    //业务逻辑
    public class SecondOperation
    {
        public double FirstNum { get; set; }

        public double SecondNum { get; set; }

        public virtual double Calculate()
        {
            var result = 0.00;
            return result;
        }

    }

    public class SecondOperationAdd : SecondOperation
    {
        public override double Calculate()
        {
            var result = 0.00;
            result = FirstNum + SecondNum;
            return result;
        }
    }

    public class SecondOperationSub : SecondOperation
    {
        public override double Calculate()
        {
            var result = 0.00;
            result = FirstNum - SecondNum;
            return result;
        }
    }

    public class SecondOperationMul : SecondOperation
    {
        public override double Calculate()
        {
            var result = 0.00;
            result = FirstNum * SecondNum;
            return result;
        }
    }

    public class SecondOperationDiv : SecondOperation
    {
        public override double Calculate()
        {
            var result = 0.00;
            if (SecondNum == 0)
            {
                throw new Exception("除数不可为0.");
            }
            result = FirstNum / SecondNum;
            return result;
        }
    }

    //运用简单工厂类
    public class OperationFactory
    {
        public static SecondOperation CreateOperate(string symbol)
        {
            SecondOperation result = null;
            switch (symbol)
            {
                case "+":
                    {
                        result = new SecondOperationAdd();
                    }
                    break;
                case "-":
                    {
                        result = new SecondOperationSub();
                    }
                    break;
                case "*":
                    {
                        result = new SecondOperationMul();
                    }
                    break;
                case "/":
                    {
                        result = new SecondOperationDiv();
                    }
                    break;
            }
            return result;
        }
    }
}
