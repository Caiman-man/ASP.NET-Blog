using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Users
            migrationBuilder.Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'230182ad-4dc4-4fee-b5af-56c8aa5daa65', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKnf45THz41zemDYrqUqFqSpANLkpjy7DH+a+XtntZHFTKWyrTU0cLS1A04Yvdnguw==', N'7CTOKVF2WLCZ7MKKPOTBHYHA7ZZEE5M3', N'1897b1ff-e828-4eaa-9474-637fd4b1522e', NULL, 0, 0, NULL, 1, 0, N'Admin', N'Admin')
            ");

            //roles
            migrationBuilder.Sql(@"
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f45f52e9-5cd2-404e-b066-30f223eafee9', N'Admin', N'ADMIN', N'b7aa00e8-e99e-4a02-baec-964b3ee59859')
            ");

            //UserRoles
            migrationBuilder.Sql(@"
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'230182ad-4dc4-4fee-b5af-56c8aa5daa65', N'f45f52e9-5cd2-404e-b066-30f223eafee9')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
