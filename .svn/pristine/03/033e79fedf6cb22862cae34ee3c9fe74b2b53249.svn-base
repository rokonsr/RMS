using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class PageDetailBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForLabel(DbDataReader objDataReader, PageDetail objPageDetail)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "MenuDtlId":
                        if (!Convert.IsDBNull(objDataReader["MenuDtlId"]))
                        {
                            objPageDetail.MenuDetailId = Convert.ToByte(objDataReader["MenuDtlId"]);
                        }
                        break;
                    case "MenuId":
                        if (!Convert.IsDBNull(objDataReader["MenuId"]))
                        {
                            objPageDetail.MenuId = Convert.ToByte(objDataReader["MenuId"].ToString());
                        }
                        break;

                    case "HeaderLabel":
                        if (!Convert.IsDBNull(objDataReader["HeaderLabel"]))
                        {
                            objPageDetail.HeaderLabel = objDataReader["HeaderLabel"].ToString();
                        }
                        break;
                    case "FooterLabel":
                        if (!Convert.IsDBNull(objDataReader["FooterLabel"]))
                        {
                            objPageDetail.FooterLabel = objDataReader["FooterLabel"].ToString();
                        }
                        break;
                    case "Description":
                        if (!Convert.IsDBNull(objDataReader["Description"]))
                        {
                            objPageDetail.Description = objDataReader["Description"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objPageDetail.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objPageDetail.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objPageDetail.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objPageDetail.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objPageDetail.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objPageDetail.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objPageDetail.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public List<PageDetail> GetLabelByMenuId(int MenuId)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            List<PageDetail> objUserList = new List<PageDetail>();
            PageDetail objPageDetail;
            try
            {
                objDbCommand.AddInParameter("MenuId", MenuId);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetTitlebyMenuId]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objPageDetail = new PageDetail();
                        this.BuildModelForLabel(objDbDataReader, objPageDetail);
                        objUserList.Add(objPageDetail);
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

            return objUserList;
        }
    }
}
