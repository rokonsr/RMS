using System;
using System.Data;
using RMS.DAL;
using System.Data.Common;
using RMS.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RMS.BLL
{
    public class MeasurementBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForMeasurement(DbDataReader objDataReader, Measurement objMeasurement)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "MeasurementId":
                        if (!Convert.IsDBNull(objDataReader["MeasurementId"]))
                        {
                            objMeasurement.MeasurementId = Convert.ToByte(objDataReader["MeasurementId"]);
                        }
                        break;
                    case "MeasurementName":
                        if (!Convert.IsDBNull(objDataReader["MeasurementName"]))
                        {
                            objMeasurement.MeasurementName = objDataReader["MeasurementName"].ToString();
                        }
                        break;
                    case "MeasurementDescription":
                        if (!Convert.IsDBNull(objDataReader["MeasurementDescription"]))
                        {
                            objMeasurement.MeasurementDescription = objDataReader["MeasurementDescription"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objMeasurement.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objMeasurement.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objMeasurement.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objMeasurement.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objMeasurement.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objMeasurement.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objMeasurement.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public List<Measurement> GetMeasurementList() //Rokon
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Measurement> objMeasurementList = new List<Measurement>();
            Measurement objMeasurement;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetMeasurementForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objMeasurement = new Measurement();
                        this.BuildModelForMeasurement(objDbDataReader, objMeasurement);
                        objMeasurementList.Add(objMeasurement);
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

            return objMeasurementList;
        }

        public string CreateMeasurementName(Measurement objMeasurement)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("MeasurementName",objMeasurement.MeasurementName);
            objDbCommand.AddInParameter("MeasurementDescription",objMeasurement.MeasurementDescription);
            objDbCommand.AddInParameter("CreatedByUserId",objMeasurement.CreatedBy);

            SqlParameter retValue=new SqlParameter("return",SqlDbType.Bit);
            retValue.Direction=ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retValue);
            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateMeasurementName]", CommandType.StoredProcedure);
                byte spReturnValue = Convert.ToByte(retValue.Value);
                if (spReturnValue==1)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successfull.";
                }
                else if (spReturnValue==0)
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
                throw new Exception("Database error",ex);
            }
            finally
            {
               objDataAccess.Dispose(objDbCommand); 
            }
        }

        public DataTable GetMeasurementForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            objDbCommand.AddInParameter("SearchText",searchText);
            DataTable dtMeasurement=new DataTable();

            try
            {
                dtMeasurement = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetMeasurementForUpdate]",CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
            return dtMeasurement;

        }

        public bool UpdateMesurement(Measurement objMeasurement) //create by Enamul
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("MeasurementId", objMeasurement.MeasurementId);
            objDbCommand.AddInParameter("MeasurementName", objMeasurement.MeasurementName);
            objDbCommand.AddInParameter("MeasurementDescription",objMeasurement.MeasurementDescription);
            objDbCommand.AddInParameter("IsActive", objMeasurement.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objMeasurement.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateMeasurement]", CommandType.StoredProcedure);
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
