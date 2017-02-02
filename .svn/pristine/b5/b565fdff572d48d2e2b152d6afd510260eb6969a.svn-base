using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.Site
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private UserInfo objUserInfo;
        private UserInfoBiz objUserInfoBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionUtility.RMSSessionContainer.OBJ_DOC_CLASS = null;
                SessionUtility.RMSSessionContainer.OBJ_CLASS = null;
                Page.Form.DefaultButton = btnLogin.UniqueID;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">\n");
            sb.Append("Sys.Application.add_load(modalSetup);\n");
            sb.Append("function modalSetup() {\n");
            sb.Append(String.Format("var modalPopup = $find('{0}');\n", ModalUserLogin.BehaviorID));
            sb.Append("modalPopup.add_shown(SetFocusOnControl); }\n");
            sb.Append("function SetFocusOnControl() {\n");
            sb.Append(String.Format("var textBox = $get('{0}');\n", txtLoginUserName.ClientID));
            sb.Append("textBox.focus();}\n");
            sb.Append("</script>\n");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Startup", sb.ToString());
        }

        protected void bntLogin_OnClick(object sender, EventArgs e)
        {
            ModalUserLogin.Show();
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            objUserInfoBiz = new UserInfoBiz();

            objUserInfo = objUserInfoBiz.GetLoginInfo(txtLoginUserName.Text.Trim(), SHA512PasswordGenerator(txtLoginPassword.Text.Trim()));

            if (objUserInfo != null)
            {
                SessionUtility.RMSSessionContainer.OBJ_CLASS = objUserInfo;

                FormsAuthentication.RedirectFromLoginPage(objUserInfo.Username, false);
                Response.Redirect(Session["returnUrl"]?.ToString() ?? "~/Home.aspx");
            }
            else
            {
                MessageBox("Unauthorized Login");
                SessionUtility.RMSSessionContainer.OBJ_CLASS = null;
                ModalUserLogin.Show();
                
            }
        }

        public string SHA512PasswordGenerator(string strInput)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] arrHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(strInput));
            StringBuilder sbHash = new StringBuilder();
            for (int i = 0; i < arrHash.Length; i++)
            {
                sbHash.Append(arrHash[i].ToString("x2"));
            }
            return sbHash.ToString();
        }


        public void MessageBox(String message)
        {
            System.Web.UI.WebControls.Label lblMessageBoxForAlert = new System.Web.UI.WebControls.Label();
            lblMessageBoxForAlert.ID = "testjavascriptlabelid";
            lblMessageBoxForAlert.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + message + "'" + ");</script>";
            Page.Controls.Add(lblMessageBoxForAlert);
        }
    }
}