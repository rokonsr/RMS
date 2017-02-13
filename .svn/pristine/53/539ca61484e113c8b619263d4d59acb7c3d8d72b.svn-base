using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Web.Services;
using RMS.DAL;
using RMS.Model;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace RMS.UI.WebServices
{
    /// <summary>
    /// Summary description for AutoCompleteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class 
        AutoCompleteService : System.Web.Services.WebService
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        [WebMethod]
        public List<string> SearchUserInfo(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetUserInfoForUpdateGv]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["Username"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchDesignation(string searchText) //created by ataur
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetDesignationBySearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["DesignationName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchRole(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetRoleInfoForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["RoleName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }


        [WebMethod]
        public List<string> SearchSupplierName(string supplierName) //created by ataur
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SupplierName", supplierName);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSupplierNameForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["SupplierName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }



        [WebMethod]
        public List<string> SearchCategory(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetCategoryInfoForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["CategoryName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchMeasurement(string searchText) //Created by Enamul
        {

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetMeasurementInfoForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["MeasurementName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchBrand(string searchText) //Created by Enamul
        {

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetBrandForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["BrandName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }


        [WebMethod]
        public List<string> SearchFoodScheduleName(string searchText) // created by ataur
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetFoodScheduleNameForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["FoodScheduleName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchRegionName(string searchText) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetRegionNameForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["RegionName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchProductCode(string searchText) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductNameForGv]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["ProductId"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchProductName(string searchText) // created by Rokon
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductNameForGv]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["ProductName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public void ProductNameIfExist(string productName) // created by Rokon
        {
            bool productNameIfUse = false;

            string cs = ConfigurationManager.ConnectionStrings["ResDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("[rdb].[uspProductNameExist]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ProductName",
                    Value = productName
                });

                con.Open();
                productNameIfUse = Convert.ToBoolean(cmd.ExecuteScalar());
            }

            Product product = new Product();
            product.ProductName = productName;
            product.ProductNameInUse = productNameIfUse;

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(product));
        }

        [WebMethod]
        public List<string> SearchCustomerusename(string searchText) // created by Ataur
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objUserList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetCustomerUsernameForSearch]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objUserList.Add(objDbDataReader["CustomerUsername"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objUserList;
        }

        [WebMethod]
        public List<string> SearchInvoiceNumber(string searchText) // created by Rokon
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objInvoiceList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetInvoiceNumber]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objInvoiceList.Add(objDbDataReader["InvoiceNumber"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objInvoiceList;
        }

        [WebMethod]
        public List<string> SearchProductId(string productId, string invoiceNumber) // created by Rokon
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objProductList = new List<string>();

            objDbCommand.AddInParameter("ProductId", productId);
            objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductForReturnPurchase]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProductList.Add(objDbDataReader["ProductId"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objProductList;
        }

        [WebMethod]
        public List<string> SearchProduct(string productname, string invoiceNumber) // created by Rokon
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objProductList = new List<string>();

            objDbCommand.AddInParameter("ProductName", productname);
            objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductForReturnPurchase]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProductList.Add(objDbDataReader["ProductName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objProductList;
        }
        [WebMethod]
        public List<string> SearchSaleInvoiceNumber(string searchText) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objInvoiceList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSaleInvoiceNumber]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objInvoiceList.Add(objDbDataReader["InvoiceNumber"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objInvoiceList;
        }

        [WebMethod]
        public Sale GetInvoiceInfo(string invoiceNo) // created by Enamul
        {
            Sale objSale = new Sale();
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            string amount = "";

            objDbCommand.AddInParameter("invoiceNo", invoiceNo);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetInvoiceInfo]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSale.TotalAmount = Convert.ToDecimal(objDbDataReader["TotalAmount"]);
                        objSale.DiscountAmount = Convert.ToDecimal(objDbDataReader["AdjustmentAmount"]);
                        objSale.PaidAmount = Convert.ToDecimal(objDbDataReader["PaidAmount"]);
                        objSale.VatAmountTotal = Convert.ToDecimal(objDbDataReader["VatAmountTotal"]);
                        objSale.DiscountAmountTotal = Convert.ToDecimal(objDbDataReader["DiscountAmountTotal"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objSale;
        }

        [WebMethod]
        public List<string> SearchProductIdForSaleReturn(string productId, string invoiceNumber) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objProductList = new List<string>();

            objDbCommand.AddInParameter("ProductId", productId);
            objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductIdForSaleReturn]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProductList.Add(objDbDataReader["ProductId"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objProductList;
        }
        [WebMethod]
        public List<string> SearchProductNameForSaleReturn(string productname, string invoiceNumber) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objProductList = new List<string>();

            objDbCommand.AddInParameter("ProductName", productname);
            objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductNameForSaleReturn]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProductList.Add(objDbDataReader["ProductName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objProductList;
        }
        [WebMethod]
        public Sale GetSaleProductInfo(string productId, string invoiceNumber) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;

            Sale objSale = new Sale();

            objDbCommand.AddInParameter("ProductId", productId);
            objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductIdForSaleReturn]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSale.ProductId = Convert.ToInt16(objDbDataReader["ProductId"]);
                        objSale.ProductName = objDbDataReader["ProductName"].ToString();
                        objSale.SellPrice = Convert.ToDecimal(objDbDataReader["SellPrice"]);
                        objSale.Vat = Convert.ToDecimal(objDbDataReader["Vat"]);
                        objSale.Discount = Convert.ToDecimal(objDbDataReader["Discount"]);
                        objSale.SellQuantity = Convert.ToDecimal(objDbDataReader["SellQuantity"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objSale;
        }
        [WebMethod]
        public Sale GetSaleProductNameInfo(string productname, string invoiceNumber) // created by Enamul
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            string amount = "";

            Sale objSale = new Sale();

            objDbCommand.AddInParameter("ProductName", productname);
            objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductNameForSaleReturn]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSale.ProductId = Convert.ToInt16(objDbDataReader["ProductId"]);
                        objSale.ProductName = objDbDataReader["ProductName"].ToString();
                        objSale.SellPrice = Convert.ToDecimal(objDbDataReader["SellPrice"]);
                        objSale.Vat = Convert.ToDecimal(objDbDataReader["Vat"]);
                        objSale.Discount = Convert.ToDecimal(objDbDataReader["Discount"]);
                        objSale.SellQuantity = Convert.ToDecimal(objDbDataReader["SellQuantity"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objSale;
        }

        [WebMethod]
        public List<string> SearchSaleLedgerInvoiceNumber(string searchText) // created by Ataur
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objInvoiceList = new List<string>();

            objDbCommand.AddInParameter("SearchText", searchText);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSaleLedgerInvoiceNumber]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objInvoiceList.Add(objDbDataReader["InvoiceNumber"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objInvoiceList;
        }



        [WebMethod]
        public List<string> GetSpecifiedSalesCustomer(string customerUsername) // created by jahangir
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objInvoiceList = new List<string>();

            objDbCommand.AddInParameter("customerUsername", customerUsername);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspCustomerName]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objInvoiceList.Add(objDbDataReader["CustomerNameWithId"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objInvoiceList;
        }



        [WebMethod]
        public List<string> GetDeservedInvoiceNumber(string customerId) // created by Ataur
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<string> objInvoiceList = new List<string>();

            objDbCommand.AddInParameter("customerId", customerId);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspCustomerRelatedInvoice]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objInvoiceList.Add(objDbDataReader["InvoiceNumber"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objInvoiceList;
        }



        [WebMethod(EnableSession = true)]
        public List<string> CutomerRecivingAmountAgainestInvoice(string customerId, string collectionSalesId, string receivingAmount) // created by Ataur
        {
            
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
          
            List<string> objInvoiceList = new List<string>();

            objDbCommand.AddInParameter("customerId", customerId);
            objDbCommand.AddInParameter("collectionSalesId", collectionSalesId);
            objDbCommand.AddInParameter("receivingAmount", receivingAmount);



            string userId = "";
            try
            {

                userId = Session["UserId"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid User", ex);
                return null;
            }

            objDbCommand.AddInParameter("userId", userId);
            

            try
            {
               int noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCutomerRecivingAmountAgainestInvoice]", CommandType.StoredProcedure);
                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();

                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                objDbCommand.Transaction.Rollback();
                throw new Exception("Database Error Occured", ex);
            }

            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return null;

    
        }

        [WebMethod]
        public Product GetProductDetailForSale(string productCode) // created by Rokon
        {
            Product objProduct = new Product();
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            //string amount = "";

            objDbCommand.AddInParameter("ProductId", productCode);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductDetailForSale]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProduct.ProductName = objDbDataReader["ProductName"].ToString();
                        objProduct.ProductStock = Convert.ToDecimal(objDbDataReader["ProductStock"].ToString());
                        objProduct.ProductSellPrice = Convert.ToDecimal(objDbDataReader["ProductSellPrice"].ToString());
                        objProduct.Vat = Convert.ToDecimal(objDbDataReader["Vat"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objProduct;
        }

        [WebMethod]
        public Customer GetCustomerDetailForSale(string customerName) // created by Rokon
        {
            Customer objCustomer = new Customer();
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            //string amount = "";

            objDbCommand.AddInParameter("CustomerUsername", customerName);
            objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetCustomerDetailForSale]", CommandType.StoredProcedure);
            try
            {
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objCustomer.CustomerFullName = objDbDataReader["CustomerFullName"].ToString();
                        objCustomer.CustomerContactNumber = objDbDataReader["CustomerContactNumber"].ToString();
                        objCustomer.CustomerTotalDue = Convert.ToDecimal(objDbDataReader["CustomerBalance"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }
            return objCustomer;
        }
    }
}
