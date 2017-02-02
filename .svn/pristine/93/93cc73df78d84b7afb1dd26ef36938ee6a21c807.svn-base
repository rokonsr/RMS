using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class BrandBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModelForBrand(DbDataReader objDataReader, Brand objBrand)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "BrandId":
                        if (!Convert.IsDBNull(objDataReader["BrandId"]))
                        {
                            objBrand.BrandId = Convert.ToInt16(objDataReader["BrandId"]);
                        }
                        break;
                    case "BrandName":
                        if (!Convert.IsDBNull(objDataReader["BrandName"]))
                        {
                            objBrand.BrandName = objDataReader["BrandName"].ToString();
                        }
                        break;
                    case "BrandDescription":
                        if (!Convert.IsDBNull(objDataReader["BrandDescription"]))
                        {
                            objBrand.BrandDescription = objDataReader["BrandDescription"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objBrand.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objBrand.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objBrand.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objBrand.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objBrand.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objBrand.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objBrand.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public List<Brand> GetBrandList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Brand> objBrandList = new List<Brand>();
            Brand objBrand;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetBrandForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objBrand = new Brand();
                        this.BuildModelForBrand(objDbDataReader, objBrand);
                        objBrandList.Add(objBrand);
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

            return objBrandList;
        }

        public string CreateBrandName(Brand objBrand)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("BrandName", objBrand.BrandName);
            objDbCommand.AddInParameter("BrandDescription", objBrand.BrandDescription);
            objDbCommand.AddInParameter("CreatedBy", objBrand.CreatedBy);

            SqlParameter retValue = new SqlParameter("return", SqlDbType.Bit);
            retValue.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retValue);
            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateBrandName]", CommandType.StoredProcedure);
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

        public DataTable GetBrandForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            objDbCommand.AddInParameter("SearchText", searchText);
            DataTable dtBrand = new DataTable();

            try
            {
                dtBrand = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetBrandForUpdate]", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
            return dtBrand;
        }

        public bool UpdateBrand(Brand objBrand)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("BrandId", objBrand.BrandId);
            objDbCommand.AddInParameter("BrandName", objBrand.BrandName);
            objDbCommand.AddInParameter("BrandDescription", objBrand.BrandDescription);
            objDbCommand.AddInParameter("IsActive", objBrand.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objBrand.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateBrand]", CommandType.StoredProcedure);
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
