using System;
using System.Collections.Generic;
using System.Text;

namespace _06Decorator
{
    public abstract class Finery
    {
        public abstract void show();
    }

    public class BaggyPants : Finery
    {
        public override void show()
        {
            Console.Write("垮裤\t");
        }
    }

    public class BigTshirt : Finery
    {
        public override void show()
        {
            Console.Write("大T恤\t");
        }
    }

    public class BrokenGymShoes : Finery
    {
        public override void show()
        {
            Console.Write("破球鞋\t");
        }
    }

    public class Suit : Finery
    {
        public override void show()
        {
            Console.Write("西装\t");
        }
    }

    public class Necktie : Finery
    {
        public override void show()
        {
            Console.Write("领带\t");
        }
    } 

    public class LeatherShoes : Finery
    {
        public override void show()
        {
            Console.Write("皮鞋\t");
        }
    }

}
