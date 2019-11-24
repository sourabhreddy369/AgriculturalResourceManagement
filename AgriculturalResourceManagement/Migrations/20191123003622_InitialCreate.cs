using Microsoft.EntityFrameworkCore.Migrations;

namespace AgriculturalResourceManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timing",
                columns: table => new
                {
                    executing = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timing", x => x.executing);
                });

            migrationBuilder.CreateTable(
                name: "Total",
                columns: table => new
                {
                    record_count = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Total", x => x.record_count);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    result_coverage = table.Column<string>(nullable: false),
                    timingexecuting = table.Column<int>(nullable: true),
                    totalrecord_count = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.result_coverage);
                    table.ForeignKey(
                        name: "FK_Info_Timing_timingexecuting",
                        column: x => x.timingexecuting,
                        principalTable: "Timing",
                        principalColumn: "executing",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Info_Total_totalrecord_count",
                        column: x => x.totalrecord_count,
                        principalTable: "Total",
                        principalColumn: "record_count",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    status = table.Column<string>(nullable: false),
                    inforesult_coverage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.status);
                    table.ForeignKey(
                        name: "FK_Categories_Info_inforesult_coverage",
                        column: x => x.inforesult_coverage,
                        principalTable: "Info",
                        principalColumn: "result_coverage",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    status = table.Column<string>(nullable: false),
                    inforesult_coverage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.status);
                    table.ForeignKey(
                        name: "FK_Reports_Info_inforesult_coverage",
                        column: x => x.inforesult_coverage,
                        principalTable: "Info",
                        principalColumn: "result_coverage",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    status = table.Column<string>(nullable: false),
                    inforesult_coverage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.status);
                    table.ForeignKey(
                        name: "FK_States_Info_inforesult_coverage",
                        column: x => x.inforesult_coverage,
                        principalTable: "Info",
                        principalColumn: "result_coverage",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    sequence = table.Column<int>(nullable: false),
                    Categoriesstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                    table.ForeignKey(
                        name: "FK_Category_Categories_Categoriesstatus",
                        column: x => x.Categoriesstatus,
                        principalTable: "Categories",
                        principalColumn: "status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    Reportsstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                    table.ForeignKey(
                        name: "FK_Report_Reports_Reportsstatus",
                        column: x => x.Reportsstatus,
                        principalTable: "Reports",
                        principalColumn: "status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    Statesstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.id);
                    table.ForeignKey(
                        name: "FK_State_States_Statesstatus",
                        column: x => x.Statesstatus,
                        principalTable: "States",
                        principalColumn: "status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_inforesult_coverage",
                table: "Categories",
                column: "inforesult_coverage");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Categoriesstatus",
                table: "Category",
                column: "Categoriesstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Info_timingexecuting",
                table: "Info",
                column: "timingexecuting");

            migrationBuilder.CreateIndex(
                name: "IX_Info_totalrecord_count",
                table: "Info",
                column: "totalrecord_count");

            migrationBuilder.CreateIndex(
                name: "IX_Report_Reportsstatus",
                table: "Report",
                column: "Reportsstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_inforesult_coverage",
                table: "Reports",
                column: "inforesult_coverage");

            migrationBuilder.CreateIndex(
                name: "IX_State_Statesstatus",
                table: "State",
                column: "Statesstatus");

            migrationBuilder.CreateIndex(
                name: "IX_States_inforesult_coverage",
                table: "States",
                column: "inforesult_coverage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Timing");

            migrationBuilder.DropTable(
                name: "Total");
        }
    }
}
