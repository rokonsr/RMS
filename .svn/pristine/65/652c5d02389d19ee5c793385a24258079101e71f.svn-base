using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class CategoryBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForCategory(DbDataReader objDataReader, Category objCategory)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "CategoryId":
                        if (!Convert.IsDBNull(objDataReader["CategoryId"]))
                        {
                            objCategory.CategoryId = Convert.ToInt16(objDataReader["CategoryId"]);
                        }
                        break;
                    case "CategoryName":
                        if (!Convert.IsDBNull(objDataReader["CategoryName"]))
                        {
                            objCategory.CategoryName = objDataReader["CategoryName"].ToString();
                        }
                        break;
                    case "CategoryDescription":
                        if (!Convert.IsDBNull(objDataReader["CategoryDescription"]))
                        {
                            objCategory.CategoryDescription = objDataReader["CategoryDescription"].ToString();
                        }
                        break;
                    case "CategoryLevel":
                        if (!Convert.IsDBNull(objDataReader["CategoryLevel"]))
                        {
                            objCategory.CategoryLevel = Convert.ToByte(objDataReader["CategoryLevel"].ToString());
                        }
                        break;
                    case "CategoryParentId":
                        if (!Convert.IsDBNull(objDataReader["CategoryParentId"]))
                        {
                            objCategory.CategoryParentId = Convert.ToInt16(objDataReader["CategoryParentId"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objCategory.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objCategory.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objCategory.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objCategory.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objCategory.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objCategory.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objCategory.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // Update category details
        public void EditCategory(Category objCategory)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("CategoryId", objCategory.CategoryId);
            objDbCommand.AddInParameter("CategoryName", objCategory.CategoryName);
            objDbCommand.AddInParameter("SecondCategoryId", objCategory.SecondCategoryId);
            objDbCommand.AddInParameter("SecondCategoryName", objCategory.SecondCategoryName);
            objDbCommand.AddInParameter("ThirdCategoryId", objCategory.ThirdCategoryId);
            objDbCommand.AddInParameter("ThirdCategoryName", objCategory.ThirdCategoryName);
            objDbCommand.AddInParameter("CategoryDescription", objCategory.CategoryDescription);
            objDbCommand.AddInParameter("CategoryStatus", objCategory.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objCategory.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateCategoryInfo]", CommandType.StoredProcedure);

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

        // Display category details in gridview on update category page
        public DataTable GetCategoryListForGv(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetCategoryForUpdateGv]", CommandType.StoredProcedure);
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

        // Get first category as a dropdown list
        public List<Category> GetCategoryList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Category> objCategoryList = new List<Category>();
            Category objCategory;
            
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetFirstCategoryForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objCategory = new Category();
                        this.BuildModelForCategory(objDbDataReader, objCategory);
                        objCategoryList.Add(objCategory);
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

            return objCategoryList;
        }

        // Get third category as a dropdown list
        public List<Category> AllThirdCategoryList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Category> objCategoryList = new List<Category>();
            Category objCategory;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspAllThirdCategory]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objCategory = new Category();
                        this.BuildModelForCategory(objDbDataReader, objCategory);
                        objCategoryList.Add(objCategory);
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

            return objCategoryList;
        }

        // Get second category as a dropdown list
        public List<Category> AllSecondCategoryList()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Category> objCategoryList = new List<Category>();
            Category objCategory;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspAllSecondCategory]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objCategory = new Category();
                        this.BuildModelForCategory(objDbDataReader, objCategory);
                        objCategoryList.Add(objCategory);
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

            return objCategoryList;
        }

        // Get second category with parameter as a dropdown list
        public List<Category> GetCategoryList(Category objCategoryParentId)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            objDbCommand.AddInParameter("ParentId", objCategoryParentId.CategoryParentId);
            DbDataReader objDbDataReader = null;
            List<Category> objCategoryList = new List<Category>();
            Category objCategory;

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetSecondCategoryForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objCategory = new Category();
                        this.BuildModelForCategory(objDbDataReader, objCategory);
                        objCategoryList.Add(objCategory);
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

            return objCategoryList;
        }

        // Create first category
        public string CreateFirstCategory(Category objCategory)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("CategoryLevel", objCategory.CategoryLevel);
            objDbCommand.AddInParameter("FirstCategoryName", objCategory.CategoryName);
            objDbCommand.AddInParameter("CategoryDescription", objCategory.CategoryDescription);
            objDbCommand.AddInParameter("CurrentUserId", objCategory.CreatedBy);
            
            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);
            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateFirstCategory]", CommandType.StoredProcedure);
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

        // Create subcategory (second & third)
        public string CreateSubCategory(Category objCategory)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("CategoryLevel", objCategory.CategoryLevel);
            objDbCommand.AddInParameter("FirstCategoryName", objCategory.CategoryName);
            objDbCommand.AddInParameter("CategoryDescription", objCategory.CategoryDescription);
            objDbCommand.AddInParameter("ParentId", objCategory.CategoryParentId);
            objDbCommand.AddInParameter("CurrentUserId", objCategory.CreatedBy);

            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);
            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateSubCategory]", CommandType.StoredProcedure);
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
    }
}
