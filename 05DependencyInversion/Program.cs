using System;

namespace _05DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 依赖倒置 
            Mark mark = new Mark();
            mark.study(new AdoNetCourse());
            mark.study(new JavaCourse());
            mark.study(new PythonCourse());
            Console.WriteLine("Hello World!");

            ///通过构造器注入调用
            Mark mark1 = new Mark(new AdoNetCourse());
            mark1.study();
            #endregion
        }
    }
}
