using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.category;

namespace salesmanager.pages
{
    public partial class en_category : System.Web.UI.Page
    {
        categoryManager brManager = new categoryManager();
        category br = new category();
        int retVal = 0, categoryId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["cId"].ToString()) == false)
                {
                    categoryId = Convert.ToInt32(Request.QueryString["cId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                if (categoryId > 0)
                {
                    getcategory(sender, e);
                }
            }
        }
        private void getcategory(object sender, EventArgs e)
        {
            br = brManager.getcategory(categoryId, 3);
            if(br !=null)
            {
                txtcategoryname.Text = br.categoryname;
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
            retVal = brManager.savecategory(categoryId, txtcategoryname.Text.Trim(), false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_category.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_category.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_category.aspx");
        }
    }
}