using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.customer;
using BAL.dropdwn;

namespace salesmanager.pages
{
    public partial class en_customer : System.Web.UI.Page
    {
        public int companyId { get { return (Session["companyId"] != null) ? Convert.ToInt32(Session["companyId"].ToString()) : 0; } set { Session["companyId"] = value; } }
        customerManager uiManager = new customerManager();
        customer ui = new customer();
        int retVal = 0, customerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["uId"].ToString()) == false)
                {   
                    customerId = Convert.ToInt32(Request.QueryString["uId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                if (customerId > 0)
                {
                    getcustomer(sender, e);
                }
            }
        }
        private void getcustomer(object sender, EventArgs e)
        {
            ui = uiManager.getcustomer(customerId, 3);
            if (ui != null)
            {
                //lblcompanyname.Text = ui.companyname;
                txtaddress.Text = ui.address;
                txtemail.Text = ui.email;
                txtmobileno.Text = ui.mobileno;
                txttelno.Text = ui.telno;
                txtname.Text = ui.cusname;
                ddlbranch.SelectedValue = ui.branchId.ToString();
                btnsave.Text = "Update";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, branchId = 0;
            companyId = 1;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = uiManager.savecustomer(customerId, txtname.Text.Trim(), txtmobileno.Text.Trim(), txttelno.Text.Trim(), txtemail.Text.Trim(), txtaddress.Text.Trim(),
                branchId, companyId, false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_customer.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_customer.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_customer.aspx");
        }
    }
}