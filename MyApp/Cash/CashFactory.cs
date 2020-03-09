using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Cash
{
    public class CashFactory
    {
        /**
         * 1.但后续会有各种打折和返利额度，需要经常编译发布
         * **/

        /**
         * 简单工厂模式 解决了 创建问题
         * **/

        public static CashSuper CreateCashSuper(string type)
        {
            CashSuper result = null;

            switch (type)
            {
                case "正常收费":
                    {
                        result = new CashNormal();
                    }
                    break;
                case "满300减100":
                    {
                        result = new CashReturn("300", "100");
                    }
                    break;
                case "打8折":
                    {
                        result = new CashRebate("0.8");
                    }
                    break;
            }

            return result;
        }
    }
}
