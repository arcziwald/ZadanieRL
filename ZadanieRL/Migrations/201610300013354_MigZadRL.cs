namespace ZadanieRL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigZadRL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "NazwaKategorii", c => c.String(maxLength: 300));
            CreateIndex("dbo.Category", "NazwaKategorii", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Category", new[] { "NazwaKategorii" });
            AlterColumn("dbo.Category", "NazwaKategorii", c => c.String());
        }
    }
}
