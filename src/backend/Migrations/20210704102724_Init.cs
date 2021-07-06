using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sleet.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOriginalLanguage = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TranslationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suggestions_User_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suggestions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("83e3920a-9152-416e-a41d-2db821f2f1d4"), "", "Invariant Language (Invariant Country)" },
                    { new Guid("8983aadc-5063-4a7f-8a03-038bc0bf41af"), "my-MM", "Burmese (Myanmar)" },
                    { new Guid("4999f90c-e055-402b-8ea5-281d672a9e7e"), "mzn", "Mazanderani" },
                    { new Guid("95438aed-995e-4910-8e6b-0ea86518047e"), "mzn-IR", "Mazanderani (Iran)" },
                    { new Guid("f8555b87-5336-4295-b4b8-c0ec9c4b990d"), "naq", "Nama" },
                    { new Guid("5e64265f-f6c1-41bf-a8ea-89aae8b4d103"), "naq-NA", "Nama (Namibia)" },
                    { new Guid("c46cedd6-71a5-44bf-af8f-f2cffcea8b57"), "nb", "Norwegian Bokmål" },
                    { new Guid("71af7fbd-165d-440a-ad0a-f3645f3ea543"), "nb-NO", "Norwegian Bokmål (Norway)" },
                    { new Guid("f44a9a7d-c77c-4959-9fde-bfb62724dd21"), "nb-SJ", "Norwegian Bokmål (Svalbard & Jan Mayen)" },
                    { new Guid("94c015a5-b0b8-4ea8-8f30-490a059eaea0"), "nd", "North Ndebele" },
                    { new Guid("685af514-69f3-42ba-8cda-008ecddce6b9"), "nd-ZW", "North Ndebele (Zimbabwe)" },
                    { new Guid("8c07cbed-7c96-4ca3-ae79-baeb52d2066e"), "nds", "Low German" },
                    { new Guid("8226205b-d596-4568-ac07-7292e41faf2d"), "nds-DE", "Low German (Germany)" },
                    { new Guid("411f69d3-4927-43d1-a01c-96462666661a"), "nds-NL", "Low German (Netherlands)" },
                    { new Guid("ef6ec32c-8ee1-4a2a-8dc2-c273ceff6dcc"), "ne", "Nepali" },
                    { new Guid("975d47b3-d069-46c2-8434-699a8a0abde4"), "ne-IN", "Nepali (India)" },
                    { new Guid("51ae48d2-c0a6-49ae-989e-25c3d26b751e"), "ne-NP", "Nepali (Nepal)" },
                    { new Guid("7ebbca13-2a54-46ab-a9c2-bb6d97e78d15"), "nl", "Dutch" },
                    { new Guid("84c4ed37-9066-4af8-8676-8f3b76ac6efb"), "nl-AW", "Dutch (Aruba)" },
                    { new Guid("11848e64-846c-4cf4-a966-8ea3c6d258be"), "nl-BE", "Dutch (Belgium)" },
                    { new Guid("0484e4a5-0706-40d5-b30b-91a5055c5b5e"), "nl-BQ", "Dutch (Bonaire, Sint Eustatius and Saba)" },
                    { new Guid("e4027c50-2a52-433e-bd16-ad786385fa7b"), "nl-CW", "Dutch (Curaçao)" },
                    { new Guid("f77a1920-edb7-440d-b6d6-c6a66d8aef5b"), "my", "Burmese" },
                    { new Guid("535911ab-e274-455e-82f8-8981b306879f"), "nl-NL", "Dutch (Netherlands)" },
                    { new Guid("7d6eb7ea-1966-443a-99ad-b61a0aa89951"), "mua-CM", "Mundang (Cameroon)" },
                    { new Guid("63b43496-2ec3-4b93-b493-5946f0d757a6"), "mt-MT", "Maltese (Malta)" },
                    { new Guid("62e4e2ad-884e-4d4c-8ec0-fb4a802e62ad"), "mgo-CM", "Metaʼ (Cameroon)" },
                    { new Guid("05a61b32-a801-4cc8-9573-81ec41af31bd"), "mi", "Maori" },
                    { new Guid("32baf604-d5db-4292-a3dd-f40d83e746b7"), "mi-NZ", "Maori (New Zealand)" },
                    { new Guid("38090f60-9862-4b1d-a616-19da450b1588"), "mk", "Macedonian" },
                    { new Guid("05f2d546-8b12-44da-a5b5-a3142817f122"), "mk-MK", "Macedonian (North Macedonia)" },
                    { new Guid("2cfa4340-68d2-42c5-be23-ecc5b1ebc5aa"), "ml", "Malayalam" },
                    { new Guid("84e08126-e339-4baa-8d83-e81ad6e232fb"), "ml-IN", "Malayalam (India)" },
                    { new Guid("83ee4d2b-cdc8-4b41-899b-43ef18e069de"), "mn", "Mongolian" },
                    { new Guid("4bacaa1b-a5bb-4b7d-ab0c-4ab12f484683"), "mn-MN", "Mongolian (Mongolia)" },
                    { new Guid("a2e249c4-bc78-4938-a2a1-1b0bb657b5e6"), "mn-Mong", "Mongolian" },
                    { new Guid("2549f775-1a12-49f8-95ce-ee939dd36c0f"), "mn-Mong-CN", "Mongolian (Mongolian, China)" },
                    { new Guid("9485be5a-2f5c-44ca-b161-77c7ee4bcb23"), "mn-Mong-MN", "Mongolian (Mongolian, Mongolia)" },
                    { new Guid("c33ff1d5-f505-4d3a-9f3f-fcdb4885a952"), "moh", "Mohawk" },
                    { new Guid("36d8400c-f28e-426c-99a3-134c659813c2"), "moh-CA", "Mohawk (Canada)" },
                    { new Guid("605d886f-ba84-4620-9de3-5ee433092ecf"), "mr", "Marathi" },
                    { new Guid("981e93a2-3ee4-4b2c-81c7-83ce9fff0271"), "mr-IN", "Marathi (India)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("032d95fd-de95-46f6-975a-3d52f7c596a5"), "ms", "Malay" },
                    { new Guid("0374ce84-fd87-4d1f-a751-f6ce131d0d00"), "ms-BN", "Malay (Brunei)" },
                    { new Guid("9bfee6f2-acc7-47ec-8bc7-544f39630513"), "ms-MY", "Malay (Malaysia)" },
                    { new Guid("4d887bf5-a081-4bb8-961d-fb177c561c08"), "ms-SG", "Malay (Singapore)" },
                    { new Guid("d64525bb-d38f-4d0a-aba1-6d0f3e11c0db"), "mt", "Maltese" },
                    { new Guid("044db733-a83e-414c-9ec7-f01a173bb3a3"), "mua", "Mundang" },
                    { new Guid("94878f44-bcd5-4d82-a9f8-501acf34b310"), "nl-SR", "Dutch (Suriname)" },
                    { new Guid("3c247834-8759-4a33-b4b9-66ce76943dee"), "nl-SX", "Dutch (Sint Maarten)" },
                    { new Guid("cdd665b7-b628-4d2c-afce-e0c0c727fb65"), "nmg", "Kwasio" },
                    { new Guid("524ef89b-033d-4c0c-a121-87ace7c5225b"), "pa-Arab", "Punjabi" },
                    { new Guid("824a1399-fff7-4784-a08d-0b947c568c17"), "pa-Arab-PK", "Punjabi (Arabic, Pakistan)" },
                    { new Guid("8051108e-2446-407d-8946-4f3e54bbb06d"), "pa-Guru", "Punjabi" },
                    { new Guid("e6a1d0fd-01a5-425c-b900-28e2e455a5ac"), "pa-Guru-IN", "Punjabi (Gurmukhi, India)" },
                    { new Guid("8c4c90a2-d56f-4d23-bfb9-aae942d784ec"), "pl", "Polish" },
                    { new Guid("0a3023b7-9c05-4e63-be15-36b35600353e"), "pl-PL", "Polish (Poland)" },
                    { new Guid("c06c3944-9776-4192-82c1-2a0a0ee4c05e"), "prg", "Prussian" },
                    { new Guid("e7c42a3b-4cae-4104-9712-3e69d5b8c9d9"), "prg-001", "Prussian (World)" },
                    { new Guid("604c73e0-96fc-4619-aa5d-b2631ffe35f8"), "ps", "Pashto" },
                    { new Guid("059bbe29-9a12-457d-b780-1d3712c299b5"), "ps-AF", "Pashto (Afghanistan)" },
                    { new Guid("10a5d2c3-629b-465c-b21d-2bf39ae2dffe"), "ps-PK", "Pashto (Pakistan)" },
                    { new Guid("15bf079d-3e44-47ba-93c0-d4cf63e4c766"), "pt", "Portuguese" },
                    { new Guid("b6ebf263-fbc3-4f1a-ad43-cf482b4a12d0"), "pt-AO", "Portuguese (Angola)" },
                    { new Guid("2f7858bc-8d53-46eb-89bd-56620d4fc855"), "pt-BR", "Portuguese (Brazil)" },
                    { new Guid("b2ea4841-6578-442d-87cd-99e8bb0f76f8"), "pt-CH", "Portuguese (Switzerland)" },
                    { new Guid("77b30ff5-636b-4915-8245-2082eb3599fa"), "pt-CV", "Portuguese (Cabo Verde)" },
                    { new Guid("8f227a2a-237c-4939-a999-e1fc7e3d4b4c"), "pt-GQ", "Portuguese (Equatorial Guinea)" },
                    { new Guid("6dfdbe0a-695b-4544-a183-4c06d6b784d9"), "pt-GW", "Portuguese (Guinea-Bissau)" },
                    { new Guid("f1600dae-1ee1-4a9b-ac1f-bd477a12d118"), "pt-LU", "Portuguese (Luxembourg)" },
                    { new Guid("371890ee-e85b-4c4b-9a3f-6f90abc4475d"), "pt-MO", "Portuguese (Macao SAR)" },
                    { new Guid("6188e562-cf11-487a-aa36-9f201435f118"), "pt-MZ", "Portuguese (Mozambique)" },
                    { new Guid("681ea045-071f-4da9-ad9e-1cc68355e6b7"), "pa", "Punjabi" },
                    { new Guid("f9e325e8-8dc3-478e-a4d1-3c7e8b7d969e"), "os-RU", "Ossetic (Russia)" },
                    { new Guid("983df180-6f30-46ad-a5f2-6a09731755c0"), "os-GE", "Ossetic (Georgia)" },
                    { new Guid("de672b65-180d-4f49-b3b1-a3138fb2a520"), "os", "Ossetic" },
                    { new Guid("0d963f39-1d67-450f-b62a-a88652f44819"), "nmg-CM", "Kwasio (Cameroon)" },
                    { new Guid("282e529d-d493-4417-95d0-45a39709d6ad"), "nn", "Norwegian Nynorsk" },
                    { new Guid("917082b1-948c-474c-86b3-866e7139c21f"), "nn-NO", "Norwegian Nynorsk (Norway)" },
                    { new Guid("209b4b3c-4bb9-4456-a354-cffbeed3b1fd"), "nnh", "Ngiemboon" },
                    { new Guid("ef107158-9a67-40c5-ac8c-3e09c6af62fc"), "nnh-CM", "Ngiemboon (Cameroon)" },
                    { new Guid("36edea8f-85d7-48e7-8111-ec08755112ba"), "nqo", "N’Ko" },
                    { new Guid("50b061dc-d828-4985-bb16-952c7471d0f0"), "nqo-GN", "N’Ko (Guinea)" },
                    { new Guid("458d3869-4d17-4469-9dfb-de361be7586c"), "nr", "South Ndebele" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("a58a6a84-01e6-40b3-b8d7-45d61c7dcb42"), "nr-ZA", "South Ndebele (South Africa)" },
                    { new Guid("0827d3d7-8a01-448f-87db-07cd18641e20"), "nso", "Sesotho sa Leboa" },
                    { new Guid("e976af73-c5dc-4f91-8057-3629d9ffd252"), "mgo", "Metaʼ" },
                    { new Guid("55243607-33c9-4266-9daa-8aeffaacb894"), "nso-ZA", "Sesotho sa Leboa (South Africa)" },
                    { new Guid("41cb1e5d-155d-4bb0-8f9b-bbc556424159"), "nus-SS", "Nuer (South Sudan)" },
                    { new Guid("292a7ec4-8a23-4dd7-9af3-6258e14a8230"), "nyn", "Nyankole" },
                    { new Guid("4e362eec-70ed-4154-b79c-da3d5a3b9e5d"), "nyn-UG", "Nyankole (Uganda)" },
                    { new Guid("45c8ef2c-aa3d-4631-95d5-c4fa9ba226e9"), "oc", "Occitan" },
                    { new Guid("439eab9c-05c2-4c18-87a7-e445b49fc59e"), "oc-FR", "Occitan (France)" },
                    { new Guid("be678ce9-6bad-4890-b1dd-8238e081d054"), "om", "Oromo" },
                    { new Guid("ce2dbe7a-4f9f-45c9-a9d9-e8e59e79a2ae"), "om-ET", "Oromo (Ethiopia)" },
                    { new Guid("e448df08-ec57-4dcf-96b9-9b991d6f7157"), "om-KE", "Oromo (Kenya)" },
                    { new Guid("3c7ac5fb-ae83-4dac-8f08-82316d8915d5"), "or", "Odia" },
                    { new Guid("2489059e-9fe5-47c4-ab71-a02da22656f8"), "or-IN", "Odia (India)" },
                    { new Guid("9f359950-a410-4a6c-8053-896ba08a20c1"), "nus", "Nuer" },
                    { new Guid("06ce4252-2952-4efa-8af4-1a58c9934b43"), "mgh-MZ", "Makhuwa-Meetto (Mozambique)" },
                    { new Guid("482e7f80-9b7d-4f27-9365-ac8330e699c0"), "mgh", "Makhuwa-Meetto" },
                    { new Guid("c66114f1-d49e-4e02-bcee-da1274165994"), "mg-MG", "Malagasy (Madagascar)" },
                    { new Guid("ca500044-81d5-4b3a-9c9b-a1af3b44edeb"), "kde-TZ", "Makonde (Tanzania)" },
                    { new Guid("c026fe5e-1493-4fc1-88f1-cfd1b2e762ef"), "kea", "Kabuverdianu" },
                    { new Guid("2838cb0c-548c-439d-9aef-288e0b7d8e8d"), "kea-CV", "Kabuverdianu (Cabo Verde)" },
                    { new Guid("aaf4b24a-e076-4b94-a611-99ada7850f95"), "khq", "Koyra Chiini" },
                    { new Guid("be64ff56-2fb8-4943-af93-8c39471475ef"), "khq-ML", "Koyra Chiini (Mali)" },
                    { new Guid("346f3a92-304b-4d46-85f6-12594cf2e357"), "ki", "Kikuyu" },
                    { new Guid("0681633e-f467-457b-82f8-04be1500f703"), "ki-KE", "Kikuyu (Kenya)" },
                    { new Guid("175ceb01-8d09-49f1-b4f5-5459334e41ca"), "kk", "Kazakh" },
                    { new Guid("e49b4d90-5200-4c49-8087-f18222331667"), "kk-KZ", "Kazakh (Kazakhstan)" },
                    { new Guid("69b51d5a-8b45-48e5-8571-2e3940e11382"), "kkj", "Kako" },
                    { new Guid("ee45de47-9e3c-4f3d-b4b9-7150d6c8ce70"), "kkj-CM", "Kako (Cameroon)" },
                    { new Guid("ea685cc7-3c38-42e2-a982-9c7b6412ba4e"), "kl", "Kalaallisut" },
                    { new Guid("2b33b563-ed56-49b1-8d9c-82940271772d"), "kl-GL", "Kalaallisut (Greenland)" },
                    { new Guid("24ef019b-49a8-4890-b095-c34261fdedbe"), "kln", "Kalenjin" },
                    { new Guid("500c233f-4195-47bf-a008-07f20376e7f0"), "kln-KE", "Kalenjin (Kenya)" },
                    { new Guid("1affeab5-8276-48b7-bb49-03c8bcce744d"), "km", "Khmer" },
                    { new Guid("025a75ca-9ce6-444a-84aa-300e02347e81"), "km-KH", "Khmer (Cambodia)" },
                    { new Guid("52e73a90-a088-4703-8a01-b6e9fdb13049"), "kn", "Kannada" },
                    { new Guid("7e7aa969-9937-4bab-a5b4-b255cbc71722"), "kn-IN", "Kannada (India)" },
                    { new Guid("fa02c399-7313-4384-a758-d3259088d248"), "ko", "Korean" },
                    { new Guid("11d0e3af-1e4c-4620-bd1b-1b3786827292"), "ko-KP", "Korean (North Korea)" },
                    { new Guid("93f9c900-6b09-45a0-a587-f76503d45bb4"), "kde", "Makonde" },
                    { new Guid("692a6766-341d-42b2-b41e-aedfc89dd250"), "kam-KE", "Kamba (Kenya)" },
                    { new Guid("ffe05080-8d86-432b-9d56-e88098a83b28"), "kam", "Kamba" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("9b534964-283e-482b-b609-aac89efb4231"), "kab-DZ", "Kabyle (Algeria)" },
                    { new Guid("6f3bbb60-f3bd-4c7e-a0dd-7d8e89646524"), "is", "Icelandic" },
                    { new Guid("9a822c53-d511-44d7-8f35-9c94990fe360"), "is-IS", "Icelandic (Iceland)" },
                    { new Guid("35c6c5ee-6f69-4765-8dd1-5002ddaf66e7"), "it", "Italian" },
                    { new Guid("925e99f8-1a57-4f61-8b18-d7cd1a467c8f"), "it-CH", "Italian (Switzerland)" },
                    { new Guid("fa39939a-b975-4b25-9eba-27c30ffc0d7d"), "it-IT", "Italian (Italy)" },
                    { new Guid("0c267584-dfec-4592-b2de-34bae21ccec4"), "it-SM", "Italian (San Marino)" },
                    { new Guid("c0bcd3ad-611a-4e60-bef2-775b1b0c17b5"), "it-VA", "Italian (Vatican City)" },
                    { new Guid("5a85f60e-f8f7-43ed-8503-eea814c4b1c7"), "iu", "Inuktitut" },
                    { new Guid("e8160332-e5e6-49f1-9ba1-142fc07dce65"), "iu-CA", "Inuktitut (Canada)" },
                    { new Guid("64c81bde-4fb9-410b-acd0-3cb12e9700f8"), "iu-Latn", "Inuktitut" },
                    { new Guid("e595dc5a-3c7a-4e62-a7f9-47d9706c7a6a"), "ko-KR", "Korean (Korea)" },
                    { new Guid("360f6b12-cae6-4705-a092-3e3d09425954"), "iu-Latn-CA", "Inuktitut (Latin, Canada)" },
                    { new Guid("e21dd77a-b366-47d7-a8d5-b4e26200f6a6"), "ja-JP", "Japanese (Japan)" },
                    { new Guid("bf758b54-d0dc-4979-8c29-5fc5467d60ec"), "jgo", "Ngomba" },
                    { new Guid("0f4f596e-893b-48b7-9234-56c7fec9faf4"), "jgo-CM", "Ngomba (Cameroon)" },
                    { new Guid("42800faa-22a9-45ad-844e-f6a4c35580d4"), "jmc", "Machame" },
                    { new Guid("49837b46-56c0-4b00-826e-86b87fae98af"), "jmc-TZ", "Machame (Tanzania)" },
                    { new Guid("06a264f6-9521-4f4a-8fa7-e78d688484fa"), "jv", "Javanese" },
                    { new Guid("fdbb1e29-569e-48f9-8af6-b4fe39f362f6"), "jv-ID", "Javanese (Indonesia)" },
                    { new Guid("39fa5131-468f-446b-8615-4e1a86026c31"), "ka", "Georgian" },
                    { new Guid("5eec5e91-adef-497d-9bda-1bfaa447e73e"), "ka-GE", "Georgian (Georgia)" },
                    { new Guid("6586f12e-b9c8-4e9d-bdbb-aed94117d541"), "kab", "Kabyle" },
                    { new Guid("f790104b-d714-4508-83e8-497373eca727"), "ja", "Japanese" },
                    { new Guid("fda1638f-b98f-43b8-b4c1-de05c9ff7c04"), "pt-PT", "Portuguese (Portugal)" },
                    { new Guid("d3eeb82b-c509-46e6-b153-d2cad6ffd89b"), "kok", "Konkani" },
                    { new Guid("4d48e49d-b4d5-4a61-b0a9-453b6f15da62"), "ks", "Kashmiri" },
                    { new Guid("777d4de2-7414-41db-bf89-155e85846d94"), "lrc", "Northern Luri" },
                    { new Guid("d5bcaf9d-e041-4f8e-82a8-b4d446dc1ee2"), "lrc-IQ", "Northern Luri (Iraq)" },
                    { new Guid("2eedacb1-a314-497d-a8b9-628715092c81"), "lrc-IR", "Northern Luri (Iran)" },
                    { new Guid("23eefa43-3410-4ce3-b838-3f68c17f8de5"), "lt", "Lithuanian" },
                    { new Guid("831ad560-d23d-4b12-a3c9-e9a29a1d8477"), "lt-LT", "Lithuanian (Lithuania)" },
                    { new Guid("ee757cea-12a7-450e-b72d-553bca311a53"), "lu", "Luba-Katanga" },
                    { new Guid("c672fe44-414b-4eb6-a5c9-37f0b6101117"), "lu-CD", "Luba-Katanga (Congo [DRC])" },
                    { new Guid("2c9201c5-fc95-4d39-bd53-d9a369f53fe2"), "luo", "Luo" },
                    { new Guid("98059ee5-d387-449d-aaa9-76b4ce72b64b"), "luo-KE", "Luo (Kenya)" },
                    { new Guid("21df3829-4363-42bf-b88b-fc68d7e96fa2"), "luy", "Luyia" },
                    { new Guid("3d5491a2-e5b2-4f27-aab2-46372eacb336"), "luy-KE", "Luyia (Kenya)" },
                    { new Guid("9be4b977-6c9a-4577-af71-0513f35baf80"), "lv", "Latvian" },
                    { new Guid("a54045aa-ee93-4d69-baa7-5ebe4888bf09"), "lv-LV", "Latvian (Latvia)" },
                    { new Guid("a74f5998-6f3c-4afd-bb43-1a5b974342d0"), "mas", "Masai" },
                    { new Guid("419bfcdb-acee-4ea7-a865-e1141f6f584b"), "mas-KE", "Masai (Kenya)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("7f29f1dc-bc83-47ec-bae5-b1998ffb7cb0"), "mas-TZ", "Masai (Tanzania)" },
                    { new Guid("761e4d8c-3aec-4586-a45e-185d127f5218"), "mer", "Meru" },
                    { new Guid("5ba90df6-2484-446b-9789-811239c67072"), "mer-KE", "Meru (Kenya)" },
                    { new Guid("356e8951-d1e8-4e54-aaff-5bf81533602c"), "mfe", "Morisyen" },
                    { new Guid("b7156265-1dd3-45a1-8546-f55234842ac2"), "mfe-MU", "Morisyen (Mauritius)" },
                    { new Guid("00626d60-c2e2-4d70-aefa-9ab62aab7135"), "mg", "Malagasy" },
                    { new Guid("7adfd0c2-3de9-4ec8-9114-c92ccd504b96"), "lo-LA", "Lao (Laos)" },
                    { new Guid("f29ef818-ca4d-49c2-a2cd-f3ea0303eddd"), "lo", "Lao" },
                    { new Guid("5144ede9-e6ab-4317-a0d9-27a66801e0ad"), "ln-CG", "Lingala (Congo)" },
                    { new Guid("bc631d31-ea94-4f5d-9a10-36c4fad811ae"), "ln-CF", "Lingala (Central African Republic)" },
                    { new Guid("4f8ecc21-4e32-4c24-b1f8-2773be50d61c"), "ks-IN", "Kashmiri (India)" },
                    { new Guid("e57d2b42-73ed-4448-b108-2dd9d9244071"), "ksb", "Shambala" },
                    { new Guid("9b82b305-403c-451c-9d2f-bc2c3ce4dd5f"), "ksb-TZ", "Shambala (Tanzania)" },
                    { new Guid("7bebe4c9-b991-4198-9182-b0e53b944fc2"), "ksf", "Bafia" },
                    { new Guid("fc170caf-0ae8-4107-b6ac-1230d860688b"), "ksf-CM", "Bafia (Cameroon)" },
                    { new Guid("15ed1621-9fd7-4558-9a3d-c93ebe6a3597"), "ksh", "Colognian" },
                    { new Guid("312bf862-bcdd-4a1b-a653-4f55826dd92e"), "ksh-DE", "Colognian (Germany)" },
                    { new Guid("3a751afc-94ef-4c45-9064-c6845cdf0435"), "kw", "Cornish" },
                    { new Guid("2bebadb7-0c45-4726-b385-5688dcd6cbd5"), "kw-GB", "Cornish (United Kingdom)" },
                    { new Guid("99ffd405-e875-40e0-8fe4-8298c7a16109"), "ky", "Kyrgyz" },
                    { new Guid("2498681e-ce97-4020-9f76-520b8c06cdd3"), "kok-IN", "Konkani (India)" },
                    { new Guid("f86f51d2-aab3-471f-a314-5496dad4c676"), "ky-KG", "Kyrgyz (Kyrgyzstan)" },
                    { new Guid("88805a21-cc73-452f-bba0-0402c53e1b54"), "lag-TZ", "Langi (Tanzania)" },
                    { new Guid("74a4d8a2-0b99-488b-b2b5-a3d1a067df3e"), "lb", "Luxembourgish" },
                    { new Guid("2c2d286b-102c-4e96-9447-e27f9e55a008"), "lb-LU", "Luxembourgish (Luxembourg)" },
                    { new Guid("94084192-e88a-4382-8711-68ec43ab3037"), "lg", "Ganda" },
                    { new Guid("f8667b59-ecbb-4455-9d56-e47ca6cfa18a"), "lg-UG", "Ganda (Uganda)" },
                    { new Guid("1fab1bec-85ff-41cf-8995-bafe0f66d67a"), "lkt", "Lakota" },
                    { new Guid("684a4e71-c9a5-4da2-9d91-9accde9cce6c"), "lkt-US", "Lakota (United States)" },
                    { new Guid("4f90f083-bc9b-4bc9-873e-7b80e4b29b56"), "ln", "Lingala" },
                    { new Guid("781723e2-d4e5-4942-9baf-928ab44771b5"), "ln-AO", "Lingala (Angola)" },
                    { new Guid("867c04c6-8d72-4b35-af24-9faa2938f1b5"), "ln-CD", "Lingala (Congo [DRC])" },
                    { new Guid("a69a55e0-73a5-4dcb-99a4-ff129faa5efc"), "lag", "Langi" },
                    { new Guid("e7f03879-8299-4f85-bb83-8915b15b0d0f"), "pt-ST", "Portuguese (São Tomé & Príncipe)" },
                    { new Guid("5cb23147-b55f-42a7-a93f-0c92039e1bc5"), "pt-TL", "Portuguese (Timor-Leste)" },
                    { new Guid("bff9c028-be7a-4dc0-9140-d5bcbabebed1"), "qu", "Quechua" },
                    { new Guid("b280d341-4fbc-4c00-9e07-c2073e50d551"), "tn", "Setswana" },
                    { new Guid("e93065c6-71cd-4927-a65e-3243cfe04136"), "tn-BW", "Setswana (Botswana)" },
                    { new Guid("fb9c4d7c-d5ef-4b0d-aa3e-b4b31e08a7a4"), "tn-ZA", "Setswana (South Africa)" },
                    { new Guid("ff45c122-47f7-4791-98fb-1a4b7e359ffd"), "to", "Tongan" },
                    { new Guid("d29ca842-6b46-4a85-9271-77c9eadf3d9c"), "to-TO", "Tongan (Tonga)" },
                    { new Guid("472222a4-5a03-4fda-a91d-c8233abd3fd4"), "tr", "Turkish" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("baa458be-d05a-4412-8bab-a130047f319b"), "tr-CY", "Turkish (Cyprus)" },
                    { new Guid("dd66e126-c642-4717-ab52-ff45df2f28bc"), "tr-TR", "Turkish (Turkey)" },
                    { new Guid("838aa411-27a4-4b93-b1b0-a2b09949e827"), "ts", "Xitsonga" },
                    { new Guid("dc1a5899-28a6-4c4d-bec9-6b6ec9fe4a37"), "ts-ZA", "Xitsonga (South Africa)" },
                    { new Guid("b81c313d-f98a-459b-9588-62c4265f20dc"), "tt", "Tatar" },
                    { new Guid("a4236817-b99c-42de-a78d-11b690910355"), "tt-RU", "Tatar (Russia)" },
                    { new Guid("1f7d3639-75c8-455c-9c1c-9f5a66887901"), "twq", "Tasawaq" },
                    { new Guid("4683d2d9-53a0-430f-afc4-255884f4e5c6"), "twq-NE", "Tasawaq (Niger)" },
                    { new Guid("004d0c7c-5035-4bb5-9856-e4d59098e0bc"), "tzm", "Central Atlas Tamazight" },
                    { new Guid("1f92981b-2e98-47e8-8e7b-7044dc32d7f8"), "tzm-MA", "Central Atlas Tamazight (Morocco)" },
                    { new Guid("fc6b0f40-5c1b-4eb7-92fc-f69dda8dc5ea"), "ug", "Uyghur" },
                    { new Guid("32d2c935-df11-4249-b1f4-72ce25e0d9d5"), "ug-CN", "Uyghur (China)" },
                    { new Guid("df3fc9d4-409c-477a-912e-6520cb0d21ba"), "uk", "Ukrainian" },
                    { new Guid("81f7c1d0-0d67-4e9c-bfbf-7c1868d6c840"), "uk-UA", "Ukrainian (Ukraine)" },
                    { new Guid("446a9837-c943-4fc7-9eb2-9b79fd6c23e3"), "ur", "Urdu" },
                    { new Guid("7619cea6-c85e-4b5f-8d4c-89f1bb731706"), "tk-TM", "Turkmen (Turkmenistan)" },
                    { new Guid("380a9423-ce24-4344-b7ad-9214e64b5921"), "tk", "Turkmen" },
                    { new Guid("225c2614-a1ba-47bd-a04a-eba297b2723a"), "tig-ER", "Tigre (Eritrea)" },
                    { new Guid("c75574d8-851b-41c0-a44b-c7b17d07a830"), "tig", "Tigre" },
                    { new Guid("956aceee-c5d4-4a50-b728-6feb294d6824"), "sw-KE", "Kiswahili (Kenya)" },
                    { new Guid("698fca59-5887-41cc-b7d4-6c1e7852f62b"), "sw-TZ", "Kiswahili (Tanzania)" },
                    { new Guid("67d215be-c784-47ac-9094-ab565a715008"), "sw-UG", "Kiswahili (Uganda)" },
                    { new Guid("db181c0b-f025-4c07-817d-a83946ac63e1"), "syr", "Syriac" },
                    { new Guid("03d143af-7854-4d78-a3b4-81d678457b35"), "syr-SY", "Syriac (Syria)" },
                    { new Guid("f38a3aa5-f0fe-4121-a687-76df55b72e2a"), "ta", "Tamil" },
                    { new Guid("351f5865-64e4-4a14-a7e2-635b09c856a7"), "ta-IN", "Tamil (India)" },
                    { new Guid("d7ead07c-597a-45eb-bbe1-458ed5556414"), "ta-LK", "Tamil (Sri Lanka)" },
                    { new Guid("24d842de-036d-47de-a2d5-959b33f0f248"), "ta-MY", "Tamil (Malaysia)" },
                    { new Guid("66cd72b3-04b5-45a2-9833-03aed75ea70d"), "ta-SG", "Tamil (Singapore)" },
                    { new Guid("1a790984-84e6-4868-95f9-b245cd9138bb"), "ur-IN", "Urdu (India)" },
                    { new Guid("f55b47b2-9dde-4b81-a9f6-03439281c4f1"), "te", "Telugu" },
                    { new Guid("ee374de5-9b7c-4b28-8231-dcef30ffde83"), "teo", "Teso" },
                    { new Guid("5c667fa9-2509-47c6-b312-60696a905cb5"), "teo-KE", "Teso (Kenya)" },
                    { new Guid("e9fe9307-167a-4905-bbad-9732bead9854"), "teo-UG", "Teso (Uganda)" },
                    { new Guid("95bf9456-01b9-4f97-9817-bc51c3857779"), "tg", "Tajik" },
                    { new Guid("abccf487-99c6-42a7-a641-5d066f24f8cc"), "tg-TJ", "Tajik (Tajikistan)" },
                    { new Guid("d589bb11-4976-4fb6-8f67-cd547a68e059"), "th", "Thai" },
                    { new Guid("765db233-add4-4ed1-b15a-413c5b8fbabb"), "th-TH", "Thai (Thailand)" },
                    { new Guid("3cc7a84c-867b-4d0e-a15b-3c32cc005da2"), "ti", "Tigrinya" },
                    { new Guid("46cb70aa-af72-4af8-88ef-66731f15022b"), "ti-ER", "Tigrinya (Eritrea)" },
                    { new Guid("6773c172-04b2-4027-9228-7904fd6fe7f6"), "ti-ET", "Tigrinya (Ethiopia)" },
                    { new Guid("6f6f337b-d36b-4f26-b765-c2c02920e7a2"), "te-IN", "Telugu (India)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("fa8a5528-6518-449d-ace5-f85da7017db8"), "sw-CD", "Kiswahili (Congo [DRC])" },
                    { new Guid("db450bef-abcb-4510-bd10-4f3f2d633c0a"), "ur-PK", "Urdu (Pakistan)" },
                    { new Guid("08bebe46-c69f-414f-94aa-b469a4222e51"), "uz-Arab", "Uzbek" },
                    { new Guid("fd95f09b-9ae9-49ab-9739-a0fe44379cbe"), "xog", "Soga" },
                    { new Guid("e5703e15-a18c-46e0-9f60-9c9313aef76d"), "xog-UG", "Soga (Uganda)" },
                    { new Guid("45fe6ab7-40bd-4afd-a6c2-c5c635ac400b"), "yav", "Yangben" },
                    { new Guid("30009bb8-92fc-47c7-a143-d494559296b5"), "yav-CM", "Yangben (Cameroon)" },
                    { new Guid("ff81c06e-dab2-4de4-874a-d8a546bb2397"), "yi", "Yiddish" },
                    { new Guid("a68d1a97-8b5d-4edc-95c1-4814d1fe2916"), "yi-001", "Yiddish (World)" },
                    { new Guid("238caa27-2d91-4ca1-9833-231b139f27d3"), "yo", "Yoruba" },
                    { new Guid("e0581370-1f24-41e9-aa53-29d9c4bbab38"), "yo-BJ", "Yoruba (Benin)" },
                    { new Guid("d93e0213-0150-44b1-a101-4226b28b1fcf"), "yo-NG", "Yoruba (Nigeria)" },
                    { new Guid("788a130d-bfe1-441a-9605-d03395f91c6b"), "zgh", "Standard Moroccan Tamazight" },
                    { new Guid("235a92d2-b237-47dd-802c-c85233d51cc7"), "zgh-MA", "Standard Moroccan Tamazight (Morocco)" },
                    { new Guid("1070acbf-d1d4-4772-92e3-f96720e5e758"), "zh", "Chinese" },
                    { new Guid("b95c8a2e-5907-4bb2-ac2e-d32dd00a4f0a"), "zh-Hans", "Chinese" },
                    { new Guid("b5076dda-8c7a-452b-9c37-f218a5668159"), "zh-Hans-CN", "Chinese (Simplified, China)" },
                    { new Guid("b65a224a-9958-4630-b2d4-9c2e53017fee"), "zh-Hans-HK", "Chinese (Simplified, Hong Kong SAR)" },
                    { new Guid("493efa6b-1939-4048-9e79-478486ae81f2"), "zh-Hans-MO", "Chinese (Simplified, Macao SAR)" },
                    { new Guid("e8a83524-6a75-4286-acac-bc21b6566c15"), "zh-Hans-SG", "Chinese (Simplified, Singapore)" },
                    { new Guid("85269bd5-243b-4e9c-8cb7-aa0a9517e84f"), "zh-Hant", "Chinese" },
                    { new Guid("44fa6272-50b1-47bc-b23d-c7e25d3eb192"), "zh-Hant-HK", "Chinese (Traditional, Hong Kong SAR)" },
                    { new Guid("d59a8049-81f3-434f-8fc1-089f2269fe9b"), "zh-Hant-MO", "Chinese (Traditional, Macao SAR)" },
                    { new Guid("1759adf8-9a70-4ea3-8182-bfa7077975ad"), "zh-Hant-TW", "Chinese (Traditional, Taiwan)" },
                    { new Guid("8e560b51-3274-4a5f-bbbd-5a54e3b1f5c0"), "xh-ZA", "isiXhosa (South Africa)" },
                    { new Guid("fccb006d-c4c4-4f7f-bb7d-e4483f037c5a"), "xh", "isiXhosa" },
                    { new Guid("feaf315a-8099-4a0e-bd22-025d12a4d8ec"), "wo-SN", "Wolof (Senegal)" },
                    { new Guid("74e65ffa-f8d5-47cb-bae6-040452cb4581"), "wo", "Wolof" },
                    { new Guid("b891b8aa-6680-47fa-88b3-f6f5fe4ef2ac"), "uz-Arab-AF", "Uzbek (Arabic, Afghanistan)" },
                    { new Guid("09bbcc65-120f-4066-ac7e-08062b09055f"), "uz-Cyrl", "Uzbek" },
                    { new Guid("bff13489-07cb-4f59-b1a4-abbdd355b327"), "uz-Cyrl-UZ", "Uzbek (Cyrillic, Uzbekistan)" },
                    { new Guid("53a4de48-e4ee-4ea8-95a8-aea95814c833"), "uz-Latn", "Uzbek" },
                    { new Guid("26b6c588-d951-416f-bafc-1888154d45af"), "uz-Latn-UZ", "Uzbek (Latin, Uzbekistan)" },
                    { new Guid("ba0b7454-fba6-4051-b5eb-a86247403126"), "vai", "Vai" },
                    { new Guid("460cf388-f1d4-401d-8775-6ae14ebee409"), "vai-Latn", "Vai" },
                    { new Guid("1945ce3d-0403-426b-901c-7d58573d16e9"), "vai-Latn-LR", "Vai (Latin, Liberia)" },
                    { new Guid("fc718a0b-980c-463a-b1e0-4e49bfef89d1"), "vai-Vaii", "Vai" },
                    { new Guid("d670dc89-ec30-41cb-aa48-28752fb79650"), "vai-Vaii-LR", "Vai (Vai, Liberia)" },
                    { new Guid("d622843e-9a8d-4d20-895b-19dc66baadff"), "uz", "Uzbek" },
                    { new Guid("b379cd46-1662-443c-a197-667c47755af2"), "ve", "Venda" },
                    { new Guid("5caf0048-6a47-4636-b81f-edefd5ebce78"), "vi", "Vietnamese" },
                    { new Guid("5c538d53-8164-40d4-95d8-07db9dd8e539"), "vi-VN", "Vietnamese (Vietnam)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("a7a60d23-efd6-4196-9d75-05a9e5de17c5"), "vo", "Volapük" },
                    { new Guid("01c06d79-13d2-492d-ac86-46965b988e43"), "vo-001", "Volapük (World)" },
                    { new Guid("a50eecf3-629d-4d60-9c0d-ebc6c7ca148a"), "vun", "Vunjo" },
                    { new Guid("1ba93818-7c36-44b9-a117-ad03319bc294"), "vun-TZ", "Vunjo (Tanzania)" },
                    { new Guid("f6a2dd4e-68ee-4e05-ad5f-a61c7f91640d"), "wae", "Walser" },
                    { new Guid("7118acf5-88a2-48d6-98dc-ff4f77245be7"), "wae-CH", "Walser (Switzerland)" },
                    { new Guid("e60cd86b-9ed6-4e25-9707-3a2a9ed85419"), "wal", "Wolaytta" },
                    { new Guid("ef48ab7b-6d0f-4719-877d-99a44b17df83"), "wal-ET", "Wolaytta (Ethiopia)" },
                    { new Guid("ef9e4a30-f4ce-4e85-aee9-bf810bbf6cb5"), "ve-ZA", "Venda (South Africa)" },
                    { new Guid("08458e85-2893-49a3-9feb-0da00cceb17e"), "ii-CN", "Yi (China)" },
                    { new Guid("c67b377d-f494-48d5-ac43-7c82587d9674"), "sw", "Kiswahili" },
                    { new Guid("60679238-a0e4-4d36-ad63-d3b26eff7c1e"), "sv-FI", "Swedish (Finland)" },
                    { new Guid("9eb09f82-5c81-4ed8-84c1-a1abd8203b34"), "sa-IN", "Sanskrit (India)" },
                    { new Guid("ff01ed19-880f-4fd7-ae5d-9cd915502cfa"), "sah", "Sakha" },
                    { new Guid("2e02b1cf-765b-419d-b2c2-df0ef5b97522"), "sah-RU", "Sakha (Russia)" },
                    { new Guid("5c89e84f-90a8-4c67-ad58-0c029e58b730"), "saq", "Samburu" },
                    { new Guid("d7bd10b4-77eb-470a-a170-10f653ccba9e"), "saq-KE", "Samburu (Kenya)" },
                    { new Guid("d2beec0f-a91a-4c32-ab90-da871eb74a04"), "sbp", "Sangu" },
                    { new Guid("c08dc61d-eefd-4906-b5c8-aee78a48f3e9"), "sbp-TZ", "Sangu (Tanzania)" },
                    { new Guid("75252ca7-802e-4446-960f-d7255bda9b3f"), "sd", "Sindhi" },
                    { new Guid("81a1f589-b2ec-4de2-943b-76c2c3edb057"), "sd-PK", "Sindhi (Pakistan)" },
                    { new Guid("6f037aa8-23c0-4bf9-9d6c-75699c991473"), "se", "Northern Sami" },
                    { new Guid("cd5c3880-b3ab-4543-85aa-45c4077f838f"), "se-FI", "Northern Sami (Finland)" },
                    { new Guid("3419a799-fd27-4253-a77b-af38a453ed50"), "se-NO", "Northern Sami (Norway)" },
                    { new Guid("149d27b7-404f-4491-b255-9b71b0459139"), "se-SE", "Northern Sami (Sweden)" },
                    { new Guid("9a4e64ae-85b1-4cc0-b858-f3d4e1fe7c00"), "seh", "Sena" },
                    { new Guid("127dc853-336c-484b-a7b4-6dfdcf11a5fb"), "seh-MZ", "Sena (Mozambique)" },
                    { new Guid("0cfb9327-a74a-473c-af59-9cf343c45e5e"), "ses", "Koyraboro Senni" },
                    { new Guid("e0023d7f-7b64-4d74-8ee2-0bcad7f6744d"), "ses-ML", "Koyraboro Senni (Mali)" },
                    { new Guid("241c2755-aeb7-4b5c-ba9b-74f6798eb7a0"), "sg", "Sango" },
                    { new Guid("12b684cd-9e21-4b58-82b4-4b7dbcbbb27e"), "sg-CF", "Sango (Central African Republic)" },
                    { new Guid("410ab912-c664-47bd-bc7b-c0774c64cb5c"), "shi", "Tachelhit" },
                    { new Guid("03edacbe-d252-4c11-9492-2059193fd931"), "shi-Latn", "Tachelhit" },
                    { new Guid("1316d07c-8018-4b1b-a95f-2bb551d30ec9"), "sa", "Sanskrit" },
                    { new Guid("6408f914-6643-4c90-b378-39534071cf48"), "rwk-TZ", "Rwa (Tanzania)" },
                    { new Guid("56ee7458-4f04-4f17-aa01-bf82e3f7e01e"), "rwk", "Rwa" },
                    { new Guid("6a715af4-6eae-4700-adc5-0893d06bb3a7"), "rw-RW", "Kinyarwanda (Rwanda)" },
                    { new Guid("4b4869dc-73e4-4dc0-8459-252ab6ace63f"), "qu-BO", "Quechua (Bolivia)" },
                    { new Guid("4caaecf8-0c2a-43e0-9344-ea731567c48b"), "qu-EC", "Quechua (Ecuador)" },
                    { new Guid("5dac7a4f-c9a9-4991-916f-3036fa8775dc"), "qu-PE", "Quechua (Peru)" },
                    { new Guid("a19557f2-bb7e-4447-8ee4-d4a894d7901b"), "quc", "Kʼicheʼ" },
                    { new Guid("fea98f7f-3307-41fa-bdb0-c5af9d751597"), "quc-GT", "Kʼicheʼ (Guatemala)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("56a87ddb-4f13-4860-9927-091deb146a22"), "rm", "Romansh" },
                    { new Guid("c2becb74-15f6-4224-8283-a16127b23940"), "rm-CH", "Romansh (Switzerland)" },
                    { new Guid("5ea3973d-f904-4f03-995e-77efc1126f2d"), "rn", "Rundi" },
                    { new Guid("c8049f0a-b99c-4215-b061-38e63292c1a0"), "rn-BI", "Rundi (Burundi)" },
                    { new Guid("06692370-ee76-4b15-bc1b-1ed4b02f20e6"), "ro", "Romanian" },
                    { new Guid("52332fd7-6630-4bd7-80d3-12654140f1c0"), "shi-Latn-MA", "Tachelhit (Latin, Morocco)" },
                    { new Guid("db8800fb-2dc3-41f1-adab-e6ea02f9c206"), "ro-MD", "Romanian (Moldova)" },
                    { new Guid("d04f7066-a9b2-47fd-9f1c-3ad3b86495f2"), "rof", "Rombo" },
                    { new Guid("03c8045a-1a5c-4e31-86c1-923014401f40"), "rof-TZ", "Rombo (Tanzania)" },
                    { new Guid("3a2c7c70-09e0-48a8-ae11-3cfbc381b373"), "ru", "Russian" },
                    { new Guid("e0f94ac3-7c47-453a-b2f6-67c503cd6b02"), "ru-BY", "Russian (Belarus)" },
                    { new Guid("1e2a865d-5cc3-4eaa-8b5c-5de60cd9c39d"), "ru-KG", "Russian (Kyrgyzstan)" },
                    { new Guid("a29bd4a5-5a38-4106-961d-4c01833cf7f5"), "ru-KZ", "Russian (Kazakhstan)" },
                    { new Guid("61eb9cd4-9f2a-4a4b-85ee-985b7dc86308"), "ru-MD", "Russian (Moldova)" },
                    { new Guid("180307ba-4a3c-4415-b24f-1370aa799bbb"), "ru-RU", "Russian (Russia)" },
                    { new Guid("1e33cdac-d460-4cae-a11d-7dd5e5fe1d9b"), "ru-UA", "Russian (Ukraine)" },
                    { new Guid("fa127704-9390-45fd-bc2a-fa426cfeee2c"), "rw", "Kinyarwanda" },
                    { new Guid("a0439271-745e-4cc3-98f7-c12a38b2acba"), "ro-RO", "Romanian (Romania)" },
                    { new Guid("f1307975-0af2-4d5a-939a-4e5036e9ab43"), "sv-SE", "Swedish (Sweden)" },
                    { new Guid("20af39cd-a1da-4d94-b4d2-cf3235e90ceb"), "shi-Tfng", "Tachelhit" },
                    { new Guid("299d2811-84eb-42c2-b164-8f0ed1500312"), "si", "Sinhala" },
                    { new Guid("b5c7e332-90a2-4a7c-8f86-1334e44b3e54"), "sr", "Serbian" },
                    { new Guid("54a4c3eb-5146-4b47-a4cc-27272c57ded8"), "sr-Cyrl", "Serbian" },
                    { new Guid("84b133b8-5c0a-44ad-b024-40b2b8860f98"), "sr-Cyrl-BA", "Serbian (Cyrillic, Bosnia & Herzegovina)" },
                    { new Guid("c0e100bd-47e8-4873-867a-9ddc2b18997a"), "sr-Cyrl-ME", "Serbian (Cyrillic, Montenegro)" },
                    { new Guid("bd7abd68-2758-4a05-ba56-036050ec1c45"), "sr-Cyrl-RS", "Serbian (Cyrillic, Serbia)" },
                    { new Guid("8c1f598a-b6a8-44d7-ad73-a28f452f4d49"), "sr-Cyrl-XK", "Serbian (Cyrillic, Kosovo)" },
                    { new Guid("a48847cb-6d48-4a7b-89a8-1f9a7f427977"), "sr-Latn", "Serbian" },
                    { new Guid("3cf169de-469e-4fc0-9173-fd93c9ff26d5"), "sr-Latn-BA", "Serbian (Latin, Bosnia & Herzegovina)" },
                    { new Guid("6058dd33-a12b-4b23-bbcb-74a82f8c8e76"), "sr-Latn-ME", "Serbian (Latin, Montenegro)" },
                    { new Guid("f7e24116-7da6-4e1b-b723-d05b7a1ae2c0"), "sr-Latn-RS", "Serbian (Latin, Serbia)" },
                    { new Guid("3d74cd12-9185-42e3-a726-cdd9c79ff632"), "sr-Latn-XK", "Serbian (Latin, Kosovo)" },
                    { new Guid("5597638e-2bf7-4fb0-bb8b-1763ac6a9f19"), "ss", "siSwati" },
                    { new Guid("6a7cef0e-896a-48b7-b2e8-76da4d4bdff0"), "ss-SZ", "siSwati (Eswatini)" },
                    { new Guid("3080ab51-e865-400c-8f3e-bac1e42a6e05"), "ss-ZA", "siSwati (South Africa)" },
                    { new Guid("2957b1bf-ceb6-4911-8116-65d292dbb7e9"), "ssy", "Saho" },
                    { new Guid("aa3bb68d-4ea4-488a-93b5-dbcd4c6bdce5"), "ssy-ER", "Saho (Eritrea)" },
                    { new Guid("3bb6ef9c-20eb-4cf1-bdcc-3de43769aafc"), "st", "Sesotho" },
                    { new Guid("779c9fdf-a584-4c4a-ac0e-1ca77d18e68a"), "st-LS", "Sesotho (Lesotho)" },
                    { new Guid("8c06ec47-de02-4f30-810f-9388b791ef6d"), "st-ZA", "Sesotho (South Africa)" },
                    { new Guid("c5bd099c-1b0a-4fe0-9e99-8590f9ca44ef"), "sv", "Swedish" },
                    { new Guid("5a47b6c8-3c6f-4eca-a791-9408b0ff0531"), "sv-AX", "Swedish (Åland Islands)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("c0443863-18ed-4533-80ff-b832afc70fac"), "sq-XK", "Albanian (Kosovo)" },
                    { new Guid("e57c2bb4-730e-40ad-8610-eeeb0286d8c7"), "sq-MK", "Albanian (North Macedonia)" },
                    { new Guid("f1aaa120-7221-400a-8611-05a4b9255097"), "sq-AL", "Albanian (Albania)" },
                    { new Guid("d959e212-1950-42db-9081-0634ee1e8909"), "sq", "Albanian" },
                    { new Guid("52586f59-65f7-4117-8744-4bb6b69cdfd2"), "si-LK", "Sinhala (Sri Lanka)" },
                    { new Guid("edcf6faf-2159-4a0b-abf3-afffbcd09999"), "sk", "Slovak" },
                    { new Guid("a62a77c9-8ac3-4fc3-b6e5-4db9f6d337a4"), "sk-SK", "Slovak (Slovakia)" },
                    { new Guid("9e763847-08d6-4481-bbe6-60f1b0e77f3d"), "sl", "Slovenian" },
                    { new Guid("5986ae02-e79c-4f24-8c21-739c93b015de"), "sl-SI", "Slovenian (Slovenia)" },
                    { new Guid("d983464f-2273-40a8-b426-f027f436ec29"), "sma", "Southern Sami" },
                    { new Guid("56a03f99-6771-472c-a072-af35622a0627"), "sma-NO", "Southern Sami (Norway)" },
                    { new Guid("6cbec3e6-6f65-44df-ab6f-5fa15619a3a2"), "sma-SE", "Southern Sami (Sweden)" },
                    { new Guid("983b50a1-f6fc-4738-8a14-be54f549a21b"), "smj", "Lule Sami" },
                    { new Guid("285a3d36-0db5-4a00-9971-815515bfb540"), "smj-NO", "Lule Sami (Norway)" },
                    { new Guid("2e3d82b2-cedf-42c7-8b08-1926517529c0"), "shi-Tfng-MA", "Tachelhit (Tifinagh, Morocco)" },
                    { new Guid("dffc3b55-aa20-4404-b8fb-0dbdc17c6922"), "smj-SE", "Lule Sami (Sweden)" },
                    { new Guid("cec83462-b0dc-4694-846e-f8b2cb1b60e6"), "smn-FI", "Inari Sami (Finland)" },
                    { new Guid("85eab1c9-36d8-45f7-af97-5c9972d60043"), "sms", "Skolt Sami" },
                    { new Guid("b72f41d6-c96d-440c-8089-bf1216dc6c73"), "sms-FI", "Skolt Sami (Finland)" },
                    { new Guid("1aac1edb-b9c2-46b3-acd4-5af1307a4841"), "sn", "Shona" },
                    { new Guid("54ecca32-8338-4fc1-b221-6b92bee34359"), "sn-ZW", "Shona (Zimbabwe)" },
                    { new Guid("8fae487f-8a45-4ddf-aa41-27a8220057ce"), "so", "Somali" },
                    { new Guid("a43a1fc3-2b01-4fba-9706-6629005d624b"), "so-DJ", "Somali (Djibouti)" },
                    { new Guid("cafad238-cbdd-4162-95ae-d2fb3a22dab8"), "so-ET", "Somali (Ethiopia)" },
                    { new Guid("d521405c-e889-4510-9e60-5822909680d7"), "so-KE", "Somali (Kenya)" },
                    { new Guid("30615e32-2606-41d3-8a56-3624d73b42e6"), "so-SO", "Somali (Somalia)" },
                    { new Guid("fd42a74c-39f6-493e-a2a9-f8863f3d6a03"), "smn", "Inari Sami" },
                    { new Guid("1857b97d-bedc-4324-b8f4-7bf1d93b055d"), "zu", "isiZulu" },
                    { new Guid("dfb60a22-430c-4292-8961-80da5732397c"), "ii", "Yi" },
                    { new Guid("ac8e4c02-0490-479c-b5dc-11cfd830d59d"), "ig", "Igbo" },
                    { new Guid("bbf5a593-0bbd-4f44-8de0-44a60e68e5d1"), "dje-NE", "Zarma (Niger)" },
                    { new Guid("9addf91f-26f1-4d6a-af54-1ea311171453"), "dsb", "Lower Sorbian" },
                    { new Guid("f6fbac90-3acb-4444-b731-078dad8d9175"), "dsb-DE", "Lower Sorbian (Germany)" },
                    { new Guid("b725a43e-5635-479f-a6e6-fada446bcf4b"), "dua", "Duala" },
                    { new Guid("bf86f660-a3d3-44fe-9028-4b064520a350"), "dua-CM", "Duala (Cameroon)" },
                    { new Guid("f1dca988-65e8-4b24-beec-58f0455e0219"), "dv", "Divehi" },
                    { new Guid("72cd67bc-20f4-4efb-806f-c21ac2ebd1a2"), "dv-MV", "Divehi (Maldives)" },
                    { new Guid("8c171ef7-5ff9-4f22-af26-51d6d61a7d10"), "dyo", "Jola-Fonyi" },
                    { new Guid("eadc809a-2cb2-4c64-9d9f-bf35389998c9"), "dyo-SN", "Jola-Fonyi (Senegal)" },
                    { new Guid("111f3540-7e54-48e4-abf5-e585dab3da3c"), "dz", "Dzongkha" },
                    { new Guid("f1a7460b-f7fe-4bd1-8b1f-496f818ec67b"), "dz-BT", "Dzongkha (Bhutan)" },
                    { new Guid("45109a19-a49c-4377-a45b-2f5ae06b6ee0"), "ebu", "Embu" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("719e73b7-89a2-493e-9596-689b790e79be"), "ebu-KE", "Embu (Kenya)" },
                    { new Guid("cbf3b5cf-5b3a-4228-ab8c-5f28e8fed703"), "ee", "Ewe" },
                    { new Guid("8fe09c2a-4a97-49ec-99b4-4bd34670adfc"), "ee-GH", "Ewe (Ghana)" },
                    { new Guid("05a54c63-2280-4b26-918f-a61d1ed5ce24"), "ee-TG", "Ewe (Togo)" },
                    { new Guid("26c2a91f-a595-4536-85e3-dfc5b71cf6e2"), "el", "Greek" },
                    { new Guid("cfc51339-1781-4830-98f8-dce8785ca907"), "el-CY", "Greek (Cyprus)" },
                    { new Guid("4397f14b-97be-4c08-b46e-ddcf399a448c"), "el-GR", "Greek (Greece)" },
                    { new Guid("be8d1800-d3d9-4fb0-aecb-eea0bd4f35f6"), "en", "English" },
                    { new Guid("7ce87551-3d3b-4e8b-ba69-015ed6e4515b"), "en-001", "English (World)" },
                    { new Guid("c3b8d9f5-efb1-48df-9678-eb4f8b281ad1"), "dje", "Zarma" },
                    { new Guid("4f8afa18-3c4b-4de3-8092-1915e734a271"), "en-150", "English (Europe)" },
                    { new Guid("a3b63c13-9830-41bd-8a5f-254fa9a9fc95"), "de-LU", "German (Luxembourg)" },
                    { new Guid("bc9bd264-3d3c-4f7b-8137-b0b2fa15e0f7"), "de-IT", "German (Italy)" },
                    { new Guid("f78d59ed-b5c1-481a-9af7-1ad49efc3443"), "ckb", "Central Kurdish" },
                    { new Guid("f444d0d6-a3b7-4240-b973-66c5467ff3df"), "ckb-IQ", "Central Kurdish (Iraq)" },
                    { new Guid("ad1ddc45-03af-4b63-8ba4-3f9326668080"), "ckb-IR", "Central Kurdish (Iran)" },
                    { new Guid("34d64a43-010e-4a49-a1b2-90ef858032b8"), "co", "Corsican" },
                    { new Guid("29b1a3c7-92ab-4292-8ee8-c2e29342ec6d"), "co-FR", "Corsican (France)" },
                    { new Guid("46f9445f-ce00-40bb-9943-3f7ac672ffd9"), "cs", "Czech" },
                    { new Guid("1d3d0078-dbc1-4c6f-886e-0b1a5a6006b0"), "cs-CZ", "Czech (Czechia)" },
                    { new Guid("7c9573d1-31da-41a4-ba69-187d49d46297"), "cu", "Church Slavic" },
                    { new Guid("77c6f9ea-bf81-4fd2-ba54-9162228e0e87"), "cu-RU", "Church Slavic (Russia)" },
                    { new Guid("b0eb3105-07c0-475a-ab10-0b4e4085c083"), "cy", "Welsh" },
                    { new Guid("1e718b7d-2655-4344-887f-8540dc50112f"), "cy-GB", "Welsh (United Kingdom)" },
                    { new Guid("36020e6f-ebd9-409d-9bb3-030180ea3e2c"), "da", "Danish" },
                    { new Guid("6cf0c89f-c8da-4197-bb90-00ce3edd6d6c"), "da-DK", "Danish (Denmark)" },
                    { new Guid("561d4164-cf71-435c-8d3c-2aaada762475"), "da-GL", "Danish (Greenland)" },
                    { new Guid("ffb60df7-5938-4aec-a6c2-fa61e7d8a7d5"), "dav", "Taita" },
                    { new Guid("5f6141fd-4997-4ee0-adb5-624add0faae3"), "dav-KE", "Taita (Kenya)" },
                    { new Guid("af7b144c-ab01-4831-99fe-063e0de204d5"), "de", "German" },
                    { new Guid("a17a866d-cc4e-4b45-ad05-a66c17e1d690"), "de-AT", "German (Austria)" },
                    { new Guid("90639a15-cead-472f-82a3-90841933ed9b"), "de-BE", "German (Belgium)" },
                    { new Guid("0d907106-eb53-4ae2-8a97-4a539fc731ff"), "de-CH", "German (Switzerland)" },
                    { new Guid("533d992a-0d9a-4603-aaac-7cb7d67d6dec"), "de-DE", "German (Germany)" },
                    { new Guid("7b79be43-10d5-4c47-af6e-b7cd5016f931"), "de-LI", "German (Liechtenstein)" },
                    { new Guid("50c2e24a-fc5e-4f80-8fc0-427c9d9a6b2a"), "en-AE", "English (United Arab Emirates)" },
                    { new Guid("dc20c19f-355c-4242-9c5e-a300be273598"), "en-AG", "English (Antigua & Barbuda)" },
                    { new Guid("c7d16789-83b7-49f4-bf54-6a381b9406fd"), "en-AI", "English (Anguilla)" },
                    { new Guid("3cbd4a84-1617-4b25-9c76-1381815dcb78"), "en-GD", "English (Grenada)" },
                    { new Guid("57e84e2d-e7e5-4a61-b0a1-fd4d1c75f215"), "en-GG", "English (Guernsey)" },
                    { new Guid("8480095b-afd4-4eef-838a-b91a9ef6f664"), "en-GH", "English (Ghana)" },
                    { new Guid("8f76b252-7d04-4eaf-98dd-ffa777ce68a6"), "en-GI", "English (Gibraltar)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("e941a59f-f95f-4ca3-9a7d-0a650a4dbb5b"), "en-GM", "English (Gambia)" },
                    { new Guid("cbc36923-0f36-458f-b684-6015047bd377"), "en-GU", "English (Guam)" },
                    { new Guid("a1dc5050-99cd-4445-9da2-48608ee80245"), "en-GY", "English (Guyana)" },
                    { new Guid("2ad3cb63-103a-4610-8077-6407e3e4d9f7"), "en-HK", "English (Hong Kong SAR)" },
                    { new Guid("9e9b1fdb-9216-4c43-9414-c91b6f6093c3"), "en-IE", "English (Ireland)" },
                    { new Guid("213f8d60-afe3-47cc-86a7-8d0d0bba72e8"), "en-IL", "English (Israel)" },
                    { new Guid("b7687682-5abb-4388-aab5-a59ceea75eba"), "en-IM", "English (Isle of Man)" },
                    { new Guid("3bf082fe-2c1f-45b1-b160-1a748c7892ea"), "en-IN", "English (India)" },
                    { new Guid("eb270e44-8ef4-472a-a3ad-26f982023845"), "en-IO", "English (British Indian Ocean Territory)" },
                    { new Guid("183c99d2-d247-4457-bcad-0c788231451d"), "en-JE", "English (Jersey)" },
                    { new Guid("b7614533-752e-43b8-bbd7-b3171fcf769b"), "en-JM", "English (Jamaica)" },
                    { new Guid("ca1f2913-6a10-4cc0-8eb3-f0bc26a9bf68"), "en-KE", "English (Kenya)" },
                    { new Guid("6db508dd-6a73-4392-8260-b6fcfd2e3cda"), "en-KI", "English (Kiribati)" },
                    { new Guid("1fc88d87-3a75-4c61-adf8-347655ce54e3"), "en-KN", "English (St. Kitts & Nevis)" },
                    { new Guid("313fd9c7-30b7-4648-85a3-fb5bc07d0ffa"), "en-KY", "English (Cayman Islands)" },
                    { new Guid("bb1c4078-fd40-4096-9f6f-45fc73e3eb99"), "en-LC", "English (St. Lucia)" },
                    { new Guid("979d4862-aed2-4ed2-a4b5-adc3b6d936a4"), "en-LR", "English (Liberia)" },
                    { new Guid("d58cf9ac-20e4-4ff5-82e2-6e138bba5637"), "en-GB", "English (United Kingdom)" },
                    { new Guid("72a170c2-09a8-4aed-8915-e16df3990ff0"), "en-FM", "English (Micronesia)" },
                    { new Guid("4d1d6774-4618-44b0-86aa-a921f4f80cf1"), "en-FK", "English (Falkland Islands)" },
                    { new Guid("0b504604-cc06-4458-9e10-ae90f8cf91b8"), "en-FJ", "English (Fiji)" },
                    { new Guid("c5e0e433-220e-4733-9b80-16afb61654da"), "en-AS", "English (American Samoa)" },
                    { new Guid("daebaa62-3796-4ee0-83a9-fab3b41f1ea6"), "en-AT", "English (Austria)" },
                    { new Guid("594aa8ce-21ea-40db-b98e-4adca7fc8f7a"), "en-AU", "English (Australia)" },
                    { new Guid("5ef8d1f3-421e-4d3e-baf3-4446431c9808"), "en-BB", "English (Barbados)" },
                    { new Guid("628534f6-d033-446f-93e1-a94273e4d8f7"), "en-BE", "English (Belgium)" },
                    { new Guid("9b96de8b-237b-4502-ac1e-2c47e16eac32"), "en-BI", "English (Burundi)" },
                    { new Guid("09107d65-4a75-4128-9174-5b8d0b663e79"), "en-BM", "English (Bermuda)" },
                    { new Guid("4804f252-0101-46c1-b3d4-05e7389e9a34"), "en-BS", "English (Bahamas)" },
                    { new Guid("b3b7fd97-3b8c-44c9-8e7f-b82a93bea5ab"), "en-BW", "English (Botswana)" },
                    { new Guid("b089a49f-6b94-48c6-a6a4-e88bc7cb2753"), "en-BZ", "English (Belize)" },
                    { new Guid("1a2c27b6-9bc5-40c3-b491-94115bc237ec"), "chr-US", "Cherokee (United States)" },
                    { new Guid("c27c92ed-ece3-443c-8fdb-a77349b2dd51"), "en-CA", "English (Canada)" },
                    { new Guid("bc73daa6-3f07-4fc2-99af-4cc3cb5d13f6"), "en-CH", "English (Switzerland)" },
                    { new Guid("21f18e56-39a4-4300-bccf-1dccc8a1fb17"), "en-CK", "English (Cook Islands)" },
                    { new Guid("8088442c-ff5a-4b90-8415-d6208f7a95b8"), "en-CM", "English (Cameroon)" },
                    { new Guid("89f95066-0c10-49e4-8764-37327ec984b0"), "en-CX", "English (Christmas Island)" },
                    { new Guid("36c85cf3-b295-43a9-8471-72b3230ff0df"), "en-CY", "English (Cyprus)" },
                    { new Guid("3667ede3-0053-45a4-8114-5bc5b5576001"), "en-DE", "English (Germany)" },
                    { new Guid("014b321e-9373-4158-ac37-d8b02eece9ee"), "en-DK", "English (Denmark)" },
                    { new Guid("c9c9dede-4da3-4401-a05e-a43e9c97b488"), "en-DM", "English (Dominica)" },
                    { new Guid("bfaeec9d-542b-4fdb-91de-ac66cab8a447"), "en-ER", "English (Eritrea)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("4ec9dfab-697e-4414-bb97-c2f9f8a9564b"), "en-FI", "English (Finland)" },
                    { new Guid("72985385-7ce2-4c7d-bfab-b8e1c10f0825"), "en-CC", "English (Cocos [Keeling] Islands)" },
                    { new Guid("19c3ba19-9f4a-49e3-bf92-91c557faef47"), "chr", "Cherokee" },
                    { new Guid("5f6eda90-86ce-4ef3-a76a-3b63fb45edc0"), "cgg-UG", "Chiga (Uganda)" },
                    { new Guid("67cbc4ba-5f39-4ee9-92d6-d72032fff5ff"), "cgg", "Chiga" },
                    { new Guid("77a23fa3-0754-4fb6-a122-e502b635df90"), "ar-LB", "Arabic (Lebanon)" },
                    { new Guid("6f4d3069-5e40-4b6b-bd04-0a31a5919862"), "ar-LY", "Arabic (Libya)" },
                    { new Guid("b9d64bd8-59c2-4292-83f2-8671dfe0f721"), "ar-MA", "Arabic (Morocco)" },
                    { new Guid("7fc3ec7d-ddea-4646-8d04-f82c667446b1"), "ar-MR", "Arabic (Mauritania)" },
                    { new Guid("0598db9b-dde9-471a-9289-0a98337ca0a0"), "ar-OM", "Arabic (Oman)" },
                    { new Guid("4a41e487-0764-46e9-956d-ffa4ea4a43ed"), "ar-PS", "Arabic (Palestinian Authority)" },
                    { new Guid("8473e60d-4491-4c89-8168-a03566458fca"), "ar-QA", "Arabic (Qatar)" },
                    { new Guid("a6eff6f3-e5c0-4693-889f-3f800a3e86ae"), "ar-SA", "Arabic (Saudi Arabia)" },
                    { new Guid("9a7a569a-2357-474b-86ab-8398ba7255c6"), "ar-SD", "Arabic (Sudan)" },
                    { new Guid("bf0067eb-bd6b-479e-8b4d-0f2f4c1ebd25"), "ar-SO", "Arabic (Somalia)" },
                    { new Guid("8340c17f-d52b-4799-a073-94ff0d51b85b"), "ar-SS", "Arabic (South Sudan)" },
                    { new Guid("9278ba00-4da8-4024-8e2c-790daccea751"), "ar-SY", "Arabic (Syria)" },
                    { new Guid("1cd86e3d-f832-4594-90fc-0d20cfc3b5d1"), "ar-TD", "Arabic (Chad)" },
                    { new Guid("b782cbdf-d9ed-4b96-9cf1-271634c6778c"), "ar-TN", "Arabic (Tunisia)" },
                    { new Guid("16e98477-ad03-4948-a7b8-30ffef334a5a"), "ar-YE", "Arabic (Yemen)" },
                    { new Guid("2b217699-2844-4cd5-91ab-09a1fd9392ca"), "arn", "Mapuche" },
                    { new Guid("6ccdef7d-bcc9-435d-b640-e889b9c134f4"), "arn-CL", "Mapuche (Chile)" },
                    { new Guid("0ee752a5-951a-4deb-a110-ee58c896afd1"), "as", "Assamese" },
                    { new Guid("bba7dabe-cf22-4464-b19e-637617a1974b"), "as-IN", "Assamese (India)" },
                    { new Guid("0bb0c526-e762-407b-bb65-2711768741ba"), "asa", "Asu" },
                    { new Guid("b8a492ff-d623-4132-a403-e051a8a5375b"), "asa-TZ", "Asu (Tanzania)" },
                    { new Guid("7b7d42fd-8ea7-4e4c-a395-af00cbaa453b"), "ar-KW", "Arabic (Kuwait)" },
                    { new Guid("5cd65695-84a2-42f4-898f-4599d4e11926"), "ar-KM", "Arabic (Comoros)" },
                    { new Guid("7a5bff46-2d8f-4552-a932-f3d2839992c7"), "ar-JO", "Arabic (Jordan)" },
                    { new Guid("dd2a90d3-0df4-4d24-8722-4ca1dba4d6c1"), "ar-IQ", "Arabic (Iraq)" },
                    { new Guid("79c30b64-3996-403d-b297-6c80d83f3101"), "aa", "Afar" },
                    { new Guid("3ebd5209-e714-4d8b-b7b2-14681fb077f5"), "aa-DJ", "Afar (Djibouti)" },
                    { new Guid("7df07e1c-5072-497e-ad84-c1b5e5222c87"), "aa-ER", "Afar (Eritrea)" },
                    { new Guid("6b7ce150-1855-4bd1-a0ff-c0c4de1658cd"), "aa-ET", "Afar (Ethiopia)" },
                    { new Guid("e3b147c4-b1c1-4629-a3ce-73fa80ef3ebd"), "af", "Afrikaans" },
                    { new Guid("3f44a10b-0d36-479e-9090-aa1a9f433f58"), "af-NA", "Afrikaans (Namibia)" },
                    { new Guid("a6d20d43-5531-45f7-b963-417f6c867496"), "af-ZA", "Afrikaans (South Africa)" },
                    { new Guid("35131890-3ddd-478b-a1bc-f0fb674f08d2"), "agq", "Aghem" },
                    { new Guid("134dadb3-903f-4ff3-ad77-6f1e18361cfc"), "agq-CM", "Aghem (Cameroon)" },
                    { new Guid("3b2fddc6-1f6a-4012-88d3-479cd1cd20a3"), "ak", "Akan" },
                    { new Guid("b8a24d7e-2b57-4649-8a18-dc04a6b75ef7"), "ast", "Asturian" },
                    { new Guid("00aefd0b-150a-4315-add8-63fcf03b5786"), "ak-GH", "Akan (Ghana)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("fb127676-f112-49b1-b429-558b02943f13"), "am-ET", "Amharic (Ethiopia)" },
                    { new Guid("949f090c-3e66-44ab-a14b-9c765771c83e"), "ar", "Arabic" },
                    { new Guid("09f5cb27-895b-4f1d-93e9-73ef809a1c2c"), "ar-001", "Arabic (World)" },
                    { new Guid("af31e63e-2a35-49de-923f-67c4879582d8"), "ar-AE", "Arabic (United Arab Emirates)" },
                    { new Guid("ad47b3e6-d32f-440c-9c44-e762c2f72ac7"), "ar-BH", "Arabic (Bahrain)" },
                    { new Guid("c0aa97c1-9f1c-45d6-8b38-d3d5b509edd3"), "ar-DJ", "Arabic (Djibouti)" },
                    { new Guid("fccc8971-ff25-4e42-b7c9-cebe4fc8c7f6"), "ar-DZ", "Arabic (Algeria)" },
                    { new Guid("aba2914b-61c7-4d5e-90a9-47990c7b9073"), "ar-EG", "Arabic (Egypt)" },
                    { new Guid("263a3200-1efa-4709-a6ca-8e657518c1b8"), "ar-ER", "Arabic (Eritrea)" },
                    { new Guid("b35bd5bb-01ac-4b65-8f92-38dcc5405dd2"), "ar-IL", "Arabic (Israel)" },
                    { new Guid("e30c580d-bc18-452a-8871-ecd55198b384"), "am", "Amharic" },
                    { new Guid("c1330963-fbbf-4bda-8083-99adb06bb53d"), "en-LS", "English (Lesotho)" },
                    { new Guid("40719db2-3538-4cb2-9af8-e6cae1dfc80b"), "ast-ES", "Asturian (Spain)" },
                    { new Guid("67f8451f-a807-42c3-8a6c-9f0ad2bdd693"), "az-Cyrl", "Azerbaijani" },
                    { new Guid("cd2f9baa-af50-44db-89a6-19d31766403c"), "brx-IN", "Bodo (India)" },
                    { new Guid("1fba4548-b03d-4909-95b5-18ff497323b3"), "bs", "Bosnian" },
                    { new Guid("a864ce7a-5490-4817-8b28-2f05f9b666f3"), "bs-Cyrl", "Bosnian" },
                    { new Guid("bc86fa93-1d2f-453c-9ade-4f510b422d4b"), "bs-Cyrl-BA", "Bosnian (Cyrillic, Bosnia & Herzegovina)" },
                    { new Guid("ed1e1ad8-c1c7-448e-97e5-df39488b1842"), "bs-Latn", "Bosnian" },
                    { new Guid("ef7afafd-4e90-44e3-abf8-112283483e92"), "bs-Latn-BA", "Bosnian (Latin, Bosnia & Herzegovina)" },
                    { new Guid("31c7f131-e643-48d1-92f2-7c3879597b19"), "byn", "Blin" },
                    { new Guid("7009cac1-1911-4967-b5ae-c477791bba44"), "byn-ER", "Blin (Eritrea)" },
                    { new Guid("911280bd-dcec-48b5-a9b9-d04427e62c40"), "ca", "Catalan" },
                    { new Guid("3a057179-b5c5-450d-9ebd-3107a04019fb"), "ca-AD", "Catalan (Andorra)" },
                    { new Guid("48f54fce-c4eb-4bf9-8377-adef1421c9f6"), "ca-ES", "Catalan (Spain)" },
                    { new Guid("5b2912fd-aa4e-4fec-9657-6dbb79391440"), "ca-ES-VALENCIA", "Catalan (Spain, Valencian)" },
                    { new Guid("b4d44e10-317a-47de-8f94-eb6541582046"), "ca-FR", "Catalan (France)" },
                    { new Guid("f7df092c-f831-4ff2-9785-27b0df7b4af3"), "ca-IT", "Catalan (Italy)" },
                    { new Guid("e18a1cc7-c44e-4ad1-9d66-101a0030a8f0"), "ccp", "Chakma" },
                    { new Guid("fd16a36c-983e-414c-9a66-27c230aab192"), "ccp-BD", "Chakma (Bangladesh)" },
                    { new Guid("61f06a02-82e6-4dda-b3ef-ec007f193b03"), "ccp-IN", "Chakma (India)" },
                    { new Guid("b2493074-e8a0-4097-9dc2-8d88ece14ff1"), "ce", "Chechen" },
                    { new Guid("18b3854e-4601-45c2-8e1d-8e18fa4a1489"), "ce-RU", "Chechen (Russia)" },
                    { new Guid("0fa04da6-fcb8-4264-9c6c-5cac074d3e76"), "ceb", "Cebuano" },
                    { new Guid("9950c5ec-72ab-431c-be4f-8718a6399154"), "ceb-PH", "Cebuano (Philippines)" },
                    { new Guid("5a9aed4e-7133-4f57-bde6-e3ff52069b47"), "brx", "Bodo" },
                    { new Guid("d40ba2e7-847a-46ee-aaff-898862abd544"), "br-FR", "Breton (France)" },
                    { new Guid("72132c7a-c650-4408-bc0a-d7201ba79406"), "br", "Breton" },
                    { new Guid("9a69b388-8cf0-42e8-96ee-e194e73075f1"), "bo-IN", "Tibetan (India)" },
                    { new Guid("90e5f13d-e3a1-44b0-89e4-453990ebce2d"), "az-Cyrl-AZ", "Azerbaijani (Cyrillic, Azerbaijan)" },
                    { new Guid("e6ad0296-fbd5-4178-9f4b-71c983a03569"), "az-Latn", "Azerbaijani" },
                    { new Guid("30ab2bf8-64f2-4b5c-bc0b-e13e536d6570"), "az-Latn-AZ", "Azerbaijani (Latin, Azerbaijan)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("92b5b6d2-9033-40da-8e80-0279f1980d36"), "ba", "Bashkir" },
                    { new Guid("21b5fe9f-fd34-434a-a4c0-63d6ef59abfc"), "ba-RU", "Bashkir (Russia)" },
                    { new Guid("02dc8285-884a-42ff-b26f-9be392276976"), "bas", "Basaa" },
                    { new Guid("02a961df-fb6a-4885-a9d2-5598a21fa1e3"), "bas-CM", "Basaa (Cameroon)" },
                    { new Guid("d1e188a4-1749-4417-b918-856e46e93483"), "be", "Belarusian" },
                    { new Guid("4465b1dd-42a8-42b9-996c-fad170e1ce84"), "be-BY", "Belarusian (Belarus)" },
                    { new Guid("115a626c-d575-47b8-bd01-a542c50d2d67"), "bem", "Bemba" },
                    { new Guid("a427522a-4619-4f5a-b033-c20805d91cce"), "az", "Azerbaijani" },
                    { new Guid("b8b032c9-4ed0-42ab-b457-85de1db45b2f"), "bem-ZM", "Bemba (Zambia)" },
                    { new Guid("1f57d310-0cd7-4ecb-b342-ae9bb31abb1c"), "bez-TZ", "Bena (Tanzania)" },
                    { new Guid("322ed054-c6c8-4e4a-aed8-ddecec5e154a"), "bg", "Bulgarian" },
                    { new Guid("b1b49608-9dc7-4055-a639-3d8e911a6cf2"), "bg-BG", "Bulgarian (Bulgaria)" },
                    { new Guid("10ef87e9-9236-4c66-928e-37685ed40bf9"), "bm", "Bamanankan" },
                    { new Guid("2422d57e-081b-45e4-834f-8212ac4b48b1"), "bm-ML", "Bamanankan (Mali)" },
                    { new Guid("e6102705-0e70-4418-ac7a-bab3706585f7"), "bn", "Bangla" },
                    { new Guid("2907b423-c238-42c0-9b91-8baf8f4ab039"), "bn-BD", "Bangla (Bangladesh)" },
                    { new Guid("4daed3a2-7ac7-4cc8-ac8c-c5dbebf8b669"), "bn-IN", "Bangla (India)" },
                    { new Guid("524d8d4e-f772-480d-9704-b977c3c94e96"), "bo", "Tibetan" },
                    { new Guid("81b26cdb-3c88-403f-ac27-0f538f284a92"), "bo-CN", "Tibetan (China)" },
                    { new Guid("47778022-0493-45b9-84d2-6f234effc929"), "bez", "Bena" },
                    { new Guid("e1051e76-fd32-4506-9f0a-dc14156a82a9"), "en-MG", "English (Madagascar)" },
                    { new Guid("4bc3b22e-a69c-4fda-b709-5955c398d2a8"), "en-MH", "English (Marshall Islands)" },
                    { new Guid("2ae8426c-4a50-4882-8aab-04823552dbba"), "en-MO", "English (Macao SAR)" },
                    { new Guid("0931002f-eb5b-4c08-a649-87391be366aa"), "fr-GQ", "French (Equatorial Guinea)" },
                    { new Guid("1fae2c7a-4616-46f1-87f9-bfee6eee6528"), "fr-HT", "French (Haiti)" },
                    { new Guid("fc76f7b6-166b-45cd-8ad0-de2532f571c7"), "fr-KM", "French (Comoros)" },
                    { new Guid("b55d3f4e-8cd0-4239-9744-e74dc13e5870"), "fr-LU", "French (Luxembourg)" },
                    { new Guid("23b3f4c4-ad01-45e5-ac0c-2fdd6edebb4c"), "fr-MA", "French (Morocco)" },
                    { new Guid("3821672b-1fb2-4e42-b1f3-49ae16ea5441"), "fr-MC", "French (Monaco)" },
                    { new Guid("94ab9f04-a332-4cb2-9586-607d39680665"), "fr-MF", "French (St. Martin)" },
                    { new Guid("c017085f-42d7-4615-a1ea-c8c86c6dde02"), "fr-MG", "French (Madagascar)" },
                    { new Guid("2dadb1c7-f9f3-48da-8e65-ed835df2cdb5"), "fr-ML", "French (Mali)" },
                    { new Guid("f60e38c8-81eb-4ee0-9ba8-2a43433bd726"), "fr-MQ", "French (Martinique)" },
                    { new Guid("17e9cee8-c579-422e-be0a-d93696a5e61e"), "fr-MR", "French (Mauritania)" },
                    { new Guid("fa9678fe-5e36-48e5-a820-355acb0a4f0d"), "fr-MU", "French (Mauritius)" },
                    { new Guid("149772f9-966a-439a-b7ca-0a14a58b21d2"), "fr-NC", "French (New Caledonia)" },
                    { new Guid("75b73c90-822f-46bf-8635-34fe42798cee"), "fr-NE", "French (Niger)" },
                    { new Guid("863f2cff-ceee-4166-9ac4-5be08d5c59dd"), "fr-PF", "French (French Polynesia)" },
                    { new Guid("20d94e4f-2c03-4122-b282-603c72d2fb70"), "fr-PM", "French (St. Pierre & Miquelon)" },
                    { new Guid("1c626885-3cb1-43cc-9e34-5bc014d0cc20"), "fr-RE", "French (Réunion)" },
                    { new Guid("62fed291-e937-4354-8170-716f265b3d7d"), "fr-RW", "French (Rwanda)" },
                    { new Guid("4e2dc2ed-c287-46f8-9bf9-5d556fe9c5a4"), "fr-SC", "French (Seychelles)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("51045f65-a66e-4287-8b9a-d3bdf7f7108d"), "fr-SN", "French (Senegal)" },
                    { new Guid("0e815979-2c2c-4079-8ec4-e3e1ee882a3a"), "fr-SY", "French (Syria)" },
                    { new Guid("92b7c030-0ca6-4e96-9680-a2116e42169b"), "fr-GP", "French (Guadeloupe)" },
                    { new Guid("bc3557f5-bd17-43ec-86ae-a71076e7abbd"), "fr-GN", "French (Guinea)" },
                    { new Guid("9ff65229-72ee-4b6a-88d5-d0c714041f90"), "fr-GF", "French (French Guiana)" },
                    { new Guid("83a46b4d-482c-4589-95fb-671504b66f68"), "fr-GA", "French (Gabon)" },
                    { new Guid("f01439c0-5be5-4997-a7a0-d68e5f5437aa"), "fi-FI", "Finnish (Finland)" },
                    { new Guid("0ee2c2b8-2432-4ac8-90de-0de2eb9e90f2"), "fil", "Filipino" },
                    { new Guid("d3c14dca-5626-4e9c-a8b3-b1d2f2791beb"), "fil-PH", "Filipino (Philippines)" },
                    { new Guid("f13338e5-e0cb-4228-b81d-5e318e7cf218"), "fo", "Faroese" },
                    { new Guid("a06b6287-3cae-433d-a279-a0b3687379a8"), "fo-DK", "Faroese (Denmark)" },
                    { new Guid("2a28efdd-da23-4be6-930d-75050eac8a74"), "fo-FO", "Faroese (Faroe Islands)" },
                    { new Guid("2e5b607f-652a-4b14-813a-904d09b5795c"), "fr", "French" },
                    { new Guid("e951bdfd-356d-4daf-8fb5-0318eb31fb84"), "fr-BE", "French (Belgium)" },
                    { new Guid("3769e78f-0449-4c04-85f4-ce752572782b"), "fr-BF", "French (Burkina Faso)" },
                    { new Guid("2cf57306-e502-43ca-a3d6-906fd5ec0450"), "fr-BI", "French (Burundi)" },
                    { new Guid("f2b6485b-e559-4c20-b416-a85df0e1b66c"), "fr-TD", "French (Chad)" },
                    { new Guid("df0b9297-be6a-41a7-8349-b2412a145366"), "fr-BJ", "French (Benin)" },
                    { new Guid("18e6bb72-88a7-43e5-a039-9b20869e81e8"), "fr-CA", "French (Canada)" },
                    { new Guid("246d681a-b3d4-42d5-811a-767588a7ad10"), "fr-CD", "French (Congo [DRC])" },
                    { new Guid("1f0608cd-5e86-450e-92eb-b3729f821f6f"), "fr-CF", "French (Central African Republic)" },
                    { new Guid("1895a110-9ade-4100-8c7c-0d5df531cfda"), "fr-CG", "French (Congo)" },
                    { new Guid("ebbee2e3-bba3-40fc-b742-1bddf5366398"), "fr-CH", "French (Switzerland)" },
                    { new Guid("a4e94a5e-af74-4b52-9fb4-a3eb9f2b8619"), "fr-CI", "French (Côte d’Ivoire)" },
                    { new Guid("7b703959-0d35-4a8e-a34f-0a56300f846a"), "fr-CM", "French (Cameroon)" },
                    { new Guid("1a0c297e-4aac-4436-bf04-2cad72ca9a97"), "fr-DJ", "French (Djibouti)" },
                    { new Guid("103e2b80-c4e9-49b0-95ee-3166c93f9ef6"), "fr-DZ", "French (Algeria)" },
                    { new Guid("77921368-6e0b-4dbc-9e2d-230595383373"), "fr-FR", "French (France)" },
                    { new Guid("84d4ab33-38bc-44c6-8a66-8fcfd3c689d5"), "fr-BL", "French (St. Barthélemy)" },
                    { new Guid("46b0b069-02c1-4517-9c54-308800c34823"), "fi", "Finnish" },
                    { new Guid("44ab409f-7267-4e52-a811-6104a4aa9170"), "fr-TG", "French (Togo)" },
                    { new Guid("ba42c12d-04c7-4d64-a855-7af386ac9c33"), "fr-VU", "French (Vanuatu)" },
                    { new Guid("d6a86dcd-4564-49fb-a661-f0a343a28201"), "ha-NE", "Hausa (Niger)" },
                    { new Guid("ff97cce9-6e09-4abc-afe1-8ee980eb05b2"), "ha-NG", "Hausa (Nigeria)" },
                    { new Guid("80c7b330-ab2f-4703-aa1e-b338e5279b81"), "haw", "Hawaiian" },
                    { new Guid("1f9f2ed0-a01c-4bff-a6b9-bc0222ae7340"), "haw-US", "Hawaiian (United States)" },
                    { new Guid("9d6f4ad0-f062-4514-a413-d064239e91ea"), "he", "Hebrew" },
                    { new Guid("b9076592-65b2-47f4-b0dd-b52382648f9f"), "he-IL", "Hebrew (Israel)" },
                    { new Guid("6a849970-4a9a-4b93-8bdf-01a892fcc0dc"), "hi", "Hindi" },
                    { new Guid("92f252d3-aa8f-46bd-89ba-85ab64af02fc"), "hi-IN", "Hindi (India)" },
                    { new Guid("b77a2449-c329-4689-8f25-1adaeab4f664"), "hr", "Croatian" },
                    { new Guid("f680d585-982f-449b-9c69-6effae3bc80b"), "hr-BA", "Croatian (Bosnia & Herzegovina)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("64c838b5-f94e-4dac-84ad-2db0b1e2f645"), "hr-HR", "Croatian (Croatia)" },
                    { new Guid("0df6b992-745f-4b1c-8b04-0eab567bcd83"), "hsb", "Upper Sorbian" },
                    { new Guid("43f9fef3-1837-46a3-9786-48e2e30feb35"), "hsb-DE", "Upper Sorbian (Germany)" },
                    { new Guid("0356e07e-32a2-44c6-af5a-f162d2542ff2"), "hu", "Hungarian" },
                    { new Guid("c3effcb9-3691-42b0-92d1-7c6cbbe4148e"), "hu-HU", "Hungarian (Hungary)" },
                    { new Guid("b0bc4f3c-bba2-4df0-bca8-f5e812f1d136"), "hy", "Armenian" },
                    { new Guid("4a344100-84fc-44c5-9286-fc552008bc3c"), "hy-AM", "Armenian (Armenia)" },
                    { new Guid("fa0f1975-4b29-4de7-9959-f4edf0bca87e"), "ia", "Interlingua" },
                    { new Guid("87223040-56a2-4b92-bc3d-3fdcf7f34f56"), "ia-001", "Interlingua (World)" },
                    { new Guid("b92e9bb2-70d3-4b10-9c36-90c35e15d2fa"), "id", "Indonesian" },
                    { new Guid("9dd0e5c8-ea4f-4aad-bd7e-4696e387c732"), "id-ID", "Indonesian (Indonesia)" },
                    { new Guid("14e8f1d6-bb8e-4aeb-bc3e-a1a61caa676e"), "ha-GH", "Hausa (Ghana)" },
                    { new Guid("6384ec3e-e092-4b53-9d11-c1d48e61fa34"), "ha", "Hausa" },
                    { new Guid("d4e4c4ab-db41-45fb-b30f-97dc6efe7667"), "gv-IM", "Manx (Isle of Man)" },
                    { new Guid("70f26c27-bad9-4f0d-92c9-5a185a899841"), "gv", "Manx" },
                    { new Guid("f4762e6f-d742-4939-8c83-13514843e6a8"), "fr-WF", "French (Wallis & Futuna)" },
                    { new Guid("55816d40-35a5-4041-b803-50f2fe5205c3"), "fr-YT", "French (Mayotte)" },
                    { new Guid("ab32e70e-4d09-48ee-aac9-890ecafd3606"), "fur", "Friulian" },
                    { new Guid("38472479-0065-44f9-8447-46e8cf006ab6"), "fur-IT", "Friulian (Italy)" },
                    { new Guid("ebd1284f-fa85-42f1-8a4e-dd5837c2bfd1"), "fy", "Western Frisian" },
                    { new Guid("2de6c174-a50e-46e1-b23b-9b01e1f98c3c"), "fy-NL", "Western Frisian (Netherlands)" },
                    { new Guid("067ed17e-5bc6-4a85-a4a1-f9c16a7200bb"), "ga", "Irish" },
                    { new Guid("7a1e9198-3541-4874-ac14-90e73054d395"), "ga-IE", "Irish (Ireland)" },
                    { new Guid("b8d77350-8550-4701-b3dc-c17df0859712"), "gd", "Scottish Gaelic" },
                    { new Guid("d0ca4533-f0d0-43c3-a4a4-bf791cbf6e8c"), "gd-GB", "Scottish Gaelic (United Kingdom)" },
                    { new Guid("537c416a-5581-42a2-9078-630b703bcc11"), "fr-TN", "French (Tunisia)" },
                    { new Guid("9fbf72f1-7bed-4dbf-b080-b57e6c57bcd5"), "gl", "Galician" },
                    { new Guid("fd97db8e-d97e-4b21-a331-3c27db6b3e6b"), "gn", "Guarani" },
                    { new Guid("3c5b85a0-ae8c-4526-b7b1-f8105d77d573"), "gn-PY", "Guarani (Paraguay)" },
                    { new Guid("68883965-0073-4da7-adae-f8d1f8fcf479"), "gsw", "Swiss German" },
                    { new Guid("431b3725-72f3-4b0f-9c3c-2580d6fa653a"), "gsw-CH", "Swiss German (Switzerland)" },
                    { new Guid("eb7636bb-ac51-4b57-b540-ac9b2c525d13"), "gsw-FR", "Swiss German (France)" },
                    { new Guid("2496c62c-0871-4b72-8f13-40a14eb18ae7"), "gsw-LI", "Swiss German (Liechtenstein)" },
                    { new Guid("097a7f78-acd2-4430-bf74-af7689d17302"), "gu", "Gujarati" },
                    { new Guid("c649b026-587f-446a-8c23-a7ed15827d44"), "gu-IN", "Gujarati (India)" },
                    { new Guid("77fe53c5-b876-4bc4-83ef-45c780262e62"), "guz", "Gusii" },
                    { new Guid("58b5762e-b428-404e-bed6-1e0ce6ac1d18"), "guz-KE", "Gusii (Kenya)" },
                    { new Guid("f3b23efc-459c-49b1-a9d9-9dc7ed2e8203"), "gl-ES", "Galician (Spain)" },
                    { new Guid("fd42b443-a9df-4fbe-a6fc-15bb14841f4c"), "ig-NG", "Igbo (Nigeria)" },
                    { new Guid("5effae71-9d49-45e0-b99b-c8048ce878ea"), "ff-Latn-SN", "Fulah (Latin, Senegal)" },
                    { new Guid("c840eac6-6e7f-4485-9c23-30187bb9ad58"), "ff-Latn-NG", "Fulah (Latin, Nigeria)" },
                    { new Guid("2cda76dc-0c2e-4f75-b987-653eebf18e91"), "en-SI", "English (Slovenia)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("8d7a95d5-0b27-45d7-a6b5-ba491ad065d1"), "en-SL", "English (Sierra Leone)" },
                    { new Guid("839ebfb0-e752-424c-aa3f-0dec0061b13c"), "en-SS", "English (South Sudan)" },
                    { new Guid("9422c306-aaf4-4a4b-840c-54a2529a0a84"), "en-SX", "English (Sint Maarten)" },
                    { new Guid("d072d401-17b3-4b86-b29c-fc9d30103bb4"), "en-SZ", "English (Eswatini)" },
                    { new Guid("c65702d7-3778-40de-baba-28c07be99936"), "en-TC", "English (Turks & Caicos Islands)" },
                    { new Guid("bb21ed02-77f5-4f77-9094-f735e833c5af"), "en-TK", "English (Tokelau)" },
                    { new Guid("3edb68c2-8ee9-4a20-ab36-a970438fbfd3"), "en-TO", "English (Tonga)" },
                    { new Guid("f01188e6-fae0-400b-aa68-74676f9e86bf"), "en-TT", "English (Trinidad & Tobago)" },
                    { new Guid("4e93683f-4e3a-4d0a-84ca-0535cca0e5fd"), "en-TV", "English (Tuvalu)" },
                    { new Guid("644dd708-482d-4103-9b6d-2c167acd7bee"), "en-TZ", "English (Tanzania)" },
                    { new Guid("9f007dac-5226-441c-a129-f0b70624922a"), "en-UG", "English (Uganda)" },
                    { new Guid("cc35bcba-ca66-47d3-aebb-4ab80303ab7b"), "en-UM", "English (U.S. Outlying Islands)" },
                    { new Guid("4e9fc4e5-a71f-4865-a465-0fb7368092c1"), "en-US", "English (United States)" },
                    { new Guid("3d845b99-b714-44a5-b774-63249b10643b"), "en-US-POSIX", "English (United States, Computer)" },
                    { new Guid("c6473e26-7c61-4d29-8a74-57b430d2527c"), "en-VC", "English (St. Vincent & Grenadines)" },
                    { new Guid("9bbd951c-d10a-43c5-9758-ae80ca47b943"), "en-VG", "English (British Virgin Islands)" },
                    { new Guid("a8b6140e-70fd-43ee-b5e2-0ba70f33bc29"), "en-VI", "English (U.S. Virgin Islands)" },
                    { new Guid("c1a80b4e-bc3e-4fb3-b886-039f1e61da9e"), "en-VU", "English (Vanuatu)" },
                    { new Guid("eeac05a8-04bc-4cad-aa79-86b9831ffa62"), "en-WS", "English (Samoa)" },
                    { new Guid("b4e93bc0-e47c-48f8-bcda-1b3098b376e4"), "en-ZA", "English (South Africa)" },
                    { new Guid("f9ceb1fc-4c01-4a5e-8a0f-1db939e61ac6"), "en-SH", "English (St Helena, Ascension, Tristan da Cunha)" },
                    { new Guid("de1c891c-eb46-4960-9de7-b7045e513842"), "en-SG", "English (Singapore)" },
                    { new Guid("4db6a3d5-4599-4e9f-832d-b3ebd7455baf"), "en-SE", "English (Sweden)" },
                    { new Guid("97f3bedb-1443-435f-bff5-f84616e660d8"), "en-SD", "English (Sudan)" },
                    { new Guid("c3f38301-45c0-4434-a0fe-c599cc6a693a"), "en-MP", "English (Northern Mariana Islands)" },
                    { new Guid("af663ae4-4502-4f83-982b-c8752d4da9fb"), "en-MS", "English (Montserrat)" },
                    { new Guid("c5000bf8-0b1d-4162-b03c-6643602ba243"), "en-MT", "English (Malta)" },
                    { new Guid("9030d725-7f71-4d0e-949d-5f5d6beaf358"), "en-MU", "English (Mauritius)" },
                    { new Guid("72fd8137-9700-465b-bbb9-ced4b315920b"), "en-MW", "English (Malawi)" },
                    { new Guid("d9f49568-d57e-4d9e-9562-e813ae6ee721"), "en-MY", "English (Malaysia)" },
                    { new Guid("cef4c3ac-de6e-4bc9-a843-4394eab6cc05"), "en-NA", "English (Namibia)" },
                    { new Guid("47168668-a3af-4afb-904d-ae3bc069b4e8"), "en-NF", "English (Norfolk Island)" },
                    { new Guid("a91163d9-adba-4156-9eae-49f000f75ab0"), "en-NG", "English (Nigeria)" },
                    { new Guid("23be5c0f-a9aa-42dd-913b-fbd50572da3b"), "en-NL", "English (Netherlands)" },
                    { new Guid("d285b953-1273-4b5b-9030-46d0eadf98ba"), "en-ZM", "English (Zambia)" },
                    { new Guid("f23a64a3-8609-4c7d-99bd-f6500d27649c"), "en-NR", "English (Nauru)" },
                    { new Guid("b357c263-f5d6-4114-b054-c7f741412891"), "en-NZ", "English (New Zealand)" },
                    { new Guid("1b7108b5-c012-4a2d-8779-0a567d46496c"), "en-PG", "English (Papua New Guinea)" },
                    { new Guid("35361db7-e6e7-4e4f-9814-4767dbb34586"), "en-PH", "English (Philippines)" },
                    { new Guid("6372e916-33b6-4859-b4c0-37648f9a7cd4"), "en-PK", "English (Pakistan)" },
                    { new Guid("e91ba99c-dbb8-470f-95ff-7ff1ad87e4fc"), "en-PN", "English (Pitcairn Islands)" },
                    { new Guid("ad64c59b-baf2-4aad-888a-74dac6eaf1bf"), "en-PR", "English (Puerto Rico)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("2534fc98-01c5-4b0e-9989-053507a30705"), "en-PW", "English (Palau)" },
                    { new Guid("0cd0375e-93ce-4f30-ade1-b272bfb79c1e"), "en-RW", "English (Rwanda)" },
                    { new Guid("9846a133-8bb7-4beb-8b0a-1b2f4f046c23"), "en-SB", "English (Solomon Islands)" },
                    { new Guid("8fbbc334-c040-4891-88ee-71335738a27e"), "en-SC", "English (Seychelles)" },
                    { new Guid("4dc7c8cc-269e-4a17-825c-ac6da2e08158"), "en-NU", "English (Niue)" },
                    { new Guid("bc81c855-2310-4b5a-ab45-0f90075614c0"), "ff-Latn-SL", "Fulah (Latin, Sierra Leone)" },
                    { new Guid("9cc0dc0a-de13-48d6-b362-d64029895989"), "en-ZW", "English (Zimbabwe)" },
                    { new Guid("9009923d-220f-444e-a017-eee1885a8a9c"), "eo-001", "Esperanto (World)" },
                    { new Guid("b9100ce0-8225-4a59-ae5b-1bd627ad9404"), "es-VE", "Spanish (Venezuela)" },
                    { new Guid("be0a6572-ed9e-4c0d-9ce0-507423ce30f5"), "et", "Estonian" },
                    { new Guid("cbff7143-9465-45c4-ae81-f3c0e0dd57d6"), "et-EE", "Estonian (Estonia)" },
                    { new Guid("09d7177e-fb4a-4071-80c5-5f7354df05f6"), "eu", "Basque" },
                    { new Guid("62c25778-908a-47b6-84b5-33fc4968bc0a"), "eu-ES", "Basque (Spain)" },
                    { new Guid("4a5de978-bdd3-4773-b530-1c2c21d0591f"), "ewo", "Ewondo" },
                    { new Guid("1a54046e-86e7-4b52-b9ce-56b7fc52181e"), "ewo-CM", "Ewondo (Cameroon)" },
                    { new Guid("d128f186-9aab-471c-aa40-6b4af1f07e5b"), "fa", "Persian" },
                    { new Guid("3d17ebd5-6e28-4d89-8a2d-c856db00ccd8"), "fa-AF", "Persian (Afghanistan)" },
                    { new Guid("b727c4dc-2118-496b-9614-a244932cf925"), "fa-IR", "Persian (Iran)" },
                    { new Guid("39ee489f-65bc-4319-b63c-fd835bf6284d"), "ff", "Fulah" },
                    { new Guid("f962c59c-c06a-4d37-8266-f7407e82cb0c"), "ff-Latn", "Fulah" },
                    { new Guid("d90316db-4cb9-497f-badb-55ab4f9643d9"), "ff-Latn-BF", "Fulah (Latin, Burkina Faso)" },
                    { new Guid("44a25c37-378e-4fb5-af59-d7740afe76f8"), "ff-Latn-CM", "Fulah (Latin, Cameroon)" },
                    { new Guid("6df1bc5b-7345-4326-bcfc-08d8cc336ec6"), "ff-Latn-GH", "Fulah (Latin, Ghana)" },
                    { new Guid("61f53e92-d5a6-4995-9170-a7cd759132e4"), "ff-Latn-GM", "Fulah (Latin, Gambia)" },
                    { new Guid("ab885826-0794-4f38-8c8f-1346b5f059ba"), "ff-Latn-GN", "Fulah (Latin, Guinea)" },
                    { new Guid("aac9bfce-704f-4819-97b9-ace45515990d"), "ff-Latn-GW", "Fulah (Latin, Guinea-Bissau)" },
                    { new Guid("2d0a8151-d944-4060-a9d0-5fa85ea3ebd3"), "ff-Latn-LR", "Fulah (Latin, Liberia)" },
                    { new Guid("2adea2d0-d16a-449c-bf47-22d8a598aef0"), "ff-Latn-MR", "Fulah (Latin, Mauritania)" },
                    { new Guid("c00bfb1e-a96b-4774-87c7-6af864064e92"), "ff-Latn-NE", "Fulah (Latin, Niger)" },
                    { new Guid("75963a9c-b515-49f8-865f-6808162ba0d4"), "es-UY", "Spanish (Uruguay)" },
                    { new Guid("a385153e-14bd-4058-bcbf-0f67e0db4604"), "es-US", "Spanish (United States)" },
                    { new Guid("118d0061-1aea-4b3a-834f-4e76cd6b3cba"), "es-SV", "Spanish (El Salvador)" },
                    { new Guid("600a980a-3604-43b1-9386-64ddddc30ea3"), "es-PY", "Spanish (Paraguay)" },
                    { new Guid("8ee4f351-cc61-482d-80ed-63875017a963"), "es", "Spanish" },
                    { new Guid("4dafe19c-53cf-4c5c-978c-54f31feb2f6c"), "es-419", "Spanish (Latin America)" },
                    { new Guid("4ac5d2dc-217c-45d6-ae66-0098eca1d500"), "es-AR", "Spanish (Argentina)" },
                    { new Guid("91582cbc-fdf9-470e-9271-74e1bb2dac0c"), "es-BO", "Spanish (Bolivia)" },
                    { new Guid("eb6bb047-e64a-4ea8-b9e0-20ebb3999ff7"), "es-BR", "Spanish (Brazil)" },
                    { new Guid("7688793d-e57f-41de-98d5-dda3ee401a28"), "es-BZ", "Spanish (Belize)" },
                    { new Guid("69df1e5b-2a58-4d7f-ac3e-6fa8ea5fe22c"), "es-CL", "Spanish (Chile)" },
                    { new Guid("09887383-b315-4f72-8099-49ae75aecb90"), "es-CO", "Spanish (Colombia)" },
                    { new Guid("956ab994-6a63-4d5a-b7e6-5d5ef2e7ba8d"), "es-CR", "Spanish (Costa Rica)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "EnglishName" },
                values: new object[,]
                {
                    { new Guid("b1a49cdc-3d61-4fc2-b511-44cc1f557331"), "es-CU", "Spanish (Cuba)" },
                    { new Guid("4ac24e8a-2d17-4d31-8081-32ea0e7cfbe0"), "eo", "Esperanto" },
                    { new Guid("ad75a2d0-0c81-43b9-b624-802c352d6794"), "es-DO", "Spanish (Dominican Republic)" },
                    { new Guid("ccaa8bb8-44ed-425f-8656-d3b4e78ef854"), "es-ES", "Spanish (Spain)" },
                    { new Guid("11733553-0930-4e71-b087-741d4ca65f98"), "es-GQ", "Spanish (Equatorial Guinea)" },
                    { new Guid("e9faa69b-894d-4ee3-b495-143a18d6a920"), "es-GT", "Spanish (Guatemala)" },
                    { new Guid("da80df6e-7513-468f-a67d-356eac15a9e5"), "es-HN", "Spanish (Honduras)" },
                    { new Guid("7e8fb5c5-575c-430e-862a-ab67116fd14b"), "es-MX", "Spanish (Mexico)" },
                    { new Guid("c14fbc42-3d51-4841-9852-d30e9fb253e4"), "es-NI", "Spanish (Nicaragua)" },
                    { new Guid("f0d9213b-88ea-493b-8a8b-e517e15c8c16"), "es-PA", "Spanish (Panama)" },
                    { new Guid("21b19ddb-cd99-414b-a27f-a2b7c73483e5"), "es-PE", "Spanish (Peru)" },
                    { new Guid("02f77d22-25b9-4214-85cb-332467104697"), "es-PH", "Spanish (Philippines)" },
                    { new Guid("2b50b24f-1f8d-4cf8-a109-e30ec9520835"), "es-PR", "Spanish (Puerto Rico)" },
                    { new Guid("7218e114-38c0-40ad-a5f3-43d3ef823d7c"), "es-EC", "Spanish (Ecuador)" },
                    { new Guid("777e5048-afa5-491c-9457-069bd6638778"), "zu-ZA", "isiZulu (South Africa)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_UserId",
                table: "Claim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ProjectId",
                table: "Components",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ReviewerId",
                table: "Suggestions",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_TranslationId",
                table: "Suggestions",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_UserId",
                table: "Suggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_ComponentId",
                table: "Translations",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageId",
                table: "Translations",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
