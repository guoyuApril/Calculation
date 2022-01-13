using System;
using System.Collections.Generic;
using System.Text;

namespace _07Proxy
{
    public interface SendGive
    {
        void SendFlowers();
        void SendChololates();
        void SendDolly();
    }

    /// <summary>
    /// 追求者类
    /// </summary>
    public class Pursuit : SendGive
    {
        public SchoolGirl MM;
        public Pursuit(SchoolGirl mm)
        {
            this.MM = mm;
        }

        public void SendFlowers()
        {
            Console.WriteLine($"{MM.Name}:送你鲜花");
        }
        public void SendChololates()
        {
            Console.WriteLine($"{MM.Name}:送你鲜花");
        }
        public void SendDolly()
        {
            Console.WriteLine($"{MM.Name}:送你洋娃娃");
        }
    }

    /// <summary>
    /// 代理类
    /// </summary>
    public class Proxy : SendGive
    {
        private Pursuit pursuit { get; set; }
        public Proxy(SchoolGirl mm)
        {
            pursuit = new Pursuit(mm);
        }
        public void SendFlowers() { pursuit.SendFlowers(); }
        public void SendChololates() { pursuit.SendChololates(); }
        public void SendDolly() { pursuit.SendDolly(); }
    }

    public class SchoolGirl
    {
        public string Name { get; set; }
    }
}

