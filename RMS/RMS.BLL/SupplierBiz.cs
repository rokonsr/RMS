using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    //--Created By Ataur-->
    public class SupplierBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForSupplier(DbDataReader objDataReader, Supplier objSupplier)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "SupplierId":
                        if (!Convert.IsDBNull(objDataReader["SupplierId"]))
                        {
                            objSupplier.SupplierId = Convert.ToInt16(objDataReader["SupplierId"]);
                        }
                        break;
                    case "SupplierName":
                        if (!Convert.IsDBNull(objDataReader["SupplierName"]))
                        {
                            objSupplier.SupplierName = objDataReader["SupplierName"].ToString();
                        }
                        break;
                    case "SupplierContactPerson":
                        if (!Convert.IsDBNull(objDataReader["SupplierContactPerson"]))
                        {
                            objSupplier.SupplierContactPerson = objDataReader["SupplierContactPerson"].ToString();
                        }
                        break;
                    case "SupplierDescription":
                        if (!Convert.IsDBNull(objDataReader["SupplierDescription"]))
                        {
                            objSupplier.SupplierDescription = objDataReader["SupplierDescription"].ToString();
                        }
                        break;
                    case "SupplierAddress":
                        if (!Convert.IsDBNull(objDataReader["SupplierAddress"]))
                        {
                            objSupplier.SupplierAddress = objDataReader["SupplierAddress"].ToString();
                        }
                        break;
                    case "UserEmail":
                        if (!Convert.IsDBNull(objDataReader["SupplierContactNo"]))
                        {
                            objSupplier.SupplierContactNo = objDataReader["SupplierContactNo"].ToString();
                        }
                        break;
                    case "SupplierEmail":
                        if (!Convert.IsDBNull(objDataReader["SupplierEmail"]))
                        {
                            objSupplier.SupplierEmail = objDataReader["SupplierEmail"].ToString();
                        }
                        break;
                    case "SupplierReference":
                        if (!Convert.IsDBNull(objDataReader["SupplierReference"]))
                        {
                            objSupplier.SupplierReference = objDataReader["SupplierReference"].ToString();
                        }
                        break;
                    case "SupplierReferenceContactNo":
                        if (!Convert.IsDBNull(objDataReader["SupplierReferenceContactNo"]))
                        {
                            objSupplier.SupplierReferenceContactNo = objDataReader["SupplierReferenceContactNo"].ToString();
                        }
                        break;
                    case "SupplierDue":
                        if (!Convert.IsDBNull(objDataReader["SupplierDue"]))
                        {
                            objSupplier.SupplierDue = Convert.ToDecimal(objDataReader["SupplierDue"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objSupplier.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objSupplier.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objSupplier.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objSupplier.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objSupplier.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objSupplier.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objSupplier.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public List<Supplier> GetSupplierList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Supplier> objSupplierList = new List<Supplier>();
            Supplier objSupplier;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSupplierForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSupplier = new Supplier();
                        this.BuildModelForSupplier(objDbDataReader, objSupplier);
                        objSupplierList.Add(objSupplier);
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

            return objSupplierList;
        }

        public string CreateSupplierInfo(Supplier objSupplier)
        {
            int noOfAffacted = 0;
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("SupplierName", objSupplier.SupplierName);
            objDbCommand.AddInParameter("SupplierContactPerson", objSupplier.SupplierContactPerson);
            objDbCommand.AddInParameter("SupplierDescription", objSupplier.SupplierDescription);
            objDbCommand.AddInParameter("SupplierAddress", objSupplier.SupplierAddress);
            objDbCommand.AddInParameter("SupplierContactNo", objSupplier.SupplierContactNo);
            objDbCommand.AddInParameter("SupplierEmail", objSupplier.SupplierEmail);
            objDbCommand.AddInParameter("SupplierReference", objSupplier.SupplierReference);
            objDbCommand.AddInParameter("SupplierReferenceContactNo", objSupplier.SupplierReferenceContactNo);
            objDbCommand.AddInParameter("CreatedByUserId", objSupplier.CreatedBy);
            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);

            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateSupplierInfo]", CommandType.StoredProcedure);

                byte spreturnvalue = Convert.ToByte(retval.Value);

                if (spreturnvalue == 1)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successful";

                }
                else if (spreturnvalue == 0)
                {
                    objDbCommand.Transaction.Rollback();
                    return "Already Exists!";
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
     
        public void UpdateSupplierInfo(Supplier objSupplier)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("SupplierId", objSupplier.SupplierId);
            objDbCommand.AddInParameter("SupplierName", objSupplier.SupplierName);
            objDbCommand.AddInParameter("SupplierContactPerson", objSupplier.SupplierContactPerson);
            objDbCommand.AddInParameter("SupplierDescription", objSupplier.SupplierDescription);
            objDbCommand.AddInParameter("SupplierAddress", objSupplier.SupplierAddress);
            objDbCommand.AddInParameter("SupplierContactNo", objSupplier.SupplierContactNo);
            objDbCommand.AddInParameter("SupplierEmail", objSupplier.SupplierEmail);
            objDbCommand.AddInParameter("SupplierReference", objSupplier.SupplierReference);
            objDbCommand.AddInParameter("SupplierReferenceContactNo", objSupplier.SupplierReferenceContactNo);
            objDbCommand.AddInParameter("IsActive", objSupplier.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objSupplier.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateSupplierInfo]", CommandType.StoredProcedure);
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
        }

        public DataTable GetSupplierListForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetSupplierInfoForUpdateGv]", CommandType.StoredProcedure);
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

        public Supplier GetSupplierDue(string selectedValue)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            Supplier objSupplier = new Supplier();
            List<Supplier> objSupplierList = new List<Supplier>();

            try
            {
                objDbCommand.AddInParameter("SupplierId", selectedValue);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSupplierDue]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objSupplier = new Supplier();
                        this.BuildModelForSupplier(objDbDataReader, objSupplier);

                        objSupplierList.Add(objSupplier);
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

            return objSupplier;
        }
    }
}
