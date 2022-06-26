namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modif_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Rasa", c => c.String());
            AddColumn("dbo.Animals", "Caracteristici", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Caracteristici");
            DropColumn("dbo.Animals", "Rasa");
        }
    }
}
