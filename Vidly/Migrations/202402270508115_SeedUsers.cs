namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'05182d50-2a72-4357-a535-4a2e75df5878', N'admin1@vidly.com', 0, N'AJNmQ+/q7IM41aZEUlzzAN3SADc3nmb8avByLmdLPdMJhWOoMt5XEKoJG9B73zXgeg==', N'b3c21a7d-c9f2-489e-85f7-93de3f48a9a9', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54d05fc8-36fa-4188-9233-3be378346d66', N'guest1@vidly.com', 0, N'AKuSKP6+Sepu7NwUD1Zl+P7QOQLMN/NNSIb3TaJyEQkHUzEP7A7NgB8Zt3YwQobP7A==', N'30652374-3a60-4553-a0d0-8ef586719542', NULL, 0, 0, NULL, 1, 0, N'guest1@vidly.com')                
            ");

            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7100b1f1-fb90-41d8-bbe5-27c11a54eab6', N'CanManageMovies')
            ");

            Sql(@"
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'05182d50-2a72-4357-a535-4a2e75df5878', N'7100b1f1-fb90-41d8-bbe5-27c11a54eab6')
            ");

        }

        public override void Down()
        {
        }
    }
}
