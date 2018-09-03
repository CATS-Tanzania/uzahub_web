using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.stockmove;

namespace salesmanager.pages
{
    public partial class info_stockmove : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        stockmoveManager ctManager = new stockmoveManager();
        stockmoveCollection ctColl = new stockmoveCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllstockmoves();
            }
        }
        private void GetAllstockmoves()
        {
            ctColl = ctManager.GetAllstockmove(0, 2);
            if (ctColl.Count > 0)
            {
                dgstockmoveInfo.DataSource = ctColl;
                dgstockmoveInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_stockmove.aspx");
        }

        protected void dgstockmoveInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deletestockmove(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllstockmoves();
        }

        protected void dgstockmoveInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgstockmoveInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgstockmoveInfo.CurrentPageIndex == 0 ? 0 : dgstockmoveInfo.PageSize;
            GetAllstockmoves();
        }
    }
}