using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace auctionComplex.Migrations
{
    public partial class init342 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(maxLength: 250, nullable: true),
                    file_size = table.Column<double>(nullable: false),
                    file_type = table.Column<string>(maxLength: 250, nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    second_name = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    username = table.Column<string>(maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: true),
                    is_admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "auction_items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(maxLength: 250, nullable: true),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    investment_size = table.Column<double>(nullable: false),
                    location = table.Column<string>(maxLength: 500, nullable: true),
                    category = table.Column<string>(maxLength: 100, nullable: true),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: true),
                    winner_id = table.Column<int>(nullable: true),
                    auctioneer_id = table.Column<int>(nullable: false),
                    is_valid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auction_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_auction_items_users_auctioneer_id",
                        column: x => x.auctioneer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_auction_items_users_winner_id",
                        column: x => x.winner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(maxLength: 48, nullable: true),
                    balance = table.Column<double>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallets_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auction_chats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    auction_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auction_chats", x => x.id);
                    table.ForeignKey(
                        name: "FK_auction_chats_auction_items_auction_id",
                        column: x => x.auction_id,
                        principalTable: "auction_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bids",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    investment_volume = table.Column<double>(nullable: false),
                    entry_percentage = table.Column<int>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    AuctionItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bids", x => x.id);
                    table.ForeignKey(
                        name: "FK_bids_auction_items_AuctionItemId",
                        column: x => x.AuctionItemId,
                        principalTable: "auction_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bids_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<decimal>(nullable: false),
                    sender_wallet_id = table.Column<int>(nullable: false),
                    receiver_wallet_id = table.Column<int>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_wallets_receiver_wallet_id",
                        column: x => x.receiver_wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_wallets_sender_wallet_id",
                        column: x => x.sender_wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_messages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(maxLength: 250, nullable: true),
                    AuctionChatId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    AttachmentId = table.Column<int>(nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_messages_attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "attachments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chat_messages_auction_chats_AuctionChatId",
                        column: x => x.AuctionChatId,
                        principalTable: "auction_chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chat_messages_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_chats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: true),
                    AuctionChatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_chats", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_chats_auction_chats_AuctionChatId",
                        column: x => x.AuctionChatId,
                        principalTable: "auction_chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_chats_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_auction_chats_auction_id",
                table: "auction_chats",
                column: "auction_id");

            migrationBuilder.CreateIndex(
                name: "IX_auction_items_auctioneer_id",
                table: "auction_items",
                column: "auctioneer_id");

            migrationBuilder.CreateIndex(
                name: "IX_auction_items_winner_id",
                table: "auction_items",
                column: "winner_id");

            migrationBuilder.CreateIndex(
                name: "IX_bids_AuctionItemId",
                table: "bids",
                column: "AuctionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_bids_UserId",
                table: "bids",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_AttachmentId",
                table: "chat_messages",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_AuctionChatId",
                table: "chat_messages",
                column: "AuctionChatId");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_UserId",
                table: "chat_messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_receiver_wallet_id",
                table: "transactions",
                column: "receiver_wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_sender_wallet_id",
                table: "transactions",
                column: "sender_wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_chats_AuctionChatId",
                table: "user_chats",
                column: "AuctionChatId");

            migrationBuilder.CreateIndex(
                name: "IX_user_chats_UserId",
                table: "user_chats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_wallets_user_id",
                table: "wallets",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bids");

            migrationBuilder.DropTable(
                name: "chat_messages");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "user_chats");

            migrationBuilder.DropTable(
                name: "attachments");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "auction_chats");

            migrationBuilder.DropTable(
                name: "auction_items");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
