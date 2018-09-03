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
    public partial class rp_stockin : System.Web.UI.Page
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
        private DataTable GetAllstockins()
        {
            DataSet ds = null;
            int branchId = 0, userId = 0;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            ds = dsManager.rp_searchInstockin(branchId, userId, txtdatefrom.Text.Trim(), txtdateto.Text.Trim(), 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgstockinInfo.DataSource = ds.Tables[0];
                dgstockinInfo.DataBind();
                lblmsg.Visible = false;
                dgstockinInfo.Visible = true;
            }
            else
            {
                lblmsg.Visible = true;
                dgstockinInfo.Visible = false;
                lblmsg.Text = "Record not found";
            }
            return ds.Tables[0];
        }

        protected void dgstockinInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgstockinInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgstockinInfo.CurrentPageIndex == 0 ? 0 : dgstockinInfo.PageSize;
            GetAllstockins();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            dgstockinInfo.CurrentPageIndex = 0;
            GetAllstockins();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtdateto.Text = "";
            txtdatefrom.Text = "";
            ddlbranch.SelectedValue = "0";
            ddluser.SelectedValue = "0";
            GetAllstockins();
        }
        protected void btnexpexcel_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string filename = "";
            dt = GetAllstockins();
            filename = Comman.GenerateFileName("stockIn");
            filename = filename + ".xls";
            ExcelHelper.ToExcel(dt, filename, HttpContext.Current.Response);
        }
    }
}