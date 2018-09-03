using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.expense;
using BAL.product;
using BAL.dropdwn;
using BAL.dataset;
using System.Data;
using System.Globalization;

namespace salesmanager.pages
{
    public partial class en_expense : System.Web.UI.Page
    {
        expenseManager stManager = new expenseManager();
        expense st = new expense();
        int retVal = 0, expenseId;
        CultureInfo us = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["cId"].ToString()) == false)
                {
                    expenseId = Convert.ToInt32(Request.QueryString["cId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddluser, "tbuser", "userId", "name", "isdel", 0);
                
                if (expenseId > 0)
                {
                    getexpense();
                }
                else
                {
                    dgproductInfo.DataSource = GetTable();
                    dgproductInfo.DataBind();
                    dgproductInfo.PagerStyle.Visible = false;
                }
            }
        }
        private DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("value", typeof(int));
            for (int i = 1; i <= 15; i++)
            {
                table.Rows.Add(i);
            }
            return table;
        }
        protected void dginvoice_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddlexpensetype = (DropDownList)e.Item.FindControl("ddlexpensetype");
                if (ddlexpensetype != null)
                {
                    dropdwnManager.fillingdropdownList(ddlexpensetype, "tbexpensetype", "expensetypeId", "expensetypename", "isDel", 0);
                }
            }
        }
        private void getexpense()
        {
            st = stManager.getexpense(expenseId, 3);
            if (st != null)
            {
                txtdate.Text = st.regdate.ToString("dd/MM/yyyy");
                ddluser.SelectedValue = st.userId.ToString();
                getmenifest(st.userId);
                ddlmanifest.SelectedValue = st.assignjobId.ToString();
                ddlbranch.SelectedValue = st.branchId.ToString();
                getexpenseItem();
                btnsave.Text = "Update";
            }
        }
        private void getexpenseItem()
        {
            //lnkbtnaddmore.Visible = true;
            DataSet ds = null;
            datasetManager dsManager = new datasetManager();
            ds = dsManager.GetAllexpenseItem(expenseId, 2);
            int k = 0;
            dgproductInfo.DataSource = ds;
            dgproductInfo.DataBind();
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlexpensetype = (DropDownList)itms.FindControl("ddlexpensetype");
                TextBox txtexpamount = (TextBox)itms.FindControl("txtexpamount");
                HiddenField hdIdd = (HiddenField)itms.FindControl("hdIdd");

                hdIdd.Value = ds.Tables[0].Rows[k]["expenseitemId"].ToString();
                ddlexpensetype.SelectedValue = ds.Tables[0].Rows[k]["expensetypeId"].ToString();
                txtexpamount.Text = Convert.ToDecimal(ds.Tables[0].Rows[k]["expamount"]).ToString("N", us);
                k++;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, branchId = 0, userId = 0, assignjobId = 0;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            assignjobId = Convert.ToInt32(ddlmanifest.SelectedValue);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = stManager.saveexpense(expenseId, assignjobId, branchId, userId, DateTime.Now, false, flag);
            saveexpenseItem(retVal);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_expense.aspx';</script>";
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record already exists');</script>";
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_expense.aspx';</script>";
            }
        }
        private void saveexpenseItem(int expenseIdd)
        {
            int expensetypeId = 0;
            decimal _expamount = 0;
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlexpensetype = (DropDownList)itms.FindControl("ddlexpensetype");
                TextBox txtexpamount = (TextBox)itms.FindControl("txtexpamount");
                HiddenField hdIdd = (HiddenField)itms.FindControl("hdIdd");

                if (ddlexpensetype != null)
                {
                    if (ddlexpensetype.SelectedValue != "" && ddlexpensetype.SelectedValue != "0")
                    {
                        expensetypeId = Convert.ToInt32(ddlexpensetype.SelectedValue);
                        if (txtexpamount.Text != "")
                        {
                            _expamount = Convert.ToDecimal(txtexpamount.Text.Trim());
                            if (btnsave.Text.ToLower() == "update")
                            {
                                int expitemId = 0;
                                if (expensetypeId != 0 && _expamount != 0)
                                {
                                    expitemId = Convert.ToInt32(hdIdd.Value);
                                    stManager.saveexpenseItem(expitemId, expenseIdd, expensetypeId, _expamount, 1);
                                }
                            }
                            else
                            {
                                if (expensetypeId != 0 && _expamount != 0)
                                {
                                    stManager.saveexpenseItem(0, expenseIdd, expensetypeId, _expamount, 0);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void ddluser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = 0;
            userId = Convert.ToInt32(ddluser.SelectedValue);
            getmenifest(userId);
        }
        private void getmenifest(int userId)
        {
            dropdwnManager.fillingdropdownList(ddlmanifest, "vw_activeManifest", "assignjobId", "manifest", "userId", userId);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_expense.aspx");
        }
    }
}