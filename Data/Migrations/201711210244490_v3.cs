namespace LocadoraS2IT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Amigo", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Amigo", "Email");
        }
    }
}
