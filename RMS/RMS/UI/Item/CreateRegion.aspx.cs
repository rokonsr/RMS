using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;


namespace RMS.UI.Item
{
    public partial class CreateRegion : BasePage
    {
        private Region objRegion;
        private RegionBiz objRegionBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegionSave_OnClick(object sender, EventArgs e)
        {
            if (CreateBrandName())
            {
                ClearInputs(Controls);
            }

        }

        private bool CreateBrandName()
        {
            objRegion=new Region();
            objRegionBiz=new RegionBiz();
            objRegion.RegionName = txtRegionName.Text.Trim();
            objRegion.RegionDescription = txtRegionDescription.Text.Trim();
            objRegion.CreatedBy= Convert.ToInt16(Session["userId"].ToString());
            MessageBox(objRegionBiz.CreateRegionName(objRegion));
            return true;
        }
    }
}