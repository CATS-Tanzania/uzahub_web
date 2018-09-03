using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.customer;

namespace salesmanager.pages
{
    public partial class info_customer : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        customerManager brManager = new customerManager();
        customerCollection brColl = new customerCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllcustomeres();
            }
        }
        private void GetAllcustomeres()
        {
            brColl = brManager.GetAllcustomer(0, 2);
            if (brColl.Count > 0)
            {
                dgcustomerInfo.DataSource = brColl;
                dgcustomerInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_customer.aspx");
        }

        protected void dgcustomerInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                brManager.deletecustomer(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllcustomeres();
        }

        protected void dgcustomerInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgcustomerInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgcustomerInfo.CurrentPageIndex == 0 ? 0 : dgcustomerInfo.PageSize;
            GetAllcustomeres();
        }
    }
}