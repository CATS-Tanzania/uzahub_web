using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.sale;
using BAL.product;
using BAL.dropdwn;
using BAL.dataset;
using System.Data;
using System.Globalization;
using Utils;

namespace salesmanager.pages
{
    public partial class info_soldItem : System.Web.UI.Page
    {
        public int userId { get { return (Session["userId"] != null) ? Convert.ToInt32(Session["userId"].ToString()) : 0; } set { Session["userId"] = value; } }
        saleManager stManager = new saleManager();
        sale st = new sale();
        int retVal = 0, saleId, assignjobId;
        CultureInfo us = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ajId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ajId"].ToString()) == false)
                {
                    assignjobId = Convert.ToInt32(Request.QueryString["ajId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                if (assignjobId > 0)
                {
                    getsoldItems();
                }
            }
        }
        protected void dgproductInfo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {

            }
        }
        private void getsoldItems()
        {
            DataSet ds = null;
            datasetManager dsManager = new datasetManager();
            ds = dsManager.GetAllsaleItem(assignjobId, 3);
            if (ds != null)
            {
                dgproductInfo.DataSource = ds;
                dgproductInfo.DataBind();
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_sale.aspx");
        }
    }
}