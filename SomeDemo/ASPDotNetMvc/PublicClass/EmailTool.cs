using ASPDotNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;

namespace ASPDotNetMvc.PublicClass
{
    public class EmailTool
    {

        /// <summary>
        /// 执行发送邮件
        /// </summary>
        /// <returns></returns>
        public static int Send(EmailModel em)
        {
            Thread.Sleep(2000);
            int res = 0;
            MailAddress maddr = new MailAddress(em.mailFrom);
            MailMessage myMail = new MailMessage();
            myMail.IsBodyHtml = true;
            //向收件人地址集合添加邮件地址            
            if (!string.IsNullOrEmpty(em.mailToArray))
            {
                string[] toarray = em.mailToArray.Split(',');
                foreach (string item in toarray)
                {
                    myMail.To.Add(item);
                }
            }
            //向抄送人地址集合添加邮件地址            
            if (!string.IsNullOrEmpty(em.mailCcArray))
            {
                string[] ccarray = em.mailCcArray.Split(',');
                foreach (string item in ccarray)
                {
                    myMail.CC.Add(item);
                }
                em.mailCcArray = !string.IsNullOrEmpty(em.mailCcArray) ? "抄送者：" + em.mailCcArray : "";
            }
            myMail.From = maddr;
            myMail.Subject = em.mailSubject;
            myMail.SubjectEncoding = Encoding.UTF8;
            myMail.Body = em.mailBody;
            myMail.BodyEncoding = Encoding.Default;
            myMail.Priority = MailPriority.High;
            myMail.IsBodyHtml = em.isbodyHtml;
            SmtpClient smtp = new SmtpClient();
            //指定发件人的邮件地址和密码以验证发件人身份
            smtp.Credentials = new System.Net.NetworkCredential(em.mailFrom, em.mailPwd);
            smtp.Host = em.host;

            //将邮件发送到SMTP邮件服务器,采用异步的方式            
            try
            {
                smtp.Send(myMail);
                res = 1;
            }
            catch
            {

            }
            return res;
        }
    }
}