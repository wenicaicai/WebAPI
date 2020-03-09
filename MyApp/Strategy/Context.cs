using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Strategy
{
    public class Context
    {
        Strategy Strategy;
        public Context(Strategy strategy)
        {
            Strategy = strategy;
        }

        public void ContextInterface()
        {
            Strategy.AlgorithmInterface();
        }
    }
}
