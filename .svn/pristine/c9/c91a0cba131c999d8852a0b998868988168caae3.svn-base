using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;
using System.Web.UI;

namespace RMS.UI.Admin
{
    public partial class AssignRole : BasePage
    {
        private UserInfo objUserInfo;
        private UserInfoBiz objUserInfoBiz;
        private Role objRole;
        private RoleBiz objRoleBiz;
        private List<NavigationMenu> objNavigationMenuList;
        private NavigationMenuBiz objNavigationMenuBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tvMenuRoleManagement.Attributes.Add("onclick", "OnTreeClick(event)");
                PopulateDropDownForRole();
            }
            BindUserRoleGrid();
        }

        private void BindUserRoleGrid()
        {
            objUserInfoBiz = new UserInfoBiz();
            DataTable dtUserList = new DataTable();

            dtUserList = objUserInfoBiz.GetUserForAssignRole(txtUserName.Text.Trim());

            gvDisplayUserInfo.DataSource = dtUserList;
            gvDisplayUserInfo.DataBind();
            gvDisplayUserInfo.ShowHeaderWhenEmpty = true;
            gvDisplayUserInfo.EmptyDataText = "There is no matching records found!";

            txtUserName.Focus();
            txtUserName.Attributes.Add("onfocus", "this.select()");

            gvDisplayUserInfo.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayUserInfo.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;
        }

        private void PopulateDropDownForRole()
        {
            objRole = new Role();
            objRoleBiz = new RoleBiz();

            List<Role> objRoleList = new List<Role>();

            objRoleList = objRoleBiz.GetRoleListForDDL();
            ddlUserRoleList.DataSource = objRoleList;
            ddlUserRoleList.DataTextField = "RoleName";
            ddlUserRoleList.DataValueField = "RoleId";
            ddlUserRoleList.DataBind();

            ddlUserRoleList.Items.Insert(0, new ListItem("--Select Role--", "0"));
        }

        protected void gvDisplayUserInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplayUserInfo.PageIndex = e.NewPageIndex;
            BindUserRoleGrid();
        }

        protected void gvDisplayUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvMenuRoleManagement.Nodes.Clear();
            GridViewRow row = gvDisplayUserInfo.SelectedRow;
            int loginId = string.IsNullOrEmpty(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[0].ToString()) ? 0 : Convert.ToInt32(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[0]);
            int roleId = string.IsNullOrEmpty(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[1].ToString()) ? 0 : Convert.ToInt32(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[1]);

            LinkButton lb = (row.FindControl("lnkBtn") as LinkButton);
            string actionType = lb.Text;
            hfLoginId.Value = loginId.ToString();

            if (actionType == "Modify Role" || actionType == "Assign Role")
            {
                ModalPopupForAssignRoleAndMenu.Show();

                txtSelectedUserName.Text = gvDisplayUserInfo.SelectedRow.Cells[0].Text;
                ddlUserRoleList.SelectedValue = roleId.ToString();
                GetTreeViewItems(loginId, roleId);
                pnlAssignRole.Visible = true;
                tvMenuRoleManagement.Visible = true;
                btnAssignRole.Visible = false;
            }
            else
            {
                ModalActiveUserStatus.Show();
                pnlActiveUserStatus.Visible = true;

                txtUserNameForUpdateStatus.Text = gvDisplayUserInfo.SelectedRow.Cells[0].Text;
                ddlUserRoleListForUpdateStatus.ClearSelection();
                ddlUserRoleListForUpdateStatus.Items.FindByText(gvDisplayUserInfo.SelectedRow.Cells[3].Text).Selected = true;
            }
        }

        private void GetTreeViewItems(int loginId, int roleId)
        {
            objNavigationMenuList =  new List<NavigationMenu>();
            objNavigationMenuBiz = new NavigationMenuBiz();
            objNavigationMenuList = objNavigationMenuBiz.GetMenuTvList(loginId, roleId);
            
            DataTable table = new DataTable();

            table.Columns.Add("MenuId", typeof(int));
            table.Columns.Add("MenuName", typeof(string));
            table.Columns.Add("ParentId", typeof(int));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (NavigationMenu objMenu in objNavigationMenuList)
            {
                table.Rows.Add(objMenu.MenuId, objMenu.MenuName, objMenu.ParentId, objMenu.IsActive);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(table);

            ds.Relations.Add("ChildRows", ds.Tables[0].Columns["MenuId"],
                ds.Tables[0].Columns["ParentId"]);

            foreach (DataRow GetParentRows in ds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(GetParentRows["ParentId"].ToString()))
                {
                    TreeNode parentTreeNode = new TreeNode();
                    parentTreeNode.Text = GetParentRows["MenuName"].ToString();
                    parentTreeNode.Value = GetParentRows["MenuId"].ToString();

                    if (GetParentRows["IsActive"].Equals(true))
                    {
                        parentTreeNode.Checked = true;
                        parentTreeNode.Expanded = true;
                    }

                    GetChildRows(GetParentRows, parentTreeNode);

                    tvMenuRoleManagement.Nodes.Add(parentTreeNode);
                }
            }
        }

        private void GetChildRows(DataRow dataRow, TreeNode treeNode)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");
            foreach (DataRow childRow in childRows)
            {
                TreeNode childTreeNode = new TreeNode();
                childTreeNode.Text = childRow["MenuName"].ToString();
                childTreeNode.Value = childRow["MenuId"].ToString();

                if (childRow["IsActive"].Equals(true))
                {
                    childTreeNode.Checked = true;
                }

                treeNode.ChildNodes.Add(childTreeNode);
                if (childRow.GetChildRows("ChildRows").Length > 0)
                {
                    GetChildRows(childRow, childTreeNode);
                    childTreeNode.Expanded = true;
                }
            }
        }

        protected void gvDisplayUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lb = (e.Row.FindControl("lnkBtn") as LinkButton);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lb.Text = null;

                if (lb != null)
                {
                    if (e.Row.Cells[3].Text == EnumMode.UserStatus.Active.ToString() && e.Row.Cells[4].Text == EnumMode.HasRole.Yes.ToString())
                    {
                        lb.Text = EnumMode.BtnAction.ModifyRole.ToString().SelectMany((x, i) => i > 0 && char.IsUpper(x) ? new[] { ' ', x } : new[] { x }).Aggregate(new StringBuilder(), (y, j) => y.Append(j)).ToString();
                    }
                    if (e.Row.Cells[3].Text == EnumMode.UserStatus.Active.ToString() && e.Row.Cells[4].Text == EnumMode.HasRole.No.ToString())
                    {
                        lb.Text = EnumMode.BtnAction.AssignRole.ToString().SelectMany((x, i) => i > 0 && char.IsUpper(x) ? new[] { ' ', x } : new[] { x }).Aggregate(new StringBuilder(), (y, j) => y.Append(j)).ToString();
                    }
                    if (e.Row.Cells[3].Text == EnumMode.UserStatus.Inactive.ToString() &&
                        (e.Row.Cells[4].Text == EnumMode.HasRole.No.ToString() || e.Row.Cells[4].Text == EnumMode.HasRole.Yes.ToString()))
                    {
                        lb.Text = EnumMode.BtnAction.ActiveUser.ToString().SelectMany((x, i) => i > 0 && char.IsUpper(x) ? new[] { ' ', x } : new[] { x }).Aggregate(new StringBuilder(), (y, j) => y.Append(j)).ToString();
                    }

                    e.Row.Cells[6].Controls.Add((Control)lb);
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text == "Inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void ddlUserRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserRoleList.SelectedIndex > 0)
            {
                ModalPopupForAssignRoleAndMenu.Show();
                tvMenuRoleManagement.Nodes.Clear();
                GetTreeViewItems(Convert.ToInt32(hfLoginId.Value), Convert.ToInt32(ddlUserRoleList.SelectedValue));
            }
            else
            {
                tvMenuRoleManagement.Nodes.Clear();
            }
        }

        protected void btnAssignRole_Click(object sender, EventArgs e)
        {
            if (AssignUserRoleAndMenu())
            {
                
            }
        }

        private bool AssignUserRoleAndMenu()
        {
            GridViewRow row = gvDisplayUserInfo.SelectedRow;

            foreach (TreeNode objNodes in tvMenuRoleManagement.CheckedNodes)
            {
                objRole = new Role();
                objRoleBiz = new RoleBiz();

                objRole.MenuId = Convert.ToByte(objNodes.Value);
                objRole.UserId = Convert.ToInt16(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[0].ToString());
                objRole.RoleId = Convert.ToByte(ddlUserRoleList.SelectedValue);
                objRole.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());

                objRoleBiz.AssignUserRoleAndMenu(objRole);
            }

            return true;
        }

        protected void btnUpdateRole_Click(object sender, EventArgs e)
        {
            UnAssignUserRoleAndMenu();
            AssignUserRoleAndMenu();
            BindUserRoleGrid();
            Response.Redirect(Request.RawUrl);
        }

        private bool UnAssignUserRoleAndMenu()
        {
            GridViewRow row = gvDisplayUserInfo.SelectedRow;

            objRole = new Role();
            objRoleBiz = new RoleBiz();

            objRole.UserId = Convert.ToInt16(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[0].ToString());
            objRole.RoleId = Convert.ToByte(ddlUserRoleList.SelectedValue);
            objRole.UpdatedBy = Convert.ToInt16(Session["UserId"].ToString());

            objRoleBiz.UnAssignUserRoleAndMenu(objRole);

            return true;
        }

        protected void btnUpdateUserStatus_Click(object sender, EventArgs e)
        {
            if (UpdateUserStatus())
            {
                BindUserRoleGrid();
            }
        }

        private bool UpdateUserStatus()
        {
            GridViewRow row = gvDisplayUserInfo.SelectedRow;

            objUserInfo = new UserInfo();
            objUserInfoBiz = new UserInfoBiz();

            objUserInfo.UserId = Convert.ToInt16(gvDisplayUserInfo.DataKeys[row.RowIndex].Values[0].ToString());
            objUserInfo.IsActive = Convert.ToBoolean(ddlUserRoleListForUpdateStatus.SelectedValue);
            objUserInfo.UpdatedBy = Convert.ToInt16(Session["UserId"].ToString());

            objUserInfoBiz.UpdateUserStatus(objUserInfo);

            return true;
        }
    }
}