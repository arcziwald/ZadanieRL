using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieRL.Model
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataContext()
            : base("DatabaseConn")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
            .HasMany<Category>(c => c.Categories)
            .WithMany(s => s.Products)
            .Map(cs =>
            {
                cs.MapLeftKey("ProductRefId");
                cs.MapRightKey("CategoryRefId");
                cs.ToTable("ProductCategory");
            });
        }
    }
}
