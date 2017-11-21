namespace LocadoraS2IT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jogo", "Genero_Id", "dbo.Genero");
            DropIndex("dbo.Jogo", new[] { "Genero_Id" });
            AlterColumn("dbo.Jogo", "Genero_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Jogo", "Genero_Id");
            AddForeignKey("dbo.Jogo", "Genero_Id", "dbo.Genero", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogo", "Genero_Id", "dbo.Genero");
            DropIndex("dbo.Jogo", new[] { "Genero_Id" });
            AlterColumn("dbo.Jogo", "Genero_Id", c => c.Guid());
            CreateIndex("dbo.Jogo", "Genero_Id");
            AddForeignKey("dbo.Jogo", "Genero_Id", "dbo.Genero", "Id");
        }
    }
}
