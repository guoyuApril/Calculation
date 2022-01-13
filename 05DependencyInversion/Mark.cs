using System;
using System.Collections.Generic;
using System.Text;

namespace _05DependencyInversion
{
    public class Mark
    {
        private ICourse Course;
        public Mark() { } 
        /// <summary>
        /// 构造器注入方法
        /// </summary>
        public Mark(ICourse course)
        {
            this.Course = course;
        }

        /// <summary>
        /// 通过构造器注入调用方法
        /// </summary>
        public void study()
        {
            this.Course.Study();
        }

        /// <summary>
        /// 非构造器注入调用方法
        /// </summary>
        /// <param name="course"></param>
        public void study(ICourse course)
        {
            course.Study();
        }

    }
}
