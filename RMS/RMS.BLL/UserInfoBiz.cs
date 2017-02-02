using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    //--Created By Ataur-->
    public class UserInfoBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForUserInfo(DbDataReader objDataReader, UserInfo objUserInfo)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "UserId":
                        if (!Convert.IsDBNull(objDataReader["UserId"]))
                        {
                            objUserInfo.UserId = Convert.ToInt16(objDataReader["UserId"]);
                        }
                        break;
                    case "Username":
                        if (!Convert.IsDBNull(objDataReader["Username"]))
                        {
                            objUserInfo.Username = objDataReader["Username"].ToString();
                        }
                        break;
                    case "UserPassword":
                        if (!Convert.IsDBNull(objDataReader["UserPassword"]))
                        {
                            objUserInfo.UserPassword = objDataReader["UserPassword"].ToString();
                        }
                        break;
                    case "DesignationId":
                        if (!Convert.IsDBNull(objDataReader["DesignationId"]))
                        {
                            objUserInfo.DesignationId = Convert.ToByte(objDataReader["DesignationId"].ToString());
                        }
                        break;
                    case "UserFullName":
                        if (!Convert.IsDBNull(objDataReader["UserFullName"]))
                        {
                            objUserInfo.UserFullName = objDataReader["UserFullName"].ToString();
                        }
                        break;
                    case "UserEmail":
                        if (!Convert.IsDBNull(objDataReader["UserEmail"]))
                        {
                            objUserInfo.UserEmail = objDataReader["UserEmail"].ToString();
                        }
                        break;
                    case "UserPhoneNo":
                        if (!Convert.IsDBNull(objDataReader["UserPhoneNo"]))
                        {
                            objUserInfo.UserPhoneNo = objDataReader["UserPhoneNo"].ToString();
                        }
                        break;
                    case "UserAddress":
                        if (!Convert.IsDBNull(objDataReader["UserAddress"]))
                        {
                            objUserInfo.UserAddress = objDataReader["UserAddress"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objUserInfo.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objUserInfo.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objUserInfo.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objUserInfo.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objUserInfo.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objUserInfo.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objUserInfo.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public DataTable GetUserForUpdateUser(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetUserInfoForUpdateGv]", CommandType.StoredProcedure);
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

        public UserInfo GetLoginInfo(string userName, string password)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            UserInfo objLoginUser = null;
            objDbCommand.AddInParameter("Username", userName);
            objDbCommand.AddInParameter("Password", password);
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspCheckUser]", CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objLoginUser = new UserInfo();
                        this.BuildModelForUserInfo(objDbDataReader, objLoginUser);
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

            return objLoginUser;
        }

        public string CreateUserInfo(UserInfo objUserInfo) //update by Enamul
        {
            

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("Username", objUserInfo.Username);
            objDbCommand.AddInParameter("UserPassword", objUserInfo.UserPassword);
            objDbCommand.AddInParameter("UserDesignationId", objUserInfo.DesignationId);
            objDbCommand.AddInParameter("UserFullName", objUserInfo.UserFullName);
            objDbCommand.AddInParameter("UserEmail", objUserInfo.UserEmail);
            objDbCommand.AddInParameter("UserPhone", objUserInfo.UserPhoneNo);
            objDbCommand.AddInParameter("UserAddress", objUserInfo.UserAddress);
            objDbCommand.AddInParameter("CurrentUserId", objUserInfo.UserId);
            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);

            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateUserInfo]", CommandType.StoredProcedure);

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

        public DataTable GetUserForAssignRole(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetUserInfoForGv]", CommandType.StoredProcedure);
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

        public void UpdateUserInfo(UserInfo objUserInfo)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("UserId",objUserInfo.UserId );
            objDbCommand.AddInParameter("Username", objUserInfo.Username);
            objDbCommand.AddInParameter("DesignationId", objUserInfo.DesignationId);
            objDbCommand.AddInParameter("UserFullName", objUserInfo.UserFullName);
            objDbCommand.AddInParameter("UserEmail", objUserInfo.UserEmail);
            objDbCommand.AddInParameter("UserPhoneNo", objUserInfo.UserPhoneNo);
            objDbCommand.AddInParameter("UserAddress", objUserInfo.UserAddress);
            objDbCommand.AddInParameter("IsActive", objUserInfo.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objUserInfo.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateUserInfo]", CommandType.StoredProcedure);
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

        public void UpdateUserStatus(UserInfo objUserInfo)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("UserId", objUserInfo.UserId);
            objDbCommand.AddInParameter("IsActive", objUserInfo.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objUserInfo.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateUserStatus]", CommandType.StoredProcedure);
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
