using System;
using System.Collections.Generic;
using System.Text;

namespace MallCashier
{
    /// <summary>
    /// 现金收费的抽象类 
    /// </summary>
    public abstract class CashSuper
    {
        /// <summary>
        /// 收现金的抽象方法
        /// 1.参数为原价；
        /// 2.返回值为当前值；
        /// </summary>
        /// <returns></returns>
        public abstract decimal AcceptCash(decimal money); 
    }

    /// <summary>
    /// 正常的现金收费类
    /// </summary>
    public class NormalCash : CashSuper
    {
        public override decimal AcceptCash(decimal money)
        {
            return money;
        }
    }

    /// <summary>
    /// 折扣现金收费类
    /// </summary>
    public class DiscountCash : CashSuper
    {
        private decimal DiscountRate { get; set; }
        public DiscountCash(decimal discountRate)
        {
            DiscountRate = discountRate;
        }
        public override decimal AcceptCash(decimal money)
        {
            return money * DiscountRate;
        }
    }

    /// <summary>
    /// 返现现金收费类
    /// </summary>
    public class ReturnCash : CashSuper
    {
        private decimal SatisfyMoney { get; set; }
        private decimal ReturnMoney { get; set; }
        public ReturnCash(decimal satisfyMoney, decimal returnMoney)
        {
            SatisfyMoney = satisfyMoney;
            ReturnMoney = returnMoney;
        }

        /// <summary>
        /// 满减类现金
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public override decimal AcceptCash(decimal money)
        {
            decimal result = money;
            if(money >= SatisfyMoney)
            {
                result = money - (Math.Floor(money / SatisfyMoney) * ReturnMoney);
            }
            return result;
        }
    }
}
