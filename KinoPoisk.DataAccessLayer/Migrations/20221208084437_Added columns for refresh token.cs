using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoisk.DataAccessLayer.Migrations {
    public partial class Addedcolumnsforrefreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("0a98ce7f-6ef6-4fab-bbc6-225387b883be"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("251a718f-4bef-481b-89c4-e2093030d142"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("94c0fe0e-eb9b-4e95-83c1-971f707e873e"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("b13a83d8-553f-4f4a-a429-304517e7710a"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("eaa6833b-4aa9-4c18-9f9a-bf3380658606"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("20864e9c-a5ee-45a2-84a9-8a7101adf6fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("640e42be-3780-49c8-9770-1d4c11157c35"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0c1ddc4c-479c-4ac5-a3f3-12f5e2920958"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("243890f0-5c40-458d-b0c5-2c879b157e1a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("45247b2e-ac4d-4687-92e3-20844991183c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4b5ea6ae-033e-4b2c-9b7d-79fc48065d2f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("87b545b1-9b6f-4060-8c76-e198be91e794"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a9300d50-bc04-44c6-9df7-b081a710a785"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b86e95ba-d651-4bd6-90e6-25c0283e8962"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bb4fbba6-e41d-4c68-beb1-e2ce6a114db6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cbaeacef-09ea-49c7-9bd3-34f86a94d448"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d64fb6b6-6ea3-4bf7-a160-9014980e0fec"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("09332cfb-3be1-4960-97c1-9307e76a2f68"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1f95b0b9-9222-468e-809c-e9d8da0fc4ab"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("38e7f467-e824-4468-b9d7-e81a9dcb9f36"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("45eaee16-19eb-438d-b875-7026734170f8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("55ca4556-bde1-43b8-8bcd-14ab0f147b1c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("89c89f2d-6d53-4def-8d22-08d3dd610d81"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9e044226-d12a-49da-b88c-3a8352102b9e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a43bcc7f-9140-48d2-b0bc-1d61cb4e4e7e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ac62cd3e-f26b-4097-bf4a-eb95c8b2e75b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bb1da9dd-ef28-4303-845d-7f8e3fea431d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f4adef93-0c35-4cb7-8c7b-5b6e76bfdeb0"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("4af1ef6a-f14c-4b60-be43-b0e6d2702f23"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("7237d50b-fccf-470b-8bc8-39d18b0c9769"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("a561ccde-0a78-4d27-b257-3bd4cde46465"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1594ccf-8957-4b2f-a86e-1a1dc90d3779"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8c0f355-683e-464a-90a3-d8e2ef8a6d5b"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce0e23e3-70d5-4643-ad93-85204885ee39"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc7a4fb2-fbc0-4d43-b5eb-18c5d43fbb48"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("e76692d7-83a8-484e-a775-929dbaf855c3"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AgeCategories",
                columns: new[] { "Id", "MinAge", "Value" },
                values: new object[,]
                {
                    { new Guid("38d6fec5-be63-4af3-8418-b50d51d2cd67"), 12L, "12+ - For children over 12 years" },
                    { new Guid("65fdddb2-3dcc-4fac-9556-78378f426008"), 0L, "0+ - All ages are allowed" },
                    { new Guid("c1df7a0b-aba7-4a2e-95b2-ad9ceef6e560"), 6L, "6+ - For children over 6 years" },
                    { new Guid("d1fce3be-d391-4cb4-9db4-63daee28e4c7"), 16L, "16+ - For children over 16 years" },
                    { new Guid("fcfc9660-4dbc-446a-84fd-20037cbce02f"), 18L, "18+ - Prohibited for children" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("170595fd-351f-4dce-8853-509d80583bab"), "8d63b8b7-894a-4048-a192-35096b0fda55", "Admin", "ADMIN" },
                    { new Guid("725f57ea-80d1-442a-882b-ad071939a180"), "e53b8cce-bc10-41ef-a5da-d1da2953d735", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("045f432e-d5d7-4f94-8db4-770bce355500"), "Germany" },
                    { new Guid("0b14d538-d52a-48c9-b1d9-89fc6ca3b748"), "Canada" },
                    { new Guid("7898f2fc-8646-465a-8739-4d2f6ccf870d"), "China" },
                    { new Guid("a7c45f5b-0e6a-4700-a52f-ad948230deda"), "Finlyadnia" },
                    { new Guid("aeb1d392-9b9a-46ef-a900-c26f9a4af3c3"), "Japan" },
                    { new Guid("cde0253c-6c99-4be0-8285-c40315ba6064"), "England" },
                    { new Guid("d0688d74-3ce5-457d-a998-f109868cf76d"), "France" },
                    { new Guid("d5c29296-0529-4370-8a9a-57fccbf90552"), "Russia" },
                    { new Guid("d627d876-d9e0-4ccd-94f8-49f97648500d"), "USA" },
                    { new Guid("e861cd7b-a863-41e3-b3e0-d59b3825f09e"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0642d454-0cb4-4442-9dee-22ca75927679"), "Kids" },
                    { new Guid("196bcf84-d8e5-4349-bcae-f91f499c6ecf"), "Comedy" },
                    { new Guid("4d018027-18dd-48e6-af0f-8471b0bcae22"), "Thriller" },
                    { new Guid("5b8cc811-55d1-4a96-ae15-2ae40999c386"), "Action movie" },
                    { new Guid("620618ad-89ad-4f5c-ad0e-e09dfe12bc20"), "Musical" },
                    { new Guid("6b644c48-b296-42e6-b455-7a9bcc052019"), "Detective" },
                    { new Guid("b2d87c91-fdc3-4911-bfbb-3349ab29dc81"), "Adventures" },
                    { new Guid("babd7e13-e056-49df-b291-e6c1d03a59f4"), "War Film" },
                    { new Guid("d795da17-4f24-4a5f-852c-af9aa9647779"), "Horror movie" },
                    { new Guid("dc493bb6-d591-4603-bce7-b6b7687233be"), "Drama" },
                    { new Guid("de8fd322-0882-49a4-b234-d7ad72509ce1"), "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "MovieRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09ddb2aa-6b25-4dd6-9bd3-6733932f7eef"), "Director" },
                    { new Guid("23db4b99-25be-4af5-a606-26d923e9f782"), "Composer" },
                    { new Guid("3d563182-85b9-4699-90d7-28aa9cb1e376"), "Producers" },
                    { new Guid("4e9a40b6-96e5-4de7-a244-40774d4f657b"), "Actors" },
                    { new Guid("8de2cc72-4a24-418b-b7d0-0efb5e446623"), "ScreenWriters" },
                    { new Guid("c989e28f-8492-499a-9d9c-ba2785a1294f"), "Director" },
                    { new Guid("efaa5603-7345-45d4-a04c-049d059d77dd"), "Artists" },
                    { new Guid("faaf0f5f-7df8-43ce-ab46-eedf178d8737"), "Operators" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("38d6fec5-be63-4af3-8418-b50d51d2cd67"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("65fdddb2-3dcc-4fac-9556-78378f426008"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("c1df7a0b-aba7-4a2e-95b2-ad9ceef6e560"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("d1fce3be-d391-4cb4-9db4-63daee28e4c7"));

            migrationBuilder.DeleteData(
                table: "AgeCategories",
                keyColumn: "Id",
                keyValue: new Guid("fcfc9660-4dbc-446a-84fd-20037cbce02f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("170595fd-351f-4dce-8853-509d80583bab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("725f57ea-80d1-442a-882b-ad071939a180"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("045f432e-d5d7-4f94-8db4-770bce355500"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b14d538-d52a-48c9-b1d9-89fc6ca3b748"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7898f2fc-8646-465a-8739-4d2f6ccf870d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a7c45f5b-0e6a-4700-a52f-ad948230deda"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aeb1d392-9b9a-46ef-a900-c26f9a4af3c3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cde0253c-6c99-4be0-8285-c40315ba6064"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d0688d74-3ce5-457d-a998-f109868cf76d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d5c29296-0529-4370-8a9a-57fccbf90552"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d627d876-d9e0-4ccd-94f8-49f97648500d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e861cd7b-a863-41e3-b3e0-d59b3825f09e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0642d454-0cb4-4442-9dee-22ca75927679"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("196bcf84-d8e5-4349-bcae-f91f499c6ecf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4d018027-18dd-48e6-af0f-8471b0bcae22"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5b8cc811-55d1-4a96-ae15-2ae40999c386"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("620618ad-89ad-4f5c-ad0e-e09dfe12bc20"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6b644c48-b296-42e6-b455-7a9bcc052019"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b2d87c91-fdc3-4911-bfbb-3349ab29dc81"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("babd7e13-e056-49df-b291-e6c1d03a59f4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d795da17-4f24-4a5f-852c-af9aa9647779"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("dc493bb6-d591-4603-bce7-b6b7687233be"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("de8fd322-0882-49a4-b234-d7ad72509ce1"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("09ddb2aa-6b25-4dd6-9bd3-6733932f7eef"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("23db4b99-25be-4af5-a606-26d923e9f782"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d563182-85b9-4699-90d7-28aa9cb1e376"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e9a40b6-96e5-4de7-a244-40774d4f657b"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("8de2cc72-4a24-418b-b7d0-0efb5e446623"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("c989e28f-8492-499a-9d9c-ba2785a1294f"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("efaa5603-7345-45d4-a04c-049d059d77dd"));

            migrationBuilder.DeleteData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("faaf0f5f-7df8-43ce-ab46-eedf178d8737"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryDate",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AgeCategories",
                columns: new[] { "Id", "MinAge", "Value" },
                values: new object[,]
                {
                    { new Guid("0a98ce7f-6ef6-4fab-bbc6-225387b883be"), 12L, "12+ - For children over 12 years" },
                    { new Guid("251a718f-4bef-481b-89c4-e2093030d142"), 0L, "0+ - All ages are allowed" },
                    { new Guid("94c0fe0e-eb9b-4e95-83c1-971f707e873e"), 18L, "18+ - Prohibited for children" },
                    { new Guid("b13a83d8-553f-4f4a-a429-304517e7710a"), 16L, "16+ - For children over 16 years" },
                    { new Guid("eaa6833b-4aa9-4c18-9f9a-bf3380658606"), 6L, "6+ - For children over 6 years" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("20864e9c-a5ee-45a2-84a9-8a7101adf6fb"), "8d632565-bdc3-47e4-be4f-aedc3e087aa4", "Admin", "ADMIN" },
                    { new Guid("640e42be-3780-49c8-9770-1d4c11157c35"), "10f3c1dc-8a9b-458f-990d-d19fea9dbd0c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c1ddc4c-479c-4ac5-a3f3-12f5e2920958"), "Japan" },
                    { new Guid("243890f0-5c40-458d-b0c5-2c879b157e1a"), "China" },
                    { new Guid("45247b2e-ac4d-4687-92e3-20844991183c"), "USA" },
                    { new Guid("4b5ea6ae-033e-4b2c-9b7d-79fc48065d2f"), "Finlyadnia" },
                    { new Guid("87b545b1-9b6f-4060-8c76-e198be91e794"), "Canada" },
                    { new Guid("a9300d50-bc04-44c6-9df7-b081a710a785"), "England" },
                    { new Guid("b86e95ba-d651-4bd6-90e6-25c0283e8962"), "Russia" },
                    { new Guid("bb4fbba6-e41d-4c68-beb1-e2ce6a114db6"), "France" },
                    { new Guid("cbaeacef-09ea-49c7-9bd3-34f86a94d448"), "Sweden" },
                    { new Guid("d64fb6b6-6ea3-4bf7-a160-9014980e0fec"), "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09332cfb-3be1-4960-97c1-9307e76a2f68"), "War Film" },
                    { new Guid("1f95b0b9-9222-468e-809c-e9d8da0fc4ab"), "Comedy" },
                    { new Guid("38e7f467-e824-4468-b9d7-e81a9dcb9f36"), "Musical" },
                    { new Guid("45eaee16-19eb-438d-b875-7026734170f8"), "Action movie" },
                    { new Guid("55ca4556-bde1-43b8-8bcd-14ab0f147b1c"), "Drama" },
                    { new Guid("89c89f2d-6d53-4def-8d22-08d3dd610d81"), "Horror movie" },
                    { new Guid("9e044226-d12a-49da-b88c-3a8352102b9e"), "Detective" },
                    { new Guid("a43bcc7f-9140-48d2-b0bc-1d61cb4e4e7e"), "Kids" },
                    { new Guid("ac62cd3e-f26b-4097-bf4a-eb95c8b2e75b"), "Fantasy" },
                    { new Guid("bb1da9dd-ef28-4303-845d-7f8e3fea431d"), "Thriller" },
                    { new Guid("f4adef93-0c35-4cb7-8c7b-5b6e76bfdeb0"), "Adventures" }
                });

            migrationBuilder.InsertData(
                table: "MovieRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4af1ef6a-f14c-4b60-be43-b0e6d2702f23"), "Director" },
                    { new Guid("7237d50b-fccf-470b-8bc8-39d18b0c9769"), "Artists" },
                    { new Guid("a561ccde-0a78-4d27-b257-3bd4cde46465"), "ScreenWriters" },
                    { new Guid("b1594ccf-8957-4b2f-a86e-1a1dc90d3779"), "Actors" },
                    { new Guid("c8c0f355-683e-464a-90a3-d8e2ef8a6d5b"), "Director" },
                    { new Guid("ce0e23e3-70d5-4643-ad93-85204885ee39"), "Composer" },
                    { new Guid("dc7a4fb2-fbc0-4d43-b5eb-18c5d43fbb48"), "Producers" },
                    { new Guid("e76692d7-83a8-484e-a775-929dbaf855c3"), "Operators" }
                });
        }
    }
}
