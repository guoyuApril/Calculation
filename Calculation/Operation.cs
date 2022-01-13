using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public class Operation
    {
        #region 操作类-封装 
        /// <summary>
        /// 操作类-业务的封装
        /// </summary>
        public double getResult(double numberA, double numberB, string operation)
        {
            double result = 0d;
            switch (operation)
            {
                case "+":
                    result = numberA + numberB;
                    break;
                case "-":
                    result = numberA - numberB;
                    break;
                case "*":
                    result = numberA * numberB;
                    break;
                case "/":
                    if (numberB != 0)
                    {
                        result = numberA / numberB;
                    }
                    else
                    {
                        Console.WriteLine("除数不能为零");
                    }
                    break;
            }
            return result;
        }
        #endregion

        #region 封装类-封装、继承、多态
        //public double NumberA { get; set; }
        //public double NumberB { get; set; }
        private double _numberA = 0;
        private double _numberB = 0;
        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        } 
        public double NumberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }
        public virtual double getResultData()
        {
            double result = 0d;
            return result; 
        }
        #endregion 
    }
}
