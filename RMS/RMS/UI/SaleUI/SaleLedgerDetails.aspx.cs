using System;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.SaleUI
{
    //--ata-->
    public partial class SaleLedgerDetails : BasePage
    {
        private SaleLedger objSaleLedger;
        private SaleLedgerBiz objSaleLedgerBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (int value in Enum.GetValues(typeof(ReceivingType)))
                {
                    ddlReceivingType.Items.Add(new ListItem(Enum.GetName(typeof(ReceivingType), value), value.ToString()));
                }

                ddlReceivingType.Items.Insert(0, new ListItem("--Select Type--", "0"));
            }
        }

        protected void ddlReceivingType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            byte selectedValue = Convert.ToByte(ddlReceivingType.SelectedValue);
        }

        protected void txtSaleLedgerInvoiceNumber_OnTextChanged(object sender, EventArgs e)
        {
            objSaleLedger = new SaleLedger();
            objSaleLedgerBiz = new SaleLedgerBiz();
         
            objSaleLedger=objSaleLedgerBiz.GetSaleLedgerInfoForSL(txtSaleLedgerInvoiceNumber.Text.Trim());

            txtCustomerUsername.Text = objSaleLedger.CustomerUsername;
            txtCurrentDue.Text = objSaleLedger.CurrentDue.ToString();
            Session["CustomerId"] = objSaleLedger.CustomerId.ToString();

        }

        protected void txtCustomerUsername_OnTextChanged(object sender, EventArgs e)
        {
            objSaleLedger = new SaleLedger();
            objSaleLedgerBiz = new SaleLedgerBiz();
           
            objSaleLedger = objSaleLedgerBiz.GetSaleLedgerInfoByCustomerUsername(txtCustomerUsername.Text.Trim());

            txtSaleLedgerInvoiceNumber.Text = objSaleLedger.InvoiceNumber;
            txtCurrentDue.Text = objSaleLedger.CurrentDue.ToString();
            Session["CustomerId"] = objSaleLedger.CustomerId.ToString();
        }

        protected void btnSubmitSaleLedgerDetails_Click(object sender, EventArgs e)
        {
            objSaleLedger=new SaleLedger();
            objSaleLedgerBiz=new SaleLedgerBiz();

            objSaleLedger.CustomerId = Convert.ToInt32(Session["CustomerId"]);
            objSaleLedger.InvoiceNumber = txtSaleLedgerInvoiceNumber.Text;
            objSaleLedger.TransactionType = Convert.ToByte(ddlReceivingType.SelectedValue);
            objSaleLedger.ReceivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
            objSaleLedger.CurrentDue = txtCurrentDue.Text != "" ? Convert.ToDecimal(txtCurrentDue.Text) : 0;
            objSaleLedger.TotalBalance = txtTotalBalance.Text != "" ? Convert.ToDecimal(txtTotalBalance.Text) : 0;
            objSaleLedger.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());

            MessageBox(objSaleLedgerBiz.CreateSaleLedger(objSaleLedger));
            Session.Remove("CustomerId");
            ClearInputs(Controls);
        }
    }
}