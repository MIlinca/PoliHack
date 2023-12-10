namespace AlzBuddy2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CriticLevels", "Value", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CriticLevels", "Value", c => c.Int(nullable: false));
        }
    }
}
