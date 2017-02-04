using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.Report.ItemReport
{
    public partial class ItemDetail : BasePage
    {
        private List<Region> objRegionList;
        private RegionBiz objRegionBiz;
        private List<FoodSchedule> objFoodScheduleList;
        private FoodScheduleBiz objFoodScheduleBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownForRegion();
            }
        }

        private void PopulateDropDownForRegion()
        {
            List<Region> objRegionList = new List<Region>();
            objRegionBiz = new RegionBiz();

            objRegionList = objRegionBiz.GetRegionList();
            ddlRegion.DataSource = objRegionList;
            ddlRegion.DataValueField = "RegionId";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();

            ddlRegion.Items.Insert(0, new ListItem("--Select Region--", "0"));
        }

        private void PopulateDropDownForFoodSchedule()
        {
            objFoodScheduleList = new List<FoodSchedule>();
            objFoodScheduleBiz = new FoodScheduleBiz();

            objFoodScheduleList = objFoodScheduleBiz.GetFoodScheduleList();
            ddlFoodSchedule.DataSource = objFoodScheduleList;
            ddlFoodSchedule.DataValueField = "FoodScheduleId";
            ddlFoodSchedule.DataTextField = "FoodScheduleName";
            ddlFoodSchedule.DataBind();

            ddlFoodSchedule.Items.Insert(0, new ListItem("--Select Food Schedule--", "0"));
        }

        protected void btnItem_OnClick(object sender, EventArgs e)
        {
            ReportDocument rdDocument = new ReportDocument();
            rdDocument.Load(Server.MapPath("ItemwiseProductDetail.rpt"));
            rdDocument.SetParameterValue("@ItemName", txtItemName.Text.Trim());
            Session["CrystalReport"] = rdDocument;
            
            CrystalReportViewer();
        }

        protected void ddlRegion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegion.SelectedIndex > 0)
            {
                ReportDocument rdDocument = new ReportDocument();
                rdDocument.Load(Server.MapPath("RegionDetail.rpt"));
                rdDocument.SetParameterValue("@RegionId", ddlRegion.SelectedValue);
                Session["CrystalReport"] = rdDocument;

                CrystalReportViewer();
            }
            else
            {
                MessageBox("Please select a country");
            }
        }

        protected void ddlFoodSchedule_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFoodSchedule.SelectedIndex > 0)
            {
                ReportDocument rdDocument = new ReportDocument();
                rdDocument.Load(Server.MapPath("SchedulewiseFood.rpt"));
                rdDocument.SetParameterValue("@ScheduleId", ddlFoodSchedule.SelectedValue);
                //Session["CrystalReport"] = rdDocument;
                CrystalReportViewer();

                //rdDocument.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("BiWeeklyReport.pdf"));
            }
            else
            {
                MessageBox("Please select a time");
            }
        }

        protected void rdItemDetailList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdItemDetailList.SelectedValue == "1")
            {
                pnlDisplayItem.Visible = true;
                pnlDisplayRegion.Visible = false;
                pnlFoodSchedule.Visible = false;
            }
            else if (rdItemDetailList.SelectedValue == "2")
            {
                pnlDisplayItem.Visible = false;
                pnlDisplayRegion.Visible = true;
                pnlFoodSchedule.Visible = false;
            }
            else if (rdItemDetailList.SelectedValue == "3")
            {
                PopulateDropDownForFoodSchedule();
                pnlDisplayItem.Visible = false;
                pnlDisplayRegion.Visible = false;
                pnlFoodSchedule.Visible = true;
            }
        }

        private void CrystalReport()
        {
            DataTable dt = new DataTable();
            string reportName = string.Empty;
            string cs = ConfigurationManager.ConnectionStrings["ResDbConn"].ConnectionString;

            if (ddlRegion.SelectedValue == "1")
            {
                DataTable dt1 = new DataTable();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select CategoryId, CategoryName from [rdb].Category", con);
                    da.Fill(dt1);
                }
                dt = dt1;
                reportName = "CrystalReport1.rpt";
            }
            else if (ddlRegion.SelectedValue == "2")
            {
                DataTable dt1 = new DataTable();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select CategoryId, CategoryName from [rdb].Category", con);
                    da.Fill(dt1);
                }
                dt = dt1;
                reportName = "CrystalReport1.rpt";
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath(reportName));

            TextObject txtName = rd.ReportDefinition.ReportObjects["txtCompany"] as TextObject;
            txtName.Text = "Dfsdfxhgfgjhhgjghk";
            rd.SetDataSource(dt);
            Session["Type"] = 1;// Convert.ToInt32(DropDownList1.SelectedValue);
            Session["CrReport"] = rd;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('Report.aspx');", true);
        }
    }
}