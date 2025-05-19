using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BdLab2Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationSubject_Publications_PublicationsId",
                table: "PublicationSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationSubject_Subjects_SubjectsId",
                table: "PublicationSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Publications_PublicationId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "AuthorPublication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "PublicationSubject",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "PublicationsId",
                table: "PublicationSubject",
                newName: "PublicationId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicationSubject_SubjectsId",
                table: "PublicationSubject",
                newName: "IX_PublicationSubject_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Review",
                newName: "IX_Review_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PublicationId",
                table: "Review",
                newName: "IX_Review_PublicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorsPublications",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublicationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsPublications", x => new { x.AuthorId, x.PublicationsId });
                    table.ForeignKey(
                        name: "FK_AuthorsPublications_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsPublications_Publications_PublicationsId",
                        column: x => x.PublicationsId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsPublications_PublicationsId",
                table: "AuthorsPublications",
                column: "PublicationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationSubject_Publications_PublicationId",
                table: "PublicationSubject",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationSubject_Subjects_SubjectId",
                table: "PublicationSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Publications_PublicationId",
                table: "Review",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Reviewers_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationSubject_Publications_PublicationId",
                table: "PublicationSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationSubject_Subjects_SubjectId",
                table: "PublicationSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Publications_PublicationId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Reviewers_ReviewerId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "AuthorsPublications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "PublicationSubject",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "PublicationId",
                table: "PublicationSubject",
                newName: "PublicationsId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicationSubject_SubjectId",
                table: "PublicationSubject",
                newName: "IX_PublicationSubject_SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_PublicationId",
                table: "Reviews",
                newName: "IX_Reviews_PublicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorPublication",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    PublicationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPublication", x => new { x.AuthorsId, x.PublicationsId });
                    table.ForeignKey(
                        name: "FK_AuthorPublication_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPublication_Publications_PublicationsId",
                        column: x => x.PublicationsId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublication_PublicationsId",
                table: "AuthorPublication",
                column: "PublicationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationSubject_Publications_PublicationsId",
                table: "PublicationSubject",
                column: "PublicationsId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationSubject_Subjects_SubjectsId",
                table: "PublicationSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Publications_PublicationId",
                table: "Reviews",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
