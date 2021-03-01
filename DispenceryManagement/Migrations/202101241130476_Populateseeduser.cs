namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populateseeduser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'2d0ea006-a8a6-4c7b-bb62-060c3f4e521f', N'tjbsminakshi2595@gmail.com', 0, N'AMftUpNTfZQh4W06Riq9YkBlg/DwmRrQQZAQWxrYmbrClFVPbm7LEzM5xpFa3sLohw==', N'e1afc9b9-f58b-477a-9abe-717136898b4a', NULL, 0, 0, NULL, 1, 0, N'Nishant Ahire', N'8765542121')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'3007f6f1-bba8-4434-8190-fb488edef649', N'ruturajjadapurkar@gmail.com', 0, N'AHJf++HQKW0OdGiq6EY+IRDLsrwarEFfV2a/wSPJd1RhBDdaP+6YYUD9kgS4jQkN2w==', N'6aa1f3b4-b97c-48c0-9dd6-69999fc699ee', NULL, 0, 0, NULL, 1, 0, N'Rakesh Rajput', N'7845454556')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'47a6ba4e-c3b4-463d-aa8e-9128b6a83ed0', N'abcdfiona408@gmail.com', 0, N'AL/mCv0sgB1vUhiZCRavKRmko0EfFWcD2m+xSPBERFoEGusdGGSWDFH/bDFuPkpIcQ==', N'5d6bec47-cc18-4928-aef5-f05365db1fc2', NULL, 0, 0, NULL, 1, 0, N'Revati Mahajan', N'87546532321')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'c0ab9b78-45fd-4196-85c1-ac03637ab9d6', N'janavishenoy82@gmail.com', 0, N'AJWDsVFUX0+GPOK0dd0NIDJimON7rvxqPs95aGz9guUe8gUzadqZ3F3jJm9/ydiPuQ==', N'8306d75f-9348-49a1-9d87-7464ef2f05a9', NULL, 0, 0, NULL, 1, 0, N'Janhavi Shenoy', N'8754652121')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'ed5933d7-a321-4e54-9008-2be99f48d64d', N'adiparab1274@gmail.com', 0, N'AJqxDgbqH7DaEesoMU4jfFJnKyAK66H47hBFlCbQPWxBIPQhz64CqHp2vgeuU26eyQ==', N'f5ebf830-f834-4507-852a-ad55bcd8e215', NULL, 0, 0, NULL, 1, 0, N'Madhavi Deshpande', N'8877445645')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Phone]) VALUES (N'f006980e-d82d-4e71-90b5-c676d90ae431', N'harrymandustepup@gmail.com', 0, N'AJykQKLvhS/0tNGVhltcLlp0W/4OGBQqc4g93aC+ET1F5oOpakz43oeAZPWesOkdwg==', N'2540c475-7efe-4282-92f1-8094c807d3be', NULL, 0, 0, NULL, 1, 0, N'vedehi joshi', N'7856454556')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4745c8b5-98c2-4417-8cef-bb257b57cbf6', N'Assitant_Doctor')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'95216717-3fd6-4d68-ac5e-84385a2d81e8', N'Doctor')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c42be732-42a5-4f67-ba47-6fdef72de485', N'Nurse')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e9e2af10-78e7-4e48-8a0f-a09a0a580326', N'Nurse_Head')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f41586f1-db5f-433b-ae56-504b5860f657', N'Others')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8856994c-a1e7-4949-89c8-c22637861171', N'Ward_Boy')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d0ea006-a8a6-4c7b-bb62-060c3f4e521f', N'4745c8b5-98c2-4417-8cef-bb257b57cbf6')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3007f6f1-bba8-4434-8190-fb488edef649', N'8856994c-a1e7-4949-89c8-c22637861171')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'47a6ba4e-c3b4-463d-aa8e-9128b6a83ed0', N'95216717-3fd6-4d68-ac5e-84385a2d81e8')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f006980e-d82d-4e71-90b5-c676d90ae431', N'c42be732-42a5-4f67-ba47-6fdef72de485')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c0ab9b78-45fd-4196-85c1-ac03637ab9d6', N'e9e2af10-78e7-4e48-8a0f-a09a0a580326')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ed5933d7-a321-4e54-9008-2be99f48d64d', N'f41586f1-db5f-433b-ae56-504b5860f657')

                ");


        }
        
        public override void Down()
        {
        }
    }
}
