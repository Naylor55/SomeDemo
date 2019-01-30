/* File Created: 五月 22, 2017 */
/* Author: 陈明亮 */
/* Description:基本、常规工具类*/
/* Email: cnaylor@163.com */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeadingSite.PublicClass
{
    /// <summary>
    /// 基本、常规工具类
    /// </summary>
    public class BaseTool
    {
        /// <summary>
        /// 字符串转Int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns>返回转换成功后的Int值，若不成功，返回0</returns>
        public static int StringToInt(string str)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(str);
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// 邮箱验证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool CheckIsEmail(string str)
        {
            bool res = false;
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (r.IsMatch(str))
            {
                res = true;
            }
            return res;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <returns></returns>
        public static void RecordLog(string str)
        {
            try
            {
                string txtpath = AppDomain.CurrentDomain.BaseDirectory;
                System.IO.FileStream fs = new System.IO.FileStream(txtpath + "\\Log.txt", System.IO.FileMode.Append);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "\t" + str + "\r\n");
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            catch { }
            finally
            { }
        }

    }
}
