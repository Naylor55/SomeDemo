using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

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
    }
}