namespace Kargo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gonderens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gonderens");
        }
    }
}
