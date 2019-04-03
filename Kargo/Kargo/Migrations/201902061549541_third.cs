namespace Kargo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pakets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PaketDurumu = c.Int(nullable: false),
                        GecerliMi = c.Boolean(nullable: false),
                        OlusturanKisi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pakets");
        }
    }
}
