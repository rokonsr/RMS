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
    public partial class CreateMeasurement : BasePage
    {
        private Measurement objMeasurement;
        private MeasurementBiz objMeasurementBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMeasurementNameSave_Click(object sender, EventArgs e)
        {
            if (CreateMeasurementName())
            {
                ClearInputs(Controls);
            }
        }

        private bool CreateMeasurementName()
        {
            objMeasurement=new Measurement();
            objMeasurementBiz=new MeasurementBiz();
            objMeasurement.MeasurementName = txtMeasurementName.Text.Trim();
            objMeasurement.MeasurementDescription = txtMeasurementDescription.Text.Trim();

            objMeasurement.CreatedBy = Convert.ToInt16(Session["userId"].ToString());
            MessageBox(objMeasurementBiz.CreateMeasurementName(objMeasurement));

            return true;
        }
    }
}