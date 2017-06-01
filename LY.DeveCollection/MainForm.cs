using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LY.DeveCollection.Base;
using LY.DeveCollection.SRExctue;
using Client.Utility.Logging;
using Client.Utility;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using Client.Utility.Protocol;
using LY.DeveCollection.Common;


namespace LY.DeveCollection
{
    public partial class MainForm : Form
    {
        #region    监听服务,全局变量设置,委托事件声明

        /// <summary>
        /// 工作台任务
        /// </summary>
        private static WorkbenchTaskList<WorkbenchTaskExecute> lstWorkbenchTask = new WorkbenchTaskList<WorkbenchTaskExecute>();
        private BindingSource modelSource = new BindingSource();

        /// <summary>
        /// DevExecuteServiceClient服务，用于提取设备执行表视图的数据 20161126XCQ
        /// </summary>
        DevExecuteServiceClient client = new SRExctue.DevExecuteServiceClient();

        private delegate void myDelegate(string str);

        private delegate void myCombox(string str);

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        /// <summary>
        /// 监听事件
        /// </summary>
        public Socket sock;          //定义一个Socket类的对象 (默认为protected
        private Socket soc;
        private IPEndPoint iep;
        private Thread th;
        private bool bol = false;
        List<Socket> arrya = new List<Socket>();
        public delegate void OnDisconnectDelegate(Object sender, IPEndPoint peer);


        public delegate void UpdateControlEventHandler(Object sender, EventArgs e, Socket sock);
        public static event UpdateControlEventHandler UpdateControl;//用于StatusList控件更新增加IP的功能

        public delegate void UpListStatuList(object sender, EventArgs e, Socket sock);
        public static event UpListStatuList RemoveListStatus;   //用于StatusList控件更新移除IP的功能


        public delegate void UpdateOperatorList(Object sender, EventArgs e, Socket soc, string ExecOrder);
        public static event UpdateOperatorList UpdateOperList;




        public static Master MBmaster;
        #endregion

        #region Event



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "tlsbtnStart":
                        if (e.ClickedItem.Text.Equals("开始任务"))
                        {
                            DeviceConnect._deviceConnects.Clear();
                            //获取合适转鼓号码
                            var Address = client.GetDevViewListAllAddress("test");
                            //    var Address = client.GetDevViewListAllDevName("test");
                            for (int i = 0; i <= Address.Length - 1; i++)
                            {
                                
                                WorkbenchTaskExecute work = new WorkbenchTaskExecute(Address[i].ToString(), Address[i].ToString());
                                //根据合适转鼓号码获取其IP
                                var ZG_2 = client.GetDevViewListByAddress("test", Address[i].ToString());

                                //遍历IP，根据IP进行下面的处理
                                if (ZG_2 != null)
                                {
                                    for (int j = 0; j <= ZG_2.Data.Length - 1; j++)
                                    //   for (int j = ZG_2.Data.Length - 1; j <= ZG_2.Data.Length - 1; j++)
                                    {
                                      
                                        //根据传入数据跟设备进行握手协议，启用监听事件，将监听到的数据保存在服务器缓存中
                                        work.LstDeveiceTask.Add(new DeveiceTaskInfo()
                                        {
                                            //CollFrequency =(int) ZG_2.Data[j].采集频率,
                                            CollFrequency = (int)ZG_2.Data[j].CollFrequency,
                                            IPUrl = ZG_2.Data[j].IPUrl,
                                            DevicePort = (ushort)ZG_2.Data[j].Port,
                                            CurrDeviceConnect = DeviceConnect.AddDeviceConnect(ZG_2.Data[j].DevCode, ZG_2.Data[j].DevName, ZG_2.Data[j].IPUrl, ZG_2.Data[j].Port.Value),
                                            ExecID = ZG_2.Data[j].ExecuteID,
                                            DevpAddress = (int)ZG_2.Data[j].DevpAddress,
                                            SendFormat = Convert.ToUInt16(Convert.ToInt32(ZG_2.Data[j].SendFormat)),
                                            CallID = (byte)ZG_2.Data[j].CallID,
                                            DevStd = ZG_2.Data[j].DevStd,
                                            DevStatus = ZG_2.Data[j].EquipStatus,
                                            DevpName = ZG_2.Data[j].DeviName,
                                            LocalAddress = ZG_2.Data[j].LocalAddress,
                                            DevName = ZG_2.Data[j].DevName,
                                            ConvertType = ZG_2.Data[j].ConvertType,
                                            ConAccAddress = ZG_2.Data[j].ConAccAddress
                                        }.init());

                                    }
                                    lstWorkbenchTask.Add(work);   


                                }


                                timer1.Start();
                                e.ClickedItem.Text = "停止任务";
                                dataGridView1.DataSource = null;
                                modelSource.DataSource = lstWorkbenchTask;
                                dataGridView1.DataSource = modelSource;

                                TaskStart.PerformClick();
                            }
                        }
                        else
                        {

                            timer1.Stop();
                            for (int i = lstWorkbenchTask.Count - 1; i >= 0; i--)
                            {
                                //lstWorkbenchTask[i].Dispose();
                                var model = lstWorkbenchTask[i];
                                lstWorkbenchTask.Remove(model);
                            }
                            modelSource.DataSource = null;
                            e.ClickedItem.Text = "开始任务";

                        }
                        break;
                    case "tsbtnExit":
                        this.Close();
                        break;

                    case "tsbtntext":

                        break;


                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            modelSource.DataSource = lstWorkbenchTask;
            dataGridView1.DataSource = modelSource;

            //if ( lstWorkbenchTask.First().LstDeveiceTask.Where(t => t.ExecID == ExecuteID).FirstOrDefault()== false)
            //{

            //}
            //if (lstWorkbenchTask.First().LstDeveiceTask.Where(t => t.DevConnectStatus == false).FirstOrDefault() != null)
            //{


            //    }
            //    try
            //    {
            //        //   timer1.Stop();



            //        //   DeviceConnect._deviceConnects.Clear();
            //        //获取合适转鼓号码
            //        var Address = client.GetDevViewListAllAddress("test");
            //        for (int i = 0; i <= Address.Length - 1; i++)
            //        {

            //            var ZG_2 = client.GetDevViewListByAddress("test", Address[i].ToString());
            //            //遍历IP，根据IP进行下面的处理
            //            for (int j = 0; j <= ZG_2.Data.Length - 1; j++)
            //            //     for (int j = ZG_2.Data.Length - 1; j <= ZG_2.Data.Length - 1; j++)
            //            {
            //                //根据传入数据跟设备进行握手协议，启用监听事件，将监听到的数据保存在服务器缓存中
            //                DeviceConnect.AddDeviceConnect(ZG_2.Data[j].DevCode, ZG_2.Data[j].DevName, ZG_2.Data[j].IPUrl, ZG_2.Data[j].Port.Value);
            //                //   DeviceConnect CurrDeviceConnect = new DeviceConnect();
            //                //        DeviceConnect CurrDeviceConnect = new DeviceConnect.AddDeviceConnect(ZG_2.Data[j].DevCode, ZG_2.Data[j].DevName, ZG_2.Data[j].IPUrl, ZG_2.Data[j].Port.Value);

            //            }


            //            //    lstWorkbenchTask.Add(work);   //启动执行表定时器，开始定时发送指令进行数据采集

            //            //  timer1.Start();
            //            //    e.ClickedItem.Text = "停止任务";
            //            //dataGridView1.DataSource = null;
            //            //modelSource.DataSource = lstWorkbenchTask;
            //            //dataGridView1.DataSource = modelSource;

            //            //     TaskStart.PerformClick();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        Utils.Logger.Error(ex.ToString() + DateTime.Now);
            //    }

            //}


        }

        private void tsbtntext_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DevStatus MyDevStatus = new DevStatus(lstWorkbenchTask[e.RowIndex]);
            MyDevStatus.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!bol)
            {
                TaskStart.Enabled = false;
                IPPortText.Enabled = false;
                //  TaskEnd.Enabled = true;
                try
                {
                    //开启监听
                    th = new Thread(new ThreadStart(BeginListen));          //创建一个新的线程专门用于处理监听,这句话可以分开写的,比如: ThreadStart ts=new ThreadStart(BeginListen); th=new Thread (ts); 不过要注意, ThreadStart的构造函数的参数一定要是无参数的函数. 在此函数名其实就是其指针, 这里是委托吗?
                    th.Start();
                    //    StutasList.Items.Add("Listenning...");
                }
                catch (SocketException se)           //处理异常
                {
                    MessageBox.Show(se.Message, "出现问题", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentNullException ae)   //参数为空异常
                {
                    StutasList.Text = "参数错误";
                    MessageBox.Show(ae.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                th.Resume();
                bol = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskStart.Enabled = true;
            TaskEnd.Enabled = false;
            IPPortText.Enabled = true;

            bol = true;
            for (int i = 0; i < arrya.Count; i++)
            {
                arrya[i].Shutdown(SocketShutdown.Both);
                arrya[i].Close();

            }
            StutasList.Items.Clear();
            StutasList.Items.Add("停止监听");
            th.Suspend();
            soc.Close();
            soc.Dispose();
            //   sock.Close();
            //   TheradScoket();

        }



        #endregion

        #region Method


        public class StateObjcet
        {
            public Socket workSocket;
            public const int BufferSize = 256;

            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }


        private void TheradScoket()
        {

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Close();
        }

        public static IPAddress GetServerIP()        //静态函数, 无需实例化即可调用.
        {
            IPHostEntry ieh = Dns.GetHostByName(Dns.GetHostName()); //不多说了, Dns类的两个静态函数
            return ieh.AddressList[0];                  //返回Address类的一个实例. 这里AddressList是数组并不奇怪,一个Server有N个IP都有可能
        }

        private void BeginListen()               //Socket监听函数, 等下作为创建新线程的参数
        {
            // 捕获所有错误的线程调用
            //  Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                soc.Bind(iep);                                  //Socket类的一个重要函数, 绑定一个IP,
                soc.Listen(1000);//监听状态
                while (true)
                {
                    allDone.Reset();
                    soc.BeginAccept(new AsyncCallback(AcceptCallback), soc);// 异步接收
                    allDone.WaitOne();
                    System.GC.Collect();
                }
            }

            catch (SocketException se)              //捕捉异常,
            {
                Utils.Logger.Error(se.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
            finally
            {
                allDone.Close();
                allDone.Dispose();
                soc.Close();
                soc.Dispose();
            }

        }


        public static void AcceptCallback(IAsyncResult er)
        {

            bool Flag_IP = false;
            try
            {
                allDone.Set();
                // 异步获取用户对象
                Socket listener = (Socket)er.AsyncState;
                //异步接收连接通讯
                Socket handler = listener.EndAccept(er);
                StateObjcet state = new StateObjcet();
                state.workSocket = handler;
                IPAddress remote_ip = ((IPEndPoint)handler.RemoteEndPoint).Address;  //获取远程连接IP，用于安全处理



                using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
                {
                    var ret = client.GetAllIPRegistForm("test");
                    foreach (SRCfPExecute.IPRegistForm i in ret.Data)
                    {
                        if (remote_ip.ToString() == i.IP)
                        {
                            UpdateControl(new MainForm(), new EventArgs(), handler);
                            Utils.Logger.Debug(i.IP + "该IP已登记，顺利连接");
                            Flag_IP = true;
                            break;
                        }
                    }
                }
                if (!Flag_IP)
                {
                    Utils.Logger.Debug(remote_ip.ToString() + "该IP未登记，连接中断");
                    Byte[] byteMessage = new Byte[100]; //存放消息的字节数组缓冲区, 注意数组表示方法,和C不同的.                      
                    byteMessage = System.Text.Encoding.Default.GetBytes("error 401:IP no Regiter");
                    Socket SelectSocket = handler;
                    SelectSocket.BeginSend(byteMessage, 0, byteMessage.Length, 0, new AsyncCallback(SendCallback), SelectSocket);
                    SelectSocket.Dispose();
                }
                else
                {

                    Byte[] byteMessage = new Byte[100]; //存放消息的字节数组缓冲区, 注意数组表示方法,和C不同的.                      
                    byteMessage = System.Text.Encoding.Default.GetBytes("Connectting");
                    Socket SelectSocket = handler;

                    try
                    {

                        SelectSocket.BeginSend(byteMessage, 0, byteMessage.Length, 0, new AsyncCallback(SendCallback), SelectSocket);

                        handler.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                    }
                    catch (ObjectDisposedException ex)
                    {
                        Utils.Logger.Error(ex.ToString());
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }

        private static void SendCallback(IAsyncResult er)
        {
            try
            {
                Socket handler = (Socket)er.AsyncState;
            }
            catch (Exception e)
            {
                Utils.Logger.Error(e.ToString());
            }
        }


        public static void ReadCallback(IAsyncResult er)
        {

            DevExecuteServiceClient client = new SRExctue.DevExecuteServiceClient();
            StateObjcet so = (StateObjcet)er.AsyncState;
            Socket s = so.workSocket;
            try
            {
                //异读取步
                int read = s.EndReceive(er);
                if (read > 0)
                {
                    s.BeginReceive(so.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReadCallback), so);

                    string Order = Encoding.ASCII.GetString(so.buffer, 0, read);

                    UpdateOperList(new MainForm(), new EventArgs(), s, Order);

                    string[] DealOrder = Order.Split('-');
                    string CheckCode = Order.Substring(0, 3);
                    string Switch = Order.Substring(4, 1);
                    int ExecuteID = Convert.ToInt16(Order.Substring(6, read - 6));

                    bool SwitchID = (Switch == "1") ? true : false;

                    var devTaskInfo = lstWorkbenchTask.First().LstDeveiceTask.Where(t => t.ExecID == ExecuteID).FirstOrDefault();
                    //         var devTaskInfo = lstWorkbenchTask.Where(t=>t.).LstDeveiceTask.Where(t => t.ExecID == ExecuteID).FirstOrDefault();

                    if (devTaskInfo == null)
                    {
                        IPAddress remote_ip = ((IPEndPoint)s.RemoteEndPoint).Address;
                        Utils.Logger.Debug(remote_ip.ToString() + "该IP发送错误指令，无该指令中的执行ID");
                        Byte[] byteMessage = new Byte[100]; //存放消息的字节数组缓冲区, 注意数组表示方法,和C不同的.                      
                        byteMessage = System.Text.Encoding.Default.GetBytes("error 402:no ExecID");
                        Socket SelectSocket = s;
                        SelectSocket.BeginSend(byteMessage, 0, byteMessage.Length, 0, new AsyncCallback(SendCallback), SelectSocket);

                    }

                    if (devTaskInfo != null)

                        //      devTaskInfo.InMBmaster.WriteSingleCoils((ushort)devTaskInfo.ExecID, (ushort)devTaskInfo.ConAccAddress.Value, SwitchID, devTaskInfo.CallID);
                        devTaskInfo.CurrDeviceConnect.Master.WriteSingleCoils((ushort)devTaskInfo.ExecID, (ushort)devTaskInfo.ConAccAddress.Value, SwitchID, devTaskInfo.CallID);
                    Utils.Logger.Debug(s.RemoteEndPoint + "执行ID" + ExecuteID.ToString() + "操作" + SwitchID.ToString());

                }
                else
                {
                    RemoveListStatus(new MainForm(), new EventArgs(), s);
                    s.Shutdown(SocketShutdown.Both);
                }
            }

            catch (SocketException)
            {

                s.Shutdown(SocketShutdown.Both);
                return;
            }
            catch (ObjectDisposedException)
            {
                return;
            }

        }


        public void Test(Object o, EventArgs e, Socket sock)  //事件处理函数，用来更新增加连接IP控件
        {
            try
            {

                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        IPAddress remote_ip = ((IPEndPoint)sock.RemoteEndPoint).Address;
                        if (this.StutasList.Items.Count == 20)
                            this.StutasList.Items.RemoveAt(this.StutasList.Items.Count - 1);
                        string text = string.Format("{0} - {1} - {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), remote_ip, "Connectting");
                        this.StutasList.Items.Insert(0, text);

                        //  this.listBoxOnline.Items.Insert(0, remote_ip);
                        this.listBoxOnline.Items.Add(remote_ip);
                        Utils.Logger.Debug(text);
                    });

                }


            }
            catch (ObjectDisposedException ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        public void RemoveIPList(object o, EventArgs e, Socket sock)
        {
            try
            {

                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        IPAddress remote_ip = ((IPEndPoint)sock.RemoteEndPoint).Address;
                        if (this.StutasList.Items.Count == 20)
                            this.StutasList.Items.RemoveAt(this.StutasList.Items.Count - 1);
                        string text = string.Format("{0} - {1} - {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), remote_ip, "Disconnect");
                        this.StutasList.Items.Insert(0, text);

                        this.listBoxOnline.Items.Remove(remote_ip);


                        Utils.Logger.Debug(text);

                        //this.comboBox1.Items.Remove(sock.RemoteEndPoint.ToString());
                        arrya.Remove(sock);
                    });

                }
            }
            catch (ObjectDisposedException ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }



        public void OperatorListTest(Object o, EventArgs e, Socket sock, string ExecOrder)  //事件处理函数，用来更新指令显示控件
        {
            try
            {

                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        IPAddress remote_ip = ((IPEndPoint)sock.RemoteEndPoint).Address;
                        if (this.OperatorList.Items.Count == 20)
                            this.OperatorList.Items.RemoveAt(this.OperatorList.Items.Count - 1);
                        string text = string.Format("{0} - {1} - {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), remote_ip, ExecOrder);
                        this.OperatorList.Items.Insert(0, text);
                        Utils.Logger.Debug(text);
                    });

                }


            }
            catch (ObjectDisposedException ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }




        #endregion

        #region 主程序
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            UpdateControl += new UpdateControlEventHandler(this.Test);  //监听服务器：订阅UpdateControl事件，指定Test方法为事件处理函数

            UpdateOperList += new UpdateOperatorList(this.OperatorListTest);  //监听服务器：订阅UpdateControl事件，指定Test方法为事件处理函数

            RemoveListStatus += new UpListStatuList(this.RemoveIPList);//订阅UpListStatuList事件，指定RemoveIPList方法为事件处理函数，用于移除断开连接的IP

            TaskEnd.Enabled = false;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IPAddress serverIp = GetServerIP();
            //   IPAddress serverIp = IPAddress.Parse("192.168.3.150");
            iep = new IPEndPoint(serverIp, Convert.ToInt32(IPPortText.Text));    //本地终结点
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);   //实例化内成员soc;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            TaskEnd.PerformClick();
            allDone.Close();
            allDone.Dispose();
            soc.Close();
            soc.Dispose();
        }

        #endregion
    }
}
