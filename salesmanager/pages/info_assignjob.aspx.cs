using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.assignjob;
using BAL.dropdwn;

namespace salesmanager.pages
{
    public partial class info_assignjob : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        assignjobManager ctManager = new assignjobManager();
        assignjobCollection ctColl = new assignjobCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddlusername, "tbuser", "userId", "name", "isdel", 0);
            }
        }
        private void GetAllassignjobs()
        {
            int userId = 0, branchId = 0;
            userId = Convert.ToInt32(ddlusername.SelectedValue);
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            ctColl = ctManager.searchInassignjob(userId, branchId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 1);
            if (ctColl.Count > 0)
            {
                dgassignjobInfo.DataSource = ctColl;
                dgassignjobInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_assignjob.aspx");
        }

        protected void dgassignjobInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deleteassignjob(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllassignjobs();
        }

        protected void dgassignjobInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgassignjobInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgassignjobInfo.CurrentPageIndex == 0 ? 0 : dgassignjobInfo.PageSize;
            GetAllassignjobs();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            dgassignjobInfo.CurrentPageIndex = 0;
            GetAllassignjobs();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtdateto.Text = "";
            txtdatefrom.Text = "";
            ddlbranch.SelectedValue = "0";
            ddlusername.SelectedValue = "0";
            ddlbranch.SelectedValue = "0";
            GetAllassignjobs();
        }
    }
}