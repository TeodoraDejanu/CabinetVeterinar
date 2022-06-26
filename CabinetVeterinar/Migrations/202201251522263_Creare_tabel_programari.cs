namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creare_tabel_programari : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programares",
                c => new
                    {
                        Id_programare = c.Int(nullable: false, identity: true),
                        Id_utilizator = c.Int(nullable: false),
                        Id_veterinar = c.Int(nullable: false),
                        Start_programare = c.DateTime(nullable: false),
                        Stop_programare = c.DateTime(nullable: false),
                        Descriere = c.String(),
                    })
                .PrimaryKey(t => t.Id_programare);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programares");
        }
    }
}
