namespace ZadanieRL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZadanieRLMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        NazwaProduktu = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ProductRefId = c.Int(nullable: false),
                        CategoryRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductRefId, t.CategoryRefId })
                .ForeignKey("dbo.Product", t => t.ProductRefId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryRefId, cascadeDelete: true)
                .Index(t => t.ProductRefId)
                .Index(t => t.CategoryRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "CategoryRefId", "dbo.Category");
            DropForeignKey("dbo.ProductCategory", "ProductRefId", "dbo.Product");
            DropIndex("dbo.ProductCategory", new[] { "CategoryRefId" });
            DropIndex("dbo.ProductCategory", new[] { "ProductRefId" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
