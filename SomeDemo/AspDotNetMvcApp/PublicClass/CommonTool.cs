using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDotNetMvc.PublicClass
{
    public class CommonTool
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <returns></returns>
        public static void RecordLog(string str)
        {
            System.IO.FileStream fs = null;
            try
            {
                string txtpath = AppDomain.CurrentDomain.BaseDirectory;
                fs = new System.IO.FileStream(txtpath + "\\Log.txt", System.IO.FileMode.Append);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "\t" + str + "\r\n");
                //开始写入
                fs.Write(data, 0, data.Length);
            }
            catch { }
            finally
            {
                fs.Flush();
                fs.Close();
            }
        }
    }

}