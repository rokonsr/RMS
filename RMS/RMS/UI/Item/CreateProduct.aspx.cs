using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class CreateProduct : BasePage
    {
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
        private Product objProduct;
        private ProductBiz objProductBiz;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownForFirstCategory();
                PopulateDropDownForSecondCategory();
                PopulateDropDownForThirdCategory();
                PopulateDropDownForBrand();
                PopulateDropDownForRegion();
                PopulateDropDownForMeasurement();
                PopulateDropDownForFoodSchedule();
            }
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

            ddlFirstCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
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

            ddlSecondCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
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

            ddlThirdCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
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
            
            ddlRegion.Items.Insert(0, new ListItem("--Select Region--", "0"));
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

            ddlBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
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

            ddlMeasurement.Items.Insert(0, new ListItem("--Select Measurement--", "0"));
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

            ddlFoodSchedule.Items.Insert(0, new ListItem("--Select Food Schedule--", "0"));
        }

        protected void ddlFirstCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFirstCategory.SelectedIndex > 0)
            {
                ddlSecondCategory.Enabled = true;
                PopulateDropDownForSecondCategory();
            }
            else
            {
                ddlSecondCategory.SelectedIndex = 0;
                ddlSecondCategory.Enabled = false;
                ddlThirdCategory.SelectedIndex = 0;
                ddlThirdCategory.Enabled = false;
                ddlRegion.SelectedIndex = 0;
                ddlRegion.Enabled = false;
                txtProductName.Text = string.Empty;
            }
        }

        protected void ddlSecondCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSecondCategory.SelectedIndex > 0)
            {
                ddlThirdCategory.Enabled = true;
                PopulateDropDownForThirdCategory();
                FoodName();
            }
            else
            {
                ddlThirdCategory.SelectedIndex = 0;
                ddlThirdCategory.Enabled = false;
                ddlRegion.SelectedIndex = 0;
                ddlRegion.Enabled = false;
                txtProductName.Text = string.Empty;
            }
        }

        protected void ddlThirdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlThirdCategory.SelectedIndex > 0)
            {
                ddlRegion.Enabled = true;
                PopulateDropDownForRegion();
                FoodName();
            }
            else
            {
                ddlRegion.SelectedIndex = 0;
                ddlRegion.Enabled = false;
                FoodName();
            }
        }

        protected void ddlRegion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            FoodName();
        }

        // Create product name from categories
        private void FoodName()
        {
            string foodName = ddlSecondCategory.SelectedItem.Text + " " + ddlThirdCategory.SelectedItem.Text + " - " + ddlRegion.SelectedItem.Text;

            txtProductName.Text = foodName;
        }

        protected void btnCreateProduct_OnClick(object sender, EventArgs e)
        {
            if (InsertProduct())
            {
                ClearInputs(Controls);
            }
        }

        // Create new product with image
        private bool InsertProduct()
        {
            objProduct = new Product();
            objProductBiz = new ProductBiz();

            HttpPostedFile postedFile = flProductImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif")
            {
                if (fileSize > 524288)
                {
                    MessageBox("Image size should not be more than 512 Kbps");
                }
                else
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    objProduct.ProductImageName = fileName;
                    objProduct.ProductImageSize = fileSize;
                    objProduct.ProductImage = bytes;
                    
                    objProduct.ProductName = txtProductName.Text.Trim();
                    objProduct.ProductDescription = txtProductDescription.Text.Trim();
                    objProduct.RegionId = Convert.ToByte(ddlRegion.SelectedItem.Value);
                    objProduct.FirstCategoryId = Convert.ToInt16(ddlFirstCategory.SelectedItem.Value);
                    objProduct.SecondCategoryId = Convert.ToInt16(ddlSecondCategory.SelectedItem.Value);
                    objProduct.ThirdCategoryId = Convert.ToInt16(ddlThirdCategory.SelectedItem.Value);
                    objProduct.BrandId = Convert.ToInt16(ddlBrand.SelectedItem.Value);
                    objProduct.MeasurementId = Convert.ToByte(ddlMeasurement.SelectedItem.Value);
                    objProduct.ProductSellPrice = Convert.ToDecimal(txtSellPrice.Text.Trim());
                    objProduct.Vat = Convert.ToDecimal(txtVatOnProduct.Text.Trim());
                    objProduct.FoodScheduleId = Convert.ToByte(ddlFoodSchedule.SelectedItem.Value);
                    objProduct.CreatedBy = Convert.ToInt16(Session["UserId"]);

                    MessageBox(objProductBiz.CreateProduct(objProduct));
                }
            }
            else
            {
                MessageBox("Please upload valid (jpg, png, gif & bmp) picture");
            }

            return true;
        }

        protected void btnResetProduct_OnClick(object sender, EventArgs e)
        {
            ClearInputs(Controls);
            ddlSecondCategory.Enabled = false;
            ddlThirdCategory.Enabled = false;
            ddlRegion.Enabled = false;
        }
    }
}