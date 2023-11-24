using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_add_relation_customerAccount_appUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "CustomerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "CustomerAccounts");
        }

        //For once; let's see what Up and Down methods do here:

        // - With Up method;
        //      - We start a migration and adding AppUserID column to CustomerAccounts table. This AppUserID fella's type is int. And it has an index called "IX_CustomerAccounts_AppUserID" which refers to AppUserID column.

        //With Down method:
        //      - This is for rollback which means takes the migration back if migration would be removed. It says i will remove a ForeignKey and Index and a Column you just created with this migration if you wanna take that migration back.

        // Cheers :))
    }
}
