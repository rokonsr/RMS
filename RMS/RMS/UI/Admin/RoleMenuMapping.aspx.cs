using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Admin
{
    public partial class RoleMenuMapping : BasePage
    {
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

        private void GetTreeViewItems(int roleId)
        {
            objNavigationMenuList = new List<NavigationMenu>();
            objNavigationMenuBiz = new NavigationMenuBiz();
            objNavigationMenuList = objNavigationMenuBiz.GetTvListForRoleMenuMapping(roleId);

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

        protected void ddlUserRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserRoleList.SelectedIndex > 0)
            {
                tvMenuRoleManagement.Nodes.Clear();
                GetTreeViewItems(Convert.ToInt32(ddlUserRoleList.SelectedValue));
            }
            else
            {
                tvMenuRoleManagement.Nodes.Clear();
            }
        }

        protected void btnAssignMenuToRole_Click(object sender, EventArgs e)
        {
            UnAssignRoleMenuMapping();
            if (tvMenuRoleManagement.CheckedNodes.Count > 0)
            {
                AssignRoleMenuMapping();
            }
            else
            {
                MessageBox("Save Successful");
            }
        }

        private bool AssignRoleMenuMapping()
        {
            foreach (TreeNode objNodes in tvMenuRoleManagement.CheckedNodes)
            {
                objRole = new Role();
                objRoleBiz = new RoleBiz();

                objRole.MenuId = Convert.ToByte(objNodes.Value);
                objRole.RoleId = Convert.ToByte(ddlUserRoleList.SelectedValue);
                objRole.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());

                objRoleBiz.AssignRoleMenuMapping(objRole);
            }
            MessageBox(objRoleBiz.AssignRoleMenuMapping(objRole));

            return true;
        }

        private bool UnAssignRoleMenuMapping()
        {
            objRole = new Role();
            objRoleBiz = new RoleBiz();

            objRole.RoleId = Convert.ToByte(ddlUserRoleList.SelectedValue);
            objRole.UpdatedBy = Convert.ToInt16(Session["UserId"].ToString());

            objRoleBiz.UnAssignRoleMenuMapping(objRole);

            return true;
        }
    }
}