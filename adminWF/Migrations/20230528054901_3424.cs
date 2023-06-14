using Microsoft.EntityFrameworkCore.Migrations;

namespace auctionComplex.Migrations
{
    public partial class _3424 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_auction_chats_auction_items_auction_id",
                table: "auction_chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_attachments_AttachmentId",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_auction_chats_AuctionChatId",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_users_UserId",
                table: "chat_messages");

            migrationBuilder.RenameColumn(
                name: "auction_id",
                table: "auction_chats",
                newName: "AuctionItemId");

            migrationBuilder.RenameIndex(
                name: "IX_auction_chats_auction_id",
                table: "auction_chats",
                newName: "IX_auction_chats_AuctionItemId");

            migrationBuilder.AddColumn<bool>(
                name: "is_verify",
                table: "users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "chat_messages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuctionChatId",
                table: "chat_messages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttachmentId",
                table: "chat_messages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_auction_chats_auction_items_AuctionItemId",
                table: "auction_chats",
                column: "AuctionItemId",
                principalTable: "auction_items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_attachments_AttachmentId",
                table: "chat_messages",
                column: "AttachmentId",
                principalTable: "attachments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_auction_chats_AuctionChatId",
                table: "chat_messages",
                column: "AuctionChatId",
                principalTable: "auction_chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_users_UserId",
                table: "chat_messages",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_auction_chats_auction_items_AuctionItemId",
                table: "auction_chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_attachments_AttachmentId",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_auction_chats_AuctionChatId",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_users_UserId",
                table: "chat_messages");

            migrationBuilder.DropColumn(
                name: "is_verify",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "AuctionItemId",
                table: "auction_chats",
                newName: "auction_id");

            migrationBuilder.RenameIndex(
                name: "IX_auction_chats_AuctionItemId",
                table: "auction_chats",
                newName: "IX_auction_chats_auction_id");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "chat_messages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuctionChatId",
                table: "chat_messages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AttachmentId",
                table: "chat_messages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_auction_chats_auction_items_auction_id",
                table: "auction_chats",
                column: "auction_id",
                principalTable: "auction_items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_attachments_AttachmentId",
                table: "chat_messages",
                column: "AttachmentId",
                principalTable: "attachments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_auction_chats_AuctionChatId",
                table: "chat_messages",
                column: "AuctionChatId",
                principalTable: "auction_chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_users_UserId",
                table: "chat_messages",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
