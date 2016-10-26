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

        protected void Page_Load(object sender, EventArgs e)
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
                    
                }
            }
        }

        protected void RadListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = RadListBox1.SelectedItem;
            //item.Text
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(DataContext context = new DataContext())
            {
                Product x = new Product();
                Category c = new Category();
                c.CategoryName = "AGD";
                x.ProductName = "Lococo";
                
                c.Products.Add(x);
                context.Products.Add(x);
                context.Categories.Add(c);
                context.SaveChanges();
            }
        }
    }
}