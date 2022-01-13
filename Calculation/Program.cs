using System;

namespace Calculation
{
    class Program
    {
        /// <summary>
        /// 用（面向对象语言）实现一个计算机控制台程序。
        /// 要求：输入两个数和运算符，得到结果
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region 计算第一版(面向过程编程)
            //Program.getCalculation();
            #endregion

            #region 计算第二版(面向对象编程-封装)
            //Program.getCalculation1();
            #endregion

            #region 计算第三版(面向对象：实现简单的工厂模式)
            Console.WriteLine("请输入要计算的第一个值：");
            string numberA = Console.ReadLine();
            Console.WriteLine("请输入要计算的是运算符：");
            string symbol = Console.ReadLine();
            Console.WriteLine("请输入要计算的第二个值：");
            string numberB = Console.ReadLine();
            var oparetionResult = Program.CreateOperation(symbol);
            oparetionResult.NumberA = Convert.ToDouble(numberA);
            oparetionResult.NumberA = Convert.ToDouble(numberB);
            var result = oparetionResult.getResultData();
            Console.WriteLine($"计算结果为：{result}");
            #endregion
        }

        #region 面向过程编程 
        /// <summary>
        /// 此方法可以满足当前需求。
        /// 但程序不易维护、扩展、灵活性差更不容易复用，达不到高质量的代码;
        /// 代码规范：
        ///     1.命名规范
        ///     2.不写无用代码
        ///     3.考虑各种边界值，保证程序不报错
        /// </summary>
        public static void getCalculation()
        {
           
            try
            { 
                Console.WriteLine("请输入要计算的第一个值：");
                string numberA = Console.ReadLine();
                Console.WriteLine("请输入要计算的是运算符：");
                string symbol = Console.ReadLine();
                Console.WriteLine("请输入要计算的第二个值：");
                string numberB = Console.ReadLine();
                double result = 0;
                switch (symbol)
                {
                    case "+":
                        result = Convert.ToDouble(numberA) + Convert.ToDouble(numberB);
                        break;
                    case "-":
                        result = Convert.ToDouble(numberA) - Convert.ToDouble(numberB);
                        break;
                    case "*":
                        result = Convert.ToDouble(numberA) * Convert.ToDouble(numberB);
                        break;
                    case "/":
                        if (numberB != "0")
                        {
                            result = Convert.ToDouble(numberA) / Convert.ToDouble(numberB);
                        }
                        else
                        {
                            Console.WriteLine("除数不能为零");
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"计算结果为：{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 面向对象编程
        /// <summary>
        /// 面向对象的三大特征：封装、继承、多态 
        /// 面向对象的好处：
        ///     第一：可维护; 只改需要改的地方
        ///     第二：可复用; 可以重复使用
        ///     第三：可扩展; 
        ///     第四：灵活性好;
        ///     
        /// 通过封装、继承、多态 降低程序耦合性
        /// 用设计模式使程序更加灵活，容易修改，易于复用(易维护，易扩展、易复用)
        /// 
        /// 1. 逻辑和界面分开=>耦合度下降（分离开，才能易维护可扩展）
        /// 2. 操作类、客户端类、继承操作类的加减乘除类
        /// 3. 紧耦合vs松耦合
        /// </summary>
        public static void getCalculation1()
        {
            try
            {
                Console.WriteLine("请输入要计算的第一个值：");
                string numberA = Console.ReadLine();
                Console.WriteLine("请输入要计算的是运算符：");
                string symbol = Console.ReadLine();
                Console.WriteLine("请输入要计算的第二个值：");
                string numberB = Console.ReadLine();
                Operation opare = new Operation();
                var  result= opare.getResult(Convert.ToDouble(numberA), Convert.ToDouble(numberB), symbol);
                Console.WriteLine($"计算结果为：{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("你的输入有误：" + ex.Message);
            } 
        }


        #endregion

        #region 简单的工厂模式
        /// <summary>
        /// 1.更改加法运算只需要更改OparetionAdd类
        ///   新增各种复杂运算，增加运算子类就OK。然后修改运算工厂，修改switch分支
        ///   修改界面就只要该界面就行
        ///   
        /// </summary>
        /// <param name="operate"></param>
        /// <returns></returns>
        public static Operation CreateOperation(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OparetionAdd();
                    break;
                case "-":
                    oper = new OparetionSub();
                    break;
                case "*":
                    oper = new OparetionMul();
                    break;
                case "/":
                    oper = new OparetionDiv();
                    break;
            }
            return oper;
        }
        #endregion

        #region UML类图
        /// 类图分三层
        ///   第一层：显示类名称（如果是抽象类：用斜体表示）
        ///   第二层：类的特性（字段、属性）
        ///   第三层：类的操作（方法、行为）
        ///     ‘+’表示public；
        ///     ‘-’表示private；
        ///     ‘#’表示protected；
        ///     
        ///  接口图分两层 （与类图的区别主要是：顶端有"<<interface>>"进行表示）
        ///    第一层：接口名称
        ///    第二层：接口方法
        ///    接口还有另一种表示方法：俗称棒棒糖表示法
        ///    
        ///  继承关系使用：空心三角形+实线表示 （箭头指向需要继承的类）
        ///  实现接口使用：空心三角形+虚线表示 （箭头指向需要实现的接口）
        ///  关联关系使用：实线箭头表示（当一个类‘知道’另一个类时，箭头指向为：另一个类）
        ///  聚合关系使用：空心菱形+实线箭头表示 (体现的时A包含B，B是A的一部分，箭头指向B)
        ///  合成(拥有)关系：实心菱形+实线箭头表示 (体现的是部分与整体的关系，箭头指向被拥有对象)
        ///  依赖关系使用：虚线箭头表示（箭头指向依赖对象）  比如动物依赖于水氧气等
        ///编程是一种技术，更加是一门艺术


        #endregion

    }
}

