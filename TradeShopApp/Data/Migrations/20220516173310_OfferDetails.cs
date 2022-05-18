using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeShopApp.Data.Migrations
{
    public partial class OfferDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferDetails",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "LongDescription", "OfferDetails" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.", "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "LongDescription", "OfferDetails" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.", "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "LongDescription", "OfferDetails" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.", "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "LongDescription", "OfferDetails" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.", "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferDetails",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "LongDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "LongDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "LongDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "LongDescription",
                value: null);
        }
    }
}
