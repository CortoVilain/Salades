namespace CodeFirst2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Composants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Salades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                        Description = c.String(),
                        Fabricant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fabricants", t => t.Fabricant_ID)
                .Index(t => t.Fabricant_ID);
            
            CreateTable(
                "dbo.Fabricants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SaladeComposants",
                c => new
                    {
                        Salade_ID = c.Int(nullable: false),
                        Composant_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Salade_ID, t.Composant_ID })
                .ForeignKey("dbo.Salades", t => t.Salade_ID, cascadeDelete: true)
                .ForeignKey("dbo.Composants", t => t.Composant_ID, cascadeDelete: true)
                .Index(t => t.Salade_ID)
                .Index(t => t.Composant_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salades", "Fabricant_ID", "dbo.Fabricants");
            DropForeignKey("dbo.SaladeComposants", "Composant_ID", "dbo.Composants");
            DropForeignKey("dbo.SaladeComposants", "Salade_ID", "dbo.Salades");
            DropIndex("dbo.SaladeComposants", new[] { "Composant_ID" });
            DropIndex("dbo.SaladeComposants", new[] { "Salade_ID" });
            DropIndex("dbo.Salades", new[] { "Fabricant_ID" });
            DropTable("dbo.SaladeComposants");
            DropTable("dbo.Fabricants");
            DropTable("dbo.Salades");
            DropTable("dbo.Composants");
        }
    }
}
