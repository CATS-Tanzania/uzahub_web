using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace salesmanager.pages
{
    public partial class dashboard : System.Web.UI.Page
    {
        public string name { get { return (Session["name"] != null) ? Session["name"].ToString() : ""; } set { Session["name"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }
    }
}