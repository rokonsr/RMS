using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.Report.PurchaseReport
{
    public partial class SupplierwisePurchaseDetail1 : BasePage
    {
        private List<Supplier> objSupplierList;
        private SupplierBiz objSupplierBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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

        protected void ddlSupplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDocument rdDocument = new ReportDocument();
            rdDocument.Load(Server.MapPath("SupplierwisePurchaseDetail.rpt"));
            rdDocument.SetParameterValue("@SupplierId", ddlSupplier.SelectedValue);
            Session["CrystalReport"] = rdDocument;
            
            CrystalReportViewer();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            ReportDocument rdDocument = new ReportDocument();
            rdDocument.Load(Server.MapPath("InvoicewisePurchaseDetail.rpt"));
            rdDocument.SetParameterValue("@InvoiceNumber", txtInvoiceNumber.Text.Trim());
            Session["CrystalReport"] = rdDocument;
            
            CrystalReportViewer();
        }

        protected void rdPurchaseDetailList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdPurchaseDetailList.SelectedValue == "1")
            {
                PopulateDropDownForSupplier();
                pnlDisplaySupplier.Visible = true;
                txtInvoiceNumber.Text = string.Empty;
                pnlDisplayInvoice.Visible = false;
            }
            else if (rdPurchaseDetailList.SelectedValue == "2")
            {
                pnlDisplaySupplier.Controls.Clear();
                pnlDisplaySupplier.Visible = false;
                pnlDisplayInvoice.Visible = true;
            }
        }
    }
}