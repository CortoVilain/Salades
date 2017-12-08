namespace CodeFirst2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutDeBoutDeCodeManquant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants");
            DropIndex("dbo.Salades", new[] { "Fabricant_ID" });
            AddColumn("dbo.Salades", "Fabricant_ID1", c => c.Int());
            CreateIndex("dbo.Salades", "Fabricant_ID1");
            AddForeignKey("dbo.Salades", "Fabricant_ID1", "dbo.Fabricants", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salades", "Fabricant_ID1", "dbo.Fabricants");
            DropIndex("dbo.Salades", new[] { "Fabricant_ID1" });
            DropColumn("dbo.Salades", "Fabricant_ID1");
            CreateIndex("dbo.Salades", "Fabricant_ID");
            AddForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants", "ID");
        }
    }
}
