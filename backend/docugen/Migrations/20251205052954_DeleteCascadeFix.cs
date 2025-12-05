using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace docugen.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCascadeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_educacionItems_curriculums_CvDataid",
                table: "educacionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_habilidadItems_curriculums_CvDataid",
                table: "habilidadItems");

            migrationBuilder.DropForeignKey(
                name: "FK_interesItems_curriculums_CvDataid",
                table: "interesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_trabajoItems_curriculums_CvDataid",
                table: "trabajoItems");

            migrationBuilder.AddColumn<int>(
                name: "CvDataid1",
                table: "trabajoItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CvDataid1",
                table: "interesItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CvDataid1",
                table: "habilidadItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CvDataid1",
                table: "educacionItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajoItems_CvDataid1",
                table: "trabajoItems",
                column: "CvDataid1");

            migrationBuilder.CreateIndex(
                name: "IX_interesItems_CvDataid1",
                table: "interesItems",
                column: "CvDataid1");

            migrationBuilder.CreateIndex(
                name: "IX_habilidadItems_CvDataid1",
                table: "habilidadItems",
                column: "CvDataid1");

            migrationBuilder.CreateIndex(
                name: "IX_educacionItems_CvDataid1",
                table: "educacionItems",
                column: "CvDataid1");

            migrationBuilder.AddForeignKey(
                name: "FK_educacionItems_curriculums_CvDataid",
                table: "educacionItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_educacionItems_curriculums_CvDataid1",
                table: "educacionItems",
                column: "CvDataid1",
                principalTable: "curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_habilidadItems_curriculums_CvDataid",
                table: "habilidadItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_habilidadItems_curriculums_CvDataid1",
                table: "habilidadItems",
                column: "CvDataid1",
                principalTable: "curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_interesItems_curriculums_CvDataid",
                table: "interesItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interesItems_curriculums_CvDataid1",
                table: "interesItems",
                column: "CvDataid1",
                principalTable: "curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_trabajoItems_curriculums_CvDataid",
                table: "trabajoItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trabajoItems_curriculums_CvDataid1",
                table: "trabajoItems",
                column: "CvDataid1",
                principalTable: "curriculums",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_educacionItems_curriculums_CvDataid",
                table: "educacionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_educacionItems_curriculums_CvDataid1",
                table: "educacionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_habilidadItems_curriculums_CvDataid",
                table: "habilidadItems");

            migrationBuilder.DropForeignKey(
                name: "FK_habilidadItems_curriculums_CvDataid1",
                table: "habilidadItems");

            migrationBuilder.DropForeignKey(
                name: "FK_interesItems_curriculums_CvDataid",
                table: "interesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_interesItems_curriculums_CvDataid1",
                table: "interesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_trabajoItems_curriculums_CvDataid",
                table: "trabajoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_trabajoItems_curriculums_CvDataid1",
                table: "trabajoItems");

            migrationBuilder.DropIndex(
                name: "IX_trabajoItems_CvDataid1",
                table: "trabajoItems");

            migrationBuilder.DropIndex(
                name: "IX_interesItems_CvDataid1",
                table: "interesItems");

            migrationBuilder.DropIndex(
                name: "IX_habilidadItems_CvDataid1",
                table: "habilidadItems");

            migrationBuilder.DropIndex(
                name: "IX_educacionItems_CvDataid1",
                table: "educacionItems");

            migrationBuilder.DropColumn(
                name: "CvDataid1",
                table: "trabajoItems");

            migrationBuilder.DropColumn(
                name: "CvDataid1",
                table: "interesItems");

            migrationBuilder.DropColumn(
                name: "CvDataid1",
                table: "habilidadItems");

            migrationBuilder.DropColumn(
                name: "CvDataid1",
                table: "educacionItems");

            migrationBuilder.AddForeignKey(
                name: "FK_educacionItems_curriculums_CvDataid",
                table: "educacionItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_habilidadItems_curriculums_CvDataid",
                table: "habilidadItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_interesItems_curriculums_CvDataid",
                table: "interesItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_trabajoItems_curriculums_CvDataid",
                table: "trabajoItems",
                column: "CvDataid",
                principalTable: "curriculums",
                principalColumn: "id");
        }
    }
}
