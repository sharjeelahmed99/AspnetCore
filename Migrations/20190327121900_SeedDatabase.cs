using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetcore.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make1')");
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make2')");
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make3')");


            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make1' ),'Make1-Model1')");
            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make1' ),'Make1-Model2')");
            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make1' ),'Make1-Model3')");

            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make2' ),'Make2-Model1')");
            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make2' ),'Make2-Model2')");
            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make2' ),'Make2-Model3')");

            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make3' ),'Make3-Model1')");
            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make3' ),'Make3-Model2')");
            migrationBuilder.Sql("Insert into Models (MakeId,Name) values ((select Id from Makes where Name = 'Make3' ),'Make3-Model3')");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Makes where Name in ('Make1','Make2','Make3')");

        }
    }
}
