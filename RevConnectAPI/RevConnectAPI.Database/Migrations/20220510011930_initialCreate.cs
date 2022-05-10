using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevConnectAPI.Database.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RevConnect");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "RevConnect",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    aboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "RevConnect",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postID);
                    table.ForeignKey(
                        name: "FK_Posts_Users_userID",
                        column: x => x.userID,
                        principalSchema: "RevConnect",
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "RevConnect",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_postID",
                        column: x => x.postID,
                        principalSchema: "RevConnect",
                        principalTable: "Posts",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_userID",
                        column: x => x.userID,
                        principalSchema: "RevConnect",
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "RevConnect",
                columns: table => new
                {
                    likeID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    postID = table.Column<int>(type: "int", nullable: true),
                    commentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.likeID);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_commentID",
                        column: x => x.commentID,
                        principalSchema: "RevConnect",
                        principalTable: "Comments",
                        principalColumn: "commentID");
                    table.ForeignKey(
                        name: "FK_Likes_Posts_postID",
                        column: x => x.postID,
                        principalSchema: "RevConnect",
                        principalTable: "Posts",
                        principalColumn: "postID");
                    table.ForeignKey(
                        name: "FK_Likes_Users_userID",
                        column: x => x.userID,
                        principalSchema: "RevConnect",
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_postID",
                schema: "RevConnect",
                table: "Comments",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userID",
                schema: "RevConnect",
                table: "Comments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_commentID",
                schema: "RevConnect",
                table: "Likes",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_postID",
                schema: "RevConnect",
                table: "Likes",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_userID",
                schema: "RevConnect",
                table: "Likes",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userID",
                schema: "RevConnect",
                table: "Posts",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes",
                schema: "RevConnect");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "RevConnect");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "RevConnect");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "RevConnect");
        }
    }
}
