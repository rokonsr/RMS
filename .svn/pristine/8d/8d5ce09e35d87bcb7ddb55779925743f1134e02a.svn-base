using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class UpdateCatagory : BasePage
    {
        private Category objCategory;
        private CategoryBiz objCategoryBiz;
        private List<Measurement> objMeasurementList;
        private MeasurementBiz objMeasurementBiz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            GridViewBindCategoryInfo();
        }

        private void GridViewBindCategoryInfo()
        {
            objCategoryBiz = new CategoryBiz();

            DataTable dtCategory = new DataTable();
            dtCategory = objCategoryBiz.GetCategoryListForGv(txtCategoryName.Text.Trim());
            gvDisplayCategory.DataSource = dtCategory;
            gvDisplayCategory.DataBind();
            gvDisplayCategory.ShowHeaderWhenEmpty = true;
            gvDisplayCategory.EmptyDataText = "No data found";

            gvDisplayCategory.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayCategory.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;
        }

        protected void gvDisplayCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplayCategory.PageIndex = e.NewPageIndex;
            GridViewBindCategoryInfo();
        }

        protected void gvDisplayCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalUpdateCategory.Show();

            GridViewRow row = gvDisplayCategory.SelectedRow;

            txtFirstCategory.Text = gvDisplayCategory.SelectedRow.Cells[0].Text;
            txtSecondCategory.Text = gvDisplayCategory.SelectedRow.Cells[1].Text;
            txtThirdCategory.Text = gvDisplayCategory.SelectedRow.Cells[2].Text;
            txtUpdateCategoryDescription.Text = gvDisplayCategory.SelectedRow.Cells[3].Text == "&nbsp;" ? "" : gvDisplayCategory.SelectedRow.Cells[3].Text;
            ddlUpdateCategoryStatus.SelectedValue = gvDisplayCategory.DataKeys[row.RowIndex].Values[3].ToString();
        }

        protected void btnUpdateCategory_OnClick(object sender, EventArgs e)
        {
            if (EditCategory())
            {
               GridViewBindCategoryInfo(); 
            }
        }

        private bool EditCategory()
        {
            objCategory = new Category();
            objCategoryBiz = new CategoryBiz();

            GridViewRow row = gvDisplayCategory.SelectedRow;

            objCategory.CategoryId = Convert.ToInt16(gvDisplayCategory.DataKeys[row.RowIndex].Values[0].ToString());
            objCategory.CategoryName = txtFirstCategory.Text.Trim();
            objCategory.SecondCategoryId = Convert.ToInt16(gvDisplayCategory.DataKeys[row.RowIndex].Values[1].ToString());
            objCategory.SecondCategoryName = txtSecondCategory.Text.Trim();
            objCategory.ThirdCategoryId = Convert.ToInt16(gvDisplayCategory.DataKeys[row.RowIndex].Values[2].ToString());
            objCategory.ThirdCategoryName = txtThirdCategory.Text.Trim();

            objCategory.CategoryDescription = txtUpdateCategoryDescription.Text.Trim();
            objCategory.IsActive = Convert.ToBoolean(ddlUpdateCategoryStatus.SelectedValue);
            objCategory.UpdatedBy = Convert.ToInt16(Session["UserId"].ToString());

            objCategoryBiz.EditCategory(objCategory);

            return true;
        }

        protected void gvDisplayCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "Inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}