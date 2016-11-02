using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Web.UI;
using ZadanieRL.Model;

namespace ZadanieRL
{
    public  class DataBaseHelpers
    {
        public DataBaseHelpers()
        {
            
        }

        public void LoadDataForAllUI(ref RadGrid RadGrid1, ref RadListBox RadListBox1, ref RadComboBox RadComboBox1)
        {

            using (DataContext context = new DataContext())
            {
                var products = context.Products;
                RadGrid1.DataSource = products.ToList();
                RadGrid1.DataBind();
                if (RadListBox1.Items.Count < 1)
                {
                    foreach (Category c in context.Categories)
                    {
                        if (c.CategoryName != null) 
                        { 
                            RadListBox1.Items.Add(c.CategoryName);
                            RadComboBox1.Items.Add(c.CategoryName);
                        }
                    }
                }
            }
        }

        public void LoadRadGridOnSelectedCategory(ref RadGrid RadGrid1 , ref RadListBox RadListBox1)
        {
            using (DataContext context = new DataContext())
            {
                string catName = RadListBox1.SelectedItem.Text;
                var querySelectedCategoryId = context.Categories.Where(x => x.CategoryName == catName)
                    .Select(y => y.CategoryId).Single();
                var products = context.Products.Where(s => s.Categories.Any(p => p.CategoryId == querySelectedCategoryId));
                RadGrid1.DataSource = products.ToList();
                RadGrid1.DataBind();
            }
        }

        public void LoadRadGrid(ref RadGrid RadGrid1)
        {
            using (DataContext context = new DataContext())
            {
                var products = context.Products;
                RadGrid1.DataSource = products.ToList();
                RadGrid1.DataBind();
            }
        }

    }
}
