using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class PurchaseReturnBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForPurchaseReturn(DbDataReader objDataReader, PurchaseReturn objPurchaseReturn)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "PurchaseReturnId":
                        if (!Convert.IsDBNull(objDataReader["PurchaseReturnId"]))
                        {
                            objPurchaseReturn.PurchaseReturnId = Convert.ToInt16(objDataReader["PurchaseReturnId"]);
                        }
                        break;
                    case "SupplierId":
                        if (!Convert.IsDBNull(objDataReader["SupplierId"]))
                        {
                            objPurchaseReturn.SupplierId = Convert.ToInt16(objDataReader["SupplierId"]);
                        }
                        break;
                    case "SupplierName":
                        if (!Convert.IsDBNull(objDataReader["SupplierName"]))
                        {
                            objPurchaseReturn.SupplierName = objDataReader["SupplierName"].ToString();
                        }
                        break;
                    case "InvoiceNumber":
                        if (!Convert.IsDBNull(objDataReader["InvoiceNumber"]))
                        {
                            objPurchaseReturn.InvoiceNumber = objDataReader["InvoiceNumber"].ToString();
                        }
                        break;
                    case "ProductId":
                        if (!Convert.IsDBNull(objDataReader["ProductId"]))
                        {
                            objPurchaseReturn.ProductId = Convert.ToInt16(objDataReader["ProductId"].ToString());
                        }
                        break;
                    case "ProductName":
                        if (!Convert.IsDBNull(objDataReader["ProductName"]))
                        {
                            objPurchaseReturn.ProductName = objDataReader["ProductName"].ToString();
                        }
                        break;
                    case "ReturnQuantity":
                        if (!Convert.IsDBNull(objDataReader["ReturnQuantity"]))
                        {
                            objPurchaseReturn.ReturnQuantity = Convert.ToDecimal(objDataReader["ReturnQuantity"].ToString());
                        }
                        break;
                    case "PurchaseId":
                        if (!Convert.IsDBNull(objDataReader["PurchaseId"]))
                        {
                            objPurchaseReturn.PurchaseId = Convert.ToInt32(objDataReader["PurchaseId"].ToString());
                        }
                        break;
                    case "TotalReturnValue":
                        if (!Convert.IsDBNull(objDataReader["TotalReturnValue"]))
                        {
                            objPurchaseReturn.TotalReturnValue = Convert.ToDecimal(objDataReader["TotalReturnValue"].ToString());
                        }
                        break;
                    case "DiscountAmount":
                        if (!Convert.IsDBNull(objDataReader["DiscountAmount"]))
                        {
                            objPurchaseReturn.DiscountAmount = Convert.ToDecimal(objDataReader["DiscountAmount"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objPurchaseReturn.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objPurchaseReturn.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objPurchaseReturn.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objPurchaseReturn.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objPurchaseReturn.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objPurchaseReturn.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objPurchaseReturn.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public PurchaseReturn GetSupplierName(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            PurchaseReturn objPurchaseReturn = new PurchaseReturn();
            List<PurchaseReturn> objSupplierList = new List<PurchaseReturn>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSupplierNameForPR]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objPurchaseReturn = new PurchaseReturn();
                        this.BuildModelForPurchaseReturn(objDbDataReader, objPurchaseReturn);

                        objSupplierList.Add(objPurchaseReturn);
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

            return objPurchaseReturn;
        }

        public string CreateReturnDetail(PurchaseReturn objPurchaseReturn)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("PurchaseId", objPurchaseReturn.PurchaseId);
            objDbCommand.AddInParameter("ProductId", objPurchaseReturn.ProductId);
            objDbCommand.AddInParameter("ReturnQuantity", objPurchaseReturn.ReturnQuantity);
            objDbCommand.AddInParameter("TotalReturnValue", objPurchaseReturn.TotalReturnValue);
            objDbCommand.AddInParameter("DiscountAmount", objPurchaseReturn.DiscountAmount);
            objDbCommand.AddInParameter("CreatedBy", objPurchaseReturn.CreatedBy);
            
            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreatePurchaseReturn]", CommandType.StoredProcedure);
                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successfully";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Cannot save. Try again";
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
        }
    }
}
