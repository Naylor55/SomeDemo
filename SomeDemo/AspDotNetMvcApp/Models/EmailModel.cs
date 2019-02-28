using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDotNetMvc.Models
{
    public class EmailModel
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
    }
}