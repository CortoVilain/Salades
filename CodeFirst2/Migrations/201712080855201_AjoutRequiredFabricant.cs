namespace CodeFirst2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutRequiredFabricant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salades", "Fabricant_ID1", "dbo.Fabricants");
            DropIndex("dbo.Salades", new[] { "Fabricant_ID1" });
            DropColumn("dbo.Salades", "Fabricant_ID");
            RenameColumn(table: "dbo.Salades", name: "Fabricant_ID1", newName: "Fabricant_ID");
            AlterColumn("dbo.Salades", "Fabricant_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Salades", "Fabricant_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Salades", "Fabricant_ID");
            AddForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants");
            DropIndex("dbo.Salades", new[] { "Fabricant_ID" });
            AlterColumn("dbo.Salades", "Fabricant_ID", c => c.Int());
            AlterColumn("dbo.Salades", "Fabricant_ID", c => c.Int());
            RenameColumn(table: "dbo.Salades", name: "Fabricant_ID", newName: "Fabricant_ID1");
            AddColumn("dbo.Salades", "Fabricant_ID", c => c.Int());
            CreateIndex("dbo.Salades", "Fabricant_ID1");
            AddForeignKey("dbo.Salades", "Fabricant_ID1", "dbo.Fabricants", "ID");
        }
    }
}
