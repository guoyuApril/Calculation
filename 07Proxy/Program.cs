using System;

namespace _07Proxy
{
    /// <summary>
    /// 代理模式
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            #region 没有代理的代码
            ///此处：直接把追求者换成里代理。
            Console.WriteLine("Hello World!");
            SchoolGirl wangli = new SchoolGirl();
            wangli.Name = "王丽";
            Pursuit daili = new Pursuit(wangli);
            daili.SendFlowers();
            daili.SendChololates();
            daili.SendDolly();
            #endregion

            #region 符合代理模式的代码
            Proxy proxy = new Proxy(wangli);
            proxy.SendFlowers();
            proxy.SendChololates();
            proxy.SendDolly();
            #endregion 
        }
    }
}
