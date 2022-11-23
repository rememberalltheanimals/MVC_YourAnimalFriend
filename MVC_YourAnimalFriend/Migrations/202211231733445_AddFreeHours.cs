namespace MVC_YourAnimalFriend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFreeHours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HelpingPaws", "FreeHours", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HelpingPaws", "FreeHours");
        }
    }
}
