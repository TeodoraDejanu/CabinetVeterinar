namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugare_animal_categorie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id_animal = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Id_utilizator = c.Int(nullable: false),
                        Varsta = c.Int(nullable: false),
                        Greutate = c.Int(nullable: false),
                        Gen = c.String(),
                        Id_categorie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_animal)
                .ForeignKey("dbo.Categories", t => t.Id_categorie, cascadeDelete: true)
                .ForeignKey("dbo.Utilizators", t => t.Id_utilizator, cascadeDelete: true)
                .Index(t => t.Id_utilizator)
                .Index(t => t.Id_categorie);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id_categorie = c.Int(nullable: false, identity: true),
                        DescriereCategorie = c.String(),
                    })
                .PrimaryKey(t => t.Id_categorie);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Id_utilizator", "dbo.Utilizators");
            DropForeignKey("dbo.Animals", "Id_categorie", "dbo.Categories");
            DropIndex("dbo.Animals", new[] { "Id_categorie" });
            DropIndex("dbo.Animals", new[] { "Id_utilizator" });
            DropTable("dbo.Categories");
            DropTable("dbo.Animals");
        }
    }
}
