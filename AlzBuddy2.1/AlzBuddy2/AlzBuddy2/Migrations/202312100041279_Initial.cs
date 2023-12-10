namespace AlzBuddy2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CriticLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Hour = c.String(),
                        Date = c.String(),
                        Message = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemperatureValue = c.Int(nullable: false),
                        FridgeDoorOpenMinutes = c.Int(nullable: false),
                        WaterLevelValue = c.Int(nullable: false),
                        CarbonMonoxideValue = c.Int(nullable: false),
                        Date = c.String(),
                        Hour = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StateValues");
            DropTable("dbo.Pacients");
            DropTable("dbo.CriticLevels");
        }
    }
}
