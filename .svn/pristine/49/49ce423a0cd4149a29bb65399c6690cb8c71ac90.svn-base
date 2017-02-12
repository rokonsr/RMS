using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.PurchaseUI
{
    public partial class CreatePurchase : BasePage
    {
        private Supplier objSupplier;
        private List<Supplier> objSupplierList;
        private SupplierBiz objSupplierBiz;
        private Purchase objPurchase;
        private PurchaseBiz objPurchaseBiz;
        private PurchaseDetail objPurchaseDetail;
        private Product objProduct;
        private ProductBiz objProductBiz;


        protected void Page_Load(object sender, EventArgs e)
        {
            txtPurchaseDate.Text= System.DateTime.Now.ToString("dd-MMM-yyyy");
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
            ddlSupplier.DataSource = objSupplierList;
            ddlSupplier.DataValueField = "SupplierId";
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataBind();

            ddlSupplier.Items.Insert(0, new ListItem("--Select Supplier--", "0"));
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (txtPurchaseQuantity.Text != "0")
            {
                pnlAddPurchaseDetailstoGridView.Visible = true;

                if (Session["PurchaseDetail"] == null)
                {
                    DataTable dt = GetDataTable();
                    DataRow dr = dt.NewRow();
                    dr["ProductCode"] = Convert.ToInt16(txtProductCode.Text.Trim());
                    dr["ProductName"] = txtProductName.Text;
                    dr["PurchaseQuantity"] = Convert.ToDouble(txtPurchaseQuantity.Text);
                    dr["PurchasePrice"] = Convert.ToDouble(txtPurchasePrice.Text);
                    dr["SalePrice"] = Convert.ToDouble(txtSalePrice.Text);
                    dr["TotalAmount"] = Convert.ToDouble(txtPurchasePrice.Text) * Convert.ToDouble(txtPurchaseQuantity.Text);

                    dt.Rows.Add(dr);

                    Session["PurchaseDetail"] = dt;
                    gvDisplayPurchaseDetail.DataSource = dt;
                    gvDisplayPurchaseDetail.DataBind();

                    ResetField();
                }
                else
                {
                    DataTable dt = (DataTable)Session["PurchaseDetail"];
                    DataRow[] d = dt.Select("ProductCode=" + txtProductCode.Text);
                    if (d.Length > 0)
                    {
                        int i;
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt16(dt.Rows[i]["ProductCode"]) == Convert.ToInt32(txtProductCode.Text))
                            {
                                dt.Rows[i]["ProductCode"] = txtProductCode.Text;
                                dt.Rows[i]["ProductName"] = txtProductName.Text;
                                dt.Rows[i]["PurchaseQuantity"] = Convert.ToDouble(txtPurchaseQuantity.Text);
                                dt.Rows[i]["PurchasePrice"] = Convert.ToDouble(txtPurchasePrice.Text);
                                dt.Rows[i]["SalePrice"] = Convert.ToDouble(txtSalePrice.Text);
                                dt.Rows[i]["TotalAmount"] = Convert.ToDouble(txtPurchasePrice.Text) * Convert.ToDouble(txtPurchaseQuantity.Text);
                            }
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr["ProductCode"] = Convert.ToInt16(txtProductCode.Text.Trim());
                        dr["ProductName"] = txtProductName.Text;
                        dr["PurchaseQuantity"] = Convert.ToDouble(txtPurchaseQuantity.Text);
                        dr["PurchasePrice"] = Convert.ToDouble(txtPurchasePrice.Text);
                        dr["SalePrice"] = Convert.ToDouble(txtSalePrice.Text);
                        dr["TotalAmount"] = Convert.ToDouble(txtPurchasePrice.Text) * Convert.ToDouble(txtPurchaseQuantity.Text);

                        dt.Rows.Add(dr);
                    }

                    Session["PurchaseDetail"] = dt;
                    gvDisplayPurchaseDetail.DataSource = dt;
                    gvDisplayPurchaseDetail.DataBind();

                    ResetField();
                }

                AmountCalculation();

                txtProductCode.Attributes.Add("onfocus", "this.select()");
                txtProductCode.Focus();
            }
            else
            {
                MessageBox("Purchase quantity should not be 0!");

                txtPurchaseQuantity.Attributes.Add("onfocus", "this.select()");
                txtPurchaseQuantity.Focus();
            }
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductCode", typeof(int));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("PurchaseQuantity", typeof(double));
            dt.Columns.Add("PurchasePrice", typeof(double));
            dt.Columns.Add("SalePrice", typeof(double));
            dt.Columns.Add("TotalAmount", typeof(double));

            return dt;
        }

        private void ResetField()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtCurrentStock.Text = string.Empty;
            txtPurchaseQuantity.Text = string.Empty;
            txtPurchasePrice.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtProductTotal.Text = string.Empty;
        }

        private decimal totalAmount = 0;
        protected void gvDisplayPurchaseDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                totalAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));

                AmountCalculation();

                txtTotalPurchaseAmount.Text = totalAmount.ToString("N2"); //Display amount in purchase master Total Amount field
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Grand Total";
                e.Row.Cells[4].Font.Bold = true;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[5].Text = totalAmount.ToString("N2");
                e.Row.Cells[5].Font.Bold = true;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void gvDisplayPurchaseDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowDelete")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(((Label)gvr.FindControl("ProductCode")).Text);
                DataTable dt = (DataTable)Session["PurchaseDetail"];

                foreach (DataRow dataRow in dt.Rows)
                {
                    if (Convert.ToInt32(dataRow["ProductCode"]) == id)
                    {
                        dataRow.Delete();
                        break;
                    }
                }
                Session["PurchaseDetail"] = dt;
                gvDisplayPurchaseDetail.DataSource = dt;
                gvDisplayPurchaseDetail.DataBind();

                AmountCalculation();

                txtProductCode.Attributes.Add("onfocus", "this.select()");
                txtProductCode.Focus();
            }

            if (e.CommandName == "RowEdit")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(((Label)gvr.FindControl("ProductCode")).Text);
                DataTable dt = (DataTable)Session["PurchaseDetail"];

                foreach (DataRow dataRow in dt.Rows)
                {
                    if (Convert.ToInt32(dataRow["ProductCode"]) == id)
                    {
                        objProductBiz = new ProductBiz();
                        objProduct = new Product();
                        objProduct = objProductBiz.AddProductForPurchase(id.ToString());

                        txtCurrentStock.Text = objProduct.ProductStock.ToString();
                        txtProductCode.Text = dataRow["ProductCode"].ToString();
                        txtProductName.Text = dataRow["ProductName"].ToString();
                        txtPurchasePrice.Text = dataRow["PurchasePrice"].ToString();
                        txtPurchaseQuantity.Text = dataRow["PurchaseQuantity"].ToString();
                        txtSalePrice.Text = dataRow["SalePrice"].ToString();
                        txtProductTotal.Text = dataRow["TotalAmount"].ToString();
                        break;
                    }
                }
            }

            if (gvDisplayPurchaseDetail.Rows.Count == 0)
            {
                txtProductCode.Attributes.Add("onfocus", "this.select()");
                txtProductCode.Focus();

                txtTotalPurchaseAmount.Text = string.Empty;
                pnlAddPurchaseDetailstoGridView.Visible = false;
            }
        }

        private void AmountCalculation()
        {
            txtPurchaseGrandTotal.Text = txtDueAmount.Text != "" && txtTotalPurchaseAmount.Text != "" ? (Convert.ToDecimal(txtDueAmount.Text) + Convert.ToDecimal(totalAmount)).ToString("N2") : txtDueAmount.Text == "" ? totalAmount.ToString("N2") : "";

            txtCurrentDue.Text = txtPurchaseGrandTotal.Text != "" && txtPaidAmount.Text != "" && txtDiscountAmount.Text != "" ? (Convert.ToDecimal(txtPurchaseGrandTotal.Text) - Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(txtDiscountAmount.Text)).ToString("N2") : txtPurchaseGrandTotal.Text != "" && txtPaidAmount.Text != "" ? (Convert.ToDecimal(txtPurchaseGrandTotal.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString("N2") : txtPurchaseGrandTotal.Text != "" ? (Convert.ToDecimal(txtPurchaseGrandTotal.Text)).ToString("N2") : "";
        }

        protected void ckUpdateSellPrice_CheckedChanged(object sender, EventArgs e)
        {
            txtSalePrice.ReadOnly = !ckUpdateSellPrice.Checked;

            txtProductTotal.Text = txtPurchaseQuantity.Text != "" && txtPurchasePrice.Text != "" ? (Convert.ToDecimal(txtPurchaseQuantity.Text) * Convert.ToDecimal(txtPurchasePrice.Text)).ToString("N2") : "";
        }

        protected void btnPurchase_OnClick(object sender, EventArgs e)
        {
            if (AddPurchase())
            {

            }
        }

        private bool AddPurchase()
        {
            objPurchase = new Purchase();
            objPurchaseBiz = new PurchaseBiz();

            HttpPostedFile postedFile = flUploadInvoice.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".pdf" || fileSize == 0)
            {
                if (fileSize > 524288)
                {
                    MessageBox("File size should not be more than 512 Kbps");
                }
                else
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    objPurchase.FileName = fileName;
                    objPurchase.FileSize = fileSize;
                    objPurchase.InvoiceFile = bytes;

                    objPurchase.SupplierId = Convert.ToInt16(ddlSupplier.SelectedValue);
                    objPurchase.InvoiceNumber = txtInvoiceNumber.Text.Trim();
                    objPurchase.PurchaseDate = Convert.ToDateTime(txtPurchaseDate.Text);
                    objPurchase.TotalAmount = Convert.ToDecimal(txtTotalPurchaseAmount.Text.Trim());
                    objPurchase.DiscountAmount = txtDiscountAmount.Text != "" ? Convert.ToDecimal(txtDiscountAmount.Text.Trim()) : 0;
                    objPurchase.PaidAmount = txtPaidAmount.Text != "" ? Convert.ToDecimal(txtPaidAmount.Text.Trim()) : 0;
                    objPurchase.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());
                    objPurchase.Remarks = txtRemarks.Text.Trim();

                    // Insert purchase details
                    DataTable dt = (DataTable)Session["PurchaseDetail"];

                    int i;
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        objPurchase.ProductId = Convert.ToInt16(dt.Rows[i][0].ToString());
                        objPurchase.PurchaseQuantity = Convert.ToDecimal(dt.Rows[i][2].ToString());
                        objPurchase.PurchasePrice = Convert.ToDecimal(dt.Rows[i][3].ToString());
                        objPurchase.ProductSellPrice = Convert.ToDecimal(dt.Rows[i][4].ToString());

                        objPurchaseBiz.CreatePurchase(objPurchase);

                        objPurchase.SupplierId = 0;
                    }

                    MessageBox("You are successfully purchase listed products. Thanks!");

                    Session.Remove("PurchaseDetail");

                    Response.Redirect("CreatePurchase.aspx");
                }
            }
            else
            {
                MessageBox("Please upload valid (pdf, jpg, png, gif & bmp) picture");
            }

            return true;
        }

        protected void txtProductCode_OnTextChanged(object sender, EventArgs e)
        {
            objProductBiz = new ProductBiz();
            objProduct = new Product();
            objProduct = objProductBiz.AddProductForPurchase(txtProductCode.Text.Trim());

            txtProductName.Text = objProduct.ProductName;
            txtCurrentStock.Text = objProduct.ProductStock.ToString();
            txtSalePrice.Text = objProduct.ProductSellPrice.ToString("N2");

            txtPurchaseQuantity.Attributes.Add("onfocus", "this.select()");
            txtPurchaseQuantity.Focus();
        }

        protected void txtProductName_OnTextChanged(object sender, EventArgs e)
        {
            objProductBiz = new ProductBiz();
            objProduct = new Product();
            objProduct = objProductBiz.AddProductForPurchase(txtProductName.Text.Trim());

            txtProductCode.Text = objProduct.ProductId.ToString();
            txtCurrentStock.Text = objProduct.ProductStock.ToString();
            txtSalePrice.Text = objProduct.ProductSellPrice.ToString("N2");

            txtPurchaseQuantity.Attributes.Add("onfocus", "this.select()");
            txtPurchaseQuantity.Focus();
        }

        protected void ddlSupplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            objSupplier = new Supplier();
            objSupplierBiz = new SupplierBiz();
            objSupplier = objSupplierBiz.GetSupplierDue(ddlSupplier.SelectedValue);

            txtDueAmount.Text = objSupplier.SupplierDue.ToString();

            txtPurchaseGrandTotal.Text = txtDueAmount.Text != "" && txtTotalPurchaseAmount.Text != "" ? (Convert.ToDecimal(txtDueAmount.Text) + Convert.ToDecimal(txtTotalPurchaseAmount.Text)).ToString("N2") : txtTotalPurchaseAmount.Text != "" ? Convert.ToDecimal(txtTotalPurchaseAmount.Text).ToString("N2") : txtDueAmount.Text != "" ? Convert.ToDecimal(txtDueAmount.Text).ToString("N2") : "";

            txtCurrentDue.Text = txtPurchaseGrandTotal.Text != "" && txtPaidAmount.Text != "" && txtDiscountAmount.Text != "" ? (Convert.ToDecimal(txtPurchaseGrandTotal.Text) - Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(txtDiscountAmount.Text)).ToString("N2") : txtPurchaseGrandTotal.Text != "" && txtPaidAmount.Text != "" ? (Convert.ToDecimal(txtPurchaseGrandTotal.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString("N2") : txtPurchaseGrandTotal.Text != "" ? (Convert.ToDecimal(txtPurchaseGrandTotal.Text)).ToString("N2") : "";
        }
    }
}