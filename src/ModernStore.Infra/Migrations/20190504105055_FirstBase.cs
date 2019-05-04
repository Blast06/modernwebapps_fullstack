using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModernStore.Infra.Migrations
{
    public partial class FirstBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "ModernStore",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                schema: "ModernStore",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ProductId",
                schema: "ModernStore",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                schema: "ModernStore",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "ModernStore",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "ModernStore",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemId",
                schema: "ModernStore",
                table: "Product",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                schema: "ModernStore",
                table: "Customer",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderItemId",
                schema: "ModernStore",
                table: "Product",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_OrderId",
                schema: "ModernStore",
                table: "Customer",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Order_OrderId",
                schema: "ModernStore",
                table: "Customer",
                column: "OrderId",
                principalSchema: "ModernStore",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderItem_OrderItemId",
                schema: "ModernStore",
                table: "Product",
                column: "OrderItemId",
                principalSchema: "ModernStore",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Order_OrderId",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderItem_OrderItemId",
                schema: "ModernStore",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderItemId",
                schema: "ModernStore",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Customer_OrderId",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                schema: "ModernStore",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "ModernStore",
                table: "Customer");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "ModernStore",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "ModernStore",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "ModernStore",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "ModernStore",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "ModernStore",
                table: "Order",
                column: "CustomerId",
                principalSchema: "ModernStore",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                schema: "ModernStore",
                table: "OrderItem",
                column: "ProductId",
                principalSchema: "ModernStore",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
