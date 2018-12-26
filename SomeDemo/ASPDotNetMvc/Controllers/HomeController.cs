using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPDotNetMvc.Models;
using ASPDotNetMvc.PublicClass;
using System.Runtime.Remoting.Messaging;

namespace ASPDotNetMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        delegate int EmailDelegate(EmailModel em);

     

        private static void SendComplited(IAsyncResult result)
        {
            string str = (string)result.AsyncState;
            AsyncResult _result = (AsyncResult)result;
            EmailDelegate d = (EmailDelegate)_result.AsyncDelegate;
            int res = d.EndInvoke(_result);
            if (res == 1)
            {
                //发送成功
                PublicClass.CommonTool.RecordLog("邮件发送成功。" + str);
            }
            else
            {
                //失败
                PublicClass.CommonTool.RecordLog("邮件发送失败。" + str);
            }
        }

    }
}
