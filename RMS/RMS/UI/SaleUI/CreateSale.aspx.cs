using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.Model;
using RMS.BLL;
using RMS.DAL;

namespace RMS.UI.SaleUI
{
    public partial class CreateSale :BasePage
    {
        private Product objProduct;
        private Sale objSale;
        private SaleDetail objSaleDetail;
        private ProductBiz objProductBiz;
        private SaleBiz objSaleBiz;
        private decimal tot,code,qty,stock;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6]
                {
                    new DataColumn("ProductId"), new DataColumn("ProductName"), new DataColumn("ProductQty"),
                    new DataColumn("ProductPricePerUnit"), new DataColumn("ProductVat"), new DataColumn("ProductTotalPrice")
                });
                Session["SellProduct"] = dt;
                this.GridviewBind();
                txtProductCode.Focus();
            }
        }
        private void GridviewBind()
        {
            GvSellProduct.Columns[0].Visible = true;
            GvSellProduct.DataSource = (DataTable)Session["SellProduct"];
            GvSellProduct.DataBind();
            GvSellProduct.Columns[0].Visible = false;
        }

        protected void GvSellProduct_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    tot += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ProductTotalPrice"));

                }
                catch
                {
                    // ignored
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Grand Total";
                e.Row.Cells[4].Font.Bold = true;

                e.Row.Cells[5].Text = tot.ToString("N2");
                e.Row.Cells[5].Font.Bold = true;
                e.Row.Cells[5].ForeColor = Color.DeepPink;
            }

        
    }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtProductCode_OnTextChanged(txtProductCode,  EventArgs.Empty);
            txtProductName_OnTextChanged(txtProductName,EventArgs.Empty);
            txtQty_OnTextChanged(txtQty, EventArgs.Empty);
            if(txtTotalPriceOfWholeQty.Text != string.Empty)
            {
                DataTable dt = (DataTable)Session["SellProduct"];
                for (int i = 0; i < GvSellProduct.Rows.Count; i++)
                {
                    string id = GvSellProduct.Rows[i].Cells[0].Text;
                    if (id == txtProductCode.Text.Trim())
                    {
                        dt.Rows[i].Delete();
                        break;
                    }
                }
                dt.Rows.Add(txtProductCode.Text.Trim(), txtProductName.Text.Trim(),
                    Convert.ToDecimal(txtQty.Text.Trim()).ToString("N3"), txtProductPricePerUnit.Text.Trim(),
                       txtVat.Text.Trim(), txtTotalPriceOfWholeProduct.Text);
                Session["SellProduct"] = dt;
                this.GridviewBind();
                //ClearInputs(Controls);
                if (txtDiscount.Text.Trim() != "")
                {
                    tot = tot - Convert.ToDecimal(txtDiscount.Text.Trim());
                }
                txtToBePaid.Text = txtCustomerDue.Text==string.Empty ? tot.ToString("N2") : (tot+Convert.ToDecimal(txtCustomerDue.Text)).ToString("N2");
                pnlsaleGridview.Visible = true;
                pnlsale.Visible = true;
                txtProductCode.Text = string.Empty;
                txtProductName.Text = string.Empty;
                txtProductStock.Text = string.Empty;
                txtProductPricePerUnit.Text = string.Empty;
                txtQty.Text = string.Empty;
                txtTotalPriceOfWholeQty.Text = string.Empty;
                txtVat.Text = string.Empty;
                txtTotalPriceOfWholeProduct.Text = string.Empty;

            }

            //txtProductCode.Focus();

        }


        protected void txtProductCode_OnTextChanged(object sender, EventArgs e)
        {
                GetProductInfo(txtProductCode.Text.Trim());
                Autofil();
        }

        protected void txtProductName_OnTextChanged(object sender, EventArgs e)
        {
                GetProductInfo(txtProductName.Text.Trim());
                Autofil();

        }

        private void Autofil()
        {
            StackFrame frame = new StackFrame(1);
            var methodName = frame.GetMethod().Name;
            if (objProduct.ProductName != null)
            {
                    txtProductCode.Text = objProduct.ProductId.ToString();
                    txtProductName.Text = objProduct.ProductName;
                    txtProductStock.Text = objProduct.ProductStock.ToString("N3");
                    txtProductPricePerUnit.Text = objProduct.ProductSellPrice.ToString("N2");
                    lblUnit.Text = objProduct.MeasurementName;
                    lblUnitSell.Text = lblUnit.Text;
                    txtVat.Text = objProduct.Vat.ToString("N2");
                    //txtQty.Text = string.Empty;
                    txtTotalPriceOfWholeQty.Text = string.Empty;
                    txtTotalPriceOfWholeProduct.Text = string.Empty;
                txtQty.Focus();
                if (objProduct.ProductStock > 0) return;
                MessageBox("No product available.");
                SelectText(methodName == "txtProductCode_OnTextChanged" ? txtProductCode : txtProductName);
            }
            else
            {
                MessageBox("No product found.");
                SelectText(methodName == "txtProductCode_OnTextChanged" ? txtProductCode : txtProductName);

            }
            

        }

        protected void txtQty_OnTextChanged(object sender, EventArgs e)
        {
            
                
            
            try
            {
                if (decimal.Parse(txtQty.Text.Trim()) > decimal.Parse(txtProductStock.Text))
                {
                    MessageBox("Please correct sell quantity.");
                    SelectText(txtQty);
                    return;
                }
                txtTotalPriceOfWholeQty.Text = (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtProductPricePerUnit.Text)).ToString("N2");
                txtTotalPriceOfWholeProduct.Text =
                    (Convert.ToDecimal(txtTotalPriceOfWholeQty.Text) +
                     (Convert.ToDecimal(txtTotalPriceOfWholeQty.Text) * Convert.ToDecimal(txtVat.Text) / 100)).ToString("N2");
            }
            catch (Exception)
            {

                MessageBox("Product/Qty Error");
                txtQty.Text = string.Empty;
            }

        }

        private void GetProductInfo(string codeOrName)
        {
            objProduct = new Product();
            objProductBiz = new ProductBiz();
            objProduct = objProductBiz.AddProductForPurchase(codeOrName);
           
        }

        protected void txtDiscount_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = Convert.ToDecimal(GvSellProduct.FooterRow.Cells[5].Text.Trim()) - Convert.ToDecimal(txtDiscount.Text.Trim());
                txtToBePaid.Text = txtCustomerDue.Text == string.Empty ? total.ToString("N2") : (total + Convert.ToDecimal(txtCustomerDue.Text)).ToString("N2");

            }
            catch

            {
                try
                {
                    txtToBePaid.Text = GvSellProduct.FooterRow.Cells[5].Text.Trim();

                }
                catch { }
            }
            txtAmountPaid_OnTextChanged(txtAmountPaid, EventArgs.Empty);
        }

        protected void txtAmountPaid_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal changeAmount = Convert.ToDecimal(txtAmountPaid.Text.Trim()) -
                                                   Convert.ToDecimal(txtToBePaid.Text.Trim());
                txtChangeAmount.Text = changeAmount.ToString("N2");
            }
            catch { }
            

        }


        protected void txtCustomerUsername_OnTextChanged(object sender, EventArgs e)
        {
            objSaleBiz = new SaleBiz();
            Customer objCustomer=new Customer();
            objCustomer = objSaleBiz.GetCustomerInfo(txtCustomerUsername.Text.Trim());
            txtCustomerFullName.Text = objCustomer.CustomerFullName;
            txtCustomerContactNo.Text = objCustomer.CustomerContactNumber;
            txtCustomerDue.Text = objCustomer.CustomerTotalDue;
            txtToBePaid.Text = txtToBePaid.Text!=string.Empty ? (Convert.ToDecimal(txtToBePaid.Text) + Convert.ToDecimal(objCustomer.CustomerTotalDue)).ToString("N2") : Convert.ToDecimal(objCustomer.CustomerTotalDue).ToString("N2");

        }

        protected void txtCustomerFullName_OnTextChanged(object sender, EventArgs e)
        {
            
        }

        protected void txtCustomerContactNo_OnTextChanged(object sender, EventArgs e)
        {
            
        }

        private void SelectText(TextBox txt)
        {
            // Is there a ScriptManager on the page?
            if (ScriptManager.GetCurrent(txt.Page) != null && ScriptManager.GetCurrent(txt.Page).IsInAsyncPostBack)
                // Set ctrlToSelect
                ScriptManager.RegisterStartupScript(txt.Page,
                                           txt.Page.GetType(),
                                           "SetFocusInUpdatePanel-" + txt.ClientID,
                                           String.Format("ctrlToSelect='{0}';", txt.ClientID),
                                           true);
            else
                txt.Page.ClientScript.RegisterStartupScript(txt.Page.GetType(),
                                                 "Select-" + txt.ClientID,
                                                 String.Format("document.getElementById('{0}').select();", txt.ClientID),
                                                 true);
        }
        
        protected void btnSell_OnClick(object sender, EventArgs e)
        {
                objSale = new Sale();
                objSaleBiz = new SaleBiz();
                objSale.CustomerUsername = txtCustomerUsername.Text.Trim();
                objSale.TotalAmount = txtToBePaid.Text == string.Empty ? 0 : decimal.Parse(txtToBePaid.Text);
                objSale.DiscountAmount = txtDiscount.Text.Trim()==string.Empty?0:decimal.Parse(txtDiscount.Text.Trim());
                objSale.PaidAmount = decimal.Parse(txtAmountPaid.Text);
                objSale.PaymentMethod = Convert.ToByte(ddlPaymentMethod.SelectedValue);
                objSale.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());
                objSale.Remarks = txtRemarks.Text.Trim();
                for (int i = 0; i < GvSellProduct.Rows.Count; i++)
                {

                    objSale.ProductId = short.Parse(GvSellProduct.Rows[i].Cells[0].Text);
                    objSale.SellQuantity = decimal.Parse(GvSellProduct.Rows[i].Cells[2].Text);
                    objSale.SellPrice = decimal.Parse(GvSellProduct.Rows[i].Cells[5].Text);
                    objSaleBiz.SellProduct(objSale);
                    objSale.PaymentMethod = 0;
                }

                Session["SellProduct"] = null;

            Master.LblupdtStatus.Visible = true;
            Master.LblupdtStatus.Text = "Updated Successfully.";
            Master.LblupdtStatus.Attributes.Add("style", "color:red; position:absolute; z-index:99; width:100%; text-align:center; top:350px; padding: 20px;background-color: rgba(146,205,0, 0.8); color: white");
            ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "UpdateStatusFadeOut('" + Master.LblupdtStatus.ClientID + "',2000)", true);
            //System.Threading.Thread.Sleep(2000);
            Response.Redirect("~/UI/SaleUI/CreateSale.aspx");
            //Response.Redirect(Request.RawUrl);
            

        }

        protected void GvSellProduct_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = Session["SellProduct"] as DataTable;
            dt.Rows[index].Delete();
            Session["SellProduct"] = dt;
            GridviewBind();
            this.txtDiscount_OnTextChanged(txtDiscount,EventArgs.Empty);
        }
    }
}