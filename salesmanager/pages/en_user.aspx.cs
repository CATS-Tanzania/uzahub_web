using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.user;
using BAL.dropdwn;

namespace salesmanager.pages
{
    public partial class en_user : System.Web.UI.Page
    {
        public int companyId { get { return (Session["companyId"] != null) ? Convert.ToInt32(Session["companyId"].ToString()) : 0; } set { Session["companyId"] = value; } }
        userManager uiManager = new userManager();
        user ui = new user();
        int retVal = 0, userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["uId"].ToString()) == false)
                {   
                    userId = Convert.ToInt32(Request.QueryString["uId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                dropdwnManager.fillingdropdownList(ddlusertype, "tbusertype", "usertypeId", "usertypename", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                if (userId > 0)
                {
                    getuser(sender, e);
                }
            }
        }
        private void getuser(object sender, EventArgs e)
        {
            ui = uiManager.getuser(userId, 3);
            if (ui != null)
            {
                //lblcompanyname.Text = ui.companyname;
                txtaddress.Text = ui.address;
                txtemail.Text = ui.email;
                txtmobileno.Text = ui.mobileno;
                txtname.Text = ui.name;
                txtusername.Text = ui.password;
                ddlbranch.SelectedValue = ui.branchId.ToString();
                ddlusertype.SelectedValue = ui.usertypeId.ToString();
                rfvpassword.Enabled = false;
                txtpassword.ReadOnly = true;
                btnsave.Text = "Update";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, usertypeId = 0, branchId = 0;
            string Encryptpassword = "";
            Encryptpassword = txtpassword.Text.Trim();
            companyId = 1;
            usertypeId = Convert.ToInt32(ddlusertype.SelectedValue);
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = uiManager.saveuser(userId, usertypeId, txtname.Text.Trim(), txtmobileno.Text.Trim(), txtemail.Text.Trim(), txtaddress.Text.Trim(),
                branchId, txtusername.Text.Trim(), Encryptpassword, companyId, false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_user.aspx';</script>";
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record already exists');</script>";
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_user.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_user.aspx");
        }
    }
}