namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fisa_pacient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fisas",
                c => new
                    {
                        Id_Fisa = c.Int(nullable: false, identity: true),
                        Id_Veterinar = c.Int(nullable: false),
                        Id_Client = c.Int(nullable: false),
                        Id_Animal = c.Int(nullable: false),
                        Numar_Fisa = c.String(),
                        Vaccinat = c.Boolean(nullable: false),
                        Produs_Vaccin = c.String(),
                        Deparazitat_Intern = c.Boolean(nullable: false),
                        Produs_DeparazitareI = c.String(),
                        Deparazitat_Extern = c.Boolean(nullable: false),
                        Produs_DeparazitareE = c.String(),
                        Observatii = c.String(),
                    })
                .PrimaryKey(t => t.Id_Fisa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fisas");
        }
    }
}
