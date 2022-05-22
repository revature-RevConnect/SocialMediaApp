using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevConnectAPI.Database.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postID",
                schema: "RevConnect",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_userID",
                schema: "RevConnect",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_userID",
                schema: "RevConnect",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_userID",
                schema: "RevConnect",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_userID",
                schema: "RevConnect",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Likes_userID",
                schema: "RevConnect",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_userID",
                schema: "RevConnect",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "firstName",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastName",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userName",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "date",
                schema: "RevConnect",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "userID",
                schema: "RevConnect",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "userID",
                schema: "RevConnect",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "userID",
                schema: "RevConnect",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "image",
                schema: "RevConnect",
                table: "Posts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "date",
                schema: "RevConnect",
                table: "Comments",
                newName: "authID");

            migrationBuilder.AlterColumn<string>(
                name: "profilePicture",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "RevConnect",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "address",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "authID",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "github",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkedin",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "twitter",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "body",
                schema: "RevConnect",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "authID",
                schema: "RevConnect",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "authID",
                schema: "RevConnect",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "postID",
                schema: "RevConnect",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "body",
                schema: "RevConnect",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postID",
                schema: "RevConnect",
                table: "Comments",
                column: "postID",
                principalSchema: "RevConnect",
                principalTable: "Posts",
                principalColumn: "postID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postID",
                schema: "RevConnect",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "active",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "address",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "authID",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "email",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "github",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "linkedin",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "phone",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "twitter",
                schema: "RevConnect",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "authID",
                schema: "RevConnect",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "authID",
                schema: "RevConnect",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "title",
                schema: "RevConnect",
                table: "Posts",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "authID",
                schema: "RevConnect",
                table: "Comments",
                newName: "date");

            migrationBuilder.AlterColumn<string>(
                name: "profilePicture",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                schema: "RevConnect",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "body",
                schema: "RevConnect",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "date",
                schema: "RevConnect",
                table: "Posts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "userID",
                schema: "RevConnect",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userID",
                schema: "RevConnect",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "postID",
                schema: "RevConnect",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "body",
                schema: "RevConnect",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userID",
                schema: "RevConnect",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userID",
                schema: "RevConnect",
                table: "Posts",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_userID",
                schema: "RevConnect",
                table: "Likes",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userID",
                schema: "RevConnect",
                table: "Comments",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postID",
                schema: "RevConnect",
                table: "Comments",
                column: "postID",
                principalSchema: "RevConnect",
                principalTable: "Posts",
                principalColumn: "postID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_userID",
                schema: "RevConnect",
                table: "Comments",
                column: "userID",
                principalSchema: "RevConnect",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_userID",
                schema: "RevConnect",
                table: "Likes",
                column: "userID",
                principalSchema: "RevConnect",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_userID",
                schema: "RevConnect",
                table: "Posts",
                column: "userID",
                principalSchema: "RevConnect",
                principalTable: "Users",
                principalColumn: "userID");
        }
    }
}
