using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebSite.Controllers
{
    public class PagingController : Controller
    {
        // GET: Paging
        public ActionResult Index()
        {
            return View();
        }
    }
}