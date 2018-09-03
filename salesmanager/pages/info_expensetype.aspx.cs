using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.expensetype;

namespace salesmanager.pages
{
    public partial class info_expensetype : System.Web.UI.Page
    {
        public int startNo { get { return (ViewState["startno"] != null) ? Convert.ToInt32(ViewState["startno"].ToString()) : 0; } set { ViewState["startno"] = value; } }
        expensetypeManager ctManager = new expensetypeManager();
        expensetypeCollection ctColl = new expensetypeCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllexpensetypes();
            }
        }
        private void GetAllexpensetypes()
        {
            ctColl = ctManager.GetAllexpensetype(0, 2);
            if (ctColl.Count > 0)
            {
                dgexpensetypeInfo.DataSource = ctColl;
                dgexpensetypeInfo.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("en_expensetype.aspx");
        }

        protected void dgexpensetypeInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                ctManager.deleteexpensetype(Convert.ToInt32(e.CommandArgument), 4);
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record deleted successfully');</script>";

            }
            GetAllexpensetypes();
        }

        protected void dgexpensetypeInfo_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgexpensetypeInfo.CurrentPageIndex = e.NewPageIndex;
            startNo = dgexpensetypeInfo.CurrentPageIndex == 0 ? 0 : dgexpensetypeInfo.PageSize;
            GetAllexpensetypes();
        }
    }
}