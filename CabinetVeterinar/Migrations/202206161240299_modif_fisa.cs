namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modif_fisa : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Fisas", "Id_Animal");
            AddForeignKey("dbo.Fisas", "Id_Animal", "dbo.Animals", "Id_animal", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fisas", "Id_Animal", "dbo.Animals");
            DropIndex("dbo.Fisas", new[] { "Id_Animal" });
        }
    }
}
