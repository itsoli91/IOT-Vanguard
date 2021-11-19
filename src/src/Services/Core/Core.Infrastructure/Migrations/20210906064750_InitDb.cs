using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Core.Infrastructure.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceTemplates",
                columns: table => new
                {
                    SequentialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Namespace = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTemplates", x => x.SequentialId);
                });

            migrationBuilder.CreateTable(
                name: "SemanticTypes",
                columns: table => new
                {
                    SequentialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    IsComplex = table.Column<bool>(type: "boolean", nullable: false),
                    Schemas = table.Column<List<string>>(type: "text[]", nullable: true),
                    Units = table.Column<List<string>>(type: "text[]", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemanticTypes", x => x.SequentialId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTemplateModels",
                columns: table => new
                {
                    SequentialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTemplateModels", x => x.SequentialId);
                    table.ForeignKey(
                        name: "FK_DeviceTemplateModels_DeviceTemplates_DeviceTemplateId",
                        column: x => x.DeviceTemplateId,
                        principalTable: "DeviceTemplates",
                        principalColumn: "SequentialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capabilities",
                columns: table => new
                {
                    SemanticTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CapabilityType = table.Column<int>(type: "integer", nullable: false),
                    Schema = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    DisplayUnit = table.Column<string>(type: "text", nullable: true),
                    IsComplex = table.Column<bool>(type: "boolean", nullable: false),
                    CapabilitySemanticTypeSequentialId = table.Column<long>(type: "bigint", nullable: true),
                    DeviceTemplateModelId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SequentialId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capabilities", x => x.SemanticTypeId);
                    table.ForeignKey(
                        name: "FK_Capabilities_DeviceTemplateModels_DeviceTemplateModelId",
                        column: x => x.DeviceTemplateModelId,
                        principalTable: "DeviceTemplateModels",
                        principalColumn: "SequentialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Capabilities_SemanticTypes_CapabilitySemanticTypeSequential~",
                        column: x => x.CapabilitySemanticTypeSequentialId,
                        principalTable: "SemanticTypes",
                        principalColumn: "SequentialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCapabilities",
                columns: table => new
                {
                    SequentialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Schema = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    CapabilityId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCapabilities", x => x.SequentialId);
                    table.ForeignKey(
                        name: "FK_SubCapabilities_Capabilities_CapabilityId",
                        column: x => x.CapabilityId,
                        principalTable: "Capabilities",
                        principalColumn: "SemanticTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_CapabilitySemanticTypeSequentialId",
                table: "Capabilities",
                column: "CapabilitySemanticTypeSequentialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_DeviceTemplateModelId",
                table: "Capabilities",
                column: "DeviceTemplateModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_Id",
                table: "Capabilities",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTemplateModels_DeviceTemplateId",
                table: "DeviceTemplateModels",
                column: "DeviceTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTemplateModels_Id",
                table: "DeviceTemplateModels",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTemplates_Id",
                table: "DeviceTemplates",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemanticTypes_Id",
                table: "SemanticTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCapabilities_CapabilityId",
                table: "SubCapabilities",
                column: "CapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCapabilities_Id",
                table: "SubCapabilities",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCapabilities");

            migrationBuilder.DropTable(
                name: "Capabilities");

            migrationBuilder.DropTable(
                name: "DeviceTemplateModels");

            migrationBuilder.DropTable(
                name: "SemanticTypes");

            migrationBuilder.DropTable(
                name: "DeviceTemplates");
        }
    }
}
