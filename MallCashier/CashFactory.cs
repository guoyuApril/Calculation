using System;
using System.Collections.Generic;
using System.Text;

namespace MallCashier
{
    public class CashFactory
    {
        public static CashSuper CreateCashSuper(string type)
        {
            CashSuper caspSuperObj = new NormalCash();
            switch (type)
            {
                case "正常收费":
                    caspSuperObj = new NormalCash();
                    break;
                case "打九折":
                    caspSuperObj = new DiscountCash((decimal)0.9);
                    break;
                case "打八折":
                    caspSuperObj = new DiscountCash((decimal)0.8);
                    break;
                case "打七折":
                    caspSuperObj = new DiscountCash((decimal)0.9);
                    break;
                case "满300减20":
                    caspSuperObj = new ReturnCash(300, 20);
                    break; 
                default:
                    break;
            }
            return caspSuperObj;
        }
    }
}
