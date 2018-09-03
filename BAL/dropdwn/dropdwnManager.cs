using System;
using System.Data;
using DAL;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Security;

namespace BAL.dropdwn
{
    public static class dropdwnManager
    {
        public static dropdwnCollection filldropdownList(string tablename, string column1, string column2, string column3, int condition)
        {
            dropdwnCollection drpdwnColl = null;
            dropdbManager.filldropdownList(delegate(IDataReader dr)
            {
                using (dr)
                {
                    drpdwnColl = new dropdwnCollection();
                    while (dr.Read())
                    {
                        dropdwn drpdwn = new dropdwn();
                        drpdwn.Column1 = SqlHelper.GetInt(dr, column1);
                        drpdwn.Column2 = SqlHelper.GetString(dr, column2);
                        drpdwnColl.Add(drpdwn);
                    }
                }
            }, tablename, column1, column2, column3, condition);
            return drpdwnColl;
        }

        public static dropdwnCollection fillingdropdownList(DropDownList ddl, string tablename, string column1, string column2, string column3, int condition)
        {
            dropdwnCollection drpdwnColl = null;
            drpdwnColl = filldropdownList(tablename, column1, column2, column3, condition);
            if (drpdwnColl != null)
            {
                ddl.DataSource = drpdwnColl;
                ddl.DataValueField = "Column1";
                ddl.DataTextField = "Column2";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("- Select -", "0"));
            }
            return drpdwnColl;
        }
        public static dropdwnCollection fillcheckList(string tablename, string column1, string column2, string column3, int condition)
        {
            dropdwnCollection drpdwnColl = null;
            dropdbManager.filldropdownList(delegate(IDataReader dr)
            {
                using (dr)
                {
                    drpdwnColl = new dropdwnCollection();
                    while (dr.Read())
                    {
                        dropdwn drpdwn = new dropdwn();
                        drpdwn.Column3 = SqlHelper.GetString(dr, column1);
                        drpdwn.Column2 = SqlHelper.GetString(dr, column2);
                        drpdwnColl.Add(drpdwn);
                    }
                }
            }, tablename, column1, column2, column3, condition);
            return drpdwnColl;
        }
        public static dropdwnCollection fillingcheckList(CheckBoxList chklst, string tablename, string column1, string column2, string column3, int condition)
        {
            dropdwnCollection drpdwnColl = null;
            drpdwnColl = fillcheckList(tablename, column1, column2, column3, condition);
            if (drpdwnColl != null)
            {
                chklst.DataSource = drpdwnColl;
                chklst.DataValueField = "Column3";
                chklst.DataTextField = "Column2";
                chklst.DataBind();
            }
            return drpdwnColl;
        }
    }
}
