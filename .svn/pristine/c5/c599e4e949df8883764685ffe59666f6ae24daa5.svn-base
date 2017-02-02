using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    //--Created By Ataur-->
    public partial class UpdateFoodSchedule : BasePage
    {
        private FoodSchedule objFoodSchedule;
        private FoodScheduleBiz objFoodScheduleBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewBindFoodScheduleInfo();
        }

        private void GridViewBindFoodScheduleInfo()
        {
            objFoodSchedule = new FoodSchedule();
            objFoodScheduleBiz = new FoodScheduleBiz();
            DataTable dtFoodSchedule = new DataTable();
            dtFoodSchedule = objFoodScheduleBiz.GetFoodScheduleListForGv(txtFoodScheduleName.Text.Trim());
            gvDisplayFoodSchedule.DataSource = dtFoodSchedule;
            gvDisplayFoodSchedule.DataBind();
            gvDisplayFoodSchedule.ShowHeaderWhenEmpty = true;
            gvDisplayFoodSchedule.EmptyDataText = "No Data Found";
            gvDisplayFoodSchedule.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayFoodSchedule.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;
        }

        protected void gvDisplayFoodSchedule_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvDisplayFoodSchedule_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateFoodSchedule.Visible = true;
            ddlUpdateFoodScheduleStatus.Items.Clear();
            ddlUpdateFoodScheduleStatus.Items.Insert(0, new ListItem("Active", "1"));
            ddlUpdateFoodScheduleStatus.Items.Insert(1, new ListItem("Inactive", "0"));
            string status = gvDisplayFoodSchedule.SelectedRow.Cells[3].Text == "Active" ? "1" : "0";
            txtUpdateFoodScheduleName.Text = gvDisplayFoodSchedule.SelectedRow.Cells[1].Text;
            txtUpdateFoodScheduleDescription.Text = gvDisplayFoodSchedule.SelectedRow.Cells[2].Text.Replace("&nbsp;",
                String.Empty);
            ddlUpdateFoodScheduleStatus.ClearSelection();
            ddlUpdateFoodScheduleStatus.Items.FindByValue(status).Selected = true;
            ModalUpdateFoodSchedule.Show();
            lblUpdateStatus.Visible = false;
        }

        protected void btnUpdateFoodSchedule_OnClick(object sender, EventArgs e)
        {
            if (EditFoodScheduleInfo())
            {
                GridViewBindFoodScheduleInfo();
            }
        }

        private bool EditFoodScheduleInfo()
        {
            objFoodSchedule = new FoodSchedule();
            objFoodScheduleBiz = new FoodScheduleBiz();
            GridViewRow row = gvDisplayFoodSchedule.SelectedRow;
            objFoodSchedule.FoodScheduleId = Convert.ToByte(gvDisplayFoodSchedule.DataKeys[row.RowIndex].Values[0].ToString());
            objFoodSchedule.FoodScheduleName = txtUpdateFoodScheduleName.Text.Trim();
            objFoodSchedule.ScheduleDescription = txtUpdateFoodScheduleDescription.Text.Trim();         
            objFoodSchedule.IsActive = ddlUpdateFoodScheduleStatus.SelectedValue == "1";
            objFoodSchedule.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            objFoodScheduleBiz.UpdateFoodScheduleInfo(objFoodSchedule);
            return true;
        }
    }
}