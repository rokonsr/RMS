using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using RMS.Model;
using RMS.DAL;

namespace RMS.BLL
{
    public class NavigationMenuBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private object objLoginUser;

        private void BuildModelForMenu(DbDataReader objDataReader, NavigationMenu objNavigationMenu)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "MenuId":
                        if (!Convert.IsDBNull(objDataReader["MenuId"]))
                        {
                            objNavigationMenu.MenuId = Convert.ToByte(objDataReader["MenuId"]);
                        }
                        break;
                    case "MenuName":
                        if (!Convert.IsDBNull(objDataReader["MenuName"]))
                        {
                            objNavigationMenu.MenuName = objDataReader["MenuName"].ToString();
                        }
                        break;
                    case "MenuClassName":
                        if (!Convert.IsDBNull(objDataReader["MenuClassName"]))
                        {
                            objNavigationMenu.MenuName = objDataReader["MenuClassName"].ToString();
                        }
                        break;

                    case "MenuLevel":
                        if (!Convert.IsDBNull(objDataReader["MenuLevel"]))
                        {
                            objNavigationMenu.MenuLevel = Convert.ToByte(objDataReader["MenuLevel"].ToString());
                        }
                        break;
                    case "MenuPath":
                        if (!Convert.IsDBNull(objDataReader["MenuPath"]))
                        {
                            objNavigationMenu.MenuPath = objDataReader["MenuPath"].ToString();
                        }
                        break;
                    case "ParentId":
                        if (!Convert.IsDBNull(objDataReader["ParentId"]))
                        {
                            objNavigationMenu.ParentId = Convert.ToByte(objDataReader["ParentId"]);
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objNavigationMenu.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objNavigationMenu.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objNavigationMenu.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objNavigationMenu.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objNavigationMenu.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objNavigationMenu.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objNavigationMenu.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        public byte GetMenuId(string menuClassName)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;

            NavigationMenu objNavigationMenu = new NavigationMenu();
            try
            {
                objDbCommand.AddInParameter("MenuClassName", menuClassName);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetMenuIdByMenuClassName]", CommandType.StoredProcedure);



                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {

                        this.BuildModelForMenu(objDbDataReader, objNavigationMenu);

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

            return objNavigationMenu.MenuId;
        }

        public List<NavigationMenu> GetMenuTvList(int loginId, int roleId)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<NavigationMenu> objMenuList = new List<NavigationMenu>();
            NavigationMenu objNavigationMenu;

            try
            {
                objDbCommand.AddInParameter("LoginId", loginId);
                objDbCommand.AddInParameter("RoleId", roleId);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].uspTvMenuRoleManagement", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objNavigationMenu = new NavigationMenu();
                        this.BuildModelForMenu(objDbDataReader, objNavigationMenu);
                        objMenuList.Add(objNavigationMenu);
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

            return objMenuList;
        }

        public List<NavigationMenu> GetMenuList(UserInfo objLoginUserId)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<NavigationMenu> objMenuList = new List<NavigationMenu>();
            NavigationMenu objNavigationMenu;
            try
            {
                objDbCommand.AddInParameter("LoginId", objLoginUserId.UserId);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetMenuByRole]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objNavigationMenu = new NavigationMenu();
                        this.BuildModelForMenu(objDbDataReader, objNavigationMenu);
                        objMenuList.Add(objNavigationMenu);
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

            return objMenuList;
        }

        public List<NavigationMenu> GetTvListForRoleMenuMapping(int roleId)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<NavigationMenu> objMenuList = new List<NavigationMenu>();
            NavigationMenu objNavigationMenu;

            try
            {
                objDbCommand.AddInParameter("RoleId", roleId);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].uspGetTvListForRoleMenuMapping", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objNavigationMenu = new NavigationMenu();
                        this.BuildModelForMenu(objDbDataReader, objNavigationMenu);
                        objMenuList.Add(objNavigationMenu);
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

            return objMenuList;
        }
    }
}
