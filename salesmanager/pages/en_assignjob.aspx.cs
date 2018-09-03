using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.assignjob;
using BAL.product;
using BAL.dropdwn;
using BAL.dataset;
using System.Data;
using System.Globalization;
using Utils;

namespace salesmanager.pages
{
    public partial class en_assignjob : System.Web.UI.Page
    {
        assignjobManager stManager = new assignjobManager();
        assignjob st = new assignjob();
        int retVal = 0, assignjobId;
        CultureInfo us = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["cId"].ToString()) == false)
                {
                    assignjobId = Convert.ToInt32(Request.QueryString["cId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                Comman.FillFuel(ddlfuelIn);
                Comman.FillFuel(ddlfuelOut);
                dropdwnManager.fillingdropdownList(ddlbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddluser, "tbuser", "userId", "name", "isdel", 0);
                if (assignjobId > 0)
                {
                    getassignjob();
                }
                else
                {
                    getcmlNo();
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
            for (int i = 1; i <= 10; i++)
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
                DropDownList ddlQty = (DropDownList)e.Item.FindControl("ddlQty");
                dropdwnManager.fillingdropdownList(ddlproduct, "tbproduct", "productId", "productname", "isdel", 0);
                Comman.FillFuel(ddlQty);
            }
        }
        private void getcmlNo()
        {
            st = stManager.getcmlNo(0, 5);
            if (st != null)
            {
                lblcmlno.Text = st.cmlNo;
            }
        }
        private void getassignjob()
        {
            st = stManager.getassignjob(assignjobId, 3);
            if (st != null)
            {
                txtdate.Text = st.regdate.ToString("dd/MM/yyyy");
                ddluser.SelectedValue = st.userId.ToString();
                ddlbranch.SelectedValue = st.branchId.ToString();
                lblcmlno.Text = st.cmlNo;
                txttruckNo.Text = st.truckNo;
                txtdriverlncno.Text = st.drvlncNo;
                txtdrivername.Text = st.driverName;
                txtconductorname.Text = st.conductorName;
                txtomreadingarrival.Text = st.omreadingarrival;
                txtomreadingdeparture.Text = st.omreadingdeparture;
                txtmileage.Text = st.mileage.ToString();
                ddlfuelIn.SelectedValue = (st.infuel < 10) ? ("0" + st.infuel.ToString()) : st.infuel.ToString();
                ddlfuelOut.SelectedValue = (st.outfuel < 10) ? ("0" + st.outfuel.ToString()) : st.outfuel.ToString();
                getassignjobItem();
                btnsave.Text = "Update";
            }
        }
        private void getassignjobItem()
        {
            //lnkbtnaddmore.Visible = true;
            DataSet ds = null;
            datasetManager dsManager = new datasetManager();
            ds = dsManager.GetAllassignjobItem(assignjobId, 2);
            int k = 0;
            dgproductInfo.DataSource = ds;
            dgproductInfo.DataBind();
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlitem = (DropDownList)itms.FindControl("ddlproduct");
                DropDownList ddlQty = (DropDownList)itms.FindControl("ddlQty");
                DropDownList ddlmeasurement = (DropDownList)itms.FindControl("ddlmeasurement");
                HiddenField hdIdd = (HiddenField)itms.FindControl("hdIdd");
                hdIdd.Value = ds.Tables[0].Rows[k]["assignjobitemId"].ToString();
                ddlitem.SelectedValue = ds.Tables[0].Rows[k]["productId"].ToString();
                ddlQty.SelectedValue = ds.Tables[0].Rows[k]["stockqty"].ToString();
                ddlmeasurement.SelectedValue = ds.Tables[0].Rows[k]["measurementQty"].ToString();
                k++;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, branchId = 0, userId = 0, infuel = 0, outfuel = 0, mileage = 0;
            infuel = Convert.ToInt32(ddlfuelIn.SelectedValue);
            outfuel = Convert.ToInt32(ddlfuelOut.SelectedValue);
            mileage = Convert.ToInt32(txtmileage.Text.Trim());
            branchId = Convert.ToInt32(ddlbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            DateTime regdate = DateTime.ParseExact(txtdate.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = stManager.saveassignjob(assignjobId, lblcmlno.Text.Trim(), txttruckNo.Text.Trim(), txtdrivername.Text.Trim(),
                txtdriverlncno.Text.Trim(), txtconductorname.Text.Trim(), infuel, txtomreadingarrival.Text.Trim(),
                txtomreadingdeparture.Text.Trim(), mileage, outfuel, branchId, userId, regdate, false, flag);
            saveassignjobItem(retVal);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_assignjob.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_assignjob.aspx';</script>";
            }
        }
        private void saveassignjobItem(int assignjobIdd)
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
                        measurementQty = Convert.ToInt32(ddlmeasurement.SelectedValue);
                        if (ddlQty.SelectedValue != "0")
                        {
                            _qty = Convert.ToInt32(ddlQty.SelectedValue);
                            if (btnsave.Text.ToLower() == "update")
                            {
                                int siitemId = 0;
                                if (itemIdd != 0)
                                {
                                    siitemId = Convert.ToInt32(hdIdd.Value);
                                    stManager.saveassignjobItem(siitemId, assignjobIdd, categoryId, itemIdd, 0, _qty, measurementQty, 0, 1);
                                }
                            }
                            else
                            {
                                if (itemIdd != 0)
                                {
                                    stManager.saveassignjobItem(0, assignjobIdd, categoryId, itemIdd, 0, _qty, measurementQty, 0, 0);
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_assignjob.aspx");
        }
    }
}