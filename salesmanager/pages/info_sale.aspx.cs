using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.dropdwn;
using BAL.sale;

namespace salesmanager.pages
{
    public partial class info_sale : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        saleManager ctManager = new saleManager();
        saleCollection ctColl = new saleCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddlusername, "tbuser", "userId", "name", "isdel", 0);
            }
        }
        private void GetAllsales()
        {
            int userId = 0, branchId = 0;
            userId = Convert.ToInt32(ddlusername.SelectedValue);
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            ctColl = ctManager.searchInsale(userId, branchId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 1);
            if (ctColl.Count > 0)
            {
                dgsaleInfo.DataSource = ctColl;
                dgsaleInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_sale.aspx");
        }

        protected void dgsaleInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deletesale(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllsales();
        }

        protected void dgsaleInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgsaleInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgsaleInfo.CurrentPageIndex == 0 ? 0 : dgsaleInfo.PageSize;
            GetAllsales();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            dgsaleInfo.CurrentPageIndex = 0;
            GetAllsales();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtdateto.Text = "";
            txtdatefrom.Text = "";
            ddlbranch.SelectedValue = "0";
            ddlusername.SelectedValue = "0";
            ddlbranch.SelectedValue = "0";
            GetAllsales();
        }
    }
}