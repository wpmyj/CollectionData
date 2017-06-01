using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AJBauer;

namespace LY.DeveCollection
{
    public static class FormatClass
    {
        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                string sun = Convert.ToString(InByte, 16);
                if (sun.Length == 1)
                    StringOut = StringOut + "0" + Convert.ToString(InByte, 16);//String.Format("{0:X2} ", InByte);
                else
                    StringOut = StringOut + Convert.ToString(InByte, 16);//String.Format("{0:X2} ", InByte);
            }
            return StringOut;
        }

        // ------------------------------------------------------------------------
        // Read start address
        // ------------------------------------------------------------------------
        public static ushort ReadStartAdr(string txtStartAdress)
        {
            // Convert hex numbers into decimal
            if (txtStartAdress.IndexOf("0x", 0, txtStartAdress.Length) == 0)
            {
                string str = txtStartAdress.Replace("0x", "");
                ushort hex = Convert.ToUInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToUInt16(txtStartAdress);
            }
        }

        public static float bound(float val, float low, float high)
        {
            if (val > high) val = high;
            if (val < low) val = low;
            return val;
        }

        public static Random r = new Random();

        /// <summary>
        /// generate a random double +/- 0.5 and divide it by 10
        /// and add it to the current value to 'bump' it up or
        /// down slightly
        /// </summary>
        /// <param name="fval">current value</param>
        /// <returns>new 'bumped' value</returns>
        public static float bumpPct(float fval)
        {
            fval += (float)(r.NextDouble() - 0.5F) / 100.0F;
            return fval;
        }

        public static bool stillOnline(Label lbl, bool lastState)
        {
            //simulated 95% uptime
            bool nextState = (r.NextDouble() <= 0.95) ? true : false;
            if (lastState && !nextState)
            {
                //now offline
                lbl.ForeColor = System.Drawing.Color.Red;
                lbl.Text = "OFFLINE";
            }
            else if (!lastState && nextState)
            {
                //now online
                lbl.ForeColor = System.Drawing.Color.Green;
                lbl.Text = "ONLINE";
            }
            return nextState;
        }

        public static void updateGaugeWidget(bool isOnline, AGauge gauge, float val)
        {
            if (isOnline)
            {
                //capacity utilization
                gauge.Value = (val * 100.0F);
                gauge.NeedleColor1 = AGauge.NeedleColorEnum.Blue;
            }
            else
            {
                gauge.NeedleColor1 = AGauge.NeedleColorEnum.Gray;
            }
        }

        /// <summary>
        /// 更新仪表盘
        /// </summary>
        /// <param name="gauge"></param>
        /// <param name="val"></param>
        public static void updateGaugeWidget
            (
                AGauge gauge,
                long val
            )
        {


            if (val <= 50)
            {
                gauge.Value = val;
                gauge.NeedleColor1
                    =
                    AGauge.NeedleColorEnum.Gray;

            }
            else
            {
                gauge.Value = val;
                gauge.NeedleColor1
                    =
                    AGauge.NeedleColorEnum.Blue;
            }

        }

    }
}
