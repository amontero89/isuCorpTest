namespace IsuCorpTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ContactName", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Reservations", "Phone", c => c.String(maxLength: 15));
            AlterColumn("dbo.Reservations", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Reservations", "Phone", c => c.String());
            AlterColumn("dbo.Reservations", "ContactName", c => c.String());
        }
    }
}
