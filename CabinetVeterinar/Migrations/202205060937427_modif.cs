namespace CabinetVeterinar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programares", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Programares", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.Programares", "Start_programare");
            DropColumn("dbo.Programares", "Stop_programare");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programares", "Stop_programare", c => c.DateTime(nullable: false));
            AddColumn("dbo.Programares", "Start_programare", c => c.DateTime(nullable: false));
            DropColumn("dbo.Programares", "End");
            DropColumn("dbo.Programares", "Start");
        }
    }
}
