using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoisk.DataAccessLayer.Migrations
{
    public partial class addedfieldUpdateDateforrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("80f5f8df-03b8-4820-b1ee-bb97b4a02b4a"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("818b1891-a714-4e27-a433-327334bef0f8"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("96ebcf82-1371-463a-8462-8eb9dff5b09f"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("e0ff79a5-4618-41d9-a173-2aa09d7c313a"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("f7cd4e41-3cc8-4eb9-b323-3ae2b090e882"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64b46c5a-0923-4942-bde5-59d2d05538fa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("692208a2-6c52-41fa-9db7-24ee68cec1b4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("23075e0f-1d6d-4774-aa3f-ca5ef54f9ea5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2731d6a4-7324-40d4-8cb0-6f16014f6cbe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("307810ea-f450-40d1-a97b-ea19f68ca871"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4f1cab76-1277-4236-84d2-74cfcb7eea07"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69409d70-bc32-484b-b99b-74a50091c8df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("714cebff-1a3c-4d19-b92e-a6a34301bc77"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8285b35d-9290-472d-962a-c5c738a00849"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8dd8d11e-261e-439e-8007-3b815257f3cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4d95efc-4434-4471-a0eb-d3ccbf181e1a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f48264a7-769c-4c9c-90ab-93fd36c30b67"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0405452a-3dba-4984-ac07-de012aafa696"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1fa3cc8a-b94e-49f7-8168-bef6ccb9da87"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("296c41d7-b1c3-47be-b9ac-442da2a728d2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6fefb7f4-ebd2-40f9-a8b3-993c75c7d4c2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8ae29546-1098-4f94-9537-19cf4219d768"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8afa1a48-e53f-484d-add8-1c1347d3eb0f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b623d720-396a-4610-8766-e124f59e4f9a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d4b943e8-22bc-4c4e-8bcc-ecff39e5a71b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f07879ec-b07f-4931-a4d2-646462d8c0c3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f10466d6-20fd-4a36-8a77-09850d35ba38"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f45aefc0-cbbc-443f-9ef5-f107e28b8e28"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("12875772-dbe6-4c28-b267-59e1fed704fb"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("157cf1a4-b8bd-46f2-ae61-fd84510ea3e5"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("2613f867-6c1c-4e5a-8a56-04e9e11e2c38"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cefb5bb-9f53-4b79-a8a8-0459be12e1d2"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ff95043-8af8-48c3-b9f1-7035662c1b2e"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b0aa46d-bde2-4fcd-9141-d5771b6c25bb"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("a4340769-f79f-48e5-aea0-09164a113a13"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("dcd5644c-f38b-4326-bdeb-a9b42589e5fe"));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "AgeCategories",
                columns: new[] { "Id", "MinAge", "Value" },
                values: new object[,]
                {
                    { new Guid("7a847696-7ac2-4f72-b310-b604136dc750"), 16L, "16+ - For children over 16 years" },
                    { new Guid("99bb58ef-08f7-4678-b94b-e7556a5ef5a3"), 0L, "0+ - All ages are allowed" },
                    { new Guid("9c083b7f-1210-4d51-8b28-cdc47bc73677"), 12L, "12+ - For children over 12 years" },
                    { new Guid("abfb38d3-92a1-4107-a330-3ad46bb5e2ef"), 6L, "6+ - For children over 6 years" },
                    { new Guid("e694c4df-fbca-40a8-ab23-a8b547f71add"), 18L, "18+ - Prohibited for children" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("70b71bb5-8a25-4ba2-91a7-d431ad1cf6e6"), "c025e86d-595a-4a92-939e-e40ec73f78e5", "Admin", "ADMIN" },
                    { new Guid("e84453a7-05fc-4049-a1c3-2af5da133b5a"), "07b6751d-1101-486c-9a7e-2a67f676f2d7", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13483e4e-e66b-471c-9453-a51f4ea6a7f3"), "Finlyadnia" },
                    { new Guid("3cd368c3-35e5-4ea4-9886-6118c932399a"), "Japan" },
                    { new Guid("59a77487-b1cc-46d4-b81d-e54d773045fd"), "USA" },
                    { new Guid("709fb44b-7d7f-47f4-b9f0-ce55f5a2517c"), "Canada" },
                    { new Guid("7c4aaa3f-d92e-48fd-a1c3-443ff109f625"), "England" },
                    { new Guid("9ddcaec0-7786-4ab2-b598-2e9995723d0f"), "Germany" },
                    { new Guid("a2ce5be0-cfde-4d89-8218-6da47275cde6"), "Sweden" },
                    { new Guid("b0036039-705c-428e-b497-0323e1b88f58"), "China" },
                    { new Guid("c72e2ed3-da4f-4f2d-b1ab-b49b1b64a8fd"), "France" },
                    { new Guid("d3aa082f-9abe-45e1-a60d-84b93ab74c02"), "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("038b7a13-7c20-40fc-bf07-5008f11e0268"), "Musical" },
                    { new Guid("0a6ee7c7-0281-42aa-b0b1-e631d14bdf4d"), "Drama" },
                    { new Guid("29cd2708-2c5b-41d9-815f-e27146127bcf"), "Horror movie" },
                    { new Guid("3213189f-c30a-4065-a728-993c13baec11"), "Adventures" },
                    { new Guid("56ab1800-eeae-4f6a-b9c8-b21f5d5edad9"), "War Film" },
                    { new Guid("5d6e07f2-a630-4e46-b073-536235376223"), "Thriller" },
                    { new Guid("717415e2-b302-496e-9632-481bdbd41a7d"), "Detective" },
                    { new Guid("bb980315-47e8-438e-af4e-a13a661991c5"), "Kids" },
                    { new Guid("c27d5478-0aaf-4885-840d-957c07b698f3"), "Action movie" },
                    { new Guid("cab81dbd-c139-4b8d-957b-2a80843528e2"), "Fantasy" },
                    { new Guid("ef6233e8-698c-4ce0-bb65-c09f90fd27a9"), "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "MovieRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a5a7a92-f2ac-4899-9876-160aa40ebab0"), "Director" },
                    { new Guid("376c4fc9-47d6-4db5-9cd6-7433f132a8f8"), "Editor" },
                    { new Guid("4fd31e4d-6ddf-42ae-b343-0622a560d513"), "Producer" },
                    { new Guid("61f8021a-26e8-4d5c-9036-6c92f2bc95fb"), "Operator" },
                    { new Guid("7f832a9e-848a-47f7-98cc-7b3b09f62f09"), "Artist" },
                    { new Guid("b0fc6a91-8fa6-408f-8924-0609654a9fa6"), "Composer" },
                    { new Guid("e9f42ca0-8172-4648-bfda-27b3641af139"), "Actor" },
                    { new Guid("fa69e973-8618-41f6-b5c3-eaa925313295"), "ScreenWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("7a847696-7ac2-4f72-b310-b604136dc750"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("99bb58ef-08f7-4678-b94b-e7556a5ef5a3"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("9c083b7f-1210-4d51-8b28-cdc47bc73677"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("abfb38d3-92a1-4107-a330-3ad46bb5e2ef"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("e694c4df-fbca-40a8-ab23-a8b547f71add"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70b71bb5-8a25-4ba2-91a7-d431ad1cf6e6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e84453a7-05fc-4049-a1c3-2af5da133b5a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("13483e4e-e66b-471c-9453-a51f4ea6a7f3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3cd368c3-35e5-4ea4-9886-6118c932399a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59a77487-b1cc-46d4-b81d-e54d773045fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("709fb44b-7d7f-47f4-b9f0-ce55f5a2517c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7c4aaa3f-d92e-48fd-a1c3-443ff109f625"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9ddcaec0-7786-4ab2-b598-2e9995723d0f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a2ce5be0-cfde-4d89-8218-6da47275cde6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b0036039-705c-428e-b497-0323e1b88f58"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c72e2ed3-da4f-4f2d-b1ab-b49b1b64a8fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d3aa082f-9abe-45e1-a60d-84b93ab74c02"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("038b7a13-7c20-40fc-bf07-5008f11e0268"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0a6ee7c7-0281-42aa-b0b1-e631d14bdf4d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("29cd2708-2c5b-41d9-815f-e27146127bcf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3213189f-c30a-4065-a728-993c13baec11"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("56ab1800-eeae-4f6a-b9c8-b21f5d5edad9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5d6e07f2-a630-4e46-b073-536235376223"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("717415e2-b302-496e-9632-481bdbd41a7d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bb980315-47e8-438e-af4e-a13a661991c5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c27d5478-0aaf-4885-840d-957c07b698f3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cab81dbd-c139-4b8d-957b-2a80843528e2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ef6233e8-698c-4ce0-bb65-c09f90fd27a9"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a5a7a92-f2ac-4899-9876-160aa40ebab0"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c4fc9-47d6-4db5-9cd6-7433f132a8f8"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("4fd31e4d-6ddf-42ae-b343-0622a560d513"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("61f8021a-26e8-4d5c-9036-6c92f2bc95fb"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f832a9e-848a-47f7-98cc-7b3b09f62f09"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0fc6a91-8fa6-408f-8924-0609654a9fa6"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9f42ca0-8172-4648-bfda-27b3641af139"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("fa69e973-8618-41f6-b5c3-eaa925313295"));

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AgeCategories",
                columns: new[] { "Id", "MinAge", "Value" },
                values: new object[,]
                {
                    { new Guid("80f5f8df-03b8-4820-b1ee-bb97b4a02b4a"), 0L, "0+ - All ages are allowed" },
                    { new Guid("818b1891-a714-4e27-a433-327334bef0f8"), 18L, "18+ - Prohibited for children" },
                    { new Guid("96ebcf82-1371-463a-8462-8eb9dff5b09f"), 6L, "6+ - For children over 6 years" },
                    { new Guid("e0ff79a5-4618-41d9-a173-2aa09d7c313a"), 16L, "16+ - For children over 16 years" },
                    { new Guid("f7cd4e41-3cc8-4eb9-b323-3ae2b090e882"), 12L, "12+ - For children over 12 years" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("64b46c5a-0923-4942-bde5-59d2d05538fa"), "fbd41a4c-b447-4470-b6f7-492087aa6fd8", "User", "USER" },
                    { new Guid("692208a2-6c52-41fa-9db7-24ee68cec1b4"), "80c1593b-9abd-49a1-b5cf-81e330fc136c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23075e0f-1d6d-4774-aa3f-ca5ef54f9ea5"), "England" },
                    { new Guid("2731d6a4-7324-40d4-8cb0-6f16014f6cbe"), "Canada" },
                    { new Guid("307810ea-f450-40d1-a97b-ea19f68ca871"), "Germany" },
                    { new Guid("4f1cab76-1277-4236-84d2-74cfcb7eea07"), "Sweden" },
                    { new Guid("69409d70-bc32-484b-b99b-74a50091c8df"), "France" },
                    { new Guid("714cebff-1a3c-4d19-b92e-a6a34301bc77"), "Japan" },
                    { new Guid("8285b35d-9290-472d-962a-c5c738a00849"), "USA" },
                    { new Guid("8dd8d11e-261e-439e-8007-3b815257f3cd"), "Russia" },
                    { new Guid("e4d95efc-4434-4471-a0eb-d3ccbf181e1a"), "China" },
                    { new Guid("f48264a7-769c-4c9c-90ab-93fd36c30b67"), "Finlyadnia" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0405452a-3dba-4984-ac07-de012aafa696"), "Horror movie" },
                    { new Guid("1fa3cc8a-b94e-49f7-8168-bef6ccb9da87"), "Musical" },
                    { new Guid("296c41d7-b1c3-47be-b9ac-442da2a728d2"), "Adventures" },
                    { new Guid("6fefb7f4-ebd2-40f9-a8b3-993c75c7d4c2"), "Comedy" },
                    { new Guid("8ae29546-1098-4f94-9537-19cf4219d768"), "Thriller" },
                    { new Guid("8afa1a48-e53f-484d-add8-1c1347d3eb0f"), "War Film" },
                    { new Guid("b623d720-396a-4610-8766-e124f59e4f9a"), "Fantasy" },
                    { new Guid("d4b943e8-22bc-4c4e-8bcc-ecff39e5a71b"), "Kids" },
                    { new Guid("f07879ec-b07f-4931-a4d2-646462d8c0c3"), "Detective" },
                    { new Guid("f10466d6-20fd-4a36-8a77-09850d35ba38"), "Drama" },
                    { new Guid("f45aefc0-cbbc-443f-9ef5-f107e28b8e28"), "Action movie" }
                });

            migrationBuilder.InsertData(
                table: "MovieRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12875772-dbe6-4c28-b267-59e1fed704fb"), "Operators" },
                    { new Guid("157cf1a4-b8bd-46f2-ae61-fd84510ea3e5"), "Artists" },
                    { new Guid("2613f867-6c1c-4e5a-8a56-04e9e11e2c38"), "Director" },
                    { new Guid("6cefb5bb-9f53-4b79-a8a8-0459be12e1d2"), "Director" },
                    { new Guid("7ff95043-8af8-48c3-b9f1-7035662c1b2e"), "Actors" },
                    { new Guid("8b0aa46d-bde2-4fcd-9141-d5771b6c25bb"), "Producers" },
                    { new Guid("a4340769-f79f-48e5-aea0-09164a113a13"), "Composer" },
                    { new Guid("dcd5644c-f38b-4326-bdeb-a9b42589e5fe"), "ScreenWriters" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
