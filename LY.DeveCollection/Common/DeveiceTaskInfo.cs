using Client.Utility;
using Client.Utility.Caching;
using Client.Utility.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Client.Utility.Logging;
using LY.DeveCollection.Common;


namespace LY.DeveCollection
{
    /// <summary>
    /// Author:xxp
    /// Reamark:设备任务对象
    /// CreateDate:20161121
    /// </summary>
    public class DeveiceTaskInfo : IDisposable
    {
        private static SQLiteHelper Mysqlite = null;
        private static ICacheManager cache = new RedisCacheManager("CacheFileServer");
        private static string CacheKey = string.Format("CollData");
        string InDevStd;



        public DeveiceTaskInfo()
        {
            if (Mysqlite == null)
                Mysqlite = new SQLiteHelper("localSQLite");
            DevConnectStatus = false;
            IsHandle = false;
        }
        public DeveiceTaskInfo init()
        {
            InDevStd = this.DevStd;
            //Ping pingSener = new Ping();
            //PingReply reply = pingSener.Send(this.IPUrl, this.DevicePort);

            //if (reply.Status == IPStatus.Success)
            //{
            //CurrDeviceConnect._Master = new InheritMaster(this.IPUrl, this.DevicePort); && CurrDeviceConnect.bAllUnConnected != true
            //InMBmaster = new InheritMaster();
            LastCollTime = DateTime.Now.AddSeconds(this.CollFrequency);

            //=========================================================连接的时候需要启动监听事件，暂停在初始化的时候启动监听事件BY XCQ 20170412  
            if (CurrDeviceConnect.bInitEvent == false && CurrDeviceConnect.bAllUnConnected != true)
            {

                CurrDeviceConnect.Master.OnResponseData += new InheritMaster.ResponseData(InMBmaster_OnResponseData);//启用数据监听事件
                CurrDeviceConnect.Master.OnException += InMBmaster_OnException;
                CurrDeviceConnect.bInitEvent = true;
            }
            //=====================================================================================================================================
            // DevConnectStatus = true;
            // }
            return this;
        }


        object obj = 1;

        /// <summary>
        /// 数据缓存保存函数位置，将获取的ID，实时时间，获取的原始值保存到238的缓存中
        /// </summary>
        /// <param name="ID">设备接口唯一性ID，用于判断哪个鼓，哪个数采仪的那个传感器</param>
        /// <param name="function"></param>
        /// <param name="values">原始值</param>
        private void InMBmaster_OnResponseData(ushort ID, byte function, byte[] values)
        {
            try
            {
                string OrginiDate;
                string ActValue;
                //   int FlagID;
                //    FlagID = ID / 1000;
                //    string Test;

                lock (obj)
                {
                    ///修正格式，由原来的KEY键为执行ID修正为KEY键
                    if (InDevStd == "FX3")
                    {
                        OrginiDate = InheritMaster.GetOrigidata(values);
                        switch (ID)
                        {
                            case 37:
                                //   Test = ConvertType;
                                // ActValue = DevDataConvert.ConverTPData(OrginiDate, "0.16", "0", "0");
                                //  ActValue = OrginiDate;

                                ActValue = String.Format("{0:F}", 0.16 * (Convert.ToDouble(OrginiDate) - 4000) / 16000);
                                //    ActValue = OrginiDate;
                                break;

                            case 38:
                                //  ActValue = DevDataConvert.ConverTPData(OrginiDate, "0.16", "0", "0");
                                //   ActValue = DevDataConvert.ConverTPData(OrginiDate, "420", "-200", "-30");  1858/16000*620
                                //      ActValue = String.Format("{0:F}", (Convert.ToDouble(OrginiDate) - 4000) / 16000 * 620 - 30);
                                ActValue = String.Format("{0:F}", Convert.ToDouble(OrginiDate) * 0.0154 - 56.56);
                                //    ActValue = OrginiDate;
                                //   ActValue = OrginiDate;
                                //   Test = ConvertType;
                                break;

                            case 39:
                                ActValue = DevDataConvert.ConverVacuumData(OrginiDate.ToString());
                                //   ActValue = OrginiDate;
                                //    ActValue = OrginiDate;
                                //  Test = ConvertType;
                                break;

                            default:
                                ActValue = "0";
                                //    Test = ConvertType;
                                break;
                        }

                        //   cache.ListLeftPush(ID.ToString(), string.Format("{0}-Time:{1}", OrginiDate, DateTime.Now.ToString("yyyyMMdd")), 24 * 60);//缓存时间一天
                        //cache.ListLeftPush(string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), ID.ToString()), ActValue, 24 * 60);//缓存时间一天
                        CurrDeviceConnect.cache.ListLeftPush(string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), ID.ToString()), ActValue, 24 * 60);//缓存时间一天
                    }

                    if (InDevStd == "AD6")
                    {
                        OrginiDate = InheritMaster.GetOrigiAD6data(values);
                        //if (OrginiDate == null)
                        //    OrginiDate = "0";

                        //  cache.ListLeftPush(ID.ToString(), string.Format("{0}-Time:{1}", OrginiDate, DateTime.Now.ToString("yyyyMMdd")), 24 * 60);//缓存时间一天
                        CurrDeviceConnect.cache.ListLeftPush(string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), ID.ToString()), OrginiDate, 24 * 60);//缓存时间一天
                    }

                    //     cache.Set(ID.ToString(), string.Format("ID:{0}-Values:{1}-Time:{2}", ID, OrginiDate, DateTime.Now.ToString()), 24 * 60);//缓存时间一天        
                    //      Mysqlite.ExecuteNonQuery(string.Format("INSERT INTO Mysqlitetext (MyDATE, MyValues, MyExcetueCode) VALUES ('{0}', '{2}', '{1}')", DateTime.Now.ToString(), ID, OrginiDate));

                }
            }
            catch (StackExchange.Redis.RedisConnectionException rce)
            {
                //DeviceConnect.cache = new RedisCacheManager("CacheFileServer");
                Utils.Logger.Error(rce.ToString());
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        void InMBmaster_OnException(ushort id, byte function, byte exception)
        {
            //DevConnectStatus = false;
            CurrDeviceConnect.Connected = false;

            Utils.Logger.Error(string.Format("ExeID:{0} -错误编号：{1}", id, exception));
        }

        // public InheritMaster InMBmaster;

        public DeveiceTaskExecute MyDevTaskExecute = new DeveiceTaskExecute();

        /// <summary>
        /// 执行编号
        /// </summary>
        public int ExecID { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public string DevCode { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName { get; set; }

        public DeviceConnect CurrDeviceConnect { set; get; }

        public bool DevConnectStatus { get; set; }

        public bool CollectStatus { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 执行频率(秒)
        /// </summary>
        public int CollFrequency { get; set; }

        /// <summary>
        /// 本地保存频率(分钟)
        /// </summary>
        public int LocalSaveFrequency { get; set; }

        /// <summary>
        /// 最后采集时间
        /// </summary>
        public DateTime LastCollTime { get; set; }

        /// <summary>
        /// 最后本地保存时间
        /// </summary>
        public DateTime LastLocalSaveTime { get; set; }

        #region
        /// <summary>
        /// 数采仪IP   XCQ新增2016-11-22
        /// 新增设备状态DevStatus字段，设备参数名称 20161129
        /// </summary>
        public string IPUrl { get; set; }

        /// <summary>
        /// 设备端口
        /// </summary>
        public ushort DevicePort { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 访问ID
        /// </summary>
        public byte CallID { get; set; }

        /// <summary>
        /// 放置区域
        /// </summary>
        public string LocalAddress { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public int DevpAddress { get; set; }

        /// <summary>
        /// 字节长度
        /// </summary>
        public ushort SendFormat { get; set; }

        /// <summary>
        /// 设备规格：用于区分FX3跟AD6不同的监听事件，绑定同时处理不同的数据
        /// </summary>
        public string DevStd { get; set; }

        public int DevStatus { get; set; }

        public string DevpName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsHandle { get; set; }

        public bool SwitchID { get; set; }

        public int? ConAccAddress { get; set; }  //控制访问地址，用于接口专门控制接口的寄存器地址

        public string ConvertType { get; set; }  //转换类型

        #endregion

        public void Dispose()
        {
            if (CurrDeviceConnect.Master.connected)
                CurrDeviceConnect.Master.Dispose();
        }
    }
}
