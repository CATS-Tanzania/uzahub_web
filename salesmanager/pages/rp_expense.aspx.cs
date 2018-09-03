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
    public partial class rp_expense : System.Web.UI.Page
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
        private DataTable GetAllexpenses()
        {
            DataSet ds = null;
            int branchId = 0, userId = 0;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            ds = dsManager.rp_searchInexpense(branchId, userId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgexpenseInfo.DataSource = ds.Tables[0];
                dgexpenseInfo.DataBind();
                lblmsg.Visible = false;
                dgexpenseInfo.Visible = true;
            }
            else
            {
                lblmsg.Visible = true;
                dgexpenseInfo.Visible = false;
                lblmsg.Text = "Record not found";
            }
            return ds.Tables[0];
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
            ddluser.SelectedValue = "0";
            GetAllexpenses();
        }
        protected void btnexpexcel_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string filename = "";
            dt = GetAllexpenses();
            filename = Comman.GenerateFileName("expense");
            filename = filename + ".xls";
            ExcelHelper.ToExcel(dt, filename, HttpContext.Current.Response);
        }
    }
}