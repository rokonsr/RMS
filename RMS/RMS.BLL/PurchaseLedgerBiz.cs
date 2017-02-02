using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class PurchaseLedgerBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForPurchaseLedger(DbDataReader objDataReader, PurchaseLedger objPurchaseLedger)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "PurchaseLedgerId":
                        if (!Convert.IsDBNull(objDataReader["PurchaseLedgerId"]))
                        {
                            objPurchaseLedger.PurchaseLedgerId = Convert.ToInt16(objDataReader["PurchaseLedgerId"]);
                        }
                        break;
                    case "SupplierId":
                        if (!Convert.IsDBNull(objDataReader["SupplierId"]))
                        {
                            objPurchaseLedger.SupplierId = Convert.ToInt16(objDataReader["SupplierId"]);
                        }
                        break;
                    case "InvoiceNumber":
                        if (!Convert.IsDBNull(objDataReader["InvoiceNumber"]))
                        {
                            objPurchaseLedger.InvoiceNumber = objDataReader["InvoiceNumber"].ToString();
                        }
                        break;
                    case "TransactionType":
                        if (!Convert.IsDBNull(objDataReader["TransactionType"]))
                        {
                            objPurchaseLedger.TransactionType = Convert.ToByte(objDataReader["TransactionType"].ToString());
                        }
                        break;
                    case "ReceivedAmount":
                        if (!Convert.IsDBNull(objDataReader["ReceivedAmount"]))
                        {
                            objPurchaseLedger.ReceivedAmount = Convert.ToDecimal(objDataReader["ReceivedAmount"].ToString());
                        }
                        break;
                    case "CurrentDue":
                        if (!Convert.IsDBNull(objDataReader["CurrentDue"]))
                        {
                            objPurchaseLedger.CurrentDue = Convert.ToDecimal(objDataReader["CurrentDue"].ToString());
                        }
                        break;
                    case "TotalBalance":
                        if (!Convert.IsDBNull(objDataReader["TotalBalance"]))
                        {
                            objPurchaseLedger.TotalBalance = Convert.ToDecimal(objDataReader["TotalBalance"].ToString());
                        }
                        break;
                    case "DueAmount":
                        if (!Convert.IsDBNull(objDataReader["DueAmount"]))
                        {
                            objPurchaseLedger.DueAmount = Convert.ToDecimal(objDataReader["DueAmount"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objPurchaseLedger.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objPurchaseLedger.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objPurchaseLedger.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objPurchaseLedger.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objPurchaseLedger.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objPurchaseLedger.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objPurchaseLedger.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string CreatePurchaseLedger(PurchaseLedger objPurchaseLedger)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("SupplierId", objPurchaseLedger.SupplierId);
            objDbCommand.AddInParameter("InvoiceNumber", objPurchaseLedger.InvoiceNumber);
            objDbCommand.AddInParameter("TransactionType", objPurchaseLedger.TransactionType);
            objDbCommand.AddInParameter("ReceivedAmount", objPurchaseLedger.ReceivedAmount);
            objDbCommand.AddInParameter("CurrentDue", objPurchaseLedger.CurrentDue);
            objDbCommand.AddInParameter("TotalBalance", objPurchaseLedger.TotalBalance);
            objDbCommand.AddInParameter("CreatedBy", objPurchaseLedger.CreatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreatePurchaseLedger]", CommandType.StoredProcedure);

                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successful";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Save Failed";
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

        public PurchaseLedger GetSingleInvoiceDetail(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            PurchaseLedger objPurchaseLedger = new PurchaseLedger();
            List<PurchaseLedger> objPurchaseLedgerList = new List<PurchaseLedger>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSingleInvoiceDetailForPL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objPurchaseLedger = new PurchaseLedger();
                        this.BuildModelForPurchaseLedger(objDbDataReader, objPurchaseLedger);

                        objPurchaseLedgerList.Add(objPurchaseLedger);
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

            return objPurchaseLedger;
        }
    }
}
