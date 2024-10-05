using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class startPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 75m, "Karagöz ve Hacivat" },
                    { 2, 175m, "Mesnevi" },
                    { 3, 375m, "Devlet" },
                    { 4, 200m, "Sefiller" },
                    { 5, 150m, "Suç ve Ceza" },
                    { 6, 300m, "Savaş ve Barış" },
                    { 7, 250m, "Karamazov Kardeşler" },
                    { 8, 450m, "İlahi Komedya" },
                    { 9, 125m, "1984" },
                    { 10, 100m, "Hayvan Çiftliği" },
                    { 11, 275m, "Don Kişot" },
                    { 12, 175m, "Beyaz Zambaklar Ülkesi" },
                    { 13, 225m, "Simyacı" },
                    { 14, 375m, "Anna Karenina" },
                    { 15, 500m, "Ulysses" },
                    { 16, 95m, "Yeraltından Notlar" },
                    { 17, 180m, "Madame Bovary" },
                    { 18, 140m, "Kürk Mantolu Madonna" },
                    { 19, 125m, "Çalıkuşu" },
                    { 20, 350m, "Moby Dick" },
                    { 21, 160m, "Kırmızı ve Siyah" },
                    { 22, 300m, "Monte Cristo Kontu" },
                    { 23, 180m, "Bülbülü Öldürmek" },
                    { 24, 200m, "Germinal" },
                    { 25, 80m, "Küçük Prens" },
                    { 26, 275m, "Yüzyıllık Yalnızlık" },
                    { 27, 90m, "Şeker Portakalı" },
                    { 28, 125m, "Fahrenheit 451" },
                    { 29, 230m, "Lolita" },
                    { 30, 150m, "Babasız Evler" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
