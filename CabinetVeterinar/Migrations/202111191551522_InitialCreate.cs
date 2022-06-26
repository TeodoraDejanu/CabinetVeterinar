namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilizators",
                c => new
                    {
                        Id_utilizator = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Parola = c.String(nullable: false),
                        Nume = c.String(),
                        Prenume = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                    })
                .PrimaryKey(t => t.Id_utilizator);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Utilizators");
        }
    }
}
