namespace IsuCorpTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStoreProcedures : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.ContactType_Insert",
                p => new
                    {
                        ContacTypeName = p.String(),
                    },
                body:
                    @"INSERT [dbo].[ContactTypes]([ContacTypeName])
                      VALUES (@ContacTypeName)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[ContactTypes]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[ContactTypes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.ContactType_Update",
                p => new
                    {
                        Id = p.Int(),
                        ContacTypeName = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[ContactTypes]
                      SET [ContacTypeName] = @ContacTypeName
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ContactType_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ContactTypes]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Reservation_Insert",
                p => new
                    {
                        ContactName = p.String(maxLength: 160),
                        Phone = p.String(maxLength: 15),
                        BirthDate = p.DateTime(),
                        BodyText = p.String(),
                        Ranking = p.Int(),
                        isFavorite = p.Boolean(),
                        ContactTypeId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Reservations]([ContactName], [Phone], [BirthDate], [BodyText], [Ranking], [isFavorite], [ContactTypeId])
                      VALUES (@ContactName, @Phone, @BirthDate, @BodyText, @Ranking, @isFavorite, @ContactTypeId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Reservations]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Reservations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Reservation_Update",
                p => new
                    {
                        Id = p.Int(),
                        ContactName = p.String(maxLength: 160),
                        Phone = p.String(maxLength: 15),
                        BirthDate = p.DateTime(),
                        BodyText = p.String(),
                        Ranking = p.Int(),
                        isFavorite = p.Boolean(),
                        ContactTypeId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Reservations]
                      SET [ContactName] = @ContactName, [Phone] = @Phone, [BirthDate] = @BirthDate, [BodyText] = @BodyText, [Ranking] = @Ranking, [isFavorite] = @isFavorite, [ContactTypeId] = @ContactTypeId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Reservation_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Reservations]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Reservation_Delete");
            DropStoredProcedure("dbo.Reservation_Update");
            DropStoredProcedure("dbo.Reservation_Insert");
            DropStoredProcedure("dbo.ContactType_Delete");
            DropStoredProcedure("dbo.ContactType_Update");
            DropStoredProcedure("dbo.ContactType_Insert");
        }
    }
}
