namespace LocadoraS2IT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Emprestimo", "DataEmprestimo");
            DropColumn("dbo.Emprestimo", "DataDevolucao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emprestimo", "DataDevolucao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Emprestimo", "DataEmprestimo", c => c.DateTime(nullable: false));
        }
    }
}
