using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS
{
    public partial class Rms : System.Web.UI.MasterPage
    {
        private List<NavigationMenu> objNavigationMenuList = new List<NavigationMenu>();
        private NavigationMenuBiz objNavigationMenuBiz = new NavigationMenuBiz();
        private NavigationMenu objNavigationMenu = new NavigationMenu();
        
        private PageDetailBiz objPageDetailBiz = new PageDetailBiz();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["returnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
           
            if (!IsPostBack)
            {
                if (SessionUtility.RMSSessionContainer.OBJ_CLASS != null)
                {
                    UserInfo objLoginUserId = new UserInfo();
                    objLoginUserId = (UserInfo)SessionUtility.RMSSessionContainer.OBJ_CLASS;
                    GetMenuList(objLoginUserId);

                    Session["DisplayFullName"] = objLoginUserId.UserFullName;
                    Session["Username"] = objLoginUserId.Username;
                    Session["UserId"] = objLoginUserId.UserId;
                }

                lblDisplayFullName.Text = "Welcome " + Session["DisplayFullName"];
            }

            if (SessionUtility.RMSSessionContainer.OBJ_CLASS == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            Response.Cache.SetNoStore();

            // Get Header Label as per MenuId

            objNavigationMenu.MenuId = objNavigationMenuBiz.GetMenuId(Page.GetType().BaseType.Name);

            List<PageDetail> objPageDetailList = new List<PageDetail>();

            objPageDetailList = objPageDetailBiz.GetLabelByMenuId(objNavigationMenu.MenuId);

            foreach (PageDetail objPageDetail in objPageDetailList)
            {
                lblMenuLabel.Text = objPageDetail.HeaderLabel;
                titleMenuLabel.Text = objPageDetail.HeaderLabel;
            }

            // Page Authentication

            if (SessionUtility.RMSSessionContainer.OBJ_CLASS != null)
            {
                if (SessionUtility.RMSSessionContainer.OBJ_Menu_CLASS != null && objNavigationMenu.MenuId != 0)
                {
                    bool isHasThisMenuId = false;

                    List<NavigationMenu> objNavigationMenuList = new List<NavigationMenu>();

                    objNavigationMenuList = SessionUtility.RMSSessionContainer.OBJ_Menu_CLASS as List<NavigationMenu>;

                    foreach (NavigationMenu objMenu in objNavigationMenuList)
                    {
                        if (objMenu.MenuId == objNavigationMenu.MenuId)
                        {
                            isHasThisMenuId = true;
                        }
                    }
                    if (isHasThisMenuId == false)
                    {
                        SessionUtility.RMSSessionContainer.OBJ_CLASS = null;
                        FormsAuthentication.RedirectToLoginPage();
                        //Response.Redirect("~/Site/index.aspx");
                    }
                }
            }
            else
            {
                SessionUtility.RMSSessionContainer.OBJ_CLASS = null;
                FormsAuthentication.RedirectToLoginPage();
                //Response.Redirect("~/Site/index.aspx");
            }
        }

        private void GetMenuList(UserInfo objLoginUserId)
        {
            objNavigationMenuList = new List<NavigationMenu>();

            objNavigationMenuList = objNavigationMenuBiz.GetMenuList(objLoginUserId);
            SessionUtility.RMSSessionContainer.OBJ_Menu_CLASS = objNavigationMenuList;

            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("MenuName", typeof(string));
            table.Columns.Add("ParentId", typeof(int));
            table.Columns.Add("MenuPath", typeof(string));

            foreach (NavigationMenu objMenu in objNavigationMenuList)
            {
                table.Rows.Add(objMenu.MenuId, objMenu.MenuName, objMenu.ParentId, objMenu.MenuPath);
            }
            DataView view = new DataView(table);
            view.RowFilter = "ParentId is NULL";
            foreach (DataRowView row in view)
            {
                MenuItem menuItem = new MenuItem(row["MenuName"].ToString(), row["Id"].ToString());
                menuItem.NavigateUrl = row["MenuPath"].ToString();
                navigationMenu.Items.Add(menuItem);
                AddChildItems(table, menuItem);
            }
        }

        private void AddChildItems(DataTable table, MenuItem menuItem)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentId=" + menuItem.Value;
            foreach (DataRowView childView in viewItem)
            {
                MenuItem childItem = new MenuItem(childView["MenuName"].ToString(), childView["Id"].ToString());
                childItem.NavigateUrl = childView["MenuPath"].ToString();
                menuItem.ChildItems.Add(childItem);
                AddChildItems(table, childItem);
            }
        }
        public Label LblupdtStatus
        {
            get { return lblUpdateStatus; }
            set { lblUpdateStatus = value; }
        }
    }
}