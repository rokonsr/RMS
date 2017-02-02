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
    //updated by Enamul
    public class RegionBiz
    {
        private IDataAccess obDataAccess;
        private DbCommand objDbCommand;
        private IDataAccess objDataAccess;

        private void BuildModelForRegion(DbDataReader objDataReader, Region objRegion)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "RegionId":
                        if (!Convert.IsDBNull(objDataReader["RegionId"]))
                        {
                            objRegion.RegionId = Convert.ToByte(objDataReader["RegionId"]);
                        }
                        break;
                    case "RegionName":
                        if (!Convert.IsDBNull(objDataReader["RegionName"]))
                        {
                            objRegion.RegionName = objDataReader["RegionName"].ToString();
                        }
                        break;
                    case "RegionDescription":
                        if (!Convert.IsDBNull(objDataReader["RegionDescription"]))
                        {
                            objRegion.RegionDescription = objDataReader["RegionDescription"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objRegion.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objRegion.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objRegion.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objRegion.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objRegion.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objRegion.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objRegion.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public List<Region> GetRegionList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Region> objRegionList = new List<Region>();
            Region objRegion;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetRegionForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objRegion = new Region();
                        this.BuildModelForRegion(objDbDataReader, objRegion);
                        objRegionList.Add(objRegion);
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

            return objRegionList;
        }

        public string CreateRegionName(Region objRegion)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("RegionName", objRegion.RegionName);
            objDbCommand.AddInParameter("RegionDescription", objRegion.RegionDescription);
            objDbCommand.AddInParameter("CreatedBy", objRegion.CreatedBy);

            SqlParameter retValue = new SqlParameter("return", SqlDbType.Bit);
            retValue.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retValue);
            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateRegionName]", CommandType.StoredProcedure);
                byte spReturnValue = Convert.ToByte(retValue.Value);
                if (spReturnValue == 1)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successfull.";
                }
                else if (spReturnValue == 0)
                {
                    objDbCommand.Transaction.Rollback();
                    return "Already Exists!";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Save Fail!";
                }

            }
            catch (Exception ex)
            {

                objDbCommand.Transaction.Rollback();
                throw new Exception("Database error", ex);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
        }

        public DataTable GetRegionForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            objDbCommand.AddInParameter("SearchText", searchText);
            DataTable dtRegion = new DataTable();

            try
            {
                dtRegion = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetRegionForUpdate]", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
            return dtRegion;
        }

        public bool UpdateRegion(Region objRegion)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("RegionId", objRegion.RegionId);
            objDbCommand.AddInParameter("RegionName", objRegion.RegionName);
            objDbCommand.AddInParameter("RegionDescription", objRegion.RegionDescription);
            objDbCommand.AddInParameter("IsActive", objRegion.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objRegion.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateRegion]", CommandType.StoredProcedure);
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
