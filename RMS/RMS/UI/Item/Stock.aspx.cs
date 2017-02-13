using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using RMS.BLL;
using RMS.DAL;
using RMS.Model;

namespace RMS.UI.Item
{
    public partial class Stock : BasePage
    {
        private Product objProduct;
        private ProductBiz objProductBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void gvDisplayProductStock_OnRowDataBound(object sender,GridViewRowEventArgs e)
        //{
        //    //gvDisplayProductStock.PageIndex = e.NewPageIndex;
        //    GridViewBindProductStockInfo();
        //}

        private void GridViewBindProductStockInfo()
        {
            objProductBiz = new ProductBiz();
            DataTable dtProductStock = new DataTable();
            string searchText = txtProductCategorySearch.Text.Trim();
            decimal stockQty = Convert.ToDecimal(txtStockQuantitySearch.Text);
            
            dtProductStock = objProductBiz.GetProductStockList(searchText, stockQty);
            gvDisplayProductStock.DataSource = dtProductStock;
            gvDisplayProductStock.DataBind();
            gvDisplayProductStock.ShowHeaderWhenEmpty = true;
            gvDisplayProductStock.EmptyDataText = "No data found";

            gvDisplayProductStock.AlternatingRowStyle.BackColor = System.Drawing.Color.AliceBlue;
            gvDisplayProductStock.SelectedRowStyle.BackColor = System.Drawing.Color.DarkKhaki;

            txtProductCategorySearch.Attributes.Add("onfocus", "this.select()");
            txtProductCategorySearch.Focus();
            txtStockQuantitySearch.Attributes.Add("onfocus", "this.select()");
            txtStockQuantitySearch.Focus();

        }

        protected void gvDisplayProduct_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvDisplayProductStock.PageIndex = e.NewPageIndex;
            GridViewBindProductStockInfo();
        }

        //protected void txtStockQuantitySearch_OnTextChanged(object sender, EventArgs e)
        //{
        //    GridViewBindProductStockInfo();
        //}

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            GridViewBindProductStockInfo();
        }
    }
}