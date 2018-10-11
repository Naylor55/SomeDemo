using LeadingClass;
using LeadingSite.PublicModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeadingSite.PublicClass
{
    /// <summary>
    /// 邮件工具类
    /// </summary>
    public class EmailTool
    {
        public string mailFrom { get; set; }//发送者
        public string mailToArray { get; set; }// 收件人，需传入参数
        public string mailCcArray { get; set; }// 抄送，需传入参数
        public string mailSubject { get; set; }// 标题，需传入参数
        public string mailBody { get; set; }// 正文，需传入参数
        public string mailPwd { get; set; }// 发件人密码
        public string host { get; set; }// SMTP邮件服务器
        public bool isbodyHtml { get; set; }// 正文是否是html格式
        public string[] attachmentsPath { get; set; }// 附件

        public EmailTool()
        {
            EmailServ serv = new EmailServ();
            if (serv.GetEmailServ())
            {
                mailFrom = serv.Email;
                mailPwd = serv.PassWord;
                host = "smtp.ym.163.com";
            }
            isbodyHtml = true;
        }



        /// <summary>
        /// 执行发送邮件
        /// </summary>
        /// <returns></returns>
        public void Send()
        {
            MailAddress maddr = new MailAddress(mailFrom);
            MailMessage myMail = new MailMessage();
            myMail.IsBodyHtml = true;
            //向收件人地址集合添加邮件地址            
            if (!string.IsNullOrEmpty(mailToArray))
            {
                string[] toarray = mailToArray.Split(',');
                foreach (string item in toarray)
                {
                    myMail.To.Add(item);
                }
            }
            //向抄送人地址集合添加邮件地址            
            if (!string.IsNullOrEmpty(mailCcArray))
            {
                string[] ccarray = mailCcArray.Split(',');
                foreach (string item in ccarray)
                {
                    myMail.CC.Add(item);
                }
                mailCcArray = !string.IsNullOrEmpty(mailCcArray) ? "抄送者：" + mailCcArray : "";
            }
            myMail.From = maddr;
            myMail.Subject = mailSubject;
            myMail.SubjectEncoding = Encoding.UTF8;
            myMail.Body = mailBody;
            myMail.BodyEncoding = Encoding.Default;
            myMail.Priority = MailPriority.High;
            myMail.IsBodyHtml = isbodyHtml;
            PublicModel.SmtpSendEmailModel smtpemailmodel = new PublicModel.SmtpSendEmailModel();
            smtpemailmodel.mailfrom = mailFrom; smtpemailmodel.mailpwd = mailPwd; smtpemailmodel.host = host;
            smtpemailmodel.mail = myMail;
            SmtpSendAsync(smtpemailmodel);
            ////判断如果异步执行是否完
            //while (result.IsCompleted == false)
            //{
            //    Thread.Sleep(20);
            //}
        }

        /// <summary>
        /// 以Smtp方式发送邮件
        /// </summary>
        /// <param name="mailfrom"></param>
        /// <param name="mailpwd"></param>
        /// <param name="host"></param>
        /// <param name="mail"></param>
        /// <returns></returns>
        private void SmtpSendAsync(SmtpSendEmailModel smtpSendEmailModel)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(smtpSendEmailModel.mailfrom, smtpSendEmailModel.mailpwd);
            smtp.Host = host;
            smtp.Port = 25;
            smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback); 
            try
            {
                smtp.SendAsync(smtpSendEmailModel.mail, smtpSendEmailModel);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                if (smtpSendEmailModel.mail != null && smtpSendEmailModel.mail.To.Count > 0)
                {
                    foreach (MailAddress item in smtpSendEmailModel.mail.To)
                    {
                        sb.Append(item.Address + "，");
                    }
                }
                Sys_ErrorLog se = new Sys_ErrorLog();
                se.ErrorMessage = "smtp发送邮件报异常:" + ex.GetType() + "，收件人：" + sb + "。" + ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "" + ex.StackTrace) + "|" + smtpSendEmailModel.mail.Subject;
                if(ex is SmtpException)
                {
                    //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpstatuscode(v=vs.90)
                    se.ErrorMessage += ((SmtpException)ex).StatusCode;
                }
                se.UpdateTime = DateTime.Now;
                se.Save();
            }
        }

        /// <summary>
        /// 异步方式发送电子邮件回调 函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            SmtpSendEmailModel data = (SmtpSendEmailModel)e.UserState;
             StringBuilder sb = new StringBuilder();
            if (data != null && data.mail.To.Count > 0)
            {
                foreach (MailAddress item in data.mail.To)
                {
                    sb.Append(item.Address + "，");
                }
            }
            Email email = new Email();
            email.MailFrom = data.mail.From.Address;
            email.MailTo = sb.ToString();
            email.Subject = data.mail.Subject;
            email.Body = data.mail.Body;
            email.SendTime = DateTime.Now;
      
            if (e.Cancelled)
            {
                email.IsOK = 0;
                email.Save();
            }
            if (e.Error != null)
            {
                Exception ex = e.Error;
                StringBuilder sbs = new StringBuilder();
                if (data.mail != null && data.mail.To.Count > 0)
                {
                    foreach (MailAddress item in data.mail.To)
                    {
                        sbs.Append(item.Address + "，");
                    }
                }
                Sys_ErrorLog se = new Sys_ErrorLog();
                se.ErrorMessage = "smtp发送邮件报异常:" + ex.GetType() + "，收件人：" + sbs + "。" + ex.Message + (ex.InnerException != null ? ex.InnerException.Message : "" + ex.StackTrace) + "|" + data.mail.Subject;
                if(ex is SmtpException)
                {
                    //https://msdn.microsoft.com/en-us/library/system.net.mail.smtpstatuscode(v=vs.90)
                    se.ErrorMessage += ((SmtpException)ex).StatusCode;
                }
                se.UpdateTime = DateTime.Now;
                se.Save();
                email.IsOK = 0;
                email.Save();
                SmtpSend(data);
            
            }
            else
            {
                email.IsOK = 1;
                email.Save();
            }
        }
        /// <summary>
        /// 同步方式发送邮件
        /// </summary>
        /// <param name="smtpEmailModel"></param>
        private static void SmtpSend(PublicModel.SmtpSendEmailModel smtpEmailModel)
        {
            Email email = new Email();
            EmailServ serv = new EmailServ();
            string from = string.Empty, pwd = string.Empty;
            if (serv.GetEmailServ())
            {
                from = serv.Email;
                pwd = serv.PassWord;
            }
            smtpEmailModel.mail.From = new MailAddress(from);
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(from, pwd);
            smtp.Host = smtpEmailModel.host;
            StringBuilder sb = new StringBuilder();
            if (smtpEmailModel.mail != null && smtpEmailModel.mail.To.Count > 0)
            {
                foreach (MailAddress item in smtpEmailModel.mail.To)
                {
                    sb.Append(item.Address + "，");
                }
            }
            try
            {
                smtp.Send(smtpEmailModel.mail);
                email.MailFrom = smtpEmailModel.mail.From.ToString();
                email.MailTo = sb.ToString();
                email.Subject = smtpEmailModel.mail.Subject;
                email.Body = smtpEmailModel.mail.Body;
                email.SendTime = DateTime.Now;
                email.IsOK = 1;
                email.Save();
            }
            catch (Exception ex)
            {
                email.IsOK = 0;
                //写log
                Sys_ErrorLog se = new Sys_ErrorLog();
                se.ErrorMessage = "[同步]smtp发送邮件报异常，收件人：" + sb.ToString() + "。" + ex.Message + "|" + smtpEmailModel.mail.Subject;
                se.UpdateTime = DateTime.Now;
                se.Save();
            }

        }
    }
}
