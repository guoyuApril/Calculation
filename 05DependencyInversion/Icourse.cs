using System;
using System.Collections.Generic;
using System.Text;

namespace _05DependencyInversion
{
    public interface ICourse
    {
        void Study();
    }

    public class AdoNetCourse : ICourse
    {
        public void Study()
        {
            Console.WriteLine("正在学习AdoNet课程");
        }
    }

    public class JavaCourse : ICourse
    {
        public void Study()
        {
            Console.WriteLine("正在学习Java课程");
        }
    }

    public class PythonCourse : ICourse
    {
        public void Study()
        {
            Console.WriteLine("正在学习Python课程");
        }
    }
}
