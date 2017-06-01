using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LY.DeveCollection.Base
{
    public partial class TextMasterInherit : Form
    {
        public TextMasterInherit()
        {
            InitializeComponent();
        }


      //  public static Master MBmaster;

        public static InheritMaster InMBmaster;

        public static InheritMaster InMBmaster01;
        public static InheritMaster InMBmaster02;
        public static InheritMaster InMBmaster03;
        public static InheritMaster InMBmaster04;
        public static InheritMaster InMBmaster05;
        public static InheritMaster InMBmaster06;
        public static InheritMaster InMBmaster07;
        public static InheritMaster InMBmaster08;




        private void button1_Click(object sender, EventArgs e)
        {
            //--------------------------直接引用master测试--------------------------------------//
            // MBmaster = new Master(IPEdit.Text, (ushort)Convert.ToInt16(PortEdit.Text));  //master类通用连接功能，带IP跟端口参数
            //MBmaster.OnResponseData += new Master.ResponseData(MBmaster_OnResponseData);//启用数据监听事件
            //Status.Text = "已连接";
            //--------------------------直接引用master测试--------------------------------------//

            InMBmaster01 = new InheritMaster(IPEdit.Text, (ushort)Convert.ToInt16(PortEdit.Text));  //master类通用连接功能，带IP跟端口参数
            InMBmaster01.OnResponseData += new InheritMaster.ResponseData(InMBmaster_OnResponseData);//启用数据监听事件
            Status.Text = "已连接";
        }

        private void InMBmaster_OnResponseData(ushort ID, byte function, byte[] values)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new InheritMaster.ResponseData(InMBmaster_OnResponseData), new object[] { ID, function, values });
                return;
            }

         //   OrigiDataEdit.Text = InMBmaster.GetOrigidata(values);
          //  MessageBox.Show(InMBmaster.GetOrigidata(values));

            OrigiDataEdit.Text = ID.ToString();

        }



        private void button2_Click(object sender, EventArgs e)
        {

            ushort ID = FormatClass.ReadStartAdr(DevIDEdit.Text); 
            ushort StartAddress = FormatClass.ReadStartAdr(AddressEdit.Text);
            ushort Length = Convert.ToUInt16(Convert.ToInt32(LenghtEdit.Text));
            byte VisID = (byte)Convert.ToInt32(VisIDEdit.Text);

            InMBmaster.ReadHoldingRegister(ID, StartAddress, Length, VisID);
         


        }

        
       
    }

    public enum DeveDataType
    { 
        /// <summary>
        /// AD6,设备
        /// </summary>
        AD6,
        FX3
    }

}
