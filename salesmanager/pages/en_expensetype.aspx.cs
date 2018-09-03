using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.expensetype;

namespace salesmanager.pages
{
    public partial class en_expensetype : System.Web.UI.Page
    {
        expensetypeManager brManager = new expensetypeManager();
        expensetype br = new expensetype();
        int retVal = 0, expensetypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["cId"].ToString()) == false)
                {
                    expensetypeId = Convert.ToInt32(Request.QueryString["cId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                if (expensetypeId > 0)
                {
                    getexpensetype(sender, e);
                }
            }
        }
        private void getexpensetype(object sender, EventArgs e)
        {
            br = brManager.getexpensetype(expensetypeId, 3);
            if(br !=null)
            {
                txtexpensetypename.Text = br.expensetypename;
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
            retVal = brManager.saveexpensetype(expensetypeId, txtexpensetypename.Text.Trim(), false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_expensetype.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_expensetype.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_expensetype.aspx");
        }
    }
}