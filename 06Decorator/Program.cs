using System;

namespace _06Decorator
{
    class Program
    {
        /// <summary>
        /// 装饰模式 
        ///           
        /// 装饰模式的结构组成：
        ///     Component:是定义对象接口，可以给这些对象动态的添加职责
        ///     ConcreteComponent: 定义了一个具体的对象，也可以给这个对象添加一些职责
        ///     Decorator:装饰模式抽象类
        ///     ConcreteDecoratorA：
        ///     ConcreteDecoratorA：具体的装饰对象
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region 封装第一版
            /// 面向对象：使用了封装、继承、抽象（多态）
            ///           添加超人装扮，只需要添加子类就行。
            ///           缺陷：没有在内部封装完成
            ///           
            /// 建造者模式：要求建造的过程是稳定的 
            ///             需要把所需的功能按正确的顺序串联起来进行控制，很难做到（装饰模式可以解决） 
            /// 
            ///     
            Console.WriteLine("第一种装扮：");
            Person person = new Person("张三"); 
            Finery baggyPants = new BaggyPants();
            Finery bigTshirt = new BigTshirt();
            Finery brokenGymShoes = new BrokenGymShoes();
            baggyPants.show();
            bigTshirt.show();
            brokenGymShoes.show();
            person.show();

            Console.WriteLine("第二种装扮：");
            Person person1 = new Person("李四");
            Finery suit = new Suit();
            Finery necktie = new Necktie();
            Finery leatherShoes = new LeatherShoes();
            suit.show();
            necktie.show();
            leatherShoes.show();
            person1.show();

            #endregion


            #region 封装（装饰模式）
            /// 装饰模式：动态的给一个对象添加一些额外的职责，
            ///           就增加功能来说，装饰模式比生成子类更为灵活。 
            #region 装饰模式-标准调用法
            Console.WriteLine("-------------装饰模式-标准调用法-------------");
            ConCreteComponent conCreteComponent = new ConCreteComponent();
            ConCreteDecoratorA conCreteDecoratorA = new ConCreteDecoratorA();
            ConCreteDecoratorB conCreteDecoratorB = new ConCreteDecoratorB();

            conCreteDecoratorA.SetDecorator(conCreteComponent);
            conCreteDecoratorB.SetDecorator(conCreteDecoratorA);
             
            //conCreteDecoratorA.Operation();
            conCreteDecoratorB.Operation();
            #endregion

            #region 装饰模式-服装调用法
            ///实现客户端想怎么装扮就怎么装扮
            ///
            Console.WriteLine("");
            Console.WriteLine("-------------装饰模式-服装调用法-------------");
            Person person2 = new Person("王五");
            SuitDecorator suitDecorator = new SuitDecorator();
            NecktieDecorator necktieDecorator = new NecktieDecorator();
            LeatherShoesDecorator leatherShoesDecorator = new LeatherShoesDecorator();
            suitDecorator.Decorator(person2);
            necktieDecorator.Decorator(leatherShoesDecorator);
            leatherShoesDecorator.Decorator(suitDecorator);
            necktieDecorator.ShowFun();

            #endregion



            #endregion

        }
    }
}
