namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificare_coloane_utilizator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizators", "Specializari", c => c.String());
            AddColumn("dbo.Utilizators", "Ani_experienta", c => c.String());
            AddColumn("dbo.Utilizators", "Descriere", c => c.String());
            AddColumn("dbo.Utilizators", "Poza", c => c.Binary());
            AddColumn("dbo.Utilizators", "Motto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizators", "Motto");
            DropColumn("dbo.Utilizators", "Poza");
            DropColumn("dbo.Utilizators", "Descriere");
            DropColumn("dbo.Utilizators", "Ani_experienta");
            DropColumn("dbo.Utilizators", "Specializari");
        }
    }
}
