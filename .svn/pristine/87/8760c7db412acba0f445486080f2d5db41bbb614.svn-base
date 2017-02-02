using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class CreateBrand :BasePage
    {
        private Brand objBrand;
        private BrandBiz objBrandBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBrandSave_OnClick(object sender, EventArgs e)
        {
            if (CreateBrandName())
            {
                ClearInputs(Controls);
            }

        }
        private bool CreateBrandName()
        {
            objBrand=new Brand();
            objBrandBiz=new BrandBiz();
            objBrand.BrandName = txtBrandName.Text.Trim();
            objBrand.BrandDescription = txtBrandDescription.Text.Trim();
            objBrand.CreatedBy = Convert.ToInt16(Session["userId"].ToString());
            MessageBox(objBrandBiz.CreateBrandName(objBrand));
            return true;
        }       
    }
}