using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asteroids.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class CreateTables : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Asteroid",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
					MinDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					MaxDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					AverageDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Velocity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					CloseApproachDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Planet = table.Column<string>(type: "nvarchar(50)", nullable: false),
					IsPotentiallyHazardous = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Asteroid", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AsteroidDateRange",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AsteroidDateRange", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AsteroidTop",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AsteroidDateRangeId = table.Column<int>(type: "int", nullable: false),
					AsteroidId = table.Column<int>(type: "int", nullable: false),
					Order = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AsteroidTop", x => x.Id);
					table.ForeignKey(
						name: "FK_AsteroidTop_AsteroidDateRange_AsteroidDateRangeId",
						column: x => x.AsteroidDateRangeId,
						principalTable: "AsteroidDateRange",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_AsteroidTop_Asteroid_AsteroidId",
						column: x => x.AsteroidId,
						principalTable: "Asteroid",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateIndex(
				name: "IX_AsteroidTop_AsteroidDateRangeId",
				table: "AsteroidTop",
				column: "AsteroidDateRangeId");

			migrationBuilder.CreateIndex(
				name: "IX_AsteroidTop_AsteroidId",
				table: "AsteroidTop",
				column: "AsteroidId");

			//migrationBuilder.Sql(AsteroidsResource._20240103133551_ScriptExample_Up);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AsteroidTop");

			migrationBuilder.DropTable(
				name: "AsteroidDateRange");

			migrationBuilder.DropTable(
				name: "Asteroid");

			//migrationBuilder.Sql(AsteroidsResource._20240103133551_ScriptExample_Down);
		}
	}
}
