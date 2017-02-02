using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;
using System.Web.UI;

namespace RMS.UI.PurchaseUI
{
    public partial class ReturnPurchase : BasePage
    {
        private List<Supplier> objSupplierList;
        private SupplierBiz objSupplierBiz;
        private PurchaseReturn objPurchaseReturn;
        private PurchaseReturnBiz objPurchaseReturnBiz;
        private Product objProduct;
        private ProductBiz objProductBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownForSupplier();
            }
        }

        private void PopulateDropDownForSupplier()
        {
            objSupplierList = new List<Supplier>();
            objSupplierBiz = new SupplierBiz();

            objSupplierList = objSupplierBiz.GetSupplierList();
            ddlSupplierList.DataSource = objSupplierList;
            ddlSupplierList.DataValueField = "SupplierId";
            ddlSupplierList.DataTextField = "SupplierName";
            ddlSupplierList.DataBind();

            ddlSupplierList.Items.Insert(0, new ListItem("--Select Supplier--", "0"));
        }

        protected void ddlSupplierList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void txtInvoiceNumber_OnTextChanged(object sender, EventArgs e)
        {
            objPurchaseReturn = new PurchaseReturn();
            objPurchaseReturnBiz = new PurchaseReturnBiz();

            objPurchaseReturn = objPurchaseReturnBiz.GetSupplierName(txtInvoiceNumber.Text.Trim());

            ddlSupplierList.SelectedValue = objPurchaseReturn.SupplierId.ToString();
            lblPurchaseId.Text = objPurchaseReturn.PurchaseId.ToString();
            lblDiscountAmount.Text = objPurchaseReturn.DiscountAmount.ToString();
            txtReturnDiscountAmount.Text = objPurchaseReturn.DiscountAmount.ToString();

            txtReturnProductCode.Attributes.Add("onfocus", "this.select()");
            txtReturnProductCode.Focus();
        }

        protected void txtProductCode_OnTextChanged(object sender, EventArgs e)
        {
            objProductBiz = new ProductBiz();
            objProduct = new Product();

            objProduct = objProductBiz.AddProductDetailsForRP(txtReturnProductCode.Text.Trim(), txtInvoiceNumber.Text.Trim());

            txtReturnProductName.Text = objProduct.ProductName;
            txtPurchaseQuantity.Text = objProduct.PurchaseQuantity.ToString();
            txtPrice.Text = objProduct.PurchasePrice.ToString();

            txtReturnQuantity.Attributes.Add("onfocus", "this.select()");
            txtReturnQuantity.Focus();
        }

        protected void txtProductName_OnTextChanged(object sender, EventArgs e)
        {
            objProductBiz = new ProductBiz();
            objProduct = new Product();

            objProduct = objProductBiz.AddProductDetailsForRP(txtReturnProductName.Text.Trim(), txtInvoiceNumber.Text.Trim());

            txtReturnProductCode.Text = objProduct.ProductId.ToString();
            txtPurchaseQuantity.Text = objProduct.PurchaseQuantity.ToString();
            txtPrice.Text = objProduct.PurchasePrice.ToString();

            txtReturnQuantity.Attributes.Add("onfocus", "this.select()");
            txtReturnQuantity.Focus();
        }

        protected void btnAddReturn_OnClick(object sender, EventArgs e)
        {
            if (txtReturnQuantity.Text != "0" && Convert.ToDecimal(txtReturnQuantity.Text) <= Convert.ToDecimal(txtPurchaseQuantity.Text))
            {
                pnlDisplayReturnDetails.Visible = true;

                if (Session["ReturnDetail"] == null)
                {
                    DataTable dt = GetDataTable();
                    DataRow dr = dt.NewRow();
                    dr["SupplierId"] = Convert.ToInt16(ddlSupplierList.SelectedValue);
                    dr["SupplierName"] = ddlSupplierList.SelectedItem.Text;
                    dr["InvoiceNumber"] = txtInvoiceNumber.Text;
                    dr["ProductId"] = Convert.ToDouble(txtReturnProductCode.Text);
                    dr["ProductName"] = txtReturnProductName.Text.Trim();
                    dr["PurchaseQuantity"] = Convert.ToDecimal(txtPurchaseQuantity.Text);
                    dr["ReturnQuantity"] = Convert.ToDouble(txtReturnQuantity.Text);
                    dr["Price"] = Convert.ToDouble(txtPrice.Text);
                    dr["ProductTotal"] = Convert.ToDouble(txtReturnQuantity.Text) * Convert.ToDouble(txtPrice.Text);

                    dt.Rows.Add(dr);

                    Session["ReturnDetail"] = dt;
                    gvReturnDetails.DataSource = dt;
                    gvReturnDetails.DataBind();

                    ResetField();
                }
                else
                {
                    DataTable dt = (DataTable)Session["ReturnDetail"];
                    DataRow[] d = dt.Select("ProductId=" + txtReturnProductCode.Text);
                    if (d.Length > 0)
                    {
                        int i;
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt16(dt.Rows[i]["ProductId"]) == Convert.ToInt32(txtReturnProductCode.Text))
                            {
                                dt.Rows[i]["SupplierId"] = Convert.ToInt16(ddlSupplierList.SelectedValue);
                                dt.Rows[i]["SupplierName"] = ddlSupplierList.SelectedItem.Text;
                                dt.Rows[i]["InvoiceNumber"] = txtInvoiceNumber.Text;
                                dt.Rows[i]["ProductId"] = Convert.ToDouble(txtReturnProductCode.Text);
                                dt.Rows[i]["ProductName"] = txtReturnProductName.Text.Trim();
                                dt.Rows[i]["PurchaseQuantity"] = Convert.ToDecimal(txtPurchaseQuantity.Text);
                                dt.Rows[i]["ReturnQuantity"] = Convert.ToDouble(txtReturnQuantity.Text);
                                dt.Rows[i]["Price"] = Convert.ToDouble(txtPrice.Text);
                                dt.Rows[i]["ProductTotal"] = Convert.ToDouble(txtReturnQuantity.Text) * Convert.ToDouble(txtPrice.Text);
                            }
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr["SupplierId"] = Convert.ToInt16(ddlSupplierList.SelectedValue);
                        dr["SupplierName"] = ddlSupplierList.SelectedItem.Text;
                        dr["InvoiceNumber"] = txtInvoiceNumber.Text;
                        dr["ProductId"] = Convert.ToDouble(txtReturnProductCode.Text);
                        dr["ProductName"] = txtReturnProductName.Text.Trim();
                        dr["PurchaseQuantity"] = Convert.ToDecimal(txtPurchaseQuantity.Text);
                        dr["ReturnQuantity"] = Convert.ToDouble(txtReturnQuantity.Text);
                        dr["Price"] = Convert.ToDouble(txtPrice.Text);
                        dr["ProductTotal"] = Convert.ToDouble(txtReturnQuantity.Text) * Convert.ToDouble(txtPrice.Text);

                        dt.Rows.Add(dr);
                    }

                    Session["ReturnDetail"] = dt;
                    gvReturnDetails.DataSource = dt;
                    gvReturnDetails.DataBind();

                    ResetField();
                }

                //AmountCalculation();

                pnlDisplayReturnDetails.Visible = true;

                txtReturnProductCode.Attributes.Add("onfocus", "this.select()");
                txtReturnProductCode.Focus();
            }
            else
            {
                MessageBox("Return quantity wrong input!");

                txtReturnQuantity.Attributes.Add("onfocus", "this.select()");
                txtReturnQuantity.Focus();
            }
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SupplierId", typeof (int));
            dt.Columns.Add("SupplierName", typeof (string));
            dt.Columns.Add("InvoiceNumber", typeof (string));
            dt.Columns.Add("ProductId", typeof (int));
            dt.Columns.Add("ProductName", typeof (string));
            dt.Columns.Add("PurchaseQuantity", typeof (decimal));
            dt.Columns.Add("Remarks", typeof (string));
            dt.Columns.Add("ReturnQuantity", typeof (decimal));
            dt.Columns.Add("Price", typeof (decimal));
            dt.Columns.Add("ProductTotal", typeof (decimal));

            return dt;
        }

        private void ResetField()
        {
            //txtInvoiceNumber.Text = string.Empty;
            //ddlSupplierList.SelectedIndex = 0;
            txtReturnProductCode.Text = string.Empty;
            txtReturnProductName.Text = string.Empty;
            txtPurchaseQuantity.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtReturnQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        protected void gvReturnDetails_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowDelete")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(((Label)gvr.FindControl("ProductId")).Text);
                DataTable dt = (DataTable)Session["ReturnDetail"];

                foreach (DataRow dataRow in dt.Rows)
                {
                    if (Convert.ToInt32(dataRow["ProductId"]) == id)
                    {
                        dataRow.Delete();
                        break;
                    }
                }
                Session["ReturnDetail"] = dt;
                gvReturnDetails.DataSource = dt;
                gvReturnDetails.DataBind();

                txtReturnProductCode.Attributes.Add("onfocus", "this.select()");
                txtReturnProductCode.Focus();
            }

            if (e.CommandName == "RowEdit")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(((Label)gvr.FindControl("ProductId")).Text);
                DataTable dt = (DataTable)Session["ReturnDetail"];

                foreach (DataRow dataRow in dt.Rows)
                {
                    if (Convert.ToInt32(dataRow["ProductId"]) == id)
                    {
                        txtReturnProductCode.Text = dataRow["ProductId"].ToString();
                        txtReturnProductName.Text = dataRow["ProductName"].ToString();
                        txtPurchaseQuantity.Text = dataRow["PurchaseQuantity"].ToString();
                        txtReturnQuantity.Text = dataRow["ReturnQuantity"].ToString();
                        txtPrice.Text = dataRow["Price"].ToString();
                        txtTotal.Text = dataRow["ProductTotal"].ToString();

                        break;
                    }
                }
                txtReturnQuantity.Attributes.Add("onfocus", "this.select()");
                txtReturnQuantity.Focus();
            }

            if (gvReturnDetails.Rows.Count == 0)
            {
                txtReturnProductCode.Attributes.Add("onfocus", "this.select()");
                txtReturnProductCode.Focus();

                txtTotalReturnValue.Text = string.Empty;
                //pnlDisplayReturnDetails.Visible = false;
            }
        }

        private decimal totalAmount = 0;
        protected void gvReturnDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;

                totalAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ProductTotal"));

                txtTotalReturnValue.Text = totalAmount.ToString("N2"); //Display amount in purchase master Total Amount field
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[7].Text = "Grand Total";
                e.Row.Cells[7].Font.Bold = true;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[8].Text = totalAmount.ToString("N2");
                e.Row.Cells[8].Font.Bold = true;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void btnSubmitReturn_OnClick(object sender, EventArgs e)
        {
            objPurchaseReturn = new PurchaseReturn();
            objPurchaseReturnBiz = new PurchaseReturnBiz();

            DataTable dt = (DataTable)Session["ReturnDetail"];

            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                objPurchaseReturn.PurchaseId = Convert.ToInt32(lblPurchaseId.Text);
                objPurchaseReturn.ProductId = Convert.ToInt16(dt.Rows[i][3].ToString());
                objPurchaseReturn.ReturnQuantity = Convert.ToDecimal(dt.Rows[i][7].ToString());
                objPurchaseReturn.TotalReturnValue = Convert.ToDecimal(txtTotalReturnValue.Text);
                objPurchaseReturn.DiscountAmount = txtReturnDiscountAmount.Text != "" ? Convert.ToDecimal(txtReturnDiscountAmount.Text) : 0;
                objPurchaseReturn.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());

                objPurchaseReturnBiz.CreateReturnDetail(objPurchaseReturn);
            }

            MessageBox("You are successfully return listed products. Thanks!");

            Session.Remove("ReturnDetail");

            Response.Redirect("ReturnPurchase.aspx");
        }
    }
}