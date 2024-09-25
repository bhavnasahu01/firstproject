using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    public partial class AddCategoryTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false), // Change here
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}



//migrationBuilder.CreateTable(
//    name: "Categories",
//    columns: table => new
//    {
//        Id = table.Column<int>(nullable: false)
//            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
//        MaxValue = table.Column<int>(nullable: false), // Change 'max' to 'MaxValue'
//        DisplayOrder = table.Column<int>(nullable: false)
//    },
//    constraints: table =>
//    {
//        table.PrimaryKey("PK_Categories", x => x.Id);
//    });
