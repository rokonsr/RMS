using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class UpdateBrand : System.Web.UI.Page
    {
        private Brand objBrand;
        private BrandBiz objBrandBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            GvBindBrand();
        }

        private void GvBindBrand()
        {
            objBrand = new Brand();
            objBrandBiz = new BrandBiz();  
            DataTable dtMeasurement = new DataTable();
            dtMeasurement = objBrandBiz.GetBrandForGv(txtBrandName.Text.Trim());
            gvBrand.DataSource = dtMeasurement;
            gvBrand.DataBind();
            gvBrand.ShowHeaderWhenEmpty = true;
            gvBrand.EmptyDataText = "No data found!";

            gvBrand.AlternatingRowStyle.BackColor = Color.AliceBlue;
            gvBrand.SelectedRowStyle.BackColor = Color.DarkKhaki;
        }

        protected void gvBrand_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[3];
                statusCell.Text = statusCell.Text == "True" ? "Active" : "Inactive";

                if (e.Row.Cells[3].Text == "Inactive")
                {
                    e.Row.BackColor = Color.Red;
                }
            }
        }

        protected void gvBrand_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateBrand.Visible = true;
            ddlUpdateBrandStatus.Items.Clear();
            ddlUpdateBrandStatus.Items.Insert(0, new ListItem("Active", "1"));
            ddlUpdateBrandStatus.Items.Insert(1, new ListItem("Inactive", "0"));
            string status = gvBrand.SelectedRow.Cells[3].Text == "Active" ? "1" : "0";
            txtUpdateBrandName.Text = gvBrand.SelectedRow.Cells[1].Text;
            txtUpdateBrandDescription.Text = gvBrand.SelectedRow.Cells[2].Text.Replace("&nbsp;", string.Empty);
            ddlUpdateBrandStatus.ClearSelection();
            ddlUpdateBrandStatus.Items.FindByValue(status).Selected = true;
            ModalUpdateBrand.Show();
            lblUpdateStatus.Visible = false;
        }

        protected void btnUpdateBrand_OnClick(object sender, EventArgs e)
        {
            
            if (EditBrand())
            {
                GvBindBrand();
                lblUpdateStatus.Visible = true;
                lblUpdateStatus.ForeColor = Color.Green;
                lblUpdateStatus.Text = "Updated Successfully.";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblUpdateStatus.ClientID + "').style.display='none'\",2000)</script>");
            }
            else
            {
                lblUpdateStatus.Visible = true;
                lblUpdateStatus.ForeColor=Color.Red;
                lblUpdateStatus.Text = "Updated Fail.";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblUpdateStatus.ClientID + "').style.display='none'\",2000)</script>");

            }

        }

        private bool EditBrand()
        {
            objBrand = new Brand();
            objBrandBiz = new BrandBiz();
            GridViewRow row = gvBrand.SelectedRow;
            objBrand.BrandId = Convert.ToByte(gvBrand.DataKeys[row.RowIndex].Values[0].ToString());
            objBrand.BrandName = txtUpdateBrandName.Text.Trim();
            objBrand.BrandDescription = txtUpdateBrandDescription.Text.Trim();
            objBrand.IsActive = ddlUpdateBrandStatus.SelectedValue == "1";
            objBrand.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            return objBrandBiz.UpdateBrand(objBrand);
            
        }
    }
}