namespace MVC_YourAnimalFriend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Regulary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HelpingPaws",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Visits = c.Int(nullable: false),
                        Sent = c.Int(nullable: false),
                        VolunteerId = c.Int(nullable: false),
                        DonationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donation", t => t.DonationId, cascadeDelete: true)
                .ForeignKey("dbo.Volunteer", t => t.VolunteerId, cascadeDelete: true)
                .Index(t => t.VolunteerId)
                .Index(t => t.DonationId);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Description = c.String(),
                        Primary = c.String(),
                        Secondary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HelpingPaws", "VolunteerId", "dbo.Volunteer");
            DropForeignKey("dbo.HelpingPaws", "DonationId", "dbo.Donation");
            DropIndex("dbo.HelpingPaws", new[] { "DonationId" });
            DropIndex("dbo.HelpingPaws", new[] { "VolunteerId" });
            DropTable("dbo.Volunteer");
            DropTable("dbo.HelpingPaws");
            DropTable("dbo.Donation");
        }
    }
}
