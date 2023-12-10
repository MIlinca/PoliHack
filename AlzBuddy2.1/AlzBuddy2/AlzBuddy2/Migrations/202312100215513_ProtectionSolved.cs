namespace AlzBuddy2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProtectionSolved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StateValues", "TemperatureValue", c => c.Double(nullable: false));
            AlterColumn("dbo.StateValues", "CarbonMonoxideValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StateValues", "CarbonMonoxideValue", c => c.Int(nullable: false));
            AlterColumn("dbo.StateValues", "TemperatureValue", c => c.Int(nullable: false));
        }
    }
}
