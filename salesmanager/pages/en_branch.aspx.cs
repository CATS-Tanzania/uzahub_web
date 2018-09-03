using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.branch;

namespace salesmanager.pages
{
    public partial class en_branch : System.Web.UI.Page
    {
        branchManager brManager = new branchManager();
        branch br = new branch();
        int retVal = 0, branchId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["bId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["bId"].ToString()) == false)
                {
                    branchId = Convert.ToInt32(Request.QueryString["bId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                if (branchId > 0)
                {
                    getbranch(sender, e);
                }
            }
        }
        private void getbranch(object sender, EventArgs e)
        {
            br = brManager.getbranch(branchId, 3);
            if(br !=null)
            {
                txtbranchname.Text = br.branchname;
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
            retVal = brManager.savebranch(branchId, txtbranchname.Text.Trim(), false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_branch.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_branch.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_branch.aspx");
        }
    }
}