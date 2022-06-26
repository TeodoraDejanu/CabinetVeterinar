namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fisa_client : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Programares", "Id_utilizator");
            AddForeignKey("dbo.Programares", "Id_utilizator", "dbo.Utilizators", "Id_utilizator", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programares", "Id_utilizator", "dbo.Utilizators");
            DropIndex("dbo.Programares", new[] { "Id_utilizator" });
        }
    }
}
