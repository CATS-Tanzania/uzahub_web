using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace salesmanager
{
    public partial class sales : System.Web.UI.MasterPage
    {
        public string name { get { return (Session["name"] != null) ? Session["name"].ToString() : ""; } set { Session["name"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("~/ilogin.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (name != "")
                {
                    lblname.Text = name;
                }
                setActive();
            }
        }
        private void setActive()
        {
            string ratVal = "";
            ratVal = new FileInfo(this.Request.Url.LocalPath).Name.ToLower();
            switch (ratVal)
            {
                case "info_branch.aspx":
                case "en_branch.aspx":
                    hylbranch.Attributes.Add("class", "active");
                    liuser.Attributes.Add("class", "active");
                    break;
                case "info_usertype.aspx":
                case "en_usertype.aspx":
                    hylusertype.Attributes.Add("class", "active");
                    liuser.Attributes.Add("class", "active");
                    break;
                case "info_user.aspx":
                case "en_user.aspx":
                    hyluseraccount.Attributes.Add("class", "active");
                    liuser.Attributes.Add("class", "active");
                    break;
                case "info_category.aspx":
                case "en_category.aspx":
                    hylcategory.Attributes.Add("class", "active");
                    liproduct.Attributes.Add("class", "active");
                    break;
                case "info_product.aspx":
                case "en_product.aspx":
                    hylproduct.Attributes.Add("class", "active");
                    liproduct.Attributes.Add("class", "active");
                    break;
                case "info_stockin.aspx":
                case "en_stockin.aspx":
                    hylstockin.Attributes.Add("class", "active");
                    liproduct.Attributes.Add("class", "active");
                    break;
                case "info_stockmove.aspx":
                case "en_stockmove.aspx":
                    hylstockmove.Attributes.Add("class", "active");
                    liproduct.Attributes.Add("class", "active");
                    break;
                case "info_customer.aspx":
                case "en_customer.aspx":
                    hylcustomer.Attributes.Add("class", "active");
                    lisales.Attributes.Add("class", "active");
                    break;
                case "info_assignjob.aspx":
                case "en_assignjob.aspx":
                    hylassignjob.Attributes.Add("class", "active");
                    lisales.Attributes.Add("class", "active");
                    break;
                case "info_sale.aspx":
                case "en_sale.aspx":
                case "info_solditem.aspx":
                    hylsales.Attributes.Add("class", "active");
                    lisales.Attributes.Add("class", "active");
                    break;
                case "info_expensetype.aspx":
                case "en_expensetype.aspx":
                    hylexpensetype.Attributes.Add("class", "active");
                    liexpense.Attributes.Add("class", "active");
                    break;
                case "info_expense.aspx":
                case "en_expense.aspx":
                    hylexpense.Attributes.Add("class", "active");
                    liexpense.Attributes.Add("class", "active");
                    break;
                case "info_expapprove.aspx":
                    hylexpapprove.Attributes.Add("class", "active");
                    liexpense.Attributes.Add("class", "active");
                    break;
                case "rp_stockin.aspx":
                    hylrpstockin.Attributes.Add("class", "active");
                    lireport.Attributes.Add("class", "active");
                    break;
                case "rp_assignjob.aspx":
                    hylrpassignjob.Attributes.Add("class", "active");
                    lireport.Attributes.Add("class", "active");
                    break;
                case "rp_sale.aspx":
                    hylrpsale.Attributes.Add("class", "active");
                    lireport.Attributes.Add("class", "active");
                    break;
                case "rp_expense.aspx":
                    hylrpexpense.Attributes.Add("class", "active");
                    lireport.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}