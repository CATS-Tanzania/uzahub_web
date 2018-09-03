using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.product;
using BAL.dropdwn;

namespace salesmanager.pages
{
    public partial class en_product : System.Web.UI.Page
    {
        productManager prManager = new productManager();
        product br = new product();
        int retVal = 0, productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["pId"].ToString()) == false)
                {
                    productId = Convert.ToInt32(Request.QueryString["pId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                //dropdwnManager.fillingdropdownList(ddlcategory, "tbcategory", "categoryId", "categoryname", "isdel", 0);
                if (productId > 0)
                {
                    getproduct(sender, e);
                }
            }
        }
        private void getproduct(object sender, EventArgs e)
        {
            br = prManager.getproduct(productId, 3);
            if (br != null)
            {
                //ddlcategory.SelectedValue = br.categoryId.ToString();
                txtproductname.Text = br.productname;
                txtbuyprice.Text = br.buyprice.ToString();
                txtsellprice.Text = br.sellprice.ToString();
                btnsave.Text = "Update";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, categoryId = 1;
            decimal buyprice = 0, sellprice = 0;
            sellprice = txtsellprice.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtsellprice.Text.Trim());
            buyprice = txtbuyprice.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtbuyprice.Text.Trim());
            //categoryId = Convert.ToInt32(ddlcategory.SelectedValue);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = prManager.saveproduct(productId, categoryId, txtproductname.Text.Trim(), buyprice, sellprice, false, flag);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_product.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_product.aspx';</script>";
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_product.aspx");
        }
    }
}