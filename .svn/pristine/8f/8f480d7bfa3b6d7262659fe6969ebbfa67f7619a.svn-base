using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class SaleReturnBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModelForProduct(DbDataReader objDataReader, Product objProduct)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "ProductId":
                        if (!Convert.IsDBNull(objDataReader["ProductId"]))
                        {
                            objProduct.ProductId = Convert.ToInt16(objDataReader["ProductId"]);
                        }
                        break;
                    case "ProductName":
                        if (!Convert.IsDBNull(objDataReader["ProductName"]))
                        {
                            objProduct.ProductName = objDataReader["ProductName"].ToString();
                        }
                        break;
                    case "ProductDescription":
                        if (!Convert.IsDBNull(objDataReader["ProductDescription"]))
                        {
                            objProduct.ProductDescription = objDataReader["ProductDescription"].ToString();
                        }
                        break;
                    case "RegionId":
                        if (!Convert.IsDBNull(objDataReader["RegionId"]))
                        {
                            objProduct.RegionId = Convert.ToByte(objDataReader["RegionId"].ToString());
                        }
                        break;
                    case "FirstCategoryId":
                        if (!Convert.IsDBNull(objDataReader["FirstCategoryId"]))
                        {
                            objProduct.FirstCategoryId = Convert.ToInt16(objDataReader["FirstCategoryId"].ToString());
                        }
                        break;
                    case "SecondCategoryId":
                        if (!Convert.IsDBNull(objDataReader["SecondCategoryId"]))
                        {
                            objProduct.SecondCategoryId = Convert.ToInt16(objDataReader["SecondCategoryId"].ToString());
                        }
                        break;
                    case "ThirdCategoryId":
                        if (!Convert.IsDBNull(objDataReader["ThirdCategoryId"]))
                        {
                            objProduct.ThirdCategoryId = Convert.ToInt16(objDataReader["ThirdCategoryId"].ToString());
                        }
                        break;
                    case "BrandId":
                        if (!Convert.IsDBNull(objDataReader["BrandId"]))
                        {
                            objProduct.BrandId = Convert.ToInt16(objDataReader["BrandId"].ToString());
                        }
                        break;
                    case "MeasurementId":
                        if (!Convert.IsDBNull(objDataReader["MeasurementId"]))
                        {
                            objProduct.MeasurementId = Convert.ToByte(objDataReader["MeasurementId"].ToString());
                        }
                        break;
                    case "ProductStock":
                        if (!Convert.IsDBNull(objDataReader["ProductStock"]))
                        {
                            objProduct.ProductStock = Convert.ToDecimal(objDataReader["ProductStock"].ToString());
                        }
                        break;
                    case "ProductSellPrice":
                        if (!Convert.IsDBNull(objDataReader["ProductSellPrice"]))
                        {
                            objProduct.ProductSellPrice = Convert.ToDecimal(objDataReader["ProductSellPrice"].ToString());
                        }
                        break;
                    case "Vat":
                        if (!Convert.IsDBNull(objDataReader["Vat"]))
                        {
                            objProduct.Vat = Convert.ToDecimal(objDataReader["Vat"].ToString());
                        }
                        break;
                    case "FoodScheduleId":
                        if (!Convert.IsDBNull(objDataReader["FoodScheduleId"]))
                        {
                            objProduct.FoodScheduleId = Convert.ToByte(objDataReader["FoodScheduleId"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objProduct.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objProduct.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objProduct.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objProduct.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objProduct.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objProduct.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objProduct.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public void ReturnProduct(SaleReturn objSaleReturn)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            int noOfAffacted = 0;
            objDbCommand.AddInParameter("InvoiceNumber", objSaleReturn.InvoiceNumber);
            objDbCommand.AddInParameter("ProductId", objSaleReturn.ProductId);
            objDbCommand.AddInParameter("ReturnQuantity", objSaleReturn.ReturnQuantity);
            objDbCommand.AddInParameter("UserId", objSaleReturn.CreatedBy);
            objDbCommand.AddInParameter("Remarks", objSaleReturn.Remarks??(object)DBNull.Value);
            
            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspReturnSale]", CommandType.StoredProcedure);
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

