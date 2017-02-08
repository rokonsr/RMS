using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.Model;

namespace RMS.UI.Admin
{
    public partial class CompanyDetail : System.Web.UI.Page
    {
        private CompanyInfo objCompanyInfo;
        private CompanyInfoBiz objCompanyInfoBiz;
        private List<CompanyInfo> objCompanyNameList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropdownForCompanyName();
            }
        }

        private void PopulateDropdownForCompanyName()
        {
            objCompanyNameList = new List<CompanyInfo>();
            objCompanyInfoBiz = new CompanyInfoBiz();

            objCompanyNameList = objCompanyInfoBiz.GetCompanyNameList();
            ddlCompanyName.DataSource = objCompanyNameList;
            ddlCompanyName.DataValueField = "CompanyId";
            ddlCompanyName.DataTextField = "CompanyName";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0, new ListItem("--Select Company --", "0"));
        }

        protected void btnCompanyInfoUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}