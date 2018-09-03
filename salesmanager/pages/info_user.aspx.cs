using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.user;

namespace salesmanager.pages
{
    public partial class info_user : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        userManager brManager = new userManager();
        userCollection brColl = new userCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAlluseres();
            }
        }
        private void GetAlluseres()
        {
            brColl = brManager.GetAlluser(0, 2);
            if (brColl.Count > 0)
            {
                dguserInfo.DataSource = brColl;
                dguserInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_user.aspx");
        }

        protected void dguserInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                brManager.deleteuser(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAlluseres();
        }

        protected void dguserInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dguserInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dguserInfo.CurrentPageIndex == 0 ? 0 : dguserInfo.PageSize;
            GetAlluseres();
        }
    }
}