using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    //--Created By Ataur-->
    public partial class CreateFoodSchedule : BasePage
    {
        private FoodSchedule objFoodSchedule;
        private FoodScheduleBiz objFoodScheduleBiz;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (CreateFoodScheduleInfo())
            {
                ClearInputs(Page.Controls);
            }
        }

        private bool CreateFoodScheduleInfo()
        {
            objFoodSchedule = new FoodSchedule();
            objFoodScheduleBiz = new FoodScheduleBiz();

            objFoodSchedule.FoodScheduleName = txtFoodScheduleName.Text.Trim();
            objFoodSchedule.ScheduleDescription = txtFoodScheduleDescription.Text.Trim();
            objFoodSchedule.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());
            MessageBox(objFoodScheduleBiz.CreateFoodScheduleInfo(objFoodSchedule));
            return true;
        }
    }
}