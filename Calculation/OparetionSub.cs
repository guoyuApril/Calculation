using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public class OparetionSub:Operation
    {
        public override double getResultData()
        {
            double result = 0d;
            result = NumberA - NumberB;
            return result;
        }
    }
}
