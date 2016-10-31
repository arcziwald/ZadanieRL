using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZadanieRL.Model;

namespace ZadanieRL
{
    public partial class ZadanieView : System.Web.UI.Page
    {
        static bool _isRequested;
        public bool IsRequested
        {
            get
            {
                return _isRequested;
            }
            set
            {
                _isRequested = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsRequested == false)
            {
                using (DataContext context = new DataContext())
                {
                    var query = from b in context.Products
                                select new { b.ProductId, b.ProductName };

                    RadGrid1.DataSource = query.ToList();
                    RadDataForm1.DataSource = query.ToList();

                    foreach (var cat in context.Categories)
                    {
                        RadListBox1.Items.Add(cat.CategoryName);
                        cbxCategoryOfNewProduct.Items.Add(cat.CategoryName);
                    }
                }
                IsRequested = true;
            }
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var querySelectedCategoryId = context.Categories.Where(x => x.CategoryName == RadListBox1.SelectedItem.Text).Select(y => y.CategoryId).Single();
                var products = context.Products.Where(s => s.Categories.Any(p => p.CategoryId == querySelectedCategoryId));
                RadGrid1.DataSource = products.ToList();
                RadGrid1.DataBind();
            }
        }

        protected void btnRadButtonAddNewProduct_Click(object sender, EventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                try
                {
                    var query = context.Categories.Where(x => x.CategoryName == cbxCategoryOfNewProduct.SelectedItem.Text).Select(s => s.CategoryId).Single();
                    Category category = new Category();
                    category.CategoryId = (int)query;
                    category.CategoryName = cbxCategoryOfNewProduct.SelectedItem.Text;

                    Product product = new Product();
                    product.ProductName = txbNewProductName.Text;
                    //product.Categories.Add(category);

                    category.Products.Add(product);
                    product.Categories.Add(category);



                    context.Products.Attach(product);
                    context.Products.Add(product);
                    //context.Categories.Add(category);
                    //context.Products.Add(product);

                    context.SaveChanges();
                    RadGrid1.DataBind();
                }
                catch
                {

                }
            }

            //protected void Button1_Click(object sender, EventArgs e)
            //{
            //    using(DataContext context = new DataContext())
            //    {
            //        Product x = new Product();
            //        Category c = new Category();
            //        c.CategoryName = "AGD";
            //        x.ProductName = "Lococo";

            //        c.Products.Add(x);
            //        context.Products.Add(x);
            //        context.Categories.Add(c);
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}