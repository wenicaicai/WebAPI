using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Cash
{
    public class CashRebate : CashSuper
    {
        private double MoneyRebate = 1.0;

        public CashRebate(string moneyRebate)
        {
            MoneyRebate = Convert.ToDouble(moneyRebate);

        }

        public override double AcceptCash(double money)
        {
            return money * MoneyRebate;
        }
    }
}
