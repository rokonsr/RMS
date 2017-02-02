using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.Model;

namespace RMS.UI.Admin
{
    //--Created By Ataur-->
    public partial class UpdateCustomer : System.Web.UI.Page
    {
        private Customer objCustomer;
        private CustomerBiz objCustomerBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewBindCustomerInfo();
        }

        private void GridViewBindCustomerInfo()
        {
            objCustomer=new Customer();
            objCustomerBiz=new CustomerBiz();
            DataTable dtCustomer=new DataTable();
            dtCustomer = objCustomerBiz.GetCustomerInfoForGv(txtCustomerUsername.Text.Trim());
            gvDisplayCustomerInfo.DataSource = dtCustomer;
            gvDisplayCustomerInfo.DataBind();
            gvDisplayCustomerInfo.ShowHeaderWhenEmpty = true;
            gvDisplayCustomerInfo.EmptyDataText = "No Data Found";
            gvDisplayCustomerInfo.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayCustomerInfo.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;
        }
        protected void gvDisplayCustomerInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[7];
                statusCell.Text = statusCell.Text == "True" ? "Active" : "Inactive";
                if (e.Row.Cells[7].Text == "Inactive")
                {
                    e.Row.BackColor = Color.Red;
                }
            }
        }

        protected void gvDisplayCustomerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {      
            pnlUpdateCustomerInfo.Visible = true;
            ddlUpdateCustomerStatus.Items.Clear();
            ddlUpdateCustomerStatus.Items.Insert(0, new ListItem("Active", "1"));
            ddlUpdateCustomerStatus.Items.Insert(1, new ListItem("Inactive", "0"));
            string status = gvDisplayCustomerInfo.SelectedRow.Cells[7].Text == "Active" ? "1" : "0";
            txtUpdateCustomerUsername.Text = gvDisplayCustomerInfo.SelectedRow.Cells[1].Text;
           //txtUpdateCustomerPassword.Text = SHA512PasswordGenerator(gvDisplayCustomerInfo.SelectedRow.Cells[2].Text);
            txtCustomerContactNo.Text = gvDisplayCustomerInfo.SelectedRow.Cells[2].Text;
            txtUpdateCustomerFullName.Text = gvDisplayCustomerInfo.SelectedRow.Cells[3].Text;
            txtUpdateCustomerDescription.Text = gvDisplayCustomerInfo.SelectedRow.Cells[4].Text.Replace("&nbsp;",
                String.Empty);
            txtUpdateCustomerAddress.Text = gvDisplayCustomerInfo.SelectedRow.Cells[5].Text.Replace("&nbsp;",String.Empty);
            txtUpdateCustomerEmail.Text = gvDisplayCustomerInfo.SelectedRow.Cells[6].Text.Replace("&nbsp;",String.Empty);
            ddlUpdateCustomerStatus.ClearSelection();
            ddlUpdateCustomerStatus.Items.FindByValue(status).Selected = true;
            ModalUpdateCustomerInfo.Show();
        }

        protected void gvDisplayCustomerInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplayCustomerInfo.PageIndex = e.NewPageIndex;       
            GridViewBindCustomerInfo();
        }

        protected void btnUpdateCustomerInfo_OnClick(object sender, EventArgs e)
        {
            if (EditCustomerInfo())
            {
                GridViewBindCustomerInfo();
            }
        }

        private bool EditCustomerInfo()
        {
            objCustomer=new Customer();
            objCustomerBiz=new CustomerBiz();
            GridViewRow row = gvDisplayCustomerInfo.SelectedRow;
            objCustomer.CustomerId = Convert.ToInt32(gvDisplayCustomerInfo.DataKeys[row.RowIndex].Values[0].ToString());
            objCustomer.CustomerUsername = txtUpdateCustomerUsername.Text.Trim();
            //objCustomer.CustomerPassword = SHA512PasswordGenerator(txtUpdateCustomerPassword.Text.Trim());
            objCustomer.CustomerContactNumber = txtCustomerContactNo.Text.Trim();
            objCustomer.CustomerFullName = txtUpdateCustomerFullName.Text.Trim();
            objCustomer.CustomerDescription = txtUpdateCustomerDescription.Text.Trim();
            objCustomer.CustomerAddress = txtUpdateCustomerAddress.Text.Trim();
            objCustomer.CustomerEmail = txtUpdateCustomerEmail.Text.Trim();
            objCustomer.IsActive = ddlUpdateCustomerStatus.SelectedValue == "1";
            objCustomer.UpdatedBy = Convert.ToInt16(Session["UserId"].ToString());

            objCustomerBiz.UpdateCustomerInfo(objCustomer);
            return true;
        }
        protected void gvDisplayCustomerInfo_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PasswordCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string username= gvDisplayCustomerInfo.Rows[rowIndex].Cells[1].Text;

                txtGetuserNameForPasswordChange.Text = username;
                //ViewState["CustomerUsername"] = username;
                //objCustomer.CustomerPassword = SHA512PasswordGenerator(txtUpdateCustomerPassword.Text.Trim());
                //objCustomer.CustomerUsername = username;


                pnlForChangePassword.Visible = true;
                ModalPopupExtenderForChangepassword.Show();
            }
        }

        protected void btnChangeCustomerPassword_OnClick(object sender, EventArgs e)
        {
            objCustomer=new Customer();
            objCustomerBiz=new CustomerBiz();

            //objCustomer.CustomerUsername = ViewState["CustomerUsername"].ToString();
            objCustomer.CustomerUsername = txtGetuserNameForPasswordChange.Text.Trim();
            objCustomer.CustomerPassword = SHA512PasswordGenerator(txtUpdateCustomerPassword.Text.Trim());
            objCustomer.UpdatedBy = Convert.ToInt16(Session["UserId"]);

            objCustomerBiz.ChangeCustomerPasswordByAdmin(objCustomer);
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