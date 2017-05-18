using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MVCWebSite.PublicClass;

namespace MVCWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 读取XML文件
        /// </summary>
        /// <returns></returns>
        public string ReadXml()
        {
            string result = "失败";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (System.IO.File.Exists(Server.MapPath("~/XMLFiles/ProjectConfig.xml")))
                {
                    XmlReader reader = XmlReader.Create(Server.MapPath("~/XMLFiles/ProjectConfig.xml"));
                    xmlDoc.Load(reader);
                    reader.Close();
                    result = "成功";
                }
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            return result;
        }

        /// <summary>
        /// 再次读取
        /// </summary>
        /// <returns></returns>
        public string ReadXmlAgain()
        {
            string result = "失败";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (System.IO.File.Exists(Server.MapPath("~/XMLFiles/ProjectConfig.xml")))
                {
                    XmlReader reader = XmlReader.Create(Server.MapPath("~/XMLFiles/ProjectConfig.xml"));
                    xmlDoc.Load(reader);
                    reader.Close();
                    result = "成功";
                }
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            return result;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string VisitWebServices()
        {
            HttpItem hi = new PublicClass.HttpItem();
            hi.URL = "http://localhost:47374/Home/Demo";
            hi.Method = "Post";
            HttpHelper hh = new PublicClass.HttpHelper();
            HttpResult hr = new PublicClass.HttpResult();
            hr = hh.GetHtml(hi);
            string html = hr.Html;
            return "";
        }

        [HttpPost]
        public JsonResult SomeData()
        {
            JsonResult json = new JsonResult();
            if (Request.Form.Count > 0)
            {
                int param = Convert.ToInt32(Request.Form["param"].ToString());
                json.Data = new { cml = "成功获取到前台传递过来的数据" + param };
            }
            return json;
        }

        public void CheckDouble()
        {
            string str = "0.03";
            double dou = Convert.ToDouble(str);
        }


    }
}