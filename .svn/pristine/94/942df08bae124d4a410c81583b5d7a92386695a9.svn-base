using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS
{
    public partial class Login : BasePage
    {
        private UserInfo objUserInfo;
        private UserInfoBiz objUserInfoBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionUtility.RMSSessionContainer.OBJ_DOC_CLASS = null;
                SessionUtility.RMSSessionContainer.OBJ_CLASS = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objUserInfoBiz = new UserInfoBiz();

            objUserInfo = objUserInfoBiz.GetLoginInfo(txtUserName.Text.Trim(), SHA512PasswordGenerator(txtPassword.Text.Trim()));

            if (objUserInfo != null)
            {
                SessionUtility.RMSSessionContainer.OBJ_CLASS = objUserInfo;

                FormsAuthentication.RedirectFromLoginPage(objUserInfo.Username, true);
                Response.Redirect(Session["returnUrl"]?.ToString() ?? "~/Home.aspx");
            }
            else
            {
                MessageBox("Unauthorized Login");
                SessionUtility.RMSSessionContainer.OBJ_CLASS = null;
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
    }
}