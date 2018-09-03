using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.stockmove;
using BAL.product;
using BAL.dropdwn;
using BAL.dataset;
using System.Data;
using System.Globalization;

namespace salesmanager.pages
{
    public partial class en_stockmove : System.Web.UI.Page
    {
        stockmoveManager stManager = new stockmoveManager();
        stockmove st = new stockmove();
        int retVal = 0, stockmoveId;
        CultureInfo us = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cId"] != null)
            {
                if (string.IsNullOrEmpty(Request.QueryString["cId"].ToString()) == false)
                {
                    stockmoveId = Convert.ToInt32(Request.QueryString["cId"]);
                }
            }
            if (!Page.IsPostBack)
            {
                txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                dropdwnManager.fillingdropdownList(ddlsrcbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddldesbranch, "tbbranch", "branchId", "branchname", "isdel", 0);
                dropdwnManager.fillingdropdownList(ddluser, "tbuser", "userId", "name", "isdel", 0);
                if (stockmoveId > 0)
                {
                    getstockmove();
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
                DropDownList ddlcategory = (DropDownList)e.Item.FindControl("ddlcategory");
                if (ddlcategory != null)
                {
                    dropdwnManager.fillingdropdownList(ddlcategory, "tbcategory", "categoryId", "categoryname", "isDel", 0);
                }
            }
        }
        private void getstockmove()
        {
            st = stManager.getstockmove(stockmoveId, 3);
            if (st != null)
            {
                txtdate.Text = st.regdate.ToString("dd/MM/yyyy");
                ddluser.SelectedValue = st.userId.ToString();
                ddlsrcbranch.SelectedValue = st.srcbranchId.ToString();
                ddldesbranch.SelectedValue = st.desbranchId.ToString();
                getstockmoveItem();
                btnsave.Text = "Update";
            }
        }
        private void getstockmoveItem()
        {
            //lnkbtnaddmore.Visible = true;
            DataSet ds = null;
            datasetManager dsManager = new datasetManager();
            ds = dsManager.GetAllstockmoveItem(stockmoveId, 2);
            int k = 0, _avlstockQty = 0;
            dgproductInfo.DataSource = ds;
            dgproductInfo.DataBind();
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                DropDownList ddlitem = (DropDownList)itms.FindControl("ddlproduct");
                TextBox txtunitprice = (TextBox)itms.FindControl("txtunitprice");
                TextBox txtqty = (TextBox)itms.FindControl("txtqty");
                TextBox txttotalAmount = (TextBox)itms.FindControl("txttotalAmount");
                TextBox txtavlqty = (TextBox)itms.FindControl("txtavlqty");
                HiddenField hdIdd = (HiddenField)itms.FindControl("hdIdd");

                hdIdd.Value = ds.Tables[0].Rows[k]["stockmoveitemId"].ToString();
                ddlcategory.SelectedValue = ds.Tables[0].Rows[k]["categoryId"].ToString();
                dropdwnManager.fillingdropdownList(ddlitem, "tbproduct", "productId", "productname", "categoryId", Convert.ToInt32(ddlcategory.SelectedValue));
                ddlitem.SelectedValue = ds.Tables[0].Rows[k]["productId"].ToString();
                txtqty.Text = ds.Tables[0].Rows[k]["stockqty"].ToString();
                txtunitprice.Text = Convert.ToDecimal(ds.Tables[0].Rows[k]["unitprice"]).ToString("N", us);
                txttotalAmount.Text = Convert.ToDecimal(ds.Tables[0].Rows[k]["totalunitamount"]).ToString("N", us);
                _avlstockQty = getavlstockQty(Convert.ToInt32(ddlitem.SelectedValue));
                txtavlqty.Text = _avlstockQty.ToString();
                k++;
            }
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            int _val = Convert.ToInt32(drp.SelectedValue);
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                if (itms.ItemType == ListItemType.AlternatingItem || itms.ItemType == ListItemType.Item)
                {
                    DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                    DropDownList ddlproduct = (DropDownList)itms.FindControl("ddlproduct");
                    if (ddlcategory != null)
                    {
                        if (ddlcategory.SelectedValue != "" && ddlcategory.SelectedValue != "0")
                        {
                            if (ddlproduct.SelectedValue == "")
                            {
                                dropdwnManager.fillingdropdownList(ddlproduct, "tbproduct", "productId", "productname", "categoryId", Convert.ToInt32(ddlcategory.SelectedValue));
                            }
                            else if (ddlcategory.SelectedValue != "0" && ddlcategory == drp)
                            {
                                dropdwnManager.fillingdropdownList(ddlproduct, "tbproduct", "productId", "productname", "categoryId", Convert.ToInt32(ddlcategory.SelectedValue));
                            }
                            ddlproduct.Focus();
                        }
                    }
                }
            }
        }
        protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            int _val = Convert.ToInt32(drp.SelectedValue);
            int itemIdd = 0, _qty = 0, _avlstockQty = 0;
            decimal _unitprice = 0, _totalamount = 0, _subtotal = 0, _vat = 0, _grandtotal = 0;
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                DropDownList ddlproduct = (DropDownList)itms.FindControl("ddlproduct");
                TextBox txtunitprice = (TextBox)itms.FindControl("txtunitprice");
                TextBox txtqty = (TextBox)itms.FindControl("txtqty");
                TextBox txtavlqty = (TextBox)itms.FindControl("txtavlqty");
                TextBox txttotalAmount = (TextBox)itms.FindControl("txttotalAmount");
                if (ddlcategory != null)
                {
                    if (ddlcategory.SelectedValue != "" && ddlcategory.SelectedValue != "0")
                    {
                        if (ddlproduct == drp)
                        {
                            if (ddlproduct.SelectedValue != "" && ddlproduct.SelectedValue != "0")
                            {
                                txtqty.Focus();
                                itemIdd = Convert.ToInt32(ddlproduct.SelectedValue);
                                _unitprice = getproductunitprice(itemIdd);
                                _avlstockQty = getavlstockQty(itemIdd);
                                txtunitprice.Text = _unitprice.ToString("N", us);
                                txtavlqty.Text = _avlstockQty.ToString();
                                if (txtqty.Text != "")
                                {
                                    _qty = Convert.ToInt32(txtqty.Text);
                                    _totalamount = _unitprice * _qty;
                                    txttotalAmount.Text = _totalamount.ToString("N", us);
                                }
                            }
                        }
                    }
                }
            }
        }
        private decimal getproductunitprice(int itemId)
        {
            productManager prManager = new productManager();
            product pr = null;
            decimal retVal = 0;
            pr = prManager.getproduct(itemId, 3);
            if (pr != null)
            {
                retVal = pr.buyprice;
            }
            return retVal;
        }
        private int getavlstockQty(int itemId)
        {
            productManager prManager = new productManager();
            product pr = null;
            int Qty = 0, branchId = 0;
            branchId = Convert.ToInt32(ddlsrcbranch.SelectedValue);
            pr = prManager.getavlstockQty(branchId, itemId, 0);
            if (pr != null)
            {
                Qty = pr.avlstockQty;
            }
            return Qty;
        }
        protected void txtqty_OnTextChanged(object sender, EventArgs e)
        {
            int itemIdd = 0, _qty = 0;
            decimal _unitprice = 0, _totalamount = 0, _subtotal = 0, _vat = 0, _grandtotal = 0;
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                DropDownList ddlitem = (DropDownList)itms.FindControl("ddlproduct");
                TextBox txtunitprice = (TextBox)itms.FindControl("txtunitprice");
                TextBox txtqty = (TextBox)itms.FindControl("txtqty");
                TextBox txttotalAmount = (TextBox)itms.FindControl("txttotalAmount");

                if (ddlcategory != null)
                {
                    if (ddlcategory.SelectedValue != "" && ddlcategory.SelectedValue != "0")
                    {
                        if (ddlitem.SelectedValue != "" && ddlitem.SelectedValue != "0")
                        {
                            itemIdd = Convert.ToInt32(ddlitem.SelectedValue);
                            if (txtqty.Text != "" && txtunitprice.Text != "")
                            {
                                _unitprice = Convert.ToDecimal(txtunitprice.Text.Trim());
                                _qty = Convert.ToInt32(txtqty.Text);
                                _totalamount = _unitprice * _qty;
                                txttotalAmount.Text = _totalamount.ToString("N", us);
                            }
                        }
                        else
                        {
                            _unitprice = 0;
                            txtunitprice.Text = _unitprice.ToString();
                        }
                    }
                }
            }
        }
        protected void btnloadcategory_Click(object sender, EventArgs e)
        {
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                HiddenField hdcategoryId = (HiddenField)itms.FindControl("hdcategoryId");
                if (ddlcategory != null)
                {
                    hdcategoryId.Value = ddlcategory.SelectedValue;
                    dropdwnManager.fillingdropdownList(ddlcategory, "tbcategory", "categoryId", "categoryname", "isDel", 0);
                    ddlcategory.SelectedValue = hdcategoryId.Value;
                }
            }
        }
        protected void btnloadItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                DropDownList ddlitem = (DropDownList)itms.FindControl("ddlproduct");
                HiddenField hditemId = (HiddenField)itms.FindControl("hditemId");

                if (ddlcategory != null)
                {
                    if (ddlcategory.SelectedValue != "0")
                    {
                        hditemId.Value = ddlitem.SelectedValue;
                        dropdwnManager.fillingdropdownList(ddlitem, "tbproduct", "productId", "productname", "categoryId", Convert.ToInt32(ddlcategory.SelectedValue));
                        ddlitem.SelectedValue = hditemId.Value;
                    }
                }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int flag = 0, srcbranchId = 0, desbranchId = 0, userId = 0;
            srcbranchId = Convert.ToInt32(ddlsrcbranch.SelectedValue);
            desbranchId = Convert.ToInt32(ddldesbranch.SelectedValue);
            userId = Convert.ToInt32(ddluser.SelectedValue);
            if (btnsave.Text.ToLower() == "update")
            {
                flag = 1;
            }
            retVal = stManager.savestockmove(stockmoveId, srcbranchId, desbranchId, userId, DateTime.Now, false, flag);
            savestockmoveItem(retVal);
            if (btnsave.Text.ToLower() == "save")
            {
                if (retVal > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<script>alert('Record save successfully'); window.location.href='info_stockmove.aspx';</script>";
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
                lblmsg.Text = "<script>alert('Record updated'); window.location.href='info_stockmove.aspx';</script>";
            }
        }
        private void savestockmoveItem(int stockmoveIdd)
        {
            int itemIdd = 0, _qty = 0, categoryId = 0;
            decimal _unitprice = 0, _totalamount = 0, _subtotal = 0, _vat = 0, _grandtotal = 0;
            foreach (DataGridItem itms in dgproductInfo.Items)
            {
                DropDownList ddlcategory = (DropDownList)itms.FindControl("ddlcategory");
                DropDownList ddlitem = (DropDownList)itms.FindControl("ddlproduct");
                TextBox txtunitprice = (TextBox)itms.FindControl("txtunitprice");
                TextBox txtqty = (TextBox)itms.FindControl("txtqty");
                TextBox txttotalAmount = (TextBox)itms.FindControl("txttotalAmount");
                HiddenField hdIdd = (HiddenField)itms.FindControl("hdIdd");

                if (ddlcategory != null)
                {
                    if (ddlcategory.SelectedValue != "" && ddlcategory.SelectedValue != "0")
                    {
                        if (ddlitem.SelectedValue != "" && ddlitem.SelectedValue != "0")
                        {
                            categoryId = Convert.ToInt32(ddlcategory.SelectedValue);
                            itemIdd = Convert.ToInt32(ddlitem.SelectedValue);
                            if (txtqty.Text != "" && txtunitprice.Text != "")
                            {
                                _unitprice = Convert.ToDecimal(txtunitprice.Text.Trim());
                                /* Total Amount */
                                _qty = Convert.ToInt32(txtqty.Text);
                                _totalamount = _unitprice * _qty;
                                txttotalAmount.Text = _totalamount.ToString();

                                if (btnsave.Text.ToLower() == "update")
                                {
                                    int siitemId = 0;
                                    if (itemIdd != 0 && _totalamount != 0)
                                    {
                                        siitemId = Convert.ToInt32(hdIdd.Value);
                                        stManager.savestockmoveItem(siitemId, stockmoveIdd, categoryId, itemIdd, _unitprice, _qty, _totalamount, 1);
                                    }
                                }
                                else
                                {
                                    if (itemIdd != 0 && _totalamount != 0)
                                    {
                                        stManager.savestockmoveItem(0, stockmoveIdd, categoryId, itemIdd, _unitprice, _qty, _totalamount, 0);
                                    }
                                }
                            }
                        }
                        else
                        {
                            _unitprice = 0;
                            txtunitprice.Text = _unitprice.ToString();
                        }
                    }
                }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("info_stockmove.aspx");
        }
    }
}