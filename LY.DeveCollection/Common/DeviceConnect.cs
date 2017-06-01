using Client.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Client.Utility.Logging;
using Client.Utility.Caching;
using Client.Utility.Extension;

namespace LY.DeveCollection.Common
{
    public class DeviceConnect
    {
        public static Dictionary<string, DeviceConnect> _deviceConnects = new Dictionary<string, DeviceConnect>();

        public ICacheManager cache;

        public static DeviceConnect AddDeviceConnect(string deveCode, string deveName, string host, int port)
        {

            if (_deviceConnects.ContainsKey(deveCode) == false)
            {
                var model = new DeviceConnect(deveCode, deveName, host, port);

                if (model._Connected == true)
                {
                    //model._Master = model.InitConnect();
                    //_deviceConnects.Add(model.DeveCode, model);

                    Utils.Logger.Error("No Connnected about Decive Because of Internet program - DeviceConnect-34");

                }
                else if (model._Connected == false)
                {

                    model._Master = model.InitConnect();
                    _deviceConnects.Add(model.DeveCode, model);

                }

                return model;
            }
            else
            {
                return _deviceConnects[deveCode];
            }

        }

        /// <summary>
        /// 初始化设备链接
        /// </summary>
        /// <returns></returns>
        private InheritMaster InitConnect(bool bInit = true)
        {
            try
            {
                if (bAllUnConnected == false)
                {

                    int iNum = 0;
                    PingReply reply = null;
                    do
                    {
                        if (iNum == 1 && bInit)
                        {
                            InternetStatus = false;
                            break;
                        }

                        if (iNum > 0)
                            System.Threading.Thread.Sleep(1000);
                        Ping pingSener = new Ping();
                        reply = pingSener.Send(this.host, this.port);
                        iNum++;
                    } while (reply.Status != IPStatus.Success && iNum <= 100);

                    if (reply.Status == IPStatus.Success)
                    {
                        if (_Master == null)
                            _Master = new InheritMaster(this.host, (ushort)this.port);
                        else
                            _Master.connect(this.host, (ushort)this.port);
                        //       if (cache == null)
                        cache = new RedisCacheManager("CacheFileServer");
                        Connected = true;
                        InternetStatus = true;
                        //_Master.OnResponseData += new InheritMaster.ResponseData(InMBmaster_OnResponseData);//启用数据监听事件
                        //_Master.OnException += InMBmaster_OnException;
                    }
                    else
                    {
                        bAllUnConnected = true;
                    }
                }
                // _Master.OnResponseData += new InheritMaster.ResponseData(InMBmaster_OnResponseData);//启用数据监听事件
                //     _Master.OnException += InMBmaster_OnException;
            }
            catch (Exception ex)
            {

            }
            return _Master;
        }

        object obj = 1;


        private DeviceConnect(string deveCode, string deveName, string host, int port)
        {
            this.deveCode = deveCode;
            this.deveName = deveName;
            this.host = host;
            this.port = port;
            bAllUnConnected = false;
        }

        public bool bInitEvent = false;
        private string deveCode;
        private string deveName;
        private string host;
        private int port;

        //  private InheritMaster _Master;
        private InheritMaster _Master;

        public string DeveCode { get { return deveCode; } }
        public string DeveName { get { return deveName; } }
        public string Host { get { return host; } }
        public int Port { get { return port; } }

        private bool _Connected;

        public bool Connected
        {
            get
            {
                if (_Connected == false)
                {
                    _Master = InitConnect(false);
                    //_Connected = true;
                }
                return _Connected;
            }
            set { _Connected = value; }
        }

        public bool bAllUnConnected { get; set; }

        public bool InternetStatus { get; set; }

        public InheritMaster Master
        {
            get
            {
                return _Master;
            }
        }
    }
}
