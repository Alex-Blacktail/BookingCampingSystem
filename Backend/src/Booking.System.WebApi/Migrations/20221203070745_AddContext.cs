using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.System.WebApi.Migrations
{
    public partial class AddContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    address_content = table.Column<string>(type: "character varying", nullable: false),
                    citizenship = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    ThirdName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "birth_certificate_foreign",
                columns: table => new
                {
                    birth_certificate_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    series = table.Column<string>(type: "character varying", nullable: true),
                    number = table.Column<string>(type: "character varying", nullable: false),
                    date_of_issue = table.Column<DateOnly>(type: "date", nullable: false),
                    issued_by = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("birth_certificate_foreign_pkey", x => x.birth_certificate_id);
                });

            migrationBuilder.CreateTable(
                name: "birth_certificate_ru",
                columns: table => new
                {
                    birth_certificate_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    series = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    number = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    date_of_issue = table.Column<DateOnly>(type: "date", nullable: false),
                    issued_by = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("birth_certificate_ru_pkey", x => x.birth_certificate_id);
                });

            migrationBuilder.CreateTable(
                name: "passport_foreign",
                columns: table => new
                {
                    passport_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    series = table.Column<string>(type: "character varying", nullable: false),
                    number = table.Column<string>(type: "character varying", nullable: false),
                    date_of_issue = table.Column<DateOnly>(type: "date", nullable: false),
                    validity = table.Column<DateOnly>(type: "date", nullable: true),
                    issued_by = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("passport_foreign_pkey", x => x.passport_id);
                });

            migrationBuilder.CreateTable(
                name: "passport_ru",
                columns: table => new
                {
                    passport_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    series = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    number = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    date_of_issue = table.Column<DateOnly>(type: "date", nullable: false),
                    issued_by = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("passport_ru_pkey", x => x.passport_id);
                });

            migrationBuilder.CreateTable(
                name: "shift_type",
                columns: table => new
                {
                    shift_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift_type", x => x.shift_type_id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "working_mode",
                columns: table => new
                {
                    working_mode_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    sunday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    sunday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    monday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    monday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    tuesday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    tuesday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    wednesday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    wednesday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    thursday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    thursday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    friday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    friday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    saturday_start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    saturday_end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_working_mode", x => x.working_mode_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "local_administrator",
                columns: table => new
                {
                    local_administrator_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    surname = table.Column<string>(type: "character varying", nullable: false),
                    patronomyc = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_administrator", x => x.local_administrator_id);
                    table.ForeignKey(
                        name: "local_administrator_fkey",
                        column: x => x.local_administrator_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "super_administrator",
                columns: table => new
                {
                    super_administrator_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    surname = table.Column<string>(type: "character varying", nullable: false),
                    patronomyc = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_super_administrator", x => x.super_administrator_id);
                    table.ForeignKey(
                        name: "super_administrator_fkey",
                        column: x => x.super_administrator_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "child",
                columns: table => new
                {
                    child_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    surname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    snils = table.Column<string>(type: "character varying", nullable: false),
                    phone_number = table.Column<string>(type: "character varying", nullable: true),
                    passport_foreign_id = table.Column<int>(type: "integer", nullable: true),
                    passport_ru_id = table.Column<int>(type: "integer", nullable: true),
                    birth_certificate_ru_id = table.Column<int>(type: "integer", nullable: true),
                    birth_certificate_foreign_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child", x => x.child_id);
                    table.ForeignKey(
                        name: "address_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "birth_foreign_fkey",
                        column: x => x.birth_certificate_foreign_id,
                        principalTable: "birth_certificate_foreign",
                        principalColumn: "birth_certificate_id");
                    table.ForeignKey(
                        name: "birth_ru_fkey",
                        column: x => x.birth_certificate_ru_id,
                        principalTable: "birth_certificate_ru",
                        principalColumn: "birth_certificate_id");
                    table.ForeignKey(
                        name: "passport_foreign_fkey",
                        column: x => x.passport_foreign_id,
                        principalTable: "passport_foreign",
                        principalColumn: "passport_id");
                    table.ForeignKey(
                        name: "passport_ru_fkey",
                        column: x => x.passport_ru_id,
                        principalTable: "passport_ru",
                        principalColumn: "passport_id");
                });

            migrationBuilder.CreateTable(
                name: "parent",
                columns: table => new
                {
                    parent_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    surname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    snils = table.Column<string>(type: "character varying", nullable: false),
                    phone_number = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    passport_foreign_id = table.Column<int>(type: "integer", nullable: true),
                    passport_ru_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parent", x => x.parent_id);
                    table.ForeignKey(
                        name: "address_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "parent_id_fkey",
                        column: x => x.parent_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "passport_foreign_fkey",
                        column: x => x.passport_foreign_id,
                        principalTable: "passport_foreign",
                        principalColumn: "passport_id");
                    table.ForeignKey(
                        name: "passport_ru_fkey",
                        column: x => x.passport_ru_id,
                        principalTable: "passport_ru",
                        principalColumn: "passport_id");
                    table.ForeignKey(
                        name: "status_fkey",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id");
                });

            migrationBuilder.CreateTable(
                name: "camp",
                columns: table => new
                {
                    camp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    short_name = table.Column<string>(type: "character varying", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    legal_entity = table.Column<string>(type: "character varying", nullable: true),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    working_mode_id = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    website_link = table.Column<string>(type: "character varying", nullable: true),
                    medical_license = table.Column<bool>(type: "boolean", nullable: true),
                    educational_license = table.Column<bool>(type: "boolean", nullable: true),
                    about = table.Column<string>(type: "text", nullable: true),
                    number_of_buildings = table.Column<int>(type: "integer", nullable: false),
                    the_area_of_​​the_land = table.Column<double>(type: "double precision", nullable: false),
                    food = table.Column<string>(type: "character varying", nullable: false),
                    childs_age_start = table.Column<double>(type: "double precision", nullable: false),
                    childs_age_end = table.Column<double>(type: "double precision", nullable: false),
                    childrens_holiday_certificate = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camp", x => x.camp_id);
                    table.ForeignKey(
                        name: "address_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "working_mode_fkey",
                        column: x => x.working_mode_id,
                        principalTable: "working_mode",
                        principalColumn: "working_mode_id");
                });

            migrationBuilder.CreateTable(
                name: "parent_child",
                columns: table => new
                {
                    parent_id = table.Column<string>(type: "text", nullable: false),
                    child_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("parent_child_pkey", x => new { x.parent_id, x.child_id });
                    table.ForeignKey(
                        name: "child_fkey",
                        column: x => x.child_id,
                        principalTable: "child",
                        principalColumn: "child_id");
                    table.ForeignKey(
                        name: "parent_fkey",
                        column: x => x.parent_id,
                        principalTable: "parent",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "feature",
                columns: table => new
                {
                    feature_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    camp_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feature", x => x.feature_id);
                    table.ForeignKey(
                        name: "camp_id",
                        column: x => x.camp_id,
                        principalTable: "camp",
                        principalColumn: "camp_id");
                });

            migrationBuilder.CreateTable(
                name: "local_administrator_camp",
                columns: table => new
                {
                    id_local_admin = table.Column<string>(type: "text", nullable: false),
                    id_camp = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("local_administrator_camp_pkey", x => new { x.id_local_admin, x.id_camp });
                    table.ForeignKey(
                        name: "camp_fkey",
                        column: x => x.id_camp,
                        principalTable: "camp",
                        principalColumn: "camp_id");
                    table.ForeignKey(
                        name: "local_admin_fkey",
                        column: x => x.id_local_admin,
                        principalTable: "local_administrator",
                        principalColumn: "local_administrator_id");
                });

            migrationBuilder.CreateTable(
                name: "shift",
                columns: table => new
                {
                    shift_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    date_start = table.Column<DateOnly>(type: "date", nullable: false),
                    date_end = table.Column<DateOnly>(type: "date", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    camp_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift", x => x.shift_id);
                    table.ForeignKey(
                        name: "camp_fkey",
                        column: x => x.camp_id,
                        principalTable: "camp",
                        principalColumn: "camp_id");
                });

            migrationBuilder.CreateTable(
                name: "shift_by_shift_type",
                columns: table => new
                {
                    shift_by_shift_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    shift_type_id = table.Column<int>(type: "integer", nullable: false),
                    shift_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift_by_shift_type", x => x.shift_by_shift_type_id);
                    table.ForeignKey(
                        name: "shift_id",
                        column: x => x.shift_id,
                        principalTable: "shift",
                        principalColumn: "shift_id");
                    table.ForeignKey(
                        name: "shift_type_fkey",
                        column: x => x.shift_type_id,
                        principalTable: "shift_type",
                        principalColumn: "shift_type_id");
                });

            migrationBuilder.CreateTable(
                name: "shift_request",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    child_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    shift_by_shift_type_id = table.Column<int>(type: "integer", nullable: false),
                    parent_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("shift_request_pkey", x => x.request_id);
                    table.ForeignKey(
                        name: "child_fkey",
                        column: x => x.child_id,
                        principalTable: "child",
                        principalColumn: "child_id");
                    table.ForeignKey(
                        name: "parent_fkey",
                        column: x => x.parent_id,
                        principalTable: "parent",
                        principalColumn: "parent_id");
                    table.ForeignKey(
                        name: "shift_by_shift_type",
                        column: x => x.shift_by_shift_type_id,
                        principalTable: "shift_by_shift_type",
                        principalColumn: "shift_by_shift_type_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fki_working_mode_fkey",
                table: "camp",
                column: "working_mode_id");

            migrationBuilder.CreateIndex(
                name: "IX_camp_address_id",
                table: "camp",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "fki_birth_foreign_fkey",
                table: "child",
                column: "birth_certificate_foreign_id");

            migrationBuilder.CreateIndex(
                name: "fki_birth_ru_fkey",
                table: "child",
                column: "birth_certificate_ru_id");

            migrationBuilder.CreateIndex(
                name: "IX_child_address_id",
                table: "child",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_child_passport_foreign_id",
                table: "child",
                column: "passport_foreign_id");

            migrationBuilder.CreateIndex(
                name: "IX_child_passport_ru_id",
                table: "child",
                column: "passport_ru_id");

            migrationBuilder.CreateIndex(
                name: "IX_feature_camp_id",
                table: "feature",
                column: "camp_id");

            migrationBuilder.CreateIndex(
                name: "fki_id_local_admin_fkey",
                table: "local_administrator",
                column: "local_administrator_id");

            migrationBuilder.CreateIndex(
                name: "fki_local_administrator_id",
                table: "local_administrator",
                column: "local_administrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_local_administrator_camp_id_camp",
                table: "local_administrator_camp",
                column: "id_camp");

            migrationBuilder.CreateIndex(
                name: "fki_address_fkey",
                table: "parent",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "fki_passport_foreign_fkey",
                table: "parent",
                column: "passport_foreign_id");

            migrationBuilder.CreateIndex(
                name: "fki_passport_ru_fkey",
                table: "parent",
                column: "passport_ru_id");

            migrationBuilder.CreateIndex(
                name: "fki_status_fkey",
                table: "parent",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_parent_child_child_id",
                table: "parent_child",
                column: "child_id");

            migrationBuilder.CreateIndex(
                name: "fki_camp_fkey",
                table: "shift",
                column: "camp_id");

            migrationBuilder.CreateIndex(
                name: "IX_shift_by_shift_type_shift_id",
                table: "shift_by_shift_type",
                column: "shift_id");

            migrationBuilder.CreateIndex(
                name: "IX_shift_by_shift_type_shift_type_id",
                table: "shift_by_shift_type",
                column: "shift_type_id");

            migrationBuilder.CreateIndex(
                name: "fki_child_fkey",
                table: "shift_request",
                column: "child_id");

            migrationBuilder.CreateIndex(
                name: "fki_parent_fkey",
                table: "shift_request",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "fki_shift_by_shift_type",
                table: "shift_request",
                column: "shift_by_shift_type_id");

            migrationBuilder.CreateIndex(
                name: "fki_super_administrator_fkey",
                table: "super_administrator",
                column: "super_administrator_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "feature");

            migrationBuilder.DropTable(
                name: "local_administrator_camp");

            migrationBuilder.DropTable(
                name: "parent_child");

            migrationBuilder.DropTable(
                name: "shift_request");

            migrationBuilder.DropTable(
                name: "super_administrator");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "local_administrator");

            migrationBuilder.DropTable(
                name: "child");

            migrationBuilder.DropTable(
                name: "parent");

            migrationBuilder.DropTable(
                name: "shift_by_shift_type");

            migrationBuilder.DropTable(
                name: "birth_certificate_foreign");

            migrationBuilder.DropTable(
                name: "birth_certificate_ru");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "passport_foreign");

            migrationBuilder.DropTable(
                name: "passport_ru");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "shift");

            migrationBuilder.DropTable(
                name: "shift_type");

            migrationBuilder.DropTable(
                name: "camp");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "working_mode");
        }
    }
}
