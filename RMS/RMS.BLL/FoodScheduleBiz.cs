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
    public class FoodScheduleBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForFoodSchedule(DbDataReader objDataReader, FoodSchedule objFoodSchedule)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "FoodScheduleId":
                        if (!Convert.IsDBNull(objDataReader["FoodScheduleId"]))
                        {
                            objFoodSchedule.FoodScheduleId = Convert.ToByte(objDataReader["FoodScheduleId"]);
                        }
                        break;
                    case "FoodScheduleName":
                        if (!Convert.IsDBNull(objDataReader["FoodScheduleName"]))
                        {
                            objFoodSchedule.FoodScheduleName = objDataReader["FoodScheduleName"].ToString();
                        }
                        break;
                    case "ScheduleDescription":
                        if (!Convert.IsDBNull(objDataReader["ScheduleDescription"]))
                        {
                            objFoodSchedule.ScheduleDescription = objDataReader["ScheduleDescription"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objFoodSchedule.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objFoodSchedule.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objFoodSchedule.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objFoodSchedule.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objFoodSchedule.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objFoodSchedule.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objFoodSchedule.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string CreateFoodScheduleInfo(FoodSchedule objFoodSchedule)
        {

            int noOfAffacted = 0;
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("FoodScheduleName", objFoodSchedule.FoodScheduleName);
            objDbCommand.AddInParameter("ScheduleDescription", objFoodSchedule.ScheduleDescription);
            objDbCommand.AddInParameter("CreatedByUserId", objFoodSchedule.CreatedBy);
            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);

            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateFoodScheduleInfo]",
                    CommandType.StoredProcedure);

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

        public List<FoodSchedule> GetFoodScheduleList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<FoodSchedule> objFoodScheduleList = new List<FoodSchedule>();
            FoodSchedule objFoodSchedule;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetFoodScheduleForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objFoodSchedule = new FoodSchedule();
                        this.BuildModelForFoodSchedule(objDbDataReader, objFoodSchedule);
                        objFoodScheduleList.Add(objFoodSchedule);
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

            return objFoodScheduleList;
        }

        public DataTable GetFoodScheduleListForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetFoodScheduleInfoForUpdateGv]",
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

        public void UpdateFoodScheduleInfo(FoodSchedule objFoodSchedule)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("FoodScheduleId", objFoodSchedule.FoodScheduleId);
            objDbCommand.AddInParameter("FoodScheduleName", objFoodSchedule.FoodScheduleName);
            objDbCommand.AddInParameter("ScheduleDescription", objFoodSchedule.ScheduleDescription);
            objDbCommand.AddInParameter("IsActive", objFoodSchedule.IsActive);
            objDbCommand.AddInParameter("UpdatedByUserId", objFoodSchedule.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateFoodScheduleInfo]",
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
