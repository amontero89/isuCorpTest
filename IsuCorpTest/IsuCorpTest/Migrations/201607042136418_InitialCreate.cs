namespace IsuCorpTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContacTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        Phone = c.String(),
                        BirthDate = c.DateTime(),
                        BodyText = c.String(),
                        Ranking = c.Int(),
                        isFavorite = c.Boolean(),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .Index(t => t.ContactTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.Reservations", new[] { "ContactTypeId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.ContactTypes");
        }
    }
}
