using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LeadingSite.PublicClass
{
    /// <summary>
    /// C#封装的HTTP请求处理类
    /// </summary>
    public  class HttpHelper
    {
        public static string SendHttpRequest(string url, Encoding encoding)
        {
            string msg = "";
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "Get";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                HttpWebResponse res = (HttpWebResponse)myRequest.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), encoding);
                msg = sr.ReadToEnd();
            }
            catch (Exception e)
            {

            }
            return msg;
        }



    }
}
