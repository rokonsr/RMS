using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using Region = RMS.Model.Region;

namespace RMS.UI.Item
{
    public partial class UpdateRegion : System.Web.UI.Page
    {
        private Region objRegion;
        private RegionBiz objRegionBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            GvBindRegion();
        }

        private void GvBindRegion()
        {
            objRegion = new Region();
            objRegionBiz = new RegionBiz();
            DataTable dtRegion = new DataTable();
            dtRegion = objRegionBiz.GetRegionForGv(txtRegionName.Text.Trim());
            gvRegion.DataSource = dtRegion;
            gvRegion.DataBind();
            gvRegion.ShowHeaderWhenEmpty = true;
            gvRegion.EmptyDataText = "No data found!";

            gvRegion.AlternatingRowStyle.BackColor = Color.AliceBlue;
            gvRegion.SelectedRowStyle.BackColor = Color.DarkKhaki;
        }

        protected void gvRegion_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvRegion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateRegion.Visible = true;
            ddlUpdateRegionStatus.Items.Clear();
            ddlUpdateRegionStatus.Items.Insert(0, new ListItem("Active", "1"));
            ddlUpdateRegionStatus.Items.Insert(1, new ListItem("Inactive", "0"));
            string status = gvRegion.SelectedRow.Cells[3].Text == "Active" ? "1" : "0";
            txtUpdateRegionName.Text = gvRegion.SelectedRow.Cells[1].Text;
            txtUpdateRegionDescription.Text = gvRegion.SelectedRow.Cells[2].Text.Replace("&nbsp;", string.Empty);
            ddlUpdateRegionStatus.ClearSelection();
            ddlUpdateRegionStatus.Items.FindByValue(status).Selected = true;
            ModalUpdateRegion.Show();
            lblUpdateStatus.Visible = false;

        }

        protected void btnUpdateRegion_OnClick(object sender, EventArgs e)
        {
            if (EditRegion())
            {
                GvBindRegion();
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

        private bool EditRegion()
        {

            objRegion = new Region();
            objRegionBiz = new RegionBiz();
            GridViewRow row = gvRegion.SelectedRow;
            objRegion.RegionId = Convert.ToByte(gvRegion.DataKeys[row.RowIndex].Values[0].ToString());
            objRegion.RegionName = txtUpdateRegionName.Text.Trim();
            objRegion.RegionDescription = txtUpdateRegionDescription.Text.Trim();
            objRegion.IsActive = ddlUpdateRegionStatus.SelectedValue == "1";
            objRegion.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            return objRegionBiz.UpdateRegion(objRegion);
        }
    }
}