using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MyApp.Cash
{
    public class CashClient
    {
        /**
         * 1.算法的选择，以往一直存在客户端中
         * 
         * 提问：如何把对应的算法选择问题 移出来
         * 
         * **/
        public void Pay(double money, string type)
        {
            CashContext cashContext = new CashContext(type);

            var result = cashContext.GetResult(money);

            WriteLine($"结果为:{result}");
        }
    }
}
