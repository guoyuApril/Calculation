using System;
using System.Collections.Generic;
using System.Text;

namespace _06Decorator
{
    public class Person
    {
        private string Name;
        public Person() { }
        public Person(string name)
        {
            this.Name = name;
        }

        #region 普通方法
        public void show()
        {
            Console.WriteLine($"装扮的{this.Name}");
        }
        #endregion

        public virtual void ShowFun()
        {
            Console.WriteLine($"已经装扮的{this.Name}");
        }
    }

    public abstract class FineryDecorator : Person
    {
        protected Person person;
        public void Decorator(Person _person) {
            this.person = _person;
        }

        /// <summary>
        /// 虚方法
        /// </summary>
        public override void ShowFun()
        {
            if (this.person != null)
            {
                this.person.ShowFun();
            }
        }
    }

    public class BaggyPantsDecorator : FineryDecorator
    {
        public override void ShowFun()
        {
            Console.Write("垮裤\t");
            base.ShowFun();
        }
    }

    public class BigTshirtDecorator : FineryDecorator
    {
        public override void ShowFun()
        {
            Console.Write("大T恤\t");
            base.ShowFun();
        }
    }

    public class BrokenGymShoesDecorator : FineryDecorator
    {
        public override void ShowFun()
        {
            Console.Write("破球鞋\t");
            base.ShowFun();
        }
    }

    public class SuitDecorator : FineryDecorator
    {
        public override void ShowFun()
        {
            Console.Write("西装\t");
            base.ShowFun();
        }
    }

    public class NecktieDecorator : FineryDecorator
    {
        public override void ShowFun()
        {
            Console.Write("领带\t");
            base.ShowFun();
        }
    }

    public class LeatherShoesDecorator : FineryDecorator
    {
        public override void ShowFun()
        {
            Console.Write("皮鞋\t");
            base.ShowFun();
        }
    }

}
