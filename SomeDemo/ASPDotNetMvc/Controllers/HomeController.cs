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

        public string SendEmail(string emailcontent)
        {
            string res = "cml";
            if (!string.IsNullOrEmpty(emailcontent))
            {

                #region 委托方式创建线程来发送邮件
                EmailDelegate ed = new EmailDelegate(EmailTool.Send);
                EmailModel em = new EmailModel();
                em.mailFrom = "serv1@66123123.com";
                em.mailToArray = "3171448083@qq.com";
                em.mailSubject = emailcontent;
                em.mailBody = emailcontent;
                em.mailPwd = "5v26LuSfRs";
                em.host = "smtp.ym.163.com";
                em.isbodyHtml = true;
                ed.BeginInvoke(em, SendComplited, "第一封邮件");
                #endregion
                #region 委托方式创建线程来发送邮件
                EmailDelegate ed2 = new EmailDelegate(EmailTool.Send);
                EmailModel em2 = new EmailModel();
                em2.mailFrom = "serv1@66123123.com";
                em2.mailToArray = "3171448083@qq.com";
                em2.mailSubject = emailcontent + "我是第二个邮件";
                em2.mailBody = emailcontent + "我是第二个邮件";
                em2.mailPwd = "55";
                em2.host = "smtp.ym.163.com";
                em2.isbodyHtml = true;
                ed2.BeginInvoke(em2, SendComplited, "第二封邮件");
                #endregion

                res = "已经在异步发送邮件了";
            }
            else
            {
                res = "发送内容不可为空。";
            }
            return res;
        }

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
