using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.sale;
using BAL.assignjob;
using BAL.product;
using BAL.dropdwn;
using BAL.dataset;
using System.Data;
using System.Globalization;
using Utils;

namespace salesmanager.pages
{
    public partial class en_sale : System.Web.UI.Page
    {
        public int userId { get { return (Session["userId"] != null) ? Convert.ToInt32(Session["userId"].ToString()) : 0; } set { Session["userId"] = value; } }
        saleManager stManager = new saleManager();
        sale st = new sale();
        int retVal = 0, saleId, assignjobId;
        CultureInfo us = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["saleId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["saleId"].ToString()) == false)
                {
                    saleId = Convert.ToInt32(Request.QueryString["saleId"]);
                }
            }
            if (Request.QueryString["ajId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ajId"].ToString()) == false)
                {
                    assignjobId = Convert.ToInt32(Request.QueryString["ajId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddluser, "tbuser", "userId", "name", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddlcustomer, "tbcustomer", "customerId", "cusname", "isDel", 0);
                if (assignjobId > 0)
                {
                    getassignjob();
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
            int cnt = 5;
            DataTable table = new DataTable();
            table.Columns.Add("value", typeof(int));
            for (int i = 1; i <= cnt; i++)
            {
                table.Rows.Add(i);
            }
            return table;
        }
        protected void dginvoice_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddlproduct = (DropDownList)e.Item.FindControl("ddlproduct");
                DropDownList ddlmeasurement = (DropDownList)e.Item.FindControl("ddlmeasurement");
                Label lblavlQty = (Label)e.Item.FindControl("lblavlQty");
                if (ddlproduct != null)
                {
                    dropdwnManager.fillingdropdownList(ddlproduct, "vw_assignjobcategory", "productId", "productname", "assignjobId", assignjobId);
                }
                if (ddlmeasurement != null)
                {
                    dropdwnManager.fillingdropdownList(ddlmeasurement, "vw_measurementQtyInassignjob", "measurementQty", "measurementQtyAmount", "assignjobId", assignjobId);
                }
                
            }
        }
        private void getassignjob()
        {
            st = stManager.getassignjob(saleId, assignjobId, 5);
            if (st != null)
            {
                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ddluser.SelectedValue = st.userId.ToString();
                ddlbranch.SelectedValue = st.branchId.ToString();
                dgproductInfo.DataSource = GetTable();
                dgproductInfo.DataBind();
                dgproductInfo.PagerStyle.Visible = false;
                btnsave.Text = "Save";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, branchId = 0, userId = 0, customerId = 0;
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            customerId = Convert.ToInt32(ddlcustomer.SelectedValue);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = stManager.savesale(saleId, assignjobId, customerId, branchId, userId, DateTime.Now, false, flag);
            savesaleItem(retVal);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_sale.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_sale.aspx';</script>";
            }
        }
        private void savesaleItem(int saleIdd)
        {
            int itemIdd = 0, _qty = 0, categoryId = 1, measurementQty = 0;
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlitem = (DropDownList)itms.FindControl("ddlproduct");
                DropDownList ddlQty = (DropDownList)itms.FindControl("ddlQty");
                DropDownList ddlmeasurement = (DropDownList)itms.FindControl("ddlmeasurement");
                HiddenField hdIdd = (HiddenField)itms.FindControl("hdIdd");

                if (ddlitem != null)
                {
                    if (ddlitem.SelectedValue != "" && ddlitem.SelectedValue != "0")
                    {
                        itemIdd = Convert.ToInt32(ddlitem.SelectedValue);
                        if (ddlQty.SelectedValue != "")
                        {
                            _qty = Convert.ToInt32(ddlQty.SelectedValue);
                            measurementQty = Convert.ToInt32(ddlmeasurement.SelectedValue);
                            if (btnsave.Text.ToLower() == "update")
                            {
                                int siitemId = 0;
                                if (itemIdd != 0)
                                {
                                    siitemId = Convert.ToInt32(hdIdd.Value);
                                    stManager.savesaleItem(siitemId, saleIdd, categoryId, itemIdd, 0, _qty, measurementQty, 0, 1);
                                }
                            }
                            else
                            {
                                if (itemIdd != 0)
                                {
                                    stManager.savesaleItem(0, saleIdd, categoryId, itemIdd, 0, _qty, measurementQty, 0, 0);
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_sale.aspx");
        }
        protected void ddlmeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productId = 0, measurementQty = 0, availableQty = 0;
            DropDownList drp = (DropDownList)sender;
            int _val = Convert.ToInt32(drp.SelectedValue);
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlmeasurement = (DropDownList)itms.FindControl("ddlmeasurement");
                DropDownList ddlproduct = (DropDownList)itms.FindControl("ddlproduct");
                DropDownList ddlQty = (DropDownList)itms.FindControl("ddlQty");
               
                Label lblavlQty = (Label)itms.FindControl("lblavlQty");
                if (ddlproduct != null)
                {
                    if (ddlproduct.SelectedValue != "" && ddlproduct.SelectedValue != "0")
                    {
                        productId = Convert.ToInt32(ddlproduct.SelectedValue);
                        measurementQty = Convert.ToInt32(ddlmeasurement.SelectedValue);
                        if (ddlmeasurement.SelectedValue != "0" && ddlmeasurement == drp)
                        {
                            availableQty = getavailableQty(productId, measurementQty);
                            lblavlQty.Text = availableQty.ToString();
                            Comman.FillFuelConditional(ddlQty, availableQty);
                        }
                        ddlmeasurement.Focus();
                    }
                }
            }
        }
        private int getavailableQty(int productId, int measurementQty)
        {
            int retVal =0;
            assignjobManager ajManager = new assignjobManager();
            assignjob aj = new assignjob();
            aj = ajManager.getavailableQty(assignjobId, productId, measurementQty, 3);
            if (aj != null)
            {
                retVal = aj.avlQty;
            }
            return retVal;
        }
    }
}