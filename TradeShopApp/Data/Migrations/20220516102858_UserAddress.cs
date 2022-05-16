using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeShopApp.Data.Migrations
{
    public partial class UserAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "ParentCategoryId" },
                values: new object[] { 12, "Smartphones", 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ThumbnailPath",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTb3I_38rtMgpNTapQ30tzsPJR03Oex6im7hg&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CategoryId",
                value: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ThumbnailPath",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Hoodie_man.jpg/330px-Hoodie_man.jpg");
        }
    }
}
