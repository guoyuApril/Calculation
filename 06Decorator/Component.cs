using System;
using System.Collections.Generic;
using System.Text;

namespace _06Decorator
{
    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConCreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("操作的具体对象");
        } 
    }

    /// <summary>
    /// 装饰模式类
    /// </summary>
    public class Decorator : Component
    {
        protected Component component;
        public void SetDecorator(Component _component)
        {
            this.component = _component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    public class ConCreteDecoratorA : Decorator
    {
        private string addState;
        public override void Operation()
        {
            base.Operation(); 
            Console.WriteLine("new state");
            Console.WriteLine("具体装饰对象A的操作");
        } 
    }
    public class ConCreteDecoratorB : Decorator
    {
        private string addState;
        public override void Operation()
        {
            base.Operation(); 
            Console.WriteLine("new stateB");
            Console.WriteLine("具体装饰对象B的操作");
        }
    }



}
