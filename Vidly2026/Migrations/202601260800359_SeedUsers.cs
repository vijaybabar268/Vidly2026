namespace Vidly2026.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0ebc854c-81a7-44fa-99f7-a027a6fa20cd', N'mosh@domain.com', 0, N'AMxkhPYxaNHkaJ+Y/OsTJjscHGYYZ79XflwqMyiLxfs7Bjm7HyMT9S14eWIl1WrYtQ==', N'03f673c8-9889-499b-8f41-4154d6bc8cf2', NULL, 0, 0, NULL, 1, 0, N'mosh@domain.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4ca92df3-4fa6-47eb-a0c5-7502b187f9d0', N'guest@vidly.com', 0, N'AIyklUcfeL5QTUwOupnFlNJa/h0h2jI1lY/62KWP90eZSeBDTZ0bDwZo+9UBIkobTA==', N'c10c1250-cd5c-458c-bfdd-64f844a09fdb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f30e58ed-94ef-4a28-a0a7-99b2086a12cc', N'admin@vidly.com', 0, N'APbn/sAfIEVHTEeDAuvb2M4oIkPeJhsGyS8VCVBrJk67NtBdiWVV0ibrZ5NuY2xzcg==', N'5dcd581c-5784-49e3-8340-c53844c3ff20', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c7123dc5-b763-4eb6-9882-e5f9d25cb5f5', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f30e58ed-94ef-4a28-a0a7-99b2086a12cc', N'c7123dc5-b763-4eb6-9882-e5f9d25cb5f5')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
