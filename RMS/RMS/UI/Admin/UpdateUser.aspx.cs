using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.Model;

namespace RMS.UI.Admin
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        UserInfo objUserInfo=new UserInfo();
        UserInfoBiz objUserInfoBiz=new UserInfoBiz();
        private Designation objDesignation;
        private DesignationBiz objDesignationBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            GvBindUseInfo();
        }
        private void GvBindUseInfo()
        {
            DataTable dtUserInfo = new DataTable();
            dtUserInfo = objUserInfoBiz.GetUserForUpdateUser(txtCreateUserName.Text.Trim());
            gvUserInfo.DataSource = dtUserInfo;
            gvUserInfo.DataBind();
            gvUserInfo.ShowHeaderWhenEmpty = true;
            gvUserInfo.EmptyDataText = "No data found!";

            gvUserInfo.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvUserInfo.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;
        }
        protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text == "Inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void PopulateDropDownForDesignation()
        {
            objDesignation = new Designation();
            objDesignationBiz = new DesignationBiz();

            List<Designation> objDesignationList = new List<Designation>();
            objDesignationList = objDesignationBiz.GetDesignationList();
            ddlUserInfoDesignation.DataSource = objDesignationList;
            ddlUserInfoDesignation.DataTextField = "DesignationName";
            ddlUserInfoDesignation.DataValueField = "DesignationId";
            ddlUserInfoDesignation.DataBind();

            //ddlUserInfoDesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));
            //ddlDesignation.Items[0].Selected = true;
            //ddlDesignation.Items[0].Attributes["Disabled"] = "Disabled";
        }

        protected void gvUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlUserInfoUpdate.Visible = true;
            ModalPopupExtender1.Show();
            txtUserNameEdit.Text = gvUserInfo.SelectedRow.Cells[1].Text;
            PopulateDropDownForDesignation();
            ddlUserInfoDesignation.ClearSelection();
            ddlUserInfoDesignation.Items.FindByText(gvUserInfo.SelectedRow.Cells[2].Text).Selected = true;
            txtUserFullName.Text= gvUserInfo.SelectedRow.Cells[3].Text;
            txtUserEmail.Text = gvUserInfo.SelectedRow.Cells[4].Text;
            txtUserPhoneNo.Text = gvUserInfo.SelectedRow.Cells[5].Text;
            txtUserAddress.Text = gvUserInfo.SelectedRow.Cells[6].Text;
            ddlUserInfoStatus.ClearSelection();
            ddlUserInfoStatus.Items.FindByText(gvUserInfo.SelectedRow.Cells[7].Text).Selected = true;
        }

        protected void btnUserInfoUpdate_Click(object sender, EventArgs e)
        {
            if (EditUserInfo())
            {
                GvBindUseInfo();
            }
        }
        private bool EditUserInfo()
        {
            objUserInfo=new UserInfo();
            objUserInfoBiz = new UserInfoBiz();
            GridViewRow row = gvUserInfo.SelectedRow;

            objUserInfo.UserId = Convert.ToByte(gvUserInfo.DataKeys[row.RowIndex].Values[0].ToString());

            objUserInfo.Username = txtUserNameEdit.Text.Trim();
            objUserInfo.DesignationId = Convert.ToByte(ddlUserInfoDesignation.SelectedValue);
            objUserInfo.UserFullName = txtUserFullName.Text;
            objUserInfo.UserEmail = txtUserEmail.Text;
            objUserInfo.UserPhoneNo = txtUserPhoneNo.Text;
            objUserInfo.UserAddress = txtUserAddress.Text;
            objUserInfo.IsActive = Convert.ToBoolean(ddlUserInfoStatus.SelectedValue);
            objUserInfo.UpdatedBy = Convert.ToInt16(Session["UserId"]);

           objUserInfoBiz.UpdateUserInfo(objUserInfo);

            return true;
        }
    }
}