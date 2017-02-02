using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class PurchaseBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForPurchase(DbDataReader objDataReader, Purchase objPurchase)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "PurchaseId":
                        if (!Convert.IsDBNull(objDataReader["PurchaseId"]))
                        {
                            objPurchase.PurchaseId = Convert.ToInt16(objDataReader["PurchaseId"]);
                        }
                        break;
                    case "SupplierId":
                        if (!Convert.IsDBNull(objDataReader["SupplierId"]))
                        {
                            objPurchase.SupplierId = Convert.ToInt16(objDataReader["SupplierId"]);
                        }
                        break;
                    case "InvoiceNumber":
                        if (!Convert.IsDBNull(objDataReader["InvoiceNumber"]))
                        {
                            objPurchase.InvoiceNumber = objDataReader["InvoiceNumber"].ToString();
                        }
                        break;
                    case "InvoiceFileId":
                        if (!Convert.IsDBNull(objDataReader["InvoiceFileId"]))
                        {
                            objPurchase.InvoiceFileId = Convert.ToInt32(objDataReader["InvoiceFileId"].ToString());
                        }
                        break;
                    case "PurchaseDate":
                        if (!Convert.IsDBNull(objDataReader["PurchaseDate"]))
                        {
                            objPurchase.PurchaseDate = Convert.ToDateTime(objDataReader["PurchaseDate"].ToString());
                        }
                        break;
                    case "TotalAmount":
                        if (!Convert.IsDBNull(objDataReader["TotalAmount"]))
                        {
                            objPurchase.TotalAmount = Convert.ToDecimal(objDataReader["TotalAmount"].ToString());
                        }
                        break;
                    case "DiscountAmount":
                        if (!Convert.IsDBNull(objDataReader["DiscountAmount"]))
                        {
                            objPurchase.DiscountAmount = Convert.ToDecimal(objDataReader["DiscountAmount"].ToString());
                        }
                        break;
                    case "PaidAmount":
                        if (!Convert.IsDBNull(objDataReader["PaidAmount"]))
                        {
                            objPurchase.PaidAmount = Convert.ToDecimal(objDataReader["PaidAmount"].ToString());
                        }
                        break;
                    case "FileName":
                        if (!Convert.IsDBNull(objDataReader["FileName"]))
                        {
                            objPurchase.FileName = objDataReader["FileName"].ToString();
                        }
                        break;
                    case "FileSize":
                        if (!Convert.IsDBNull(objDataReader["FileSize"]))
                        {
                            objPurchase.FileSize = Convert.ToByte(objDataReader["FileSize"].ToString());
                        }
                        break;
                    case "InvoiceFile":
                        if (!Convert.IsDBNull(objDataReader["InvoiceFile"]))
                        {
                            objPurchase.InvoiceFile = (byte[])objDataReader["InvoiceFile"];
                        }
                        break;
                    case "PurchaseDetailId":
                        if (!Convert.IsDBNull(objDataReader["PurchaseDetailId"]))
                        {
                            objPurchase.PurchaseDetailId = Convert.ToInt32(objDataReader["PurchaseDetailId"].ToString());
                        }
                        break;
                    case "ProductId":
                        if (!Convert.IsDBNull(objDataReader["ProductId"]))
                        {
                            objPurchase.ProductId = Convert.ToInt16(objDataReader["ProductId"].ToString());
                        }
                        break;
                    case "PurchaseQuantity":
                        if (!Convert.IsDBNull(objDataReader["PurchaseQuantity"]))
                        {
                            objPurchase.PurchaseQuantity = Convert.ToDecimal(objDataReader["PurchaseQuantity"].ToString());
                        }
                        break;
                    case "PurchasePrice":
                        if (!Convert.IsDBNull(objDataReader["PurchasePrice"]))
                        {
                            objPurchase.PurchasePrice = Convert.ToDecimal(objDataReader["PurchasePrice"].ToString());
                        }
                        break;
                    case "ProductSellPrice":
                        if (!Convert.IsDBNull(objDataReader["ProductSellPrice"]))
                        {
                            objPurchase.ProductSellPrice = Convert.ToDecimal(objDataReader["ProductSellPrice"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objPurchase.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objPurchase.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objPurchase.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objPurchase.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objPurchase.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objPurchase.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objPurchase.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public bool CreatePurchase(Purchase objPurchase)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("FileName", objPurchase.FileName);
            objDbCommand.AddInParameter("FileSize", objPurchase.FileSize);
            objDbCommand.AddInParameter("InvoiceFile", objPurchase.InvoiceFile);

            objDbCommand.AddInParameter("SupplierId", objPurchase.SupplierId);
            objDbCommand.AddInParameter("InvoiceNumber", objPurchase.InvoiceNumber);
            objDbCommand.AddInParameter("PurchaseDate", objPurchase.PurchaseDate);
            objDbCommand.AddInParameter("TotalAmount", objPurchase.TotalAmount);
            objDbCommand.AddInParameter("DiscountAmount", objPurchase.DiscountAmount);
            objDbCommand.AddInParameter("PaidAmount", objPurchase.PaidAmount);
            objDbCommand.AddInParameter("UserId", objPurchase.CreatedBy);
            objDbCommand.AddInParameter("Remarks", objPurchase.Remarks);

            // Insert purchase details
            objDbCommand.AddInParameter("ProductId", objPurchase.ProductId);
            objDbCommand.AddInParameter("PurchaseQuantity", objPurchase.PurchaseQuantity);
            objDbCommand.AddInParameter("PurchasePrice", objPurchase.PurchasePrice);

            objDbCommand.AddInParameter("ProductSellPrice", objPurchase.ProductSellPrice);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreatePurchase]", CommandType.StoredProcedure);
                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return true;
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return false;
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
