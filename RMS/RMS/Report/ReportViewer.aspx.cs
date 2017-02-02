﻿using System;
using CrystalDecisions.CrystalReports.Engine;

namespace RMS.Report
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer.ReportSource = (ReportDocument)Session["CrystalReport"];
            CrystalReportViewer.EnableDatabaseLogonPrompt = false;
            CrystalReportViewer.ToolPanelView = 0;
            CrystalReportViewer.Zoom(125);
            Session.Remove("CrystalReport");
        }
    }
}