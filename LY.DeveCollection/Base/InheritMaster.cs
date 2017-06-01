using LY.DeveCollection.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.DeveCollection
{
    public class InheritMaster:Master
    {
       
        public InheritMaster()
        {
        }

        public InheritMaster(string ip, ushort port)
        {
              connect(ip, port);

         //   Master MBmaster = new Master(ip, port);  //master类通用连接功能，带IP跟端口参数
        //    MBmaster.OnResponseData += new Master.ResponseData(MBmaster_OnResponseData);//启用数据监听事件

        }

        public void FX3Open(ushort ID, ushort StartAddress, ushort Length,byte DecId)
        {


            ReadHoldingRegister(ID, StartAddress, Length, DecId);
        
        }


        public void AD6Open(ushort ID, ushort StartAddress, ushort Length, byte DecId)
        {
       

            ReadCoils(ID, StartAddress, Length, DecId);

        }


        public void IoClose(ushort port)
        {
 

        }


        /// <summary>
        /// 获取FX3设备原始数据，未经过转换
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GetOrigidata(byte[] values)
        {
            
            //if (datatype == DeveDataType.AD6)
            //{ 
            //}
            byte[] byt = new byte[4];
            //第一量程
            byt[3] = values[1];
            byt[2] = values[0];
            byt[1] = values[3];
            byt[0] = values[2];

            try
            {
                string hexStr = FormatClass.ByteToString(byt);
                byte[] StringOut = new byte[4];

                for (int i = 0; i < StringOut.Length; i++)
                {
                    try
                    {
                        StringOut[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);
                    }
                    catch
                    {
                        StringOut[i] = Convert.ToByte(hexStr.Substring(i * 1, 1), 16);
                    }
                }

                Array.Reverse(StringOut);
                float ff = BitConverter.ToSingle(StringOut, 0);
                string str = String.Format("{0:F}", ff);

         //       txtbox.Text = str;
         //   double fff = (Convert.ToDouble(maxvlave) - Convert.ToDouble(minvlave)) * (Convert.ToDouble(str) - 4000) / 16000 + Convert.ToDouble(pianchavlave);


                //  return String.Format("{0:F}", ff);
                return str;
            }
            catch (Exception ex)
            {
               
             //   MessageBox.Show(ex.Message);
                return "false";

            }

        }

        /// <summary>
        /// 获取实际值，需要传入原始量，最大量程，最小量程，偏差值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxvlave"></param>
        /// <param name="minvlave"></param>
        /// <param name="pianchavlave"></param>
        /// <returns></returns>
        public string GetActualdata(string str, string maxvlave, string minvlave, string pianchavlave)
        {
            try
            {

                double fff = (Convert.ToDouble(maxvlave) - Convert.ToDouble(minvlave)) * (Convert.ToDouble(str) - 4000) / 16000 + Convert.ToDouble(pianchavlave);

                return String.Format("{0:F}", fff);
            
            }
            catch
            {
                return "false";

            }
           
        }


        public static string GetOrigiAD6data(byte[] values)
        {
            try
            {
                return values[0].ToString();

            }
            catch {
                return null;

            }

        }



    }
}
