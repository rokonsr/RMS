using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Admin
{
    public partial class CreateDesignation : BasePage
    {

        private Designation objDesignation;
        private DesignationBiz objDesignationBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            
              
           
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            if (CreateUserDesignation())
            {

            }
            txtDesignationSearch.Text=String.Empty;
        }

        private bool CreateUserDesignation()
        {
            objDesignation = new Designation();
            objDesignationBiz = new DesignationBiz();

            objDesignation.DesignationName = txtDesignationSearch.Text.Trim();
            objDesignation.UserId = Convert.ToInt16(Session["UserId"].ToString());

            MessageBox(objDesignationBiz.CreateDesignation(objDesignation));
            return true;
        }

    }
}