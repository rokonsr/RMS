using RMS.DAL;
using System;
using System.Data;
using System.Data.Common;
using RMS.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RMS.BLL
{
    public class DesignationBiz
    {
           //Created by Ataur

        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForDesignation(DbDataReader objDataReader, Designation objDesignation)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "DesignationId":
                        if (!Convert.IsDBNull(objDataReader["DesignationId"]))
                        {
                            objDesignation.DesignationId = Convert.ToByte(objDataReader["DesignationId"]);
                        }
                        break;
                    case "DesignationName":
                        if (!Convert.IsDBNull(objDataReader["DesignationName"]))
                        {
                            objDesignation.DesignationName = objDataReader["DesignationName"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objDesignation.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objDesignation.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objDesignation.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objDesignation.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objDesignation.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objDesignation.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objDesignation.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public List<Designation> GetDesignationList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Designation> objDesignationList = new List<Designation>();
            Designation objDesignation;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetDesignationForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objDesignation = new Designation();
                        this.BuildModelForDesignation(objDbDataReader, objDesignation);
                        objDesignationList.Add(objDesignation);
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

            return objDesignationList;
        }

        public string CreateDesignation(Designation objDesignation)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("DesignationName", objDesignation.DesignationName);
            objDbCommand.AddInParameter("CurrentUserId", objDesignation.UserId);

            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);

            try
            {
               objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateDesignation]", CommandType.StoredProcedure);
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

        public bool UpdateDesignation(Designation objDesignation)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("DesignationId",objDesignation.DesignationId);
            objDbCommand.AddInParameter("DesignationName", objDesignation.DesignationName);
            objDbCommand.AddInParameter("IsActive", objDesignation.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objDesignation.UpdatedBy);
            

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateDesignation]", CommandType.StoredProcedure);
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

        public DataTable GetDesignation(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dtDesignation=new DataTable();
            objDbCommand.AddInParameter("SearchText", searchText);
            try
            {
                dtDesignation = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetDesignationForUpdate]", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dtDesignation;
        }
    }
}
