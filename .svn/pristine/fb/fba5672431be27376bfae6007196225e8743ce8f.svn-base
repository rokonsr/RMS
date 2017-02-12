using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class CreateCategory : BasePage
    {
        private Category objCategory;
        private List<Category> objCategoryList; 
        private CategoryBiz objCategoryBiz;
        private List<Measurement> objMeasurementList;
        private MeasurementBiz objMeasurementBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PopulateDropDownForMeasurement();

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

        protected void btnAddFirstCategory_Click(object sender, EventArgs e)
        {
            if (CreateFirstCategory())
            {
                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;
            }
        }

        private bool CreateFirstCategory()
        {
            objCategory = new Category();
            objCategoryBiz = new CategoryBiz();

            objCategory.CategoryLevel = Convert.ToByte(ddlCategoryType.SelectedValue);
            objCategory.CategoryName = txtCategoryName.Text.Trim();
            objCategory.CategoryDescription = txtCategoryDescription.Text.Trim();
            objCategory.CreatedBy = Convert.ToInt16(Session["UserId"]);

            MessageBox(objCategoryBiz.CreateFirstCategory(objCategory));

            return true;
        }

        protected void ddlCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoryType.SelectedIndex == 1)
            {
                pnlCreateCategory.Visible = true;
                pnlSubCategory.Controls.Clear();
                pnlSubCategory.Visible = false;
                btnAddFirstCategory.Visible = true;
                btnAddSecondCategory.Visible = false;
                btnAddThirdCategory.Visible = false;
            }
            else if (ddlCategoryType.SelectedIndex == 2)
            {
                pnlSubCategory.Visible = true;

                PopulateDropDownForFirstCategory();
                pnlCreateCategory.Visible = true;
                btnAddFirstCategory.Visible = true;
                btnAddSecondCategory.Visible = false;
                btnAddThirdCategory.Visible = false;
            }
            else if (ddlCategoryType.SelectedIndex == 0)
            {
                pnlCreateCategory.Controls.Clear();
                pnlCreateCategory.Visible = false;
                pnlSubCategory.Controls.Clear();
                pnlSubCategory.Visible = false;
            }
        }

        protected void ddlFirstCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFirstCategory.SelectedIndex > 0)
            {
                pnlCreateCategory.Visible = true;
                btnAddSecondCategory.Visible = true;
                btnAddThirdCategory.Visible = false;
                btnAddFirstCategory.Visible = false;

                PopulateDropDownForSecondCategory();

                if (ddlSecondCategory.Items.Count > 1)
                {
                    ddlSecondCategory.Visible = true;
                }
                else
                {
                    ddlSecondCategory.Controls.Clear();
                    ddlSecondCategory.Visible = false;
                }
            }
            else
            {
                ddlSecondCategory.Controls.Clear();
                ddlSecondCategory.Visible = false;
                ddlThirdCategory.Controls.Clear();
                ddlThirdCategory.Visible = false;
                btnAddThirdCategory.Visible = false;
                btnAddFirstCategory.Visible = true;
                btnAddSecondCategory.Visible = false;
            }
        }

        protected void ddlSecondCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFirstCategory.SelectedIndex > 0 & ddlSecondCategory.SelectedIndex > 0)
            {
                pnlCreateCategory.Visible = true;
                btnAddThirdCategory.Visible = true;
                btnAddFirstCategory.Visible = false;
                btnAddSecondCategory.Visible = false;

                PopulateDropDownForThirdCategory();

                if (ddlThirdCategory.Items.Count > 1)
                {
                    ddlThirdCategory.Visible = true;
                }
                else
                {
                    ddlThirdCategory.Controls.Clear();
                    ddlThirdCategory.Visible = false;
                }
            }
            else
            {
                ddlThirdCategory.Visible = false;
                ddlThirdCategory.Controls.Clear();
                btnAddThirdCategory.Visible = false;
                btnAddFirstCategory.Visible = false;
                btnAddSecondCategory.Visible = true;
                pnlCreateCategory.Visible = true;
            }
        }

        protected void ddlThirdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlThirdCategory.SelectedIndex > 0)
            {
                pnlCreateCategory.Visible = false;
            }
            else
            {
                pnlCreateCategory.Visible = true;
            }
        }

        protected void btnAddSecondCategory_Click(object sender, EventArgs e)
        {
           
            if (CreateSecondCategory())
            {
                PopulateDropDownForSecondCategory();
                ddlSecondCategory.Visible = true;                                
                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;
            }
        }

        // Create second category
        private bool CreateSecondCategory()
        {
            objCategory = new Category();
            objCategoryBiz = new CategoryBiz();

            objCategory.CategoryLevel = 2; // Hardcoded value the category level
            objCategory.CategoryName = txtCategoryName.Text.Trim();
            objCategory.CategoryDescription = txtCategoryDescription.Text.Trim();
            objCategory.CategoryParentId = Convert.ToInt16(ddlFirstCategory.SelectedValue);
            objCategory.CreatedBy = Convert.ToInt16(Session["UserId"]);

            MessageBox(objCategoryBiz.CreateSubCategory(objCategory));

            return true;
        }

        protected void btnAddThirdCategory_Click(object sender, EventArgs e)
        {
            
            if (CreateThirdCategory())
            {
                PopulateDropDownForThirdCategory();
                ddlThirdCategory.Visible = true;
                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;
            }
        }

        // Create third category
        private bool CreateThirdCategory()
        {
            objCategory = new Category();
            objCategoryBiz = new CategoryBiz();

            objCategory.CategoryLevel = 3; // Hardcoded value the category level
            objCategory.CategoryName = txtCategoryName.Text.Trim();
            objCategory.CategoryDescription = txtCategoryDescription.Text.Trim();
            objCategory.CategoryParentId = Convert.ToInt16(ddlSecondCategory.SelectedValue);
            objCategory.CreatedBy = Convert.ToInt16(Session["UserId"]);

            MessageBox(objCategoryBiz.CreateSubCategory(objCategory));

            return true;
        }
    }
}