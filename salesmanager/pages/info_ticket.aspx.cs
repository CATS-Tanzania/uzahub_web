using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace salesmanager.pages
{
    public partial class info_ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            emaildetai();
        }
        private void emaildetai()
        {
            string userName = "", password = "", subject = "", Fromemail = "", Toemail = "", smtp = "", port = "", strMail = "";
            bool chkmail = false;
            Fromemail = "software@catsgroup.co.tz";
            Toemail = "software@catsgroup.co.tz";
            smtp = "smtp2.cats-net.com";
            port = "587";
            userName = "software@catsgroup.co.tz";
            subject = txtsubject.Text;
            strMail = customer_msgbody();
            chkmail = sendEmail(Fromemail, Toemail, subject, strMail, userName, password, smtp, port);
            if (chkmail)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Query sent');</script>";
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Please enter valid email address');</script>";
            }
            txtsubject.Text = "";
            txtmsg.Text = "";
        }
        private string customer_msgbody()
        {
            string strMail = "";
            strMail = txtmsg.Text;
            return strMail;
        }
        public bool sendEmail(string From, string To, string Subject, string Message, string userName, string Password, string smtp, string port)
        {
            try
            {
                string fromAddress = From;
                string toAddress = To;
                System.Net.Mail.MailMessage message = new
                System.Net.Mail.MailMessage(fromAddress, toAddress);
                message.From = new System.Net.Mail.MailAddress(fromAddress, "Sales Manager");
                message.Bcc.Add("software@catsgroup.co.tz");
                message.Subject = Subject;// "StubHub Ticket's Alert";
                message.Body = Message;// "<b>from mail class</b><br>Manish";           
                message.IsBodyHtml = true;
                message.Priority = System.Net.Mail.MailPriority.High;
                string smtpClient = smtp;
                System.Net.Mail.SmtpClient client = new
                System.Net.Mail.SmtpClient(smtpClient, Convert.ToInt32(port));
                client.EnableSsl = false;
                //client.Credentials = new System.Net.NetworkCredential(userName, Password);
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}