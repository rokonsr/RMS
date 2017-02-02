using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class RoleBiz
    {
        //Created by Ataur
        //update by Enamul
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModelForRole(DbDataReader objDataReader, Role objRole)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "RoleId":
                        if (!Convert.IsDBNull(objDataReader["RoleId"]))
                        {
                            objRole.RoleId = Convert.ToByte(objDataReader["RoleId"]);
                        }
                        break;
                    case "RoleName":
                        if (!Convert.IsDBNull(objDataReader["RoleName"]))
                        {
                            objRole.RoleName = objDataReader["RoleName"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objRole.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objRole.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objRole.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objRole.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objRole.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objRole.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objRole.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public string AssignUserRole(Role objRole)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("UserId", objRole.UserId);
            objDbCommand.AddInParameter("RoleId", objRole.RoleId);
            objDbCommand.AddInParameter("CreatedByUserId", objRole.CreatedBy);

            try
            {            
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateUserRoleMapping]", CommandType.StoredProcedure);
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
        public string CreateRole(Role objRole) //updated by enamul
        {
            
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("RoleName", objRole.RoleName);
            objDbCommand.AddInParameter("CurrentUserId", objRole.UserId);
            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);
            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateRole]", CommandType.StoredProcedure);
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

        public string UnAssignRoleMenuMapping(Role objRole)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("RoleId", objRole.RoleId);
            objDbCommand.AddInParameter("UpdatedByUserId", objRole.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUnAssignRoleMenuMapping]", CommandType.StoredProcedure);
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

        public string AssignRoleMenuMapping(Role objRole)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("RoleId", objRole.RoleId);
            objDbCommand.AddInParameter("MenuId", objRole.MenuId);
            objDbCommand.AddInParameter("CreatedByUserId", objRole.CreatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspAssignRoleMenuMapping]", CommandType.StoredProcedure);
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

        public List<Role> GetRoleListForDDL()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<Role> objRoleList = new List<Role>();
            Role objRole;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetRoleForDDL]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objRole = new Role();
                        this.BuildModelForRole(objDbDataReader, objRole);
                        objRoleList.Add(objRole);
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

            return objRoleList;
        }
        public DataTable GetUserRoleInfo(Role objRole)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                //objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetRoleInfoForGv]", CommandType.StoredProcedure);
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

        public string UpdateRole(Role objRole)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("RoleId", objRole.RoleId);
            objDbCommand.AddInParameter("RoleName", objRole.RoleName);
            objDbCommand.AddInParameter("isActive", objRole.IsActive);
            objDbCommand.AddInParameter("UpdatedByUserId", objRole.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateRole]", CommandType.StoredProcedure);
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

        public string AssignUserRoleAndMenu(Role objRole)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("UserId", objRole.UserId);
            objDbCommand.AddInParameter("RoleId", objRole.RoleId);
            objDbCommand.AddInParameter("MenuId", objRole.MenuId);
            objDbCommand.AddInParameter("CreatedBy", objRole.UserId);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspAssignUserRoleAndMenu]", CommandType.StoredProcedure);

                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Assign Role Successfully";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Assign Role Failed";
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

        public string UnAssignUserRoleAndMenu(Role objRole)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("UserId", objRole.UserId);
            objDbCommand.AddInParameter("RoleId", objRole.RoleId);
            objDbCommand.AddInParameter("UpdatedBy", objRole.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUnAssignUserRoleAndMenu]", CommandType.StoredProcedure);

                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Update Successful";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Update Failed";
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
