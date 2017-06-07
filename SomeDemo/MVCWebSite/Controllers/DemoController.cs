using MVCWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace MVCWebSite.Controllers
{
    public class DemoController : Controller
    {
        WebShopEntities db = new WebShopEntities();

        // GET: Demo
        public ActionResult Index(int id = 1)
        {
            var data = (from item in db.Goods select item).OrderByDescending(a => a.g_ID).ToPagedList(id, 2);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MVCPager", data);
            }
            return View(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSomeData()
        {
            JsonResult json = new JsonResult();
            json.Data = new { cml = "我是后台返回的结果" };
            return json;
        }





    }
}