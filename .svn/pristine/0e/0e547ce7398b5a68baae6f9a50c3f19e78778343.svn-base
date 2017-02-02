using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Admin
{
    //Created by ataur
    public partial class CreateUser : BasePage
    {
        private UserInfo objUserInfo;
        private UserInfoBiz objUserInfoBiz;
        private Designation objDesignation;
        private DesignationBiz objDesignationBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                PopulateDropDownForDesignation();
            }  
        }

        private void PopulateDropDownForDesignation()
        {
            objDesignation = new Designation();
            objDesignationBiz = new DesignationBiz();

            List<Designation> objDesignationList = new List<Designation>();
            objDesignationList = objDesignationBiz.GetDesignationList();
            ddlDesignation.DataSource = objDesignationList;
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataBind();

            ddlDesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));
            //ddlDesignation.Items[0].Selected = true;
            //ddlDesignation.Items[0].Attributes["Disabled"] = "Disabled";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (CreateUserInfo())
            {
                ClearInputs(Page.Controls);
            }
        }

        private bool CreateUserInfo()
        {
            objUserInfo = new UserInfo();
            objUserInfoBiz = new UserInfoBiz();

            objUserInfo.Username = txtCreateUserName.Text.Trim();
            objUserInfo.UserPassword = SHA512PasswordGenerator(txtCreateUserPassword.Text.Trim());
            objUserInfo.DesignationId = Convert.ToByte(ddlDesignation.SelectedValue);
            objUserInfo.UserFullName = txtFullName.Text.Trim();
            objUserInfo.UserEmail = txtEmail.Text.Trim();
            objUserInfo.UserPhoneNo = txtPhoneNo.Text.Trim();
            objUserInfo.UserAddress = txtAddress.Text.Trim();
            objUserInfo.UserId = Convert.ToInt16(Session["UserId"].ToString());

            MessageBox(objUserInfoBiz.CreateUserInfo(objUserInfo));

            return true;
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