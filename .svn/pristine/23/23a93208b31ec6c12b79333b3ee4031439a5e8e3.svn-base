using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class CreateSupplier : BasePage
    {
        //--Created By Ataur-->

        private Supplier objSupplier;
        private SupplierBiz objSupplierBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (CreateSupplierInfo())
            {
                ClearInputs(Page.Controls);
            }

        }

        private bool CreateSupplierInfo()
        {
            objSupplier = new Supplier();
            objSupplierBiz = new SupplierBiz();
            objSupplier.SupplierName = txtSupplierName.Text.Trim();
            objSupplier.SupplierContactPerson = txtSupplierContactPerson.Text.Trim();
            objSupplier.SupplierDescription = txtSupplierDescription.Text.Trim();
            objSupplier.SupplierAddress = txtSupplierAddress.Text.Trim();
            objSupplier.SupplierContactNo = txtSupplierContactNo.Text.Trim();
            objSupplier.SupplierContactNo = txtSupplierContactNo.Text.Trim();
            objSupplier.SupplierContactNo = txtSupplierContactNo.Text.Trim();
            objSupplier.SupplierEmail = txtSupplierEmail.Text.Trim();
            objSupplier.SupplierReference = txtSupplierReference.Text.Trim();
            objSupplier.SupplierReferenceContactNo = txtSupplierReferenceContactNo.Text.Trim();

            objSupplier.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());
            MessageBox(objSupplierBiz.CreateSupplierInfo(objSupplier));

            return true;
        }
    }
}