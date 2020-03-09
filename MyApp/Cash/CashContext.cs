using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Cash
{
    /**
     * 名词解释 
     * DP -- 条件语句 
     * **/


    /**
     * 1.改进的策略
     * 直接在Context实现Cash 
     * **/

        /**
         * 1.如果添加 “满200减100”，则要修改CashContext的switch分支
         * 答：利用反射 “反射，反射，程序员的快乐”
         * **/

    public class CashContext
    {
        private CashSuper CashSuper;

        public CashContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    {
                        CashSuper = new CashNormal();
                    }
                    break;
                case "满300减100":
                    {
                        CashSuper = new CashReturn("100", "300");
                    }
                    break;
                case "打8折":
                    {
                        CashSuper = new CashRebate("0.8");
                    }
                    break;
            }

        }

        public double GetResult(double money)
        {
            return CashSuper.AcceptCash(money);
        }
    }
}
