using Client.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Utility.Logging;
using LY.DeveCollection.SRExctue;
using System.Net.NetworkInformation;

namespace LY.DeveCollection
{
    /// <summary>
    /// Author:xxp
    /// Remark:设备任务执行类
    /// CreateDate:20161121
    /// </summary>
    public class DeveiceTaskExecute
    {
        /// <summary>
        /// 任务执行异步处理
        /// </summary>
        /// <param name="model">设备任务对象</param>
        /// <returns></returns>
        /// 
        public static InheritMaster InMBmaster;
        DevExecuteServiceClient client = new SRExctue.DevExecuteServiceClient();
        string OrginiDate;
        static int i_Num;

        //   public  static Task<string> TaskExecuteAsync(DeveiceTaskInfo model)
        public static string TaskExecuteAsync(DeveiceTaskInfo model)
        //public static async Task<string> TaskExecuteAsync(DeveiceTaskInfo model)
        {

            ushort ID;
            ushort StartAddress;
            ushort Length;
            byte VisID;
            string DevStd;
            bool ConnectStatus;
            bool SwitchID;
            ushort ConvertType;
            ushort NewTypeData;



            //  2、判断本地保存时间
            //InMBmaster = new InheritMaster(model.IPUrl, model.DevicePort);  //master类通用连接功能，带IP跟端口参数    DateTime.Now.ToString(),
            try
            {
                if (model.CurrDeviceConnect.Connected)
                {

                    //model.InMBmaster.connect(model.IPUrl, model.DevicePort);
                    //1、采集设备数据,返回值
                    ID = (ushort)model.ExecID;                 //执行ID
                    StartAddress = (ushort)model.DevpAddress;  //开始地址
                    Length = model.SendFormat;                  //数据长度
                    VisID = model.CallID;                      //访问ID
                    DevStd = model.DevStd;                     //设备规格
                    SwitchID = model.SwitchID;
                    //    model.ConAccAddress = 0;
                    //  ConvertType = model.ConvertType;
                    if (model.ConvertType == null)
                    {
                        ConvertType = 0;
                    }
                    else
                    {
                        ConvertType = Convert.ToUInt16(model.ConvertType);
                    }

                    NewTypeData = (ushort)(ConvertType * 1000 + ID);

                    if (model.IsHandle == false)
                    {
                        if (DevStd == "FX3")

                            //  model.InMBmaster.ReadHoldingRegister(ID, StartAddress, Length, VisID);
                            model.CurrDeviceConnect.Master.ReadHoldingRegister(ID, StartAddress, Length, VisID);
                        //   System.Threading.Thread.Sleep(100);


                        if (DevStd == "AD6")
                        {
                            //  System.Threading.Thread.Sleep(100);
                            //  model.InMBmaster.ReadDiscreteInputs(ID, StartAddress, Length, VisID);
                            model.CurrDeviceConnect.Master.ReadDiscreteInputs(ID, StartAddress, Length, VisID);

                        }


                    }
                    else
                    {
                        model.CurrDeviceConnect.Master.WriteSingleCoils(ID, StartAddress, SwitchID, VisID);
                        model.IsHandle = false;
                    }

                    //else if (DevStd == "Send")
                    //{

                    //  //  
                    // //   model.InMBmaster.disconnect();
                    //    //model.IsHandle = false;

                    //}
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
            if (model.LastLocalSaveTime.AddMinutes(model.LocalSaveFrequency) == DateTime.Now)
            {
                //3、存储本地SQLite数据库
            }
            //4、存储缓存数据库 暂定在DeveiceTaskInfo执行存储缓存数据库的功能
            return string.Empty;
        }
    }
}
