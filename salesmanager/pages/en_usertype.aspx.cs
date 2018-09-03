using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.usertype;

namespace salesmanager.pages
{
    public partial class en_usertype : System.Web.UI.Page
    {
        usertypeManager brManager = new usertypeManager();
        usertype br = new usertype();
        int retVal = 0, usertypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["uId"].ToString()) == false)
                {
                    usertypeId = Convert.ToInt32(Request.QueryString["uId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                if (usertypeId > 0)
                {
                    getusertype(sender, e);
                }
            }
        }
        private void getusertype(object sender, EventArgs e)
        {
            br = brManager.getusertype(usertypeId, 3);
            if(br !=null)
            {
                txtusertypename.Text = br.usertypename;
                btnsave.Text = "Update";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = brManager.saveusertype(usertypeId, txtusertypename.Text.Trim(), false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_usertype.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_usertype.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_usertype.aspx");
        }
    }
}