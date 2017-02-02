using System;
using System.Data;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.Model;

namespace RMS.UI.Item
{
    //Created By Ataur
    public partial class UpdateSupplier : System.Web.UI.Page
    {
        private Supplier objSupplier;
        private SupplierBiz objSupplierBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewBindSupplierInfo();
        }

        private void GridViewBindSupplierInfo()
        {
            objSupplierBiz = new SupplierBiz();
            DataTable dtSupplier = new DataTable();
            dtSupplier = objSupplierBiz.GetSupplierListForGv(txtSupplierName.Text.Trim());
            gvDisplaySupplier.DataSource = dtSupplier;
            gvDisplaySupplier.DataBind();
            gvDisplaySupplier.ShowHeaderWhenEmpty = true;
            gvDisplaySupplier.EmptyDataText = "No Data Found";

            gvDisplaySupplier.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplaySupplier.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;
        }

        protected void btnUpdateSupplier_OnClick(object sender, EventArgs e)
        {
            if (EditSupplier())
            {
                GridViewBindSupplierInfo();
            }
        }

        protected void gvDisplaySupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplaySupplier.PageIndex = e.NewPageIndex;
            GridViewBindSupplierInfo();
        }

        protected void gvDisplaySupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateSupplier.Visible = true;
            ModalUpdateSupplier.Show();
            GridViewRow row = gvDisplaySupplier.SelectedRow;

            txtUpdateSupplierName.Text = gvDisplaySupplier.SelectedRow.Cells[1].Text;
            txtUpdateSupplierContactPerson.Text = gvDisplaySupplier.SelectedRow.Cells[2].Text;
            txtUpdateSupplierDescription.Text = gvDisplaySupplier.SelectedRow.Cells[3].Text.Replace("&nbsp;",
                String.Empty); 
            txtUpdateSupplierAddress.Text = gvDisplaySupplier.SelectedRow.Cells[4].Text;
            txtUpdateSupplierContactNo.Text = gvDisplaySupplier.SelectedRow.Cells[5].Text;
            txtUpdateSupplierEmail.Text = gvDisplaySupplier.SelectedRow.Cells[6].Text.Replace("&nbsp;",
                String.Empty); 
            txtUpdateSupplierReference.Text = gvDisplaySupplier.SelectedRow.Cells[7].Text;
            txtUpdateSupplierReferenceContactNo.Text = gvDisplaySupplier.SelectedRow.Cells[8].Text;
            ddlUpdateSupplierStatus.Text = gvDisplaySupplier.DataKeys[row.RowIndex].Values[1].ToString();
        }

        private bool EditSupplier()
        {
            objSupplier=new Supplier();
            objSupplierBiz=new SupplierBiz();
            GridViewRow row = gvDisplaySupplier.SelectedRow;
            objSupplier.SupplierId = Convert.ToInt16(gvDisplaySupplier.DataKeys[row.RowIndex].Values[0].ToString());

            objSupplier.SupplierName = txtUpdateSupplierName.Text.Trim();
            objSupplier.SupplierContactPerson = txtUpdateSupplierContactPerson.Text.Trim();
            objSupplier.SupplierDescription = txtUpdateSupplierDescription.Text.Trim();
            objSupplier.SupplierAddress = txtUpdateSupplierAddress.Text.Trim();
            objSupplier.SupplierContactNo = txtUpdateSupplierContactNo.Text.Trim();
            objSupplier.SupplierEmail = txtUpdateSupplierEmail.Text.Trim();
            objSupplier.SupplierReference = txtUpdateSupplierReference.Text.Trim();
            objSupplier.SupplierReferenceContactNo = txtUpdateSupplierReferenceContactNo.Text.Trim();
            objSupplier.IsActive = Convert.ToBoolean(ddlUpdateSupplierStatus.SelectedValue);
            objSupplier.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            objSupplierBiz.UpdateSupplierInfo(objSupplier);

            return true;
        }

        protected void gvDisplaySupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[9].Text == "Inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}