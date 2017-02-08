﻿using System;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.SaleUI
{
    public partial class AdvanceSaleReceive : BasePage
    {
        //--Ataur-->
        private AdvanceSaleAmount objAdvanceSaleAmount;
        private AdvanceSaleAmountBiz objAdvanceSaleAmountBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (int value in Enum.GetValues(typeof(TransactionType)))
                {
                    ddlTransactionType.Items.Add(new ListItem(Enum.GetName(typeof(TransactionType), value), value.ToString()));
                }

                ddlTransactionType.Items.Insert(0, new ListItem("--Select Type--", "0"));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objAdvanceSaleAmount = new AdvanceSaleAmount();
            objAdvanceSaleAmountBiz = new AdvanceSaleAmountBiz();

            objAdvanceSaleAmount.CustomerUsername = txtCustomerUsername.Text.Trim();
            objAdvanceSaleAmount.TransactionType = Convert.ToByte(ddlTransactionType.SelectedValue);
            objAdvanceSaleAmount.TransactionAmount = Convert.ToDecimal(txtTransactionAmount.Text);
            objAdvanceSaleAmount.CreatedBy = Convert.ToInt16(Session["UserId"].ToString());

            MessageBox(objAdvanceSaleAmountBiz.AdvanceSaleReceiveAmount(objAdvanceSaleAmount));
            ClearInputs(Controls);
        }
    }
}