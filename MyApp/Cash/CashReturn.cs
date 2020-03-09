using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Cash
{
    public class CashReturn : CashSuper
    {
        private double MoneyReturn = 0.00;
        private double MoneyCondition = 0.0d;

        public CashReturn(string moneyCondition, string moneyReturn)
        {
            MoneyReturn = Convert.ToDouble(moneyReturn);
            MoneyCondition = Convert.ToDouble(moneyCondition);
        }

        public override double AcceptCash(double money)
        {
            var result = money;
            if (money >= MoneyCondition)
            {
                result = money - (money / MoneyCondition) * MoneyReturn;
            }
            return result;
        }
    }
}
