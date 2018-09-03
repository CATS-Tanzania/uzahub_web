using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.product;

namespace salesmanager.pages
{
    public partial class info_product : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        productManager brManager = new productManager();
        productCollection brColl = new productCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllproductes();
            }
        }
        private void GetAllproductes()
        {
            brColl = brManager.GetAllproduct(0, 2);
            if (brColl.Count > 0)
            {
                dgproductInfo.DataSource = brColl;
                dgproductInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_product.aspx");
        }

        protected void dgproductInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                brManager.deleteproduct(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllproductes();
        }

        protected void dgproductInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgproductInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgproductInfo.CurrentPageIndex == 0 ? 0 : dgproductInfo.PageSize;
            GetAllproductes();
        }
    }
}