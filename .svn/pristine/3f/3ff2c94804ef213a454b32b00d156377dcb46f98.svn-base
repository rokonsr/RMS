using System;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Admin
{
    public partial class CreateRole : BasePage
    {
        private Role objRole;
        private RoleBiz objRoleBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (CreateUserRole())
            {
                txtRoleName.Text=String.Empty;
            }
        }
        private bool CreateUserRole()
        {
            objRole = new Role();
            objRoleBiz = new RoleBiz();

            objRole.RoleName = txtRoleName.Text.Trim();           
            objRole.UserId= Convert.ToInt16(Session["UserId"].ToString());

            MessageBox(objRoleBiz.CreateRole(objRole));
            return true;
        }
    }
}