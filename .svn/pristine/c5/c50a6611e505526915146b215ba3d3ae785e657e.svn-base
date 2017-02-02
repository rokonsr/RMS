using System;
using System.Data;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;


//Created By Ataur

namespace RMS.UI.Admin
{
    public partial class UpdateRole : BasePage
    {
        private Role objRole;
        private RoleBiz objRoleBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindRoleInfoGrid();
        }

        private void BindRoleInfoGrid()
        {
            objRoleBiz = new RoleBiz();
            DataTable dtRoleList = new DataTable();
            dtRoleList = objRoleBiz.GetUserRoleInfo(objRole);
            gvDisplayRoleInfo.DataSource = dtRoleList;
            gvDisplayRoleInfo.DataBind();
            gvDisplayRoleInfo.ShowHeaderWhenEmpty = true;
            gvDisplayRoleInfo.EmptyDataText = "There is no matching records found!";

            gvDisplayRoleInfo.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayRoleInfo.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;

        }

        protected void gvDisplayRoleInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplayRoleInfo.PageIndex = e.NewPageIndex;
            BindRoleInfoGrid();
        }

        protected void gvDisplayRoleInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUpdateRole.Visible = true;

            GridViewRow row = gvDisplayRoleInfo.SelectedRow;

            txtRoleName.Text = gvDisplayRoleInfo.SelectedRow.Cells[0].Text;
            ddlUserRoleList.SelectedValue = gvDisplayRoleInfo.DataKeys[row.RowIndex].Values[1].ToString();

            this.ModalPopupExtender1.Show();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (UpdateUserRole())
            {
                BindRoleInfoGrid();
            }
        }

        private bool UpdateUserRole()
        {
            objRole = new Role();
            objRoleBiz = new RoleBiz();

            GridViewRow row = gvDisplayRoleInfo.SelectedRow;

            objRole.RoleId = Convert.ToInt16(gvDisplayRoleInfo.DataKeys[row.RowIndex].Values[0].ToString());
            objRole.RoleName = txtRoleName.Text.Trim();
            objRole.IsActive = Convert.ToBoolean(ddlUserRoleList.SelectedValue);
            objRole.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            objRoleBiz.UpdateRole(objRole);

            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void gvDisplayRoleInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "Inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}