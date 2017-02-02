using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RMS.DAL
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.MaintainScrollPositionOnPostBack = true;
        }

        protected override void InitializeCulture()
        {
            string cultureName = "en-GB";
            this.UICulture = cultureName;
            this.Culture = cultureName;
           CultureInfo objCultureInfo = new System.Globalization.CultureInfo(cultureName);
            objCultureInfo.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = objCultureInfo;
           Thread.CurrentThread.CurrentUICulture = objCultureInfo;
            base.InitializeCulture();
        }

        public void MessageBox(String message)
        {
            System.Web.UI.WebControls.Label lblMessageBoxForAlert = new System.Web.UI.WebControls.Label();
            lblMessageBoxForAlert.ID = "testjavascriptlabelid";
            lblMessageBoxForAlert.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + message + "'" + ");</script>";
            Page.Controls.Add(lblMessageBoxForAlert);
        }

        Label lblUpdateStatus=new Label();
        public void UpdateSuccessfull()
        {
            lblUpdateStatus.Text= "Updated Successfully.";
            lblUpdateStatus.Attributes.Add("style", "color:red; position:absolute; z-index:99; width:100%; text-align:center; top:350px; padding: 20px;background-color: rgba(146,205,0, 0.8); color: white");
            //Master.LblupdtStatus.Visible = true;
            //Master.LblupdtStatus.ForeColor = Color.Green;
            //Master.LblupdtStatus.Text = "Updated Successfully.";

            //Master.LblupdtStatus.Attributes.Add("style", "color:red; position:absolute; z-index:99; width:100%; text-align:center; top:350px; padding: 20px;background-color: rgba(146,205,0, 0.8); color: white");
            ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "UpdateStatusFadeOut('" + lblUpdateStatus.ClientID + "',2000)", true);
            
        }

        protected void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)(ctrl)).SelectedIndex = 0;
                }

                //else if (ctrl.GetType() == typeof(Label))
                //{
                //    ((Label)(ctrl)).Text = string.Empty;
                //}
                //else if (ctrl.GetType() == typeof(CheckBox))
                //{
                //    ((CheckBox)(ctrl)).Checked = false;
                //}
                //else if (ctrl.GetType() == typeof(CheckBoxList))
                //{
                //    ((CheckBoxList)(ctrl)).ClearSelection();
                //}
                //else if (ctrl.GetType() == typeof(RadioButton))
                //{
                //    ((RadioButton)(ctrl)).Checked = false;
                //}
                //else if (ctrl.GetType() == typeof(RadioButtonList))
                //{
                //    ((RadioButtonList)(ctrl)).ClearSelection();
                //}

                ClearInputs(ctrl.Controls);
            }
        }

        protected enum ReceivingType
        {
            Received = 1,
            Due = 2,
            Partial = 3
        }

        protected void CrystalReportViewer()
        {
            string url = "../ReportViewer.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=1150,height=1000,left=400,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}
