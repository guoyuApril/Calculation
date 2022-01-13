using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public class OparetionDiv : Operation
    {
        /// <summary>
        /// 实现了 继承封装多态
        /// 做到了解耦，实现了可扩展、可维护、
        /// </summary>
        /// <returns></returns>
        public override double getResultData()
        {
            double result = 0d;
            if (NumberB == 0)
            {
                throw new Exception("除数不能为空");
            }
            result = NumberA / NumberB;
            return result;
        }
    }
}
