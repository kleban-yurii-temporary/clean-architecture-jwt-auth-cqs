using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduTrack.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    EduYear = table.Column<string>(type: "TEXT", nullable: true),
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
                    EduYear = table.Column<string>(type: "TEXT", nullable: true),
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
                table: "LessonTimes",
                columns: new[] { "Id", "End", "Num", "Start" },
                values: new object[,]
                {
                    { new Guid("0195be5b-0c15-4d92-a6e1-4cc8bf75f728"), new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(1, 1, 1, 14, 10, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1366cece-852d-4142-95b0-9173feb77334"), new DateTime(1, 1, 1, 13, 50, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(1, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52bd289d-a43e-4b3c-a80e-961eb86f8d2f"), new DateTime(1, 1, 1, 8, 50, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("712d3a26-a3c4-4cdb-9d32-dac82965d6d4"), new DateTime(1, 1, 1, 10, 20, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76a3fb7d-d243-47cc-907a-258c5a1a0c99"), new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(1, 1, 1, 18, 40, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7904d201-9456-4086-ac1f-d71128486c2f"), new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1, 1, 1, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5c99223-8cc3-4299-be9c-9a5c916402b1"), new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(1, 1, 1, 10, 40, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b84a5454-0f8a-499f-80c0-8d6effffc860"), new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(1, 1, 1, 17, 10, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ceeb5b30-ff30-4236-8b9b-4696ced117c4"), new DateTime(1, 1, 1, 8, 50, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CantBeRemoved", "Group", "Key", "OwnerId", "Value" },
                values: new object[,]
                {
                    { new Guid("25e3698f-3ccb-4754-b855-fb16d76e2591"), true, "zoom", "zoom_api_base_url", null, "https://api.zoom.us/v2" },
                    { new Guid("3eaa1e02-92a7-4d24-9144-5dcb7a80a549"), true, "zoom", "zoom_api_access_token_url", null, "https://zoom.us/oauth/token" },
                    { new Guid("41814cfd-2d26-4ccf-ad45-24b8dc29fb66"), true, "zoom", "zoom_api_users_me_webinars", null, "https://api.zoom.us/v2/users/me/webinars" },
                    { new Guid("596ed383-b842-4909-8926-9b86fe827456"), true, "zoom", "zoom_api_users_me_recordings", null, "https://api.zoom.us/v2/users/me/recordings" },
                    { new Guid("938ea27a-22af-4ea9-b1ea-d6c407d66fbd"), true, "zoom", "zoom_api_users_me", null, "https://api.zoom.us/v2/users/me" },
                    { new Guid("d2f45476-ed43-4c73-8f13-8bb7d9c7a911"), true, "zoom", "zoom_api_auth_url", null, "https://zoom.us/oauth/authorize" },
                    { new Guid("fe014504-4b3e-4f3a-9bec-d829557704ce"), true, "zoom", "zoom_api_users_me_meetings", null, "https://api.zoom.us/v2/users/me/meetings?type=previous_meetings" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsApproved", "LastName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "Role" },
                values: new object[] { new Guid("df132ae6-4c80-4282-bcf3-89b2850c9341"), "yurakleban@gmail.com", "Юрій", true, "Клебан", "ghTVSMIJ/5biUBiG5UkVBEv1mJa94uydbkXP9rYE5Hs=", new byte[] { 172, 136, 149, 206, 135, 12, 2, 149, 179, 113, 214, 7, 168, 134, 186, 182 }, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "teacher" });

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "CourseId", "LessonType", "Order", "PerStudentNorm", "ShortTitle", "Title" },
                values: new object[,]
                {
                    { new Guid("05575ebf-c53d-4148-aff9-dc546da8ca94"), null, -1, 7, 0.25, "Залік", "Залік" },
                    { new Guid("22cd573e-226b-45f9-88af-be26b3604081"), null, -1, 10, 15.0, "Кваліф. роб.", "Керівництво кваліфікаційними роботами" },
                    { new Guid("26aa70d9-27b3-4c8a-b426-a7cab749a829"), null, -1, 11, null, "Реценз.", "Рецензування" },
                    { new Guid("368b3f7a-107f-4f83-a486-8c0f8fc69707"), null, 1, 1, null, "Лекц.", "Лекційні заняття" },
                    { new Guid("5004f8b6-d3fa-4edc-a66c-db45ec648f77"), null, -1, 6, 0.25, "Пром. контр.", "Проміжний контроль" },
                    { new Guid("54ca67a4-21e4-45fd-9951-a44bcfd31af6"), null, -1, 14, 2.0, "Кер. практ.", "Керівництво практикою" },
                    { new Guid("65740572-ba41-4281-9ed7-c72e12adcb0a"), null, -1, 13, 0.5, "ЕК(екзамен)", "Участь у роботі ЕК(екзамен)" },
                    { new Guid("8bddca39-d2f6-44ad-8ba9-9b776f9ee08d"), null, 5, 8, 0.33000000000000002, "Екзамен", "Екзамен" },
                    { new Guid("8d930a69-5707-4880-9916-0ebd9726d7fd"), null, 4, 4, null, "Конс. екз.", "Консультації до екзамену" },
                    { new Guid("99d5aca9-dacb-41ba-898b-c09a130bc515"), null, -1, 16, null, "Кер. стаж.", "Керівництво стажистами" },
                    { new Guid("9a53d3fa-59db-41ac-b882-49ec7afea7b9"), null, -1, 5, null, "Конс. сем", "Консультації впродовж семестру" },
                    { new Guid("a16b62b3-5f8e-4919-81b7-bc853be65035"), null, -1, 9, 3.0, "Курс. роб.", "Курсові роботи" },
                    { new Guid("c4dd361b-33dd-469e-988e-22dbc46d2764"), null, -1, 12, null, "ЕК(захист)", "Участь у роботі ЕК(захист)" },
                    { new Guid("c81099c5-6058-45bd-94e7-955284ea60e2"), null, 2, 2, null, "Груп.", "Групові заняття" },
                    { new Guid("f9a1624f-1fd4-4f50-9531-e608ad7972bc"), null, -1, 15, null, "Кер. асп.", "Керівництво аспірантами" },
                    { new Guid("fbac5ad3-4111-4e8f-b793-6708ab4b7482"), null, -1, 17, null, "Контр. відв.", "Контрольні відвідування" },
                    { new Guid("fdc77966-adf6-4843-b925-4014a0367514"), null, 3, 3, null, "Лаб.", "Лабораторні заняття" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CantBeRemoved", "Group", "Key", "OwnerId", "Value" },
                values: new object[,]
                {
                    { new Guid("0519aba1-f713-4f44-a552-816ae73a458b"), true, "zoom", "zoom_api_client_id", new Guid("df132ae6-4c80-4282-bcf3-89b2850c9341"), "Yo_UM8esSOqJCHMRHCJVg" },
                    { new Guid("108ee04d-af96-4c3a-929d-492132e22e25"), true, "zoom", "zoom_api_client_secret", new Guid("df132ae6-4c80-4282-bcf3-89b2850c9341"), "PsF2x0mNgKwe77LhROffARNyI6rDCZeO" }
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
                name: "Users");
        }
    }
}
