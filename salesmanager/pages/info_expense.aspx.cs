using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.dropdwn;
using BAL.expense;

namespace salesmanager.pages
{
    public partial class info_expense : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        expenseManager ctManager = new expenseManager();
        expenseCollection ctColl = new expenseCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddlusername, "tbuser", "userId", "name", "isdel", 0);
            }
        }
        private void GetAllexpenses()
        {
            int userId = 0, branchId = 0;
            userId = Convert.ToInt32(ddlusername.SelectedValue);
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            ctColl = ctManager.searchInexpense(userId, branchId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 1);
            if (ctColl.Count > 0)
            {
                dgexpenseInfo.DataSource = ctColl;
                dgexpenseInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_expense.aspx");
        }

        protected void dgexpenseInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deleteexpense(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllexpenses();
        }

        protected void dgexpenseInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgexpenseInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgexpenseInfo.CurrentPageIndex == 0 ? 0 : dgexpenseInfo.PageSize;
            GetAllexpenses();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            dgexpenseInfo.CurrentPageIndex = 0;
            GetAllexpenses();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtdateto.Text = "";
            txtdatefrom.Text = "";
            ddlbranch.SelectedValue = "0";
            ddlusername.SelectedValue = "0";
            ddlbranch.SelectedValue = "0";
            GetAllexpenses();
        }
    }
}