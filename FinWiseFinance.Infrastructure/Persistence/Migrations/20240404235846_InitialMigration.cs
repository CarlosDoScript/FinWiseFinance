using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinWiseFinance.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    CpfCnpj = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Income = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    CorporateReason = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeSalary = table.Column<int>(type: "int", nullable: false),
                    DayOfReceipt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    IdCompanyBranch = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_CompanyBranch_IdCompanyBranch",
                        column: x => x.IdCompanyBranch,
                        principalTable: "CompanyBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TotalAmountDue = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    TotalInstallments = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    InstallmentStart = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdBank = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Bank_IdBank",
                        column: x => x.IdBank,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    Daily = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DeductMonthlyIncome = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdBank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyExpense_Bank_IdBank",
                        column: x => x.IdBank,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyExpense_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTarget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    Link = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    SpecifiedValue = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    CombinedTotal = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    DeductMonthlyIncome = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CombinedHistory = table.Column<bool>(type: "bit", nullable: false),
                    Purchased = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdBank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTarget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTarget_Bank_IdBank",
                        column: x => x.IdBank,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseTarget_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdProfession = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfession_Profession_IdProfession",
                        column: x => x.IdProfession,
                        principalTable: "Profession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfession_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Installment = table.Column<int>(type: "int", nullable: false),
                    Due = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    InstallmentAmount = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    BarCode = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdBill = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdBank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentBill_Bank_IdBank",
                        column: x => x.IdBank,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentBill_Bill_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallmentBill_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseObjectiveHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 18, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdPurchaseTarget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseObjectiveHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseObjectiveHistory_PurchaseTarget_IdPurchaseTarget",
                        column: x => x.IdPurchaseTarget,
                        principalTable: "PurchaseTarget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseObjectiveHistory_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdBank",
                table: "Bill",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdUser",
                table: "Bill",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DailyExpense_IdBank",
                table: "DailyExpense",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_DailyExpense_IdUser",
                table: "DailyExpense",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentBill_IdBank",
                table: "InstallmentBill",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentBill_IdBill",
                table: "InstallmentBill",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentBill_IdUser",
                table: "InstallmentBill",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseObjectiveHistory_IdPurchaseTarget",
                table: "PurchaseObjectiveHistory",
                column: "IdPurchaseTarget");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseObjectiveHistory_IdUser",
                table: "PurchaseObjectiveHistory",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTarget_IdBank",
                table: "PurchaseTarget",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTarget_IdUser",
                table: "PurchaseTarget",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdCompanyBranch",
                table: "User",
                column: "IdCompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfession_IdProfession",
                table: "UserProfession",
                column: "IdProfession");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfession_IdUser",
                table: "UserProfession",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyExpense");

            migrationBuilder.DropTable(
                name: "InstallmentBill");

            migrationBuilder.DropTable(
                name: "PurchaseObjectiveHistory");

            migrationBuilder.DropTable(
                name: "UserProfession");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "PurchaseTarget");

            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CompanyBranch");
        }
    }
}
