using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.branch;

namespace salesmanager.pages
{
    public partial class info_branch : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        branchManager brManager = new branchManager();
        branchCollection brColl = new branchCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllbranches();
            }
        }
        private void GetAllbranches()
        {
            brColl = brManager.GetAllbranch(0, 2);
            if (brColl.Count > 0)
            {
                dgbranchInfo.DataSource = brColl;
                dgbranchInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_branch.aspx");
        }

        protected void dgbranchInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                brManager.deletebranch(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllbranches();
        }

        protected void dgbranchInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgbranchInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgbranchInfo.CurrentPageIndex == 0 ? 0 : dgbranchInfo.PageSize;
            GetAllbranches();
        }
    }
}