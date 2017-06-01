using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Utility;
using Client.Utility.Logging;
using System.Threading;

namespace LY.DeveCollection
{
    /// <summary>
    /// Author:xxp
    /// Remark:工作台任务处理类
    /// CreateDate:20161121
    /// </summary>
    public class WorkbenchTaskExecute : IDisposable
    {
        private string _WorkbenchCode;
        private string _WorkbenchName;
        private bool _TaskStatus = false;

        /// <summary>
        /// 计时器
        /// </summary>
        private System.Timers.Timer _timer;
        private bool CoolFrechFlag = true;






        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkbenchTaskExecute(string _WorkbenchCode, string _WorkbenchName)
        {
            _timer = new System.Timers.Timer();
            LstDeveiceTask = new List<DeveiceTaskInfo>();



            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            //_timer.Tick += _timer_Tick;
            this._WorkbenchCode = _WorkbenchCode;
            this._WorkbenchName = _WorkbenchName;

        }

        void _timer_Tick(object sender, EventArgs e)
        {
            var dt1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                var lstModel = LstDeveiceTask.Where(t => (t.Priority == 0)).OrderByDescending(t => t.Priority).ToList(); //优先级越大越先执行
                foreach (var model in lstModel)
                {
                    //if (CoolFrechFlag)
                    //{
                    //    model.LastCollTime = DateTime.Now.AddSeconds(3);
                    //    CoolFrechFlag = false;

                    //}

                    //int i = DateTime.Compare(dt1, model.LastCollTime);
                    if (model.LastCollTime.ToString("yyyy-MM-dd HH:mm:ss").Equals(dt1))
                    {

                        System.Threading.Thread.Sleep(1000);
                        //执行设备命令
                        Task.Run(() =>
                        {
                            DeveiceTaskExecute.TaskExecuteAsync(model);
                        });

                        //执行完成在当前时间+执行频率；
                        model.LastCollTime = DateTime.Now.AddSeconds(3);
                    }




                    //model.CollFrequency--;


                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        int inTimer = 0;

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (Interlocked.Exchange(ref inTimer, 1) == 0)
            {
                try
                {

                    var lstModel = LstDeveiceTask.Where(t => (t.Priority == 0)).OrderByDescending(t => t.Priority).ToList(); //优先级越大越先执行
                    foreach (var model in lstModel)
                    {
                        //if (CoolFrechFlag)
                        //{
                        //    model.LastCollTime = DateTime.Now.AddSeconds(3);
                        //    CoolFrechFlag = false;

                        //}      
                      
                        if (model.LastCollTime <= DateTime.Now)
                        {
                            //Utils.Logger.Debug(string.Format("Time:{0}  ExecID:{1}  DevConnectStatus:{2}", DateTime.Now.ToString(), model.ExecID, model.DevConnectStatus.ToString()));

                            System.Threading.Thread.Sleep(100);
                            //执行设备命令
                            Task.Run(() =>
                            {
                                DeveiceTaskExecute.TaskExecuteAsync(model);
                            });

                            //执行完成在当前时间+执行频率；
                            model.LastCollTime = DateTime.Now.AddSeconds(model.CollFrequency);
                        }




                        //model.CollFrequency--;


                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
                finally
                {
                    Interlocked.Exchange(ref inTimer, 0);
                }
            }
        }




        /// <summary>
        /// 工作台编码
        /// </summary>
        public string WorkbenchCode
        {
            get { return _WorkbenchCode; }
        }

        /// <summary>
        /// 工作台名称
        /// </summary>
        public string WorkbenchName
        {
            get { return _WorkbenchName; }
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        public bool TaskStatus
        {
            get { return _TaskStatus; }
        }

        /// <summary>
        /// 设备任务集合
        /// </summary>
        public List<DeveiceTaskInfo> LstDeveiceTask
        {
            get;
            set;
        }

        /// <summary>
        /// 设备子任务个数
        /// </summary>
        public int CurrCount
        {
            get { return LstDeveiceTask != null ? LstDeveiceTask.Count : 0; }
        }

        /// <summary>
        /// 开启任务
        /// </summary>
        public void StartTask()
        {
            _timer.Start();
            _TaskStatus = true;
        }

        /// <summary>
        /// 关闭任务
        /// </summary>
        public void StopTask()
        {
            _timer.Stop();
            foreach (var item in LstDeveiceTask)
            {
                item.Dispose();
            }
            _TaskStatus = false;
        }



        public void Dispose()
        {
            StopTask();
        }
    }
}
