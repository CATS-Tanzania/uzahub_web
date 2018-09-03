using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.category;

namespace salesmanager.pages
{
    public partial class info_category : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        categoryManager ctManager = new categoryManager();
        categoryCollection ctColl = new categoryCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllcategorys();
            }
        }
        private void GetAllcategorys()
        {
            ctColl = ctManager.GetAllcategory(0, 2);
            if (ctColl.Count > 0)
            {
                dgcategoryInfo.DataSource = ctColl;
                dgcategoryInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_category.aspx");
        }

        protected void dgcategoryInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deletecategory(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllcategorys();
        }

        protected void dgcategoryInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgcategoryInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgcategoryInfo.CurrentPageIndex == 0 ? 0 : dgcategoryInfo.PageSize;
            GetAllcategorys();
        }
    }
}