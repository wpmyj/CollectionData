using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.DeveCollection
{
    /// <summary>
    /// Author:xxp
    /// Remark:工作平台任务集合对象
    /// CreateData:20161121
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WorkbenchTaskList<T> : List<T> where T : WorkbenchTaskExecute
    {
        /// <summary>
        /// 新增工作平台任务
        /// </summary>
        /// <param name="model">工作平台任务</param
        public new void Add(T model)
        {
            model.StartTask();
            base.Add(model);
      
          
        }


        /// <summary>
        ///  移除工作平台任务
        /// </summary>
        /// <param name="model">工作平台任务</param>
        public new void Remove(T model)
        {
            model.StopTask();
            base.Remove(model);
        }

        /// <summary>
        ///  移除工作平台任务
        /// </summary>
        /// <param name="index">索引</param>
        public new void RemoveAt(int index)
        {
            var model = this[index];
            Remove(model);
        }
    }
}
