using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.PurchaseUI
{
    public partial class PurchaseLedgerDetails : BasePage
    {
        private Supplier objSupplier;
        private List<Supplier> objSupplierList;
        private SupplierBiz objSupplierBiz;
        private PurchaseLedger objPurchaseLedger;
        private PurchaseLedgerBiz objPurchaseLedgerBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownForSupplier();

                foreach (int value in Enum.GetValues(typeof(ReceivingType)))
                {
                    ddlReceivingType.Items.Add(new ListItem(Enum.GetName(typeof(ReceivingType), value), value.ToString()));
                }

                ddlReceivingType.Items.Insert(0, new ListItem("--Select Type--", "0"));
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

        protected void txtInvoiceNumberList_OnTextChanged(object sender, EventArgs e)
        {
            objPurchaseLedger = new PurchaseLedger();
            objPurchaseLedgerBiz = new PurchaseLedgerBiz();

            objPurchaseLedger = objPurchaseLedgerBiz.GetSingleInvoiceDetail(txtInvoiceNumber.Text.Trim());

            ddlSupplier.SelectedValue = objPurchaseLedger.SupplierId.ToString();
            txtInvoiceDue.Text = objPurchaseLedger.DueAmount.ToString();

            objSupplier = new Supplier();
            objSupplierBiz = new SupplierBiz();
            objSupplier = objSupplierBiz.GetSupplierDue(ddlSupplier.SelectedValue);
            txtTotalBalance.Text = objSupplier.SupplierDue.ToString();

            ddlReceivingType.Attributes.Add("onfocus", "this.select()");
            ddlReceivingType.Focus();
        }

        protected void btnCreateLedger_OnClick(object sender, EventArgs e)
        {
            objPurchaseLedger = new PurchaseLedger();
            objPurchaseLedgerBiz = new PurchaseLedgerBiz();

            objPurchaseLedger.SupplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
            objPurchaseLedger.InvoiceNumber = txtInvoiceNumber.Text;
            objPurchaseLedger.TransactionType = Convert.ToByte(ddlReceivingType.SelectedValue);
            objPurchaseLedger.ReceivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
            objPurchaseLedger.CurrentDue = txtCurrentDue.Text != "" ? Convert.ToDecimal(txtCurrentDue.Text) : 0;
            objPurchaseLedger.TotalBalance = txtCurrentBalance.Text != "" ? Convert.ToDecimal(txtCurrentBalance.Text) : 0;
            objPurchaseLedger.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());

            MessageBox(objPurchaseLedgerBiz.CreatePurchaseLedger(objPurchaseLedger));

            ClearInputs(Controls);
        }
    }
}