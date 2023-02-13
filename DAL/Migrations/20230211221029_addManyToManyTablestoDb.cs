using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addManyToManyTablestoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParameter_Parameters_ProductId",
                table: "ProductParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParameter_Products_ProductId",
                table: "ProductParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryParameter_Parameters_SubCategoryId",
                table: "SubCategoryParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryParameter_SubCategories_SubCategoryId",
                table: "SubCategoryParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryParameter",
                table: "SubCategoryParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductParameter",
                table: "ProductParameter");

            migrationBuilder.RenameTable(
                name: "SubCategoryParameter",
                newName: "SubCategoryParameters");

            migrationBuilder.RenameTable(
                name: "ProductParameter",
                newName: "ProductParameters");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryParameter_SubCategoryId",
                table: "SubCategoryParameters",
                newName: "IX_SubCategoryParameters_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParameter_ProductId",
                table: "ProductParameters",
                newName: "IX_ProductParameters_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryParameters",
                table: "SubCategoryParameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductParameters",
                table: "ProductParameters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParameters_Parameters_ProductId",
                table: "ProductParameters",
                column: "ProductId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParameters_Products_ProductId",
                table: "ProductParameters",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryParameters_Parameters_SubCategoryId",
                table: "SubCategoryParameters",
                column: "SubCategoryId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryParameters_SubCategories_SubCategoryId",
                table: "SubCategoryParameters",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductParameters_Parameters_ProductId",
                table: "ProductParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductParameters_Products_ProductId",
                table: "ProductParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryParameters_Parameters_SubCategoryId",
                table: "SubCategoryParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryParameters_SubCategories_SubCategoryId",
                table: "SubCategoryParameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryParameters",
                table: "SubCategoryParameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductParameters",
                table: "ProductParameters");

            migrationBuilder.RenameTable(
                name: "SubCategoryParameters",
                newName: "SubCategoryParameter");

            migrationBuilder.RenameTable(
                name: "ProductParameters",
                newName: "ProductParameter");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryParameters_SubCategoryId",
                table: "SubCategoryParameter",
                newName: "IX_SubCategoryParameter_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductParameters_ProductId",
                table: "ProductParameter",
                newName: "IX_ProductParameter_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryParameter",
                table: "SubCategoryParameter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductParameter",
                table: "ProductParameter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParameter_Parameters_ProductId",
                table: "ProductParameter",
                column: "ProductId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductParameter_Products_ProductId",
                table: "ProductParameter",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryParameter_Parameters_SubCategoryId",
                table: "SubCategoryParameter",
                column: "SubCategoryId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryParameter_SubCategories_SubCategoryId",
                table: "SubCategoryParameter",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
