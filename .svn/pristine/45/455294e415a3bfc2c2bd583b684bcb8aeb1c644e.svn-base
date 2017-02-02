using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class ProductBiz
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
                    case "MeasurementName":
                        if (!Convert.IsDBNull(objDataReader["MeasurementName"]))
                        {
                            objProduct.MeasurementName = objDataReader["MeasurementName"].ToString();
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
                    case "PurchasePrice":
                        if (!Convert.IsDBNull(objDataReader["PurchasePrice"]))
                        {
                            objProduct.PurchasePrice = Convert.ToDecimal(objDataReader["PurchasePrice"].ToString());
                        }
                        break;
                    case "PurchaseQuantity":
                        if (!Convert.IsDBNull(objDataReader["PurchaseQuantity"]))
                        {
                            objProduct.PurchaseQuantity = Convert.ToDecimal(objDataReader["PurchaseQuantity"].ToString());
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

        public Product AddProductDetailsForRP(string searchText, string invoiceNumber)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            Product objProduct = new Product();
            List<Product> objProductList = new List<Product>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbCommand.AddInParameter("InvoiceNumber", invoiceNumber);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductDetailsForPR]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProduct = new Product();
                        this.BuildModelForProduct(objDbDataReader, objProduct);

                        objProductList.Add(objProduct);
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

            return objProduct;
        }

        // Display all the product details in gridview on update product page
        public DataTable GetProductList(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            DataTable dt = new DataTable();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[rdb].[uspGetProductNameForGv]", CommandType.StoredProcedure);
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

        // Create new product
        public string CreateProduct(Product objProduct)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("ProductName", objProduct.ProductName);
            objDbCommand.AddInParameter("ProductDescription", objProduct.ProductDescription);
            objDbCommand.AddInParameter("ImageName", objProduct.ProductImageName);
            objDbCommand.AddInParameter("ImageSize", objProduct.ProductImageSize);
            objDbCommand.AddInParameter("ProductImage", objProduct.ProductImage);
            objDbCommand.AddInParameter("RegionId", objProduct.RegionId);
            objDbCommand.AddInParameter("FirstCategoryId", objProduct.FirstCategoryId);
            objDbCommand.AddInParameter("SecondCategoryId", objProduct.SecondCategoryId);
            objDbCommand.AddInParameter("ThirdCategoryId", objProduct.ThirdCategoryId);
            objDbCommand.AddInParameter("BrandId", objProduct.BrandId);
            objDbCommand.AddInParameter("MeasurementId", objProduct.MeasurementId);
            objDbCommand.AddInParameter("SellPrice", objProduct.ProductSellPrice);
            objDbCommand.AddInParameter("Vat", objProduct.Vat);
            objDbCommand.AddInParameter("FoodScheduleId", objProduct.FoodScheduleId);
            objDbCommand.AddInParameter("UserId", objProduct.CreatedBy);

            SqlParameter retval = new SqlParameter("return", SqlDbType.Bit);
            retval.Direction = ParameterDirection.ReturnValue;
            objDbCommand.Parameters.Add(retval);

            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspCreateProduct]", CommandType.StoredProcedure);
                byte spreturnvalue = Convert.ToByte(retval.Value);

                if (spreturnvalue == 1)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successfully";
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

        // Edit product details
        public void EditUpdate(Product objProduct)
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("ProductId", objProduct.ProductId);
            objDbCommand.AddInParameter("RegionId", objProduct.RegionId);
            objDbCommand.AddInParameter("ImageName", objProduct.ProductImageName);
            objDbCommand.AddInParameter("ImageSize", objProduct.ProductImageSize);
            objDbCommand.AddInParameter("ProductImage", objProduct.ProductImage);
            objDbCommand.AddInParameter("FirstCategoryId", objProduct.FirstCategoryId);
            objDbCommand.AddInParameter("SecondCategoryId", objProduct.SecondCategoryId);
            objDbCommand.AddInParameter("ThirdCategoryId", objProduct.ThirdCategoryId);
            objDbCommand.AddInParameter("ProductName", objProduct.ProductName);
            objDbCommand.AddInParameter("ProductDescription", objProduct.ProductDescription);
            objDbCommand.AddInParameter("BrandId", objProduct.BrandId);
            objDbCommand.AddInParameter("MeasurementId", objProduct.MeasurementId);
            objDbCommand.AddInParameter("SellPrice", objProduct.ProductSellPrice);
            objDbCommand.AddInParameter("Vat", objProduct.Vat);
            objDbCommand.AddInParameter("FoodScheduleId", objProduct.FoodScheduleId);
            objDbCommand.AddInParameter("ProductStatus", objProduct.IsActive);
            objDbCommand.AddInParameter("UpdatedBy", objProduct.UpdatedBy);

            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "[rdb].[uspUpdateProduct]", CommandType.StoredProcedure);

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

        public Product AddProductForPurchase(string searchText)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            Product objProduct = new Product();
            List<Product> objProductList = new List<Product>();

            try
            {
                objDbCommand.AddInParameter("SearchText", searchText);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[rdb].[uspGetProductNameForGv]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objProduct = new Product();
                        this.BuildModelForProduct(objDbDataReader, objProduct);

                        objProductList.Add(objProduct);
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

            return objProduct;
        }
    }
}
