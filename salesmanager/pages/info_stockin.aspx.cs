using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.stockin;

namespace salesmanager.pages
{
    public partial class info_stockin : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        stockinManager ctManager = new stockinManager();
        stockinCollection ctColl = new stockinCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllstockins();
            }
        }
        private void GetAllstockins()
        {
            ctColl = ctManager.GetAllstockin(0, 2);
            if (ctColl.Count > 0)
            {
                dgstockinInfo.DataSource = ctColl;
                dgstockinInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_stockin.aspx");
        }

        protected void dgstockinInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deletestockin(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllstockins();
        }

        protected void dgstockinInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgstockinInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgstockinInfo.CurrentPageIndex == 0 ? 0 : dgstockinInfo.PageSize;
            GetAllstockins();
        }
    }
}