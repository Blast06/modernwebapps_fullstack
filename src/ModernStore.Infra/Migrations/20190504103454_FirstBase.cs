using Microsoft.EntityFrameworkCore.Migrations;

namespace ModernStore.Infra.Migrations
{
    public partial class FirstBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.EnsureSchema(
                name: "ModernStore");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "ModernStore");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "ModernStore");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItem",
                newSchema: "ModernStore");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Order",
                newSchema: "ModernStore");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "ModernStore");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "ModernStore",
                table: "User",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "ModernStore",
                table: "User",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "ModernStore",
                table: "Product",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "ModernStore",
                table: "Product",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "ModernStore",
                table: "Order",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document_Number",
                schema: "ModernStore",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email_EmailAddress",
                schema: "ModernStore",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_FirstName",
                schema: "ModernStore",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_LastName",
                schema: "ModernStore",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "Customer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "Id",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Document_Number",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email_EmailAddress",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Name_FirstName",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Name_LastName",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "ModernStore",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "ModernStore",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                schema: "ModernStore",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "ModernStore",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "ModernStore",
                newName: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Order",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");
        }
    }
}
