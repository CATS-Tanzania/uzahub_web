using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.user;
using Utils;

namespace salesmanager
{
    public partial class ilogin : System.Web.UI.Page
    {
        userManager uiManager = new userManager();
        user ui = new user();
        string DecryptPass = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["logout"] != null)
                {
                    if (Request.QueryString["logout"] == "1")
                    {
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        HttpContext.Current.Request.Cookies.Clear();
                    }
                }
                if (Request.Cookies["username"] != null)
                {
                    txtusername.Text = Request.Cookies["username"].Value;
                }
                if (Request.Cookies["password"] != null)
                {
                    txtpassword.Attributes.Add("value", Request.Cookies["password"].Value);
                }
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                {
                    chkremember.Checked = true;
                }
            }
        }
        private void Loginuser()
        {
            ui = uiManager.getloginuser(txtusername.Text.Trim(), txtpassword.Text.Trim(), 5);
            if (ui != null)
            {
                DecryptPass = Comman.Decryptdata(ui.password);
                if (DecryptPass == txtpassword.Text.Trim())
                {
                    Session["name"] = ui.name;
                    Session["userId"] = ui.userId;
                    Session["branchId"] = ui.branchId.ToString();
                    if (chkremember.Checked == true)
                    {
                        Response.Cookies["username"].Value = txtusername.Text.Trim();
                        Response.Cookies["password"].Value = txtpassword.Text.Trim();
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(15);
                    }
                    else
                    {
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Redirect("~/pages/dashboard.aspx");
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Username and password does not match";
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Loginuser();
        }
    }
}