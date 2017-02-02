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
    public partial class UpdateMeasurement : System.Web.UI.Page
    {
        private Measurement objMeasurement;
        private MeasurementBiz objMeasurementBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

            GvBindMeasurement();
        }

        private void GvBindMeasurement()
        {
            objMeasurement=new Measurement();
            objMeasurementBiz=new MeasurementBiz();
            DataTable dtMeasurement=new DataTable();
            dtMeasurement = objMeasurementBiz.GetMeasurementForGv(txtMeasurementName.Text.Trim());
            gvMeasurement.DataSource = dtMeasurement;
            gvMeasurement.DataBind();
            gvMeasurement.ShowHeaderWhenEmpty = true;
            gvMeasurement.EmptyDataText = "No data found!";

            gvMeasurement.AlternatingRowStyle.BackColor = Color.AliceBlue;
            gvMeasurement.SelectedRowStyle.BackColor = Color.DarkKhaki;
        }

        protected void gvMeasurement_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvMeasurement_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateMeasurement.Visible = true;
            ddlUpdateMeasurementStatus.Items.Clear();
            ddlUpdateMeasurementStatus.Items.Insert(0, new ListItem("Active", "1"));
            ddlUpdateMeasurementStatus.Items.Insert(1, new ListItem("Inactive", "0"));
            string status = gvMeasurement.SelectedRow.Cells[3].Text == "Active" ? "1" : "0";
            txtUpdateMeasurementName.Text = gvMeasurement.SelectedRow.Cells[1].Text.Replace("&nbsp;",string.Empty);
            txtUpdateMeasurementDescription.Text = gvMeasurement.SelectedRow.Cells[2].Text.Replace("&nbsp;",string.Empty);
            ddlUpdateMeasurementStatus.ClearSelection();
            ddlUpdateMeasurementStatus.Items.FindByValue(status).Selected = true;
            ModalUpdateMeasurement.Show();
            lblUpdateStatus.Visible = false;
        }

        protected void btnUpdateMeasurement_OnClick(object sender, EventArgs e)
        {
            if (EditMeasurement())
            {
                GvBindMeasurement();
                lblUpdateStatus.Visible = true;
                lblUpdateStatus.ForeColor = Color.Green;
                lblUpdateStatus.Text = "Updated Successfully.";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblUpdateStatus.ClientID + "').style.display='none'\",2000)</script>");
            }
            else
            {
                lblUpdateStatus.Visible = true;
                lblUpdateStatus.ForeColor = Color.Red;
                lblUpdateStatus.Text = "Updated Fail.";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblUpdateStatus.ClientID + "').style.display='none'\",2000)</script>");

            }
        }

        private bool EditMeasurement()
        {
            objMeasurement=new Measurement();
            objMeasurementBiz=new MeasurementBiz();
            GridViewRow row = gvMeasurement.SelectedRow;
            objMeasurement.MeasurementId = Convert.ToByte(gvMeasurement.DataKeys[row.RowIndex].Values[0].ToString());
            objMeasurement.MeasurementName = txtUpdateMeasurementName.Text.Trim();
            objMeasurement.MeasurementDescription = txtUpdateMeasurementDescription.Text.Trim();
            objMeasurement.IsActive = ddlUpdateMeasurementStatus.SelectedValue == "1";
            objMeasurement.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            return objMeasurementBiz.UpdateMesurement(objMeasurement);
            
        }
    }
}