using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.Model;
using RMS.DAL;
namespace RMS.UI.Admin
{
    public partial class UpdateDesignation : System.Web.UI.Page
    {
        private Designation objDesignation;
        private DesignationBiz objDesignationBiz;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GvBindDesignation();

        }


        protected void btnUpdateDesignation_Click(object sender, EventArgs e)
        {
            if (EditDesignation())
            {

                GvBindDesignation();
                Master.LblupdtStatus.Visible = true;
                Master.LblupdtStatus.Text = "Updated Successfully.";
                Master.LblupdtStatus.Attributes.Add("style", "color:red; position:absolute; z-index:99; width:100%; text-align:center; top:350px; padding: 20px;background-color: rgba(146,205,0, 0.8); color: white");
                ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "UpdateStatusFadeOut('" + Master.LblupdtStatus.ClientID + "',2000)", true);

            }
            else
            {
                Master.LblupdtStatus.Visible = true;
                Master.LblupdtStatus.ForeColor = Color.Red;
                Master.LblupdtStatus.Text = "Updated Fail.";
                Master.LblupdtStatus.Style[HtmlTextWriterStyle.Position] = "Absolute";
                Master.LblupdtStatus.Style[HtmlTextWriterStyle.Top] = "10px";
                ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "UpdateStatusFadeOut('" + Master.LblupdtStatus.ClientID + "',5000)", true);

            }
        }

        private void GvBindDesignation()
        {
            objDesignation = new Designation();
            objDesignationBiz = new DesignationBiz();
            DataTable dtDesignation = new DataTable();
            dtDesignation = objDesignationBiz.GetDesignation(txtDesignationSearch.Text.Trim());
            gvDesignation.DataSource = dtDesignation;
            gvDesignation.DataBind();
            gvDesignation.ShowHeaderWhenEmpty = true;
            gvDesignation.EmptyDataText = "No data found!";
            gvDesignation.AlternatingRowStyle.BackColor = Color.AliceBlue;
            gvDesignation.SelectedRowStyle.BackColor = Color.DarkKhaki;
        }

        private bool EditDesignation()
        {
            objDesignation = new Designation();
            objDesignationBiz = new DesignationBiz();
            GridViewRow row = gvDesignation.SelectedRow;
            objDesignation.DesignationId = Convert.ToByte(gvDesignation.DataKeys[row.RowIndex].Values[0].ToString());
            objDesignation.DesignationName = txtDesignationNameEdit.Text.Trim();
            objDesignation.IsActive = ddlUserStatus.SelectedValue == "1";
            objDesignation.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            return objDesignationBiz.UpdateDesignation(objDesignation);

            
        }

        protected void gvDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateDes.Visible = true;
            ddlUserStatus.Items.Clear();
            ddlUserStatus.Items.Insert(0, new ListItem("Active", "1"));
            ddlUserStatus.Items.Insert(1, new ListItem("Inactive", "0"));
            string a = gvDesignation.SelectedRow.Cells[2].Text == "Active" ? "1" : "0";
            txtDesignationNameEdit.Text = gvDesignation.SelectedRow.Cells[1].Text;
            ddlUserStatus.ClearSelection();
            ddlUserStatus.Items.FindByValue(a).Selected = true;
            ModalPopupExtender1.Show();
            Master.LblupdtStatus.Visible = false;

        }

        protected void gvDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[2];
                statusCell.Text = statusCell.Text == "True" ? "Active" : "Inactive";

                if (e.Row.Cells[2].Text == "Inactive")
                {
                    e.Row.BackColor = Color.Red;
                }
            }
        }
        
    }
}