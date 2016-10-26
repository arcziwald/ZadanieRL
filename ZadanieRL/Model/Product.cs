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
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.Categories = new List<Category>();
        }

        [Key]
        [Column("ProductId")]
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [Column("NazwaProduktu")]
        [DisplayName("Nazwa")]
        public string ProductName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
