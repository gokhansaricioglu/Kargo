namespace Kargo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gonderens", "OlusturanKisi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gonderens", "OlusturanKisi");
        }
    }
}
