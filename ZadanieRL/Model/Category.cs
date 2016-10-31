using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieRL.Model
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [Key]
        [Column("CategoryId")]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }

        [Column("NazwaKategorii")]
        [DisplayName("Nazwa Kategorii")]
        [StringLength(300)]
        [Index(IsUnique=true)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
