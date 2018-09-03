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
    public partial class rp_sale : System.Web.UI.Page
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
        private DataTable GetAllsales()
        {
            DataSet ds = null;
            int branchId = 0, userId = 0;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            ds = dsManager.rp_searchInsale(branchId, userId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgsaleInfo.DataSource = ds.Tables[0];
                dgsaleInfo.DataBind();
                lblmsg.Visible = false;
                dgsaleInfo.Visible = true;
            }
            else
            {
                lblmsg.Visible = true;
                dgsaleInfo.Visible = false;
                lblmsg.Text = "Record not found";
            }
            return ds.Tables[0];
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
            ddluser.SelectedValue = "0";
            GetAllsales();
        }
        protected void btnexpexcel_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string filename = "";
            dt = GetAllsales();
            filename = Comman.GenerateFileName("sale");
            filename = filename + ".xls";
            ExcelHelper.ToExcel(dt, filename, HttpContext.Current.Response);
        }
    }
}