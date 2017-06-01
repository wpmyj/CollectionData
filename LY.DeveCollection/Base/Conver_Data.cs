using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace LY.DeveCollection
{
    public class Conver_Data
    {
        /// <summary>
        /// 十进制转换为二进制
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string DecToBin(string x)
        {
            string z = null;
            int X = Convert.ToInt32(x);
            int i = 0;
            long a, b = 0;
            while (X > 0)
            {
                a = X % 2;
                X = X / 2;
                b = b + a * Pow(10, i);
                i++;
            }
            z = Convert.ToString(b);
            return z;
        }

        /// <summary>
        /// 16进制转ASCII码
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static string HexToAscii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(
                    Convert.ToString(
                        Convert.ToChar(Int32.Parse(hexString.Substring(i, 2),
                                                   System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 十进制转换为八进制
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string DecToOtc(string x)
        {
            string z = null;
            int X = Convert.ToInt32(x);
            int i = 0;
            long a, b = 0;
            while (X > 0)
            {
                a = X % 8;
                X = X / 8;
                b = b + a * Pow(10, i);
                i++;
            }
            z = Convert.ToString(b);
            return z;
        }

        /// <summary>
        /// 十进制转换为十六进制
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string DecToHex(string x)
        {
            if (string.IsNullOrEmpty(x))
            {
                return "0";
            }
            string z = null;
            int X = Convert.ToInt32(x);
            Stack a = new Stack();
            int i = 0;
            while (X > 0)
            {
                a.Push(Convert.ToString(X % 16));
                X = X / 16;
                i++;
            }
            while (a.Count != 0)
                z += ToHex(Convert.ToString(a.Pop()));
            if (string.IsNullOrEmpty(z))
            {
                z = "0";
            }
            return z;
        }

        /// <summary>
        /// 二进制转换为十进制
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string BinToDec(string x)
        {
            string z = null;
            int X = Convert.ToInt32(x);
            int i = 0;
            long a, b = 0;
            while (X > 0)
            {
                a = X % 10;
                X = X / 10;
                b = b + a * Pow(2, i);
                i++;
            }
            z = Convert.ToString(b);
            return z;
        }

        /// <summary>
        /// 二进制转换为十进制，定长转换
        /// </summary>
        /// <param name="x"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public static string BinToDec(string x, short iLength)
        {
            StringBuilder sb = new StringBuilder();
            int iCount = 0;

            iCount = x.Length / iLength;

            if (x.Length % iLength > 0)
            {
                iCount += 1;
            }

            int X = 0;

            for (int i = 0; i < iCount; i++)
            {
                if ((i + 1) * iLength > x.Length)
                {
                    X = Convert.ToInt32(x.Substring(i * iLength, (x.Length - iLength)));
                }
                else
                {
                    X = Convert.ToInt32(x.Substring(i * iLength, iLength));
                }
                int j = 0;
                long a, b = 0;
                while (X > 0)
                {
                    a = X % 10;
                    X = X / 10;
                    b = b + a * Pow(2, j);
                    j++;
                }
                sb.AppendFormat("{0:D2}", b);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 二进制转换为十六进制，定长转换
        /// </summary>
        /// <param name="x"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public static string BinToHex(string x, short iLength)
        {
            StringBuilder sb = new StringBuilder();
            int iCount = 0;

            iCount = x.Length / iLength;

            if (x.Length % iLength > 0)
            {
                iCount += 1;
            }

            int X = 0;

            for (int i = 0; i < iCount; i++)
            {
                if ((i + 1) * iLength > x.Length)
                {
                    X = Convert.ToInt32(x.Substring(i * iLength, (x.Length - iLength)));
                }
                else
                {
                    X = Convert.ToInt32(x.Substring(i * iLength, iLength));
                }
                int j = 0;
                long a, b = 0;
                while (X > 0)
                {
                    a = X % 10;
                    X = X / 10;
                    b = b + a * Pow(2, j);
                    j++;
                }
                //前补0
                sb.Append(DecToHex(b.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 八进制转换为十进制
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string OctToDec(string x)
        {
            string z = null;
            int X = Convert.ToInt32(x);
            int i = 0;
            long a, b = 0;
            while (X > 0)
            {
                a = X % 10;
                X = X / 10;
                b = b + a * Pow(8, i);
                i++;
            }
            z = Convert.ToString(b);
            return z;
        }


        /// <summary>
        /// 十六进制转换为十进制
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string HexToDec(string x)
        {
            if (string.IsNullOrEmpty(x))
            {
                return "0";
            }
            string z = null;
            Stack a = new Stack();
            int i = 0, j = 0, l = x.Length;
            long Tong = 0;
            while (i < l)
            {
                a.Push(ToDec(Convert.ToString(x[i])));
                i++;
            }
            while (a.Count != 0)
            {
                Tong = Tong + Convert.ToInt64(a.Pop()) * Pow(16, j);
                j++;
            }
            z = Convert.ToString(Tong);
            return z;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static long Pow(long x, long y)
        {
            int i = 1;
            long X = x;
            if (y == 0)
                return 1;
            while (i < y)
            {
                x = x * X;
                i++;
            }
            return x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static string ToDec(string x)
        {
            switch (x)
            {
                case "A":
                    return "10";
                case "B":
                    return "11";
                case "C":
                    return "12";
                case "D":
                    return "13";
                case "E":
                    return "14";
                case "F":
                    return "15";
                default:
                    return x;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static string ToHex(string x)
        {
            switch (x)
            {
                case "10":
                    return "A";
                case "11":
                    return "B";
                case "12":
                    return "C";
                case "13":
                    return "D";
                case "14":
                    return "E";
                case "15":
                    return "F";
                default:
                    return x;
            }
        }

        /// <summary>
        /// 将16进制BYTE数组转换成16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes, int iLength) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                if (bytes.Length < iLength)
                {
                    iLength = bytes.Length;
                }

                for (int i = 0; i < iLength; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// 将byte数组转换为16进制字符串
        /// </summary>
        /// <param name="bytes">要转换的数组</param>
        /// <param name="iStart">数组下标</param>
        /// <param name="iLength">长度</param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes, int iStart, int iLength) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                //缓冲区长度问题，需清空缓冲区
                if (bytes.Length < (iLength + iStart))
                {
                    iLength = bytes.Length;
                }

                for (int i = iStart; i < iLength + iStart; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexString"></param>
        /// <param name="discarded"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (Uri.IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            return HexToByte(newString);
        }

        /// <summary>
        /// Converts from binary coded decimal to integer
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static uint BcdToDec(uint num)
        {
            return HornerScheme(num, 0x10, 10);
        }

        /// <summary>
        /// Converts from integer to binary coded decimal
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static uint DecToBcd(uint num)
        {
            return HornerScheme(num, 10, 0x10);
        }

        private static uint HornerScheme(uint num, uint divider, uint factor)
        {
            uint remainder = 0, quotient = 0, result = 0;
            remainder = num % divider;
            quotient = num / divider;
            if (!(quotient == 0 && remainder == 0))
                result += HornerScheme(quotient, divider, factor) * factor + remainder;
            return result;
        }

        /// <summary>
        /// byte数组尾部0截取函数
        /// </summary>
        /// <param name="buf">原始byte数组</param>
        /// <param name="iLength">要截取的长度</param>
        /// <returns>截取后的数组</returns>
        public static byte[] InterceptByte(byte[] buf, int iLength)
        {
            StringBuilder sb = new StringBuilder(iLength * 2);
            sb = sb.Append(ToHexString(buf, (short)iLength));
            int discarded = 0;
            byte[] bReturn = GetBytes(sb.ToString(), out discarded);

            if (discarded > 0)
            {
                throw new Exception("byte数组截取有数据丢失！");
            }
            return bReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexToByte(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                hexString = "00";
            }
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 日期转BCD数组
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="type">4 6 7</param>
        /// <returns></returns>
        public static byte[] DateTimeToBCD(DateTime dateTime, ushort type)
        {
            string strServerTime = string.Format("{0:yyyyMMddHHmmss}", dateTime);

            byte[] bcd = new byte[type];
            if (type == 4)
            {
                bcd[0] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(0, 2))).ToString("D2"));
                bcd[1] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(2, 2))).ToString("D2"));
                bcd[2] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(4, 2))).ToString("D2"));
                bcd[3] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(6, 2))).ToString("D2"));
            }
            if (type == 6)
            {
                bcd[0] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(2, 2))).ToString("D2"));
                bcd[1] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(4, 2))).ToString("D2"));
                bcd[2] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(6, 2))).ToString("D2"));
                bcd[3] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(8, 2))).ToString("D2"));
                bcd[4] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(10, 2))).ToString("D2"));
                bcd[5] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(12, 2))).ToString("D2"));
            }
            if (type == 7)
            {
                bcd[0] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(0, 2))).ToString("D2"));
                bcd[1] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(2, 2))).ToString("D2"));
                bcd[2] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(4, 2))).ToString("D2"));
                bcd[3] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(6, 2))).ToString("D2"));
                bcd[4] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(8, 2))).ToString("D2"));
                bcd[5] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(10, 2))).ToString("D2"));
                bcd[5] = byte.Parse(DecToBcd(uint.Parse(strServerTime.Substring(12, 2))).ToString("D2"));
            }
            return bcd;
        }

        /// <summary>
        /// BCD时间转日期时间
        /// </summary>
        /// <param name="bcdTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DateTime BCDToDateTime(byte[] bcdTime, ushort type)
        {
            StringBuilder sb = new StringBuilder();
            if (type == 4) //4位BCD码的日期
            {
                sb.Append(BcdToDec(bcdTime[0]).ToString("D2"));
                sb.Append(BcdToDec(bcdTime[1]).ToString("D2"));
                sb.Append('-' + BcdToDec(bcdTime[2]).ToString("D2"));
                sb.Append('-' + BcdToDec(bcdTime[3]).ToString("D2") + " ");
            }
            if (type == 6) //6位BCD码的时间
            {
                sb.Append(DateTime.Now.ToString("yyyy").Substring(0, 2));
                sb.Append(BcdToDec(bcdTime[0]).ToString("D2"));
                sb.Append('-' + BcdToDec(bcdTime[1]).ToString("D2"));
                sb.Append('-' + BcdToDec(bcdTime[2]).ToString("D2") + " ");
                sb.Append(BcdToDec(bcdTime[3]).ToString("D2") + ":");
                sb.Append(BcdToDec(bcdTime[4]).ToString("D2") + ":");
                sb.Append(BcdToDec(bcdTime[5]));
            }
            if (type == 7) //7位BCD码的日期
            {
                sb.Append(BcdToDec(bcdTime[0]).ToString("D2"));
                sb.Append(BcdToDec(bcdTime[1]).ToString("D2"));
                sb.Append('-' + BcdToDec(bcdTime[2]).ToString("D2"));
                sb.Append('-' + BcdToDec(bcdTime[3]).ToString("D2") + " ");
                sb.Append(BcdToDec(bcdTime[4]).ToString("D2") + ":");
                sb.Append(BcdToDec(bcdTime[5]).ToString("D2") + ":");
                sb.Append(BcdToDec(bcdTime[6]));
            }

            DateTime dt;
            //2011-3-26 当日期出错时的处理
            DateTime.TryParse(sb.ToString(), out dt);

            return dt;
        }


    }
}
