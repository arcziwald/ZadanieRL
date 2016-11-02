using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ZadanieRL.Model;

namespace ZadanieRL
{
    public partial class ZadanieView : System.Web.UI.Page
    {
        DataBaseHelpers DataBaseHelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataBaseHelper == null)
            {
                DataBaseHelper = new DataBaseHelpers();
            }
            DataBaseHelper.LoadDataForAllUI(ref RadGrid1, ref RadListBox1, ref RadComboBox1);
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBaseHelper.LoadRadGridOnSelectedCategory(ref RadGrid1, ref RadListBox1);
        }

        public void btnRadButtonAddNewProduct_Click(object sender, EventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                try
                {
                    var query = context.Categories.Where(x => x.CategoryName == RadComboBox1.SelectedItem.Text).
                        Select(s => s.CategoryId).Single();
                    Category category = new Category();
                    category.CategoryId = (int)query;
                    category.CategoryName = RadComboBox1.SelectedItem.Text;
                    Product product = new Product();
                    product.ProductName = txbNewProductName.Text;
                    category.Products.Add(product);
                    product.Categories.Add(category);
                    context.Products.Attach(product);
                    context.Products.Add(product);
                    context.SaveChanges();
                    DataBaseHelper.LoadRadGridOnSelectedCategory(ref RadGrid1, ref RadListBox1);

                }
                catch
                {

                }
            }
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int strtxt = Convert.ToInt16(item["ProductId"].Text); 
                using(DataContext context= new DataContext())
                {
                    try
                    {
                        var query = context.Products.Where(x => x.ProductId == strtxt).Single();
                        context.Products.Remove(query);
                        context.SaveChanges();
                    }
                    catch
                    {

                    }
                }
                DataBaseHelper.LoadRadGridOnSelectedCategory(ref RadGrid1, ref RadListBox1);
                RadGrid1.DataBind();
            }
        }
    }
}