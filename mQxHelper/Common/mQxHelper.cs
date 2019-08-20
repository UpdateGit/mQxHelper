﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    public class mQxHelper
    {

        #region 生成订单号
        ///// <summary>
        ///// 生成订单号
        ///// </summary>
        ///// <param name="MerchantID"></param>
        ///// <returns></returns>
        //public string GetOrderNumber(int MerchantID)
        //{
        //    //生成订单号
        //    //订单号生成原则：年（4位）+月（2位）+日（2位）+时（2位）+分（2位）+秒（2位）+商家编号（5位，不够左补0）+5位随机数，2018 10 10 21 30 2 1      00001 43261

        //    //商家编号（5位，不够左补0）
        //    string merchant = MerchantID.ToString();
        //    merchant = merchant.PadLeft(5, '0');     // 共5位，之前用0补齐

        //    string num = GetRandomString(5);//自动生成一个5位随机数

        //    string ordernum = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") +
        //    DateTime.Now.ToString("hh") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss") +
        //    merchant + num;

        //    return ordernum;
        //}
        #endregion

        #region 生成记录编号
        /// <summary>
        /// 生成记录编号
        /// </summary>
        /// <returns></returns>
        public static string GetRecordNumber(string PrefixCode)
        {
            //记录编号生成原则：毫米级时间戳+5位随机数
            string recordNumber = PrefixCode + GetTimeStamp() + GetRandomNum(10000, 99999);

            return recordNumber;
        }
        #endregion

        #region  获取时间戳 -毫秒
        /// <summary> 
        /// 获取时间戳 -毫秒
        /// </summary> 
        /// <returns></returns> 
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();

        }
        #endregion

        #region 获取非负随机整数
        /// <summary>
        /// 摘要:
        ///     返回一个非负随机整数。
        ///
        /// 返回结果:
        ///     一个 32 位有符号的整数，它是大于或等于 0 且小于比System.Int32.MaxValue。
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomNum(int maxValue)
        {
            return new Random(GetRandomSeed()).Next(maxValue);
        }
        #endregion

        #region 获取在指定范围内的任意整数
        /// <summary>
        /// 摘要:
        ///     返回在指定范围内的任意整数。
        ///
        /// 参数:
        ///   minValue:
        ///     返回的随机数字包含下限。
        ///
        ///   maxValue:
        ///     返回随机数的不含上限。 maxValue必须大于或等于minValue。
        ///
        /// 返回结果:
        ///     32 位有符号的整数大于或等于minValue和小于maxValue; 即，返回值的范围包括minValue但不是maxValue。 如果minValue等于maxValue，minValue返回。
        ///
        /// 异常:
        ///   T:System.ArgumentOutOfRangeException:
        ///     minValue 大于 maxValue。
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomNum(int minValue, int maxValue)
        {
            return new Random(GetRandomSeed()).Next(5000, 30000);//玩家没有猜对，机器人猜对的时间在5秒~30秒
        }
        #endregion

        #region 描 述:创建加密随机数生成器 生成强随机种子
        /// <summary>
        /// 描 述:创建加密随机数生成器 生成强随机种子
        /// </summary>
        /// <returns></returns>
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        #endregion

        #region 判断字符串是否为字母或数字
        /// <summary>
        /// 判断字符串是否为字母或数字
        /// </summary>
        public static bool IsNumOrAlp(string str)
        {
            string pattern = @"^[A-Za-z0-9]+$";  //@意思忽略转义，+匹配前面一次或多次，$匹配结尾
            Match match = Regex.Match(str, pattern);
            return match.Success;
        } 
        #endregion
    }
}
