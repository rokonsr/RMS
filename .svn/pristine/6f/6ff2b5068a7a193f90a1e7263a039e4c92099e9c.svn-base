using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    //--Created By Ataur-->
    public class CustomerBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModelForCustomer(DbDataReader objDataReader, Customer objCustomer)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "CustomerId":
                        if (!Convert.IsDBNull(objDataReader["CustomerId"]))
                        {
                            objCustomer.CustomerId = Convert.ToInt32(objDataReader["CustomerId"]);
                        }
                        break;
                    case "CustomerUsername":
                        if (!Convert.IsDBNull(objDataReader["CustomerUsername"]))
                        {
                            objCustomer.CustomerUsername = objDataReader["CustomerUsername"].ToString();
                        }
                        break;
                    case "CustomerPassword":
                        if (!Convert.IsDBNull(objDataReader["CustomerPassword"]))
                        {
                            objCustomer.CustomerPassword = objDataReader["CustomerPassword"].ToString();
                        }
                        break;
                    case "CustomerContactNumber":
                        if (!Convert.IsDBNull(objDataReader["CustomerContactNumber"]))
                        {
                            objCustomer.CustomerContactNumber =objDataReader["CustomerContactNumber"].ToString();
                        }
                        break;
                    case "CustomerFullName":
                        if (!Convert.IsDBNull(objDataReader["CustomerFullName"]))
                        {
                            objCustomer.CustomerFullName = objDataReader["CustomerFullName"].ToString();
                        }
                        break;
                    case "CustomerDescription":
                        if (!Convert.IsDBNull(objDataReader["CustomerDescription"]))
                        {
                            objCustomer.CustomerDescription = objDataReader["CustomerDescription"].ToString();
                        }
                        break;
                    case "CustomerAddress":
                        if (!Convert.IsDBNull(objDataReader["CustomerAddress"]))
                        {
                            objCustomer.CustomerAddress = objDataReader["CustomerAddress"].ToString();
                        }
                        break;
                    case "CustomerEmail":
                        if (!Convert.IsDBNull(objDataReader["CustomerEmail"]))
                        {
                            objCustomer.CustomerEmail = objDataReader["CustomerEmail"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objCustomer.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objCustomer.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objCustomer.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objCustomer.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objCustomer.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objCustomer.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objCustomer.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public string CreateCustomerInfo(Customer objCustomer)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("CustomerUsername", objCustomer.CustomerUsername);
            objDbCommand.AddInParameter("CustomerPassword", objCustomer.CustomerPassword);
            objDbCommand.AddInParameter("CustomerContactNumber", objCustomer.CustomerContactNumber);
            objDbCommand.AddInParameter("CustomerFullName", objCustomer.CustomerFullName);
            objDbCommand.AddInParameter("CustomerDescription", objCustomer.CustomerDescription);
            objDbCommand.AddInParameter("CustomerAddress", objCustomer.CustomerAddress);
            objDbCommand.AddInParameter("CustomerEmail", objCustomer.CustomerEmail);
            objDbCommand.AddInParameter("CreatedByUserId", objCustomer.CreatedBy);

            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);

            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateCustomerInfo]", CommandType.StoredProcedure);

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
        public DataTable GetCustomerInfoForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetCustomerInfoForUpdateGv]",
                    CommandType.StoredProcedure);
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
        public void UpdateCustomerInfo(Customer objCustomer)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("CustomerId", objCustomer.CustomerId);
            objDbCommand.AddInParameter("CustomerUsername", objCustomer.CustomerUsername);
            objDbCommand.AddInParameter("CustomerContactNumber", objCustomer.CustomerContactNumber);
            objDbCommand.AddInParameter("CustomerFullName",objCustomer.CustomerFullName);
            objDbCommand.AddInParameter("CustomerDescription",objCustomer.CustomerDescription);
            objDbCommand.AddInParameter("CustomerAddress",objCustomer.CustomerAddress);
            objDbCommand.AddInParameter("CustomerEmail",objCustomer.CustomerEmail);
            objDbCommand.AddInParameter("IsActive", objCustomer.IsActive);
            objDbCommand.AddInParameter("UpdatedByUserId", objCustomer.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateCustomerInfo]",
                    CommandType.StoredProcedure);
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

        public void ChangeCustomerPasswordByAdmin(Customer objCustomer)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            
            objDbCommand.AddInParameter("CustomerUsername", objCustomer.CustomerUsername);
            objDbCommand.AddInParameter("NewPassword",objCustomer.CustomerPassword);                            
            objDbCommand.AddInParameter("UpdatedByUserId", objCustomer.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateCustomerPasswordByAdmin]",
                    CommandType.StoredProcedure);
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
    }
}
