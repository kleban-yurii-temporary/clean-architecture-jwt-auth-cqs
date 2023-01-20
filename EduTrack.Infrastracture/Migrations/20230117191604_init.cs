using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduTrack.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EduYears",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Start = table.Column<int>(type: "INTEGER", nullable: false),
                    End = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Num = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    RefreshToken = table.Column<string>(type: "TEXT", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupCode = table.Column<string>(type: "TEXT", nullable: true),
                    EduYearId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CourseTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Semestr = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    PracticeGroupsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LabsGroupsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LecturesHours = table.Column<double>(type: "REAL", nullable: false),
                    PracticeHours = table.Column<double>(type: "REAL", nullable: false),
                    LaboratoryHours = table.Column<double>(type: "REAL", nullable: false),
                    ConsultationHours = table.Column<double>(type: "REAL", nullable: false),
                    ExamHours = table.Column<double>(type: "REAL", nullable: false),
                    MaxDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseTypes_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "CourseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_EduYears_EduYearId",
                        column: x => x.EduYearId,
                        principalTable: "EduYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    CantBeRemoved = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseInvites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpiryOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeactivated = table.Column<bool>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseInvites_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGroups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonType = table.Column<int>(type: "INTEGER", nullable: false),
                    PerStudentNorm = table.Column<double>(type: "REAL", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTypes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SubGroupId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentRecords_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentRecords_SubGroups_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "SubGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Num = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SubGroupId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DocumentedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RealDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SubGroupUniteCode = table.Column<long>(type: "INTEGER", nullable: false),
                    WorkTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LessonType = table.Column<int>(type: "INTEGER", nullable: false),
                    GradeType = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxGrade = table.Column<double>(type: "REAL", nullable: false),
                    Unlist = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lessons_SubGroups_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "SubGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lessons_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Semestr = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupCode = table.Column<string>(type: "TEXT", nullable: true),
                    EduYearId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    WorkTypeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Hours = table.Column<double>(type: "REAL", nullable: true),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherCourses_EduYears_EduYearId",
                        column: x => x.EduYearId,
                        principalTable: "EduYears",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OtherCourses_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherCourses_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplexGradeItemHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaxGrade = table.Column<double>(type: "REAL", nullable: false),
                    LessonId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexGradeItemHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplexGradeItemHeaders_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GradesAndPresenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LessonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsPresent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Grade = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesAndPresenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradesAndPresenses_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradesAndPresenses_StudentRecords_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherWorkHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Hours = table.Column<double>(type: "REAL", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherWorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherWorkHours_OtherCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "OtherCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplexGradeItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Grade = table.Column<double>(type: "REAL", nullable: false),
                    GradeAndPresenseId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexGradeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplexGradeItems_GradesAndPresenses_GradeAndPresenseId",
                        column: x => x.GradeAndPresenseId,
                        principalTable: "GradesAndPresenses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EduYears",
                columns: new[] { "Id", "End", "Start" },
                values: new object[] { new Guid("f49e19d5-9605-43c1-b9a7-f189586090eb"), 2023, 2022 });

            migrationBuilder.InsertData(
                table: "LessonTimes",
                columns: new[] { "Id", "End", "Num", "Start" },
                values: new object[,]
                {
                    { new Guid("1222602e-e78e-4049-a93f-5b1529ad1248"), new DateTime(1, 1, 1, 8, 50, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("156551d4-6855-4926-9e06-41921df6ceee"), new DateTime(1, 1, 1, 13, 50, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(1, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("17903d08-d58c-4af2-bec9-aa495f2665ae"), new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1, 1, 1, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3793be03-38de-4f88-be5f-79087d9e48a7"), new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(1, 1, 1, 14, 10, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("727e22a3-e9a7-4c70-9ae9-7d73ad9d56ba"), new DateTime(1, 1, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("84b936e9-7c25-465f-b9f3-4083020aefde"), new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(1, 1, 1, 10, 40, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("944f07af-5433-43cd-8f90-0d9ebf8e2ad3"), new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(1, 1, 1, 17, 10, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8efe94a-203b-4550-8d8b-0a9b7f1fe696"), new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(1, 1, 1, 18, 40, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb20014b-6370-40ef-99f3-ea09879a9445"), new DateTime(1, 1, 1, 8, 50, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CantBeRemoved", "Group", "Key", "OwnerId", "Value" },
                values: new object[,]
                {
                    { new Guid("3cb3c841-ec48-4841-8487-aee0873783e3"), true, "zoom", "zoom_api_users_me_webinars", null, "https://api.zoom.us/v2/users/me/webinars" },
                    { new Guid("4e5daa7a-75fb-4b3f-8fdf-efdb683b57f9"), true, "zoom", "zoom_api_users_me_recordings", null, "https://api.zoom.us/v2/users/me/recordings" },
                    { new Guid("86fe5e77-b92d-43f5-8ef5-94f5ee037ce2"), true, "zoom", "zoom_api_users_me_meetings", null, "https://api.zoom.us/v2/users/me/meetings?type=previous_meetings" },
                    { new Guid("a8a3b4a6-de1c-4559-a3cf-bac2f2a2dd43"), true, "zoom", "zoom_api_users_me", null, "https://api.zoom.us/v2/users/me" },
                    { new Guid("b9c755a4-6dfe-4850-bcfe-c90a5eeb8976"), true, "zoom", "zoom_api_base_url", null, "https://api.zoom.us/v2" },
                    { new Guid("c427798f-cd2a-4185-a5dd-fbde35609d92"), true, "zoom", "zoom_api_access_token_url", null, "https://zoom.us/oauth/token" },
                    { new Guid("ebe39b42-3746-40f0-8b39-afabdf619269"), true, "zoom", "zoom_api_auth_url", null, "https://zoom.us/oauth/authorize" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsApproved", "LastName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "Role" },
                values: new object[] { new Guid("4c5b022e-c82f-41c3-b1fb-c936a4132e33"), "yurakleban@gmail.com", "Юрій", true, "Клебан", "Rjd8FlRSK8EDkfbzJXM634vij+q61B/qHIXpBwIjZLk=", new byte[] { 65, 241, 174, 237, 48, 162, 27, 87, 47, 28, 153, 88, 147, 245, 216, 44 }, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "teacher" });

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "CourseId", "LessonType", "Order", "PerStudentNorm", "ShortTitle", "Title" },
                values: new object[,]
                {
                    { new Guid("0f962e0e-c6fc-482f-b541-1cab9d088b6e"), null, -1, 7, 0.25, "Залік", "Залік" },
                    { new Guid("1157afc3-4546-4a67-ae28-4615b71e4dc2"), null, -1, 16, null, "Кер. стаж.", "Керівництво стажистами" },
                    { new Guid("20ea3cb2-ebff-4401-b7da-adf12b7f49cf"), null, -1, 10, 15.0, "Кваліф. роб.", "Керівництво кваліфікаційними роботами" },
                    { new Guid("24d3da74-b1a4-4d8a-b404-df4cd2f0fc3d"), null, -1, 17, null, "Контр. відв.", "Контрольні відвідування" },
                    { new Guid("2606a254-5f5d-4f03-b4e9-479f65893d20"), null, -1, 9, 3.0, "Курс. роб.", "Курсові роботи" },
                    { new Guid("4853e8db-30bc-4b05-bb0a-4107ddcfdcb8"), null, 5, 8, 0.33000000000000002, "Екзамен", "Екзамен" },
                    { new Guid("493ceb9f-28ca-4fad-b8a6-1c1655f6dbdd"), null, -1, 13, 0.5, "ЕК(екзамен)", "Участь у роботі ЕК(екзамен)" },
                    { new Guid("5f8fa6e5-b408-4043-80a2-e94f66d35b18"), null, -1, 12, null, "ЕК(захист)", "Участь у роботі ЕК(захист)" },
                    { new Guid("6a7f1a57-00d7-456f-93ee-9f307eb0c0df"), null, 4, 4, null, "Конс. екз.", "Консультації до екзамену" },
                    { new Guid("72fb6e65-b1ec-4217-8e31-3dcd5ee3bd65"), null, -1, 6, 0.25, "Пром. контр.", "Проміжний контроль" },
                    { new Guid("9904944f-403c-4f79-9847-b5353baa23fa"), null, -1, 15, null, "Кер. асп.", "Керівництво аспірантами" },
                    { new Guid("ad25bbb9-c56e-4adc-9b76-2c84a7e8051c"), null, 3, 3, null, "Лаб.", "Лабораторні заняття" },
                    { new Guid("b319a8d3-3995-4315-b99d-cde41c7f4195"), null, -1, 5, null, "Конс. сем", "Консультації впродовж семестру" },
                    { new Guid("c1b8eec2-7c15-491d-b48d-2b73663ec270"), null, -1, 11, null, "Реценз.", "Рецензування" },
                    { new Guid("db5bfafb-2f2e-4c03-872a-2940034c3e66"), null, -1, 14, 2.0, "Кер. практ.", "Керівництво практикою" },
                    { new Guid("e125b5c7-2b01-4958-b7b8-b5c257198da1"), null, 1, 1, null, "Лекц.", "Лекційні заняття" },
                    { new Guid("e13493ad-0a12-4c0e-8b1d-3f6b7c5c08ab"), null, 2, 2, null, "Груп.", "Групові заняття" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CantBeRemoved", "Group", "Key", "OwnerId", "Value" },
                values: new object[,]
                {
                    { new Guid("189e79f4-08ca-4dae-a48e-7405811ec434"), true, "zoom", "zoom_api_client_secret", new Guid("4c5b022e-c82f-41c3-b1fb-c936a4132e33"), "PsF2x0mNgKwe77LhROffARNyI6rDCZeO" },
                    { new Guid("4945473e-cb1b-4e95-a8ab-c4699b0d3ef6"), true, "zoom", "zoom_api_client_id", new Guid("4c5b022e-c82f-41c3-b1fb-c936a4132e33"), "Yo_UM8esSOqJCHMRHCJVg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplexGradeItemHeaders_LessonId",
                table: "ComplexGradeItemHeaders",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplexGradeItems_GradeAndPresenseId",
                table: "ComplexGradeItems",
                column: "GradeAndPresenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInvites_CourseId",
                table: "CourseInvites",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseTypeId",
                table: "Courses",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EduYearId",
                table: "Courses",
                column: "EduYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OwnerId",
                table: "Courses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesAndPresenses_LessonId",
                table: "GradesAndPresenses",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesAndPresenses_StudentId",
                table: "GradesAndPresenses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubGroupId",
                table: "Lessons",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_WorkTypeId",
                table: "Lessons",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_OwnerId",
                table: "Options",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCourses_EduYearId",
                table: "OtherCourses",
                column: "EduYearId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCourses_OwnerId",
                table: "OtherCourses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCourses_WorkTypeId",
                table: "OtherCourses",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherWorkHours_CourseId",
                table: "OtherWorkHours",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRecords_CourseId",
                table: "StudentRecords",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRecords_SubGroupId",
                table: "StudentRecords",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRecords_UserId",
                table: "StudentRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_CourseId",
                table: "SubGroups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypes_CourseId",
                table: "WorkTypes",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplexGradeItemHeaders");

            migrationBuilder.DropTable(
                name: "ComplexGradeItems");

            migrationBuilder.DropTable(
                name: "CourseInvites");

            migrationBuilder.DropTable(
                name: "LessonTimes");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "OtherWorkHours");

            migrationBuilder.DropTable(
                name: "GradesAndPresenses");

            migrationBuilder.DropTable(
                name: "OtherCourses");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "StudentRecords");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "SubGroups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseTypes");

            migrationBuilder.DropTable(
                name: "EduYears");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
