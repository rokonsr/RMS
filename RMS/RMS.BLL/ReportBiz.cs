using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class ReportBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        public DataTable SupplierwisePurchaseDetails(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SupplierId", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[cr].[uspCRSupplierwisePurchaseDetails]", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable InvoicewisePurchaseDetails(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("InvoiceNumber", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[cr].[uspCRInvoicewisePurchaseDetail]", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }
    }

    public class CompanyInformation
    {
        private CompanyInfoBiz objCompanyInfoBiz;

        public CompanyInformation()
        {
            CompanyInfo();
        }

        public string txtCompanyName { get; set; }
        public byte[] txtCompanyLogo { get; set; }
        public string txtCompanyAddress { get; set; }
        public string txtCompanyPhone { get; set; }
        public string txtCompanyFax { get; set; }
        public string txtCompanyEmail { get; set; }
        public string txtTradeLicense { get; set; }
        public string txtTINCertificate { get; set; }
        public string txtBSTIApproval { get; set; }
        public string VATRegNumber { get; set; }

        void CompanyInfo()
        {
            objCompanyInfoBiz = new CompanyInfoBiz();

            DataTable objCompanyInfo = new DataTable();
            objCompanyInfo = objCompanyInfoBiz.CompanyDetails();
            txtCompanyName = objCompanyInfo.Rows[0]["CompanyName"].ToString();
            txtCompanyAddress = objCompanyInfo.Rows[0]["CompanyAddress"].ToString();
            txtTradeLicense = objCompanyInfo.Rows[0]["TradeLicense"].ToString();
        }
    }
}
