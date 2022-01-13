using System;
using System.Collections.Generic;
using System.Text;

namespace MallCashier
{
    /// <summary>
    /// 策略模式：
    /// 策略模式定义了家族算法，分别封装起来，让他们之间可以相互调用.
    /// 算法本身是一种策略
    /// </summary>
    public abstract class Strategy
    {
        /// <summary>
        /// 定义一个抽象的公共算法接口
        /// </summary>
        public abstract decimal AlgorithmInterface(decimal money);
    }

    /// <summary>
    /// 具体的算法策略：
    /// 正常收费算法
    /// </summary>
    public class NormalCashStrategy : Strategy
    {
        public override decimal AlgorithmInterface(decimal money)
        {
            return money;
        }
    }

    /// <summary>
    /// 具体的算法策略：
    /// 折扣收费算法
    /// </summary>
    public class DiscountCashStrategy : Strategy
    {
        private decimal DiscountRate { get; set; }
        public DiscountCashStrategy(decimal discountRate)
        {
            DiscountRate = discountRate;
        }
        public override decimal AlgorithmInterface(decimal money)
        {
            return money * DiscountRate;
        } 
    }

    /// <summary>
    /// 具体的算法策略：
    /// 满减类算法
    /// </summary>
    public class ReturnCashStrategy : Strategy
    {
        private decimal SatisfyMoney { get; set; }
        private decimal ReturnMoney { get; set; }
        public ReturnCashStrategy(decimal satisfyMoney, decimal returnMoney)
        {
            SatisfyMoney = satisfyMoney;
            ReturnMoney = returnMoney;
        }

        /// <summary>
        /// 满减类现金
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public override decimal AlgorithmInterface(decimal money)
        {
            decimal result = money;
            if (money >= SatisfyMoney)
            {
                result = money - (Math.Floor(money / SatisfyMoney) * ReturnMoney);
            }
            return result;
        } 
    }
}
