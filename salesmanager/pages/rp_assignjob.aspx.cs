using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.dataset;
using System.Data;
using BAL.dropdwn;
using Utils;

namespace salesmanager.pages
{
    public partial class rp_assignjob : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        datasetManager dsManager = new datasetManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddluser, "tbuser", "userId", "name", "isdel", 0);
            }
        }
        private DataTable GetAllassignjobs()
        {
            DataSet ds = null;
            int branchId = 0, userId = 0;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            ds = dsManager.rp_searchInassignjob(branchId, userId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgassignjobInfo.DataSource = ds.Tables[0];
                dgassignjobInfo.DataBind();
                lblmsg.Visible = false;
                dgassignjobInfo.Visible = true;
            }
            else
            {
                lblmsg.Visible = true;
                dgassignjobInfo.Visible = false;
                lblmsg.Text = "Record not found";
            }
            return ds.Tables[0];
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
            ddluser.SelectedValue = "0";
            GetAllassignjobs();
        }
        protected void btnexpexcel_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string filename = "";
            dt = GetAllassignjobs();
            filename = Comman.GenerateFileName("Assign_job");
            filename = filename + ".xls";
            ExcelHelper.ToExcel(dt, filename, HttpContext.Current.Response);
        }
    }
}