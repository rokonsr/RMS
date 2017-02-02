
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class UpdateProduct : BasePage
    {
        private Product objProduct;
        private ProductBiz objProductBiz;
        private Category objCategory;
        private List<Category> objCategoryList;
        private CategoryBiz objCategoryBiz;
        private List<Measurement> objMeasurementList;
        private MeasurementBiz objMeasurementBiz;
        private List<Brand> objBrandList;
        private BrandBiz objBrandBiz;
        private List<Region> objRegionList;
        private RegionBiz objRegionBiz;
        private List<FoodSchedule> objFoodScheduleList;
        private FoodScheduleBiz objFoodScheduleBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewBindProductInfo();
        }

        private void GridViewBindProductInfo()
        {
            objProductBiz = new ProductBiz();
            DataTable dtProduct = new DataTable();
            dtProduct = objProductBiz.GetProductList(txtProductName.Text.Trim());
            gvDisplayProduct.DataSource = dtProduct;
            gvDisplayProduct.DataBind();
            gvDisplayProduct.ShowHeaderWhenEmpty = true;
            gvDisplayProduct.EmptyDataText = "No data found";

            gvDisplayProduct.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayProduct.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;

            txtProductName.Attributes.Add("onfocus", "this.select()");
            txtProductName.Focus();
        }

        private void PopulateDropDownForFirstCategory()
        {
            List<Category> objCategoryList = new List<Category>();
            objCategoryBiz = new CategoryBiz();

            objCategoryList = objCategoryBiz.GetCategoryList();
            ddlFirstCategory.DataSource = objCategoryList;
            ddlFirstCategory.DataValueField = "CategoryId";
            ddlFirstCategory.DataTextField = "CategoryName";
            ddlFirstCategory.DataBind();
        }

        private void PopulateDropDownForSecondCategory()
        {
            objCategory = new Category();

            List<Category> objCategoryList = new List<Category>();
            objCategoryBiz = new CategoryBiz();
            objCategory.CategoryParentId = Convert.ToInt16(ddlFirstCategory.SelectedValue);
            objCategoryList = objCategoryBiz.GetCategoryList(objCategory);
            ddlSecondCategory.DataSource = objCategoryList;
            ddlSecondCategory.DataValueField = "CategoryId";
            ddlSecondCategory.DataTextField = "CategoryName";
            ddlSecondCategory.DataBind();
        }

        private void PopulateDropDownForThirdCategory()
        {
            objCategory = new Category();

            List<Category> objCategoryList = new List<Category>();
            objCategoryBiz = new CategoryBiz();
            objCategory.CategoryParentId = Convert.ToInt16(ddlSecondCategory.SelectedValue);
            objCategoryList = objCategoryBiz.GetCategoryList(objCategory);
            ddlThirdCategory.DataSource = objCategoryList;
            ddlThirdCategory.DataValueField = "CategoryId";
            ddlThirdCategory.DataTextField = "CategoryName";
            ddlThirdCategory.DataBind();
        }

        private void PopulateDropDownForRegion()
        {
            List<Region> objRegionList = new List<Region>();
            objRegionBiz = new RegionBiz();

            objRegionList = objRegionBiz.GetRegionList();
            ddlRegion.DataSource = objRegionList;
            ddlRegion.DataValueField = "RegionId";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
        }

        private void PopulateDropDownForBrand()
        {
            List<Brand> objBrandList = new List<Brand>();
            objBrandBiz = new BrandBiz();

            objBrandList = objBrandBiz.GetBrandList();
            ddlBrand.DataSource = objBrandList;
            ddlBrand.DataValueField = "BrandId";
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataBind();
        }

        private void PopulateDropDownForMeasurement()
        {
            List<Measurement> objMeasurementList = new List<Measurement>();
            objMeasurementBiz = new MeasurementBiz();

            objMeasurementList = objMeasurementBiz.GetMeasurementList();
            ddlMeasurement.DataSource = objMeasurementList;
            ddlMeasurement.DataTextField = "MeasurementName";
            ddlMeasurement.DataValueField = "MeasurementId";
            ddlMeasurement.DataBind();
        }

        private void PopulateDropDownForFoodSchedule()
        {
            List<FoodSchedule> objFoodScheduleList = new List<FoodSchedule>();
            objFoodScheduleBiz = new FoodScheduleBiz();

            objFoodScheduleList = objFoodScheduleBiz.GetFoodScheduleList();
            ddlFoodSchedule.DataSource = objFoodScheduleList;
            ddlFoodSchedule.DataValueField = "FoodScheduleId";
            ddlFoodSchedule.DataTextField = "FoodScheduleName";
            ddlFoodSchedule.DataBind();
        }

        protected void gvDisplayProduct_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvDisplayProduct.PageIndex = e.NewPageIndex;
            GridViewBindProductInfo();
        }

        protected void gvDisplayProduct_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ModalUpdateProduct.Show();

            PopulateDropDownForFirstCategory();
            DropDownAllSecondCategory();
            DropDownAllThirdCategory();

            PopulateDropDownForBrand();
            PopulateDropDownForRegion();
            PopulateDropDownForMeasurement();
            PopulateDropDownForFoodSchedule();

            GridViewRow row = gvDisplayProduct.SelectedRow;

            ddlRegion.SelectedValue = gvDisplayProduct.DataKeys[row.RowIndex].Values[1].ToString();

            ddlFirstCategory.ClearSelection();
            ddlFirstCategory.Items.FindByText(gvDisplayProduct.SelectedRow.Cells[3].Text).Selected = true;
            ddlSecondCategory.ClearSelection();
            ddlSecondCategory.Items.FindByText(gvDisplayProduct.SelectedRow.Cells[4].Text).Selected = true;
            ddlThirdCategory.ClearSelection();
            ddlThirdCategory.Items.FindByText(gvDisplayProduct.SelectedRow.Cells[5].Text).Selected = true;
            txtUpdateProductName.Text = gvDisplayProduct.SelectedRow.Cells[0].Text;
            txtUpdateProductDescription.Text = gvDisplayProduct.SelectedRow.Cells[1].Text == "&nbsp;" ? "" : gvDisplayProduct.SelectedRow.Cells[1].Text;
            ddlBrand.SelectedValue = gvDisplayProduct.DataKeys[row.RowIndex].Values[2].ToString();
            ddlMeasurement.SelectedValue = gvDisplayProduct.DataKeys[row.RowIndex].Values[3].ToString();
            txtProductStock.Text = gvDisplayProduct.SelectedRow.Cells[8].Text;
            txtSellPrice.Text = gvDisplayProduct.SelectedRow.Cells[9].Text;
            txtUpdateVat.Text = gvDisplayProduct.SelectedRow.Cells[10].Text;
            ddlFoodSchedule.SelectedValue = gvDisplayProduct.DataKeys[row.RowIndex].Values[4].ToString();
            ddlUpdateProductStatus.SelectedValue = gvDisplayProduct.DataKeys[row.RowIndex].Values[5].ToString();

            ddlSecondCategory.Enabled = false;
            ddlThirdCategory.Enabled = false;
        }

        private void DropDownAllSecondCategory()
        {
            List<Category> objCategoryList = new List<Category>();
            objCategoryBiz = new CategoryBiz();

            objCategoryList = objCategoryBiz.AllSecondCategoryList();
            ddlSecondCategory.DataSource = objCategoryList;
            ddlSecondCategory.DataValueField = "CategoryId";
            ddlSecondCategory.DataTextField = "CategoryName";
            ddlSecondCategory.DataBind();
        }

        private void DropDownAllThirdCategory()
        {
            List<Category> objCategoryList = new List<Category>();
            objCategoryBiz = new CategoryBiz();

            objCategoryList = objCategoryBiz.AllThirdCategoryList();
            ddlThirdCategory.DataSource = objCategoryList;
            ddlThirdCategory.DataValueField = "CategoryId";
            ddlThirdCategory.DataTextField = "CategoryName";
            ddlThirdCategory.DataBind();
        }

        protected void gvDisplayProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[12].Text == "Inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            GridViewBindProductInfo();
        }

        protected void ddlRegion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            FoodName();
        }

        protected void ddlFirstCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFirstCategory.SelectedIndex >= 0)
            {
                PopulateDropDownForSecondCategory();
                ddlSecondCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                PopulateDropDownForThirdCategory();
                ddlThirdCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                FoodName();
                ddlSecondCategory.Enabled = true;
            }
        }

        protected void ddlSecondCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSecondCategory.SelectedIndex != 0)
            {
                PopulateDropDownForThirdCategory();
                ddlThirdCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                FoodName();
                ddlThirdCategory.Enabled = true;
            }
            else
            {
                ddlThirdCategory.Enabled = false;
            }
        }

        protected void ddlThirdCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlThirdCategory.SelectedIndex >= 0)
            {
                FoodName();
            }
        }

        // Create product from categories
        private void FoodName()
        {
            string foodName = ddlSecondCategory.SelectedItem.Text + " " + ddlThirdCategory.SelectedItem.Text + " - " + ddlRegion.SelectedItem.Text;

            txtUpdateProductName.Text = foodName;
        }

        protected void btnUpdateProduct_OnClick(object sender, EventArgs e)
        {
            if (EditUpdate())
            {
                GridViewBindProductInfo();
            }
        }

        // Update product details with image
        private bool EditUpdate()
        {
            objProduct = new Product();
            objProductBiz = new ProductBiz();

            HttpPostedFile postedFile = flUpdateProductImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileSize == 0)
            {
                if (fileSize > 524288)
                {
                    MessageBox("Image size should not be more than 512 Kbps");
                    ModalUpdateProduct.Show();
                }
                else
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    objProduct.ProductImageName = fileName;
                    objProduct.ProductImageSize = fileSize;
                    objProduct.ProductImage = bytes;

                    GridViewRow row = gvDisplayProduct.SelectedRow;

                    objProduct.ProductId = Convert.ToInt16(gvDisplayProduct.DataKeys[row.RowIndex].Values[0].ToString());
                    objProduct.RegionId = Convert.ToByte(ddlRegion.SelectedValue);
                    objProduct.FirstCategoryId = Convert.ToInt16(ddlFirstCategory.SelectedValue);
                    objProduct.SecondCategoryId = Convert.ToInt16(ddlSecondCategory.SelectedValue);
                    objProduct.ThirdCategoryId = Convert.ToInt16(ddlThirdCategory.SelectedValue);
                    objProduct.ProductName = txtUpdateProductName.Text.Trim();
                    objProduct.ProductDescription = txtUpdateProductDescription.Text.Trim();
                    objProduct.BrandId = Convert.ToInt16(ddlBrand.SelectedValue);
                    objProduct.MeasurementId = Convert.ToByte(ddlMeasurement.SelectedValue);
                    objProduct.ProductSellPrice = Convert.ToDecimal(txtSellPrice.Text.Trim());
                    objProduct.Vat = Convert.ToDecimal(txtUpdateVat.Text.Trim());
                    objProduct.FoodScheduleId = Convert.ToByte(ddlFoodSchedule.SelectedValue);
                    objProduct.IsActive = Convert.ToBoolean(ddlUpdateProductStatus.SelectedValue);
                    objProduct.UpdatedBy = Convert.ToInt16(Session["UserId"]);

                    objProductBiz.EditUpdate(objProduct);
                }
            }
            else
            {
                MessageBox("Please upload valid (jpg, png, gif & bmp) picture");
                ModalUpdateProduct.Show();
            }

            return true;
        }
    }
}