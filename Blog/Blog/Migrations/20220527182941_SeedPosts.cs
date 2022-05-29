using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class SeedPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Posts
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Posts] ON
            INSERT INTO [dbo].[Posts] ([Id], [Title], [Body], [Image], [DateCreated]) VALUES (1, N'How to use Apple’s new repair program', N'With Apple’s blessing, you can finally fix your iPhone from the comfort of your own home. On Wednesday, the company announced a new section of its website where you can buy tools and replacement parts, including new display screens, batteries, and speakers. The online store seems easy enough to use, and Apple is even offering customer repair kits — which weigh around 79 pounds — that you can rent for $49 a week.', N'img_29-05-2022-00-46-13.png', N'2022-05-25 00:00:00')
            INSERT INTO [dbo].[Posts] ([Id], [Title], [Body], [Image], [DateCreated]) VALUES (2, N'Quantum computers could change the world', N'In an increasingly digital world, further progress will depend on our ability to get ever more out of the computers we create. And that will depend on the work of researchers like Chow and his colleagues, toiling away in windowless labs to achieve a revolutionary new development around some of the hardest problems in computer engineering — and along the way, trying to build the future.', N'img_29-05-2022-15-36-00.png', N'2022-05-26 00:00:00')
            INSERT INTO [dbo].[Posts] ([Id], [Title], [Body], [Image], [DateCreated]) VALUES (3, N'Windows 11 – Is It Worth The Upgrade?', N'While Windows 11 isn’t perfect, it is still an excellent platform to help increase your productivity.  Whether you need to organize your desktop more conveniently or take enjoyable notes via your touchscreen, the OS won’t let you down. Plus, you get a revamped taskbar and powerful Voice Typing compatible with most major languages.', N'img_29-05-2022-15-44-01.png', N'2022-05-27 00:00:00')
            SET IDENTITY_INSERT [dbo].[Posts] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
