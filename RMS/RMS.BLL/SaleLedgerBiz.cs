using RMS.DAL;
using RMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RMS.BLL
{
    //--Created by Ataur-->
    public class SaleLedgerBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForSaleLedger(DbDataReader objDataReader, SaleLedger objSaleLedger)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "SaleLedgerId":
                        if (!Convert.IsDBNull(objDataReader["SaleLedgerId"]))
                        {
                            objSaleLedger.SaleLedgerId = Convert.ToInt16(objDataReader["SaleLedgerId"]);
                        }
                        break;
                    case "CustomerId":
                        if (!Convert.IsDBNull(objDataReader["CustomerId"]))
                        {
                            objSaleLedger.CustomerId = Convert.ToInt16(objDataReader["CustomerId"]);
                        }
                        break;
                    case "InvoiceNumber":
                        if (!Convert.IsDBNull(objDataReader["InvoiceNumber"]))
                        {
                            objSaleLedger.InvoiceNumber = Convert.ToString(objDataReader["InvoiceNumber"].ToString());
                        }
                        break;
                    case "TransactionType":
                        if (!Convert.IsDBNull(objDataReader["TransactionType"]))
                        {
                            objSaleLedger.TransactionType = Convert.ToByte(objDataReader["TransactionType"].ToString());
                        }
                        break;
                    case "ReceivedAmount":
                        if (!Convert.IsDBNull(objDataReader["ReceivedAmount"]))
                        {
                            objSaleLedger.ReceivedAmount = Convert.ToDecimal(objDataReader["ReceivedAmount"].ToString());
                        }
                        break;
                    case "CurrentDue":
                        if (!Convert.IsDBNull(objDataReader["CurrentDue"]))
                        {
                            objSaleLedger.CurrentDue = Convert.ToDecimal(objDataReader["CurrentDue"].ToString());
                        }
                        break;
                    case "TotalBalance":
                        if (!Convert.IsDBNull(objDataReader["TotalBalance"]))
                        {
                            objSaleLedger.TotalBalance = Convert.ToDecimal(objDataReader["TotalBalance"].ToString());
                        }
                        break;
                    case "CustomerUsername":
                        if (!Convert.IsDBNull(objDataReader["CustomerUsername"]))
                        {
                            objSaleLedger.CustomerUsername = objDataReader["CustomerUsername"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objSaleLedger.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objSaleLedger.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objSaleLedger.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objSaleLedger.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objSaleLedger.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objSaleLedger.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objSaleLedger.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public SaleLedger GetSaleLedgerInfoForSL(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;

            SaleLedger objSaleLedger = new SaleLedger();
            List<SaleLedger> objPurchaseLedgerList = new List<SaleLedger>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSingleInvoiceDetailForSL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSaleLedger = new SaleLedger();
                        this.BuildModelForSaleLedger(objDbDataReader, objSaleLedger);

                        objPurchaseLedgerList.Add(objSaleLedger);
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

            return objSaleLedger;
        }

        public SaleLedger GetSaleLedgerInfoByCustomerUsername(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;

            SaleLedger objSaleLedger = new SaleLedger();
            List<SaleLedger> objPurchaseLedgerList = new List<SaleLedger>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSingleCustomerDetailForSL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSaleLedger = new SaleLedger();
                        this.BuildModelForSaleLedger(objDbDataReader, objSaleLedger);

                        objPurchaseLedgerList.Add(objSaleLedger);
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

            return objSaleLedger;
        }

        public string CreateSaleLedger(SaleLedger objSaleLedger)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("CustomerId", objSaleLedger.CustomerId);
            objDbCommand.AddInParameter("InvoiceNumber", objSaleLedger.InvoiceNumber);
            objDbCommand.AddInParameter("TransactionType", objSaleLedger.TransactionType);
            objDbCommand.AddInParameter("ReceivedAmount", objSaleLedger.ReceivedAmount);
            objDbCommand.AddInParameter("CurrentDue", objSaleLedger.CurrentDue);
            objDbCommand.AddInParameter("TotalBalance", objSaleLedger.TotalBalance);
            objDbCommand.AddInParameter("CreatedBy", objSaleLedger.CreatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateSaleLedger]", CommandType.StoredProcedure);

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

        //public PurchaseLedger GetSingleInvoiceDetail(string searchText)
        //{
        //    objDataAccess = DataAccess.NewDataAccess();
        //    objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
        //    DbDataReader objDbDataReader = null;
        //    SaleLedger objSaleLedger = new SaleLedger();
        //    List<SaleLedger> objSaleLedgerList = new List<SaleLedger>();

        //    try
        //    {
        //        objDbCommand.AddInParameter("SearchText", searchText);
        //        objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSingleInvoiceDetailForPL]", CommandType.StoredProcedure);

        //        if (objDbDataReader.HasRows)
        //        {
        //            while (objDbDataReader.Read())
        //            {
        //                objSaleLedger = new SaleLedger();
        //                this.BuildModelForSaleLedger(objDbDataReader, objSaleLedger);

        //                objSaleLedgerList.Add(objSaleLedger);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error : " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (objDbDataReader != null)
        //        {
        //            objDbDataReader.Close();
        //        }
        //        objDataAccess.Dispose(objDbCommand);
        //    }

        //    return objSaleLedger;
        //}
    }
}

