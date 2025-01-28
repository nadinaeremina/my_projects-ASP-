using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkCRUD.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: ["Id", "Nickname", "Gender", "Breed", "Birthday", "Rating", "Price", "Description"],
                values: new object[,]
                {
                { 1, "Richard", "M", "Scotland", new DateTime(2020, 2, 14), 5, 35000.00, 
                        "Lorem ipsum dolor sit amet consectetur adipisicing elit. Sit, accusamus alias quos aperiam" +
                        " laborum molestiae illo, laboriosam vel vero eaque blanditiis beatae quasi eius, quibusdam " +
                        "asperiores repellendus sequi eligendi? Vitae neque quos rem reiciendis et enim quaerat ex. " +
                        "Ducimus vel omnis perspiciatis impedit magnam id reprehenderit dolor asperiores mollitia nulla!" },
                { 2, "Miya", "F", "Siamese", new DateTime(2022, 12, 1), 3, 20000.00, 
                        "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum, consequatur!" },
                { 3, "Rocky", "M", "Sphinx", new DateTime(2023, 5, 4), 4, 55000.00, 
                        "Lorem ipsum dolor sit amet consectetur " +
                        "adipisicing elit. Esse deleniti sequi possimus? Cumque sit laborum id corrupti blanditiis officiis harum!" },
                { 4, "Lola", "F", "British", new DateTime(2019, 4, 5), 3, 25000.00, 
                        "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Neque quasi at facere vitae commodi beatae nesciunt" +
                        " maxime nostrum quas inventore assumenda quisquam quidem optio sint, molestiae molestias natus dolores voluptas." },
                { 5, "Saimon", "M", "Maine Coon", new DateTime(2024, 10, 10), 4, 65000.00, 
                        "Lorem ipsum dolor sit amet consectetur adipisicing elit. " +
                        "Explicabo eveniet qui neque suscipit impedit officiis." },
                { 6, "Koka", "F", "Bengali", new DateTime(2022, 12, 22), 5, 45000.00,
                        "Lorem ipsum dolor sit amet consectetur adipisicing elit. Laborum obcaecati blanditiis tenetur voluptates nisi," +
                        " placeat voluptatum saepe vero vel veritatis facere accusantium ipsam sit ratione quis. Tempora, velit ipsa natus " +
                        "quasi unde adipisci ut, numquam rerum, exercitationem nobis quae id" },
                { 7, "Maxi", "M", "Oriental", new DateTime(2021, 12, 14), 3, 20000.00,
                        "Lorem ipsum dolor sit amet consectetur adipisicing elit. Iure magnam quasi maxime eius assumenda aspernatur distinctio eveniet non. " +
                        "Nobis officia, vitae eaque non incidunt dicta" },
                { 8, "Spicy", "M", "Scotland", new DateTime(2022, 9, 1), 3, 40000.00, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Eum, sunt." },
                { 9, "Mimi", "F", "British", new DateTime(2024, 12, 1), 4, 35000.00,
                        "Lorem ipsum dolor sit amet consectetur adipisicing elit. Cumque nulla laudantium officiis delectus hic, amet sapiente exercitationem" +
                        " sint excepturi recusandae praesentium dolore commodi, dolorum numquam" },
                { 10, "Pupa", "M", "Sphinx", new DateTime(2020, 2, 14), 4, 30000.00,
                        "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Expedita, repellat eligendi. Consequatur temporibus quasi sed commodi fuga eos vero deleniti" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 10; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Cats",
                    keyColumn: "Id",
                    keyValue: i
                );
            }
        }
    }
}
