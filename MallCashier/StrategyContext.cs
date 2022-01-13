using System;
using System.Collections.Generic;
using System.Text;

namespace MallCashier
{
    public class StrategyContext
    {
        Strategy strategy;
        /// <summary>
        /// 初始化，传入对应的具体策略对象
        /// </summary>
        /// <param name="_strategy"></param>
        public StrategyContext(string type)
        { 
            switch (type)
            {
                case "正常收费":
                    strategy = new NormalCashStrategy();
                    break;
                case "打九折":
                    strategy = new DiscountCashStrategy((decimal)0.9);
                    break;
                case "打八折":
                    strategy = new DiscountCashStrategy((decimal)0.8);
                    break;
                case "打七折":
                    strategy = new DiscountCashStrategy((decimal)0.9);
                    break;
                case "满300减20":
                    strategy = new ReturnCashStrategy(300, 20);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 根据具体的策略对象，调用其算法的方法
        /// </summary>
        public decimal GetResult(decimal money)
        {
            var result = strategy.AlgorithmInterface(money);
            return result;
        }
    }
}
