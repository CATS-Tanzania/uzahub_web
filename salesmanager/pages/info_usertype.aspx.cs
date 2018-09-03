using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.usertype;

namespace salesmanager.pages
{
    public partial class info_usertype : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        usertypeManager brManager = new usertypeManager();
        usertypeCollection brColl = new usertypeCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllusertypees();
            }
        }
        private void GetAllusertypees()
        {
            brColl = brManager.GetAllusertype(0, 2);
            if (brColl.Count > 0)
            {
                dgusertypeInfo.DataSource = brColl;
                dgusertypeInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_usertype.aspx");
        }

        protected void dgusertypeInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                brManager.deleteusertype(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllusertypees();
        }

        protected void dgusertypeInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgusertypeInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgusertypeInfo.CurrentPageIndex == 0 ? 0 : dgusertypeInfo.PageSize;
            GetAllusertypees();
        }
    }
}