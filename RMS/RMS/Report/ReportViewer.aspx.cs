﻿using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace RMS.Report
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rd = (ReportDocument)Session["CrystalReport"];
            if(rd != null)
            { 


            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report" + DateTime.Now);
           
            CrystalReportViewer.ReportSource = rd;
            Response.End();
            Session.Remove("CrystalReport");
            }
        }
    }
}