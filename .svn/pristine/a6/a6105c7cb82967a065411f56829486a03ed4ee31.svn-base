using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Admin
{
    public partial class CreateCustomer :BasePage
    {
        private Customer objCustomer;
        private CustomerBiz objCustomerBiz;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (CreateCustomerInfo())
            {
                ClearInputs(Page.Controls);
            }
        }

        private bool CreateCustomerInfo()
        {
            objCustomer=new Customer();
            objCustomerBiz=new CustomerBiz();

            objCustomer.CustomerUsername = txtCustomerUsername.Text.Trim();
            objCustomer.CustomerPassword = SHA512PasswordGenerator(txtCustomerPassword.Text.Trim());
            objCustomer.CustomerContactNumber = txtCustomerContactNo.Text.Trim();
            objCustomer.CustomerFullName = txtCustomerFullName.Text.Trim();
            objCustomer.CustomerDescription = txtCustomerDescription.Text.Trim();
            objCustomer.CustomerAddress = txtCustomerAddress.Text.Trim();
            objCustomer.CustomerEmail = txtCustomerEmail.Text.Trim();

            objCustomer.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());
            MessageBox(objCustomerBiz.CreateCustomerInfo(objCustomer));
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