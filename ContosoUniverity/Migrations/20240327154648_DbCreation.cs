using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignments",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignments", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_OfficeAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade); //TODO: Change this to NoAction, will require dropping the DB
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => new { x.CourseId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893"), "ffakhouri@contosouniveristy.edu", "Fadi", new DateTime(2002, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fakhouri" },
                    { new Guid("455dfcc1-552a-45fa-b94e-d973906490cc"), "rzheng@contosouniversity.edu", "Roger", new DateTime(2004, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zheng" },
                    { new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148"), "kabercrombie@contosouniversity.edu", "Kim", new DateTime(1995, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abercrombie" },
                    { new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91"), "rharui@contosouniversity.edu", "Roger", new DateTime(1998, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harui" },
                    { new Guid("e24a644d-9a45-4f66-966c-580fd191573a"), "ckapoor@contosouniversity.edu", "Candace", new DateTime(2001, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kapoor" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "EnrollmentDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"), "calexander@contosouniversity.edu", new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carson", "Alexander" },
                    { new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb"), "aanand@contosouniversity.edu", new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo", "Anand" },
                    { new Guid("53cea385-aa61-4e81-ba7a-38d7ed60ce4f"), "lnorman@contosouniversity.edu", new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Norman" },
                    { new Guid("554039c7-cba1-4404-9fbe-21918a9190f7"), "nolivetto@contosouniversity.edu", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nino", "Olivetto" },
                    { new Guid("5e9c10d4-3b0a-4ccb-8a77-fb2d7e702c6b"), "pjustice@contosouniversity.edu", new DateTime(2011, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peggy", "Justice" },
                    { new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"), "malonso@contosouniversity.edu", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meredith", "Alonso" },
                    { new Guid("7a1be69a-38ac-4cde-a105-615de38c2d12"), "yli@contosouniversity.edu", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yan", "Li" },
                    { new Guid("7d84360e-4967-4c7b-8e4c-0f085de7ca4d"), "gbarzdukas@contosouniversity.edu", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gytis", "Barzdukas" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Budget", "InstructorId", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("00c4512a-6c05-482b-9026-3f413f477132"), 100000m, new Guid("e24a644d-9a45-4f66-966c-580fd191573a"), "Economics", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c19f20e6-e77d-492d-bbc2-dce3c7603448"), 350000m, new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148"), "English", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8eee19f-7040-492f-81c8-62cbe50d8467"), 100000m, new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893"), "Mathematics", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce1815fb-6730-4b7a-9e3c-322db0c98414"), 350000m, new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91"), "Engineering", new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OfficeAssignments",
                columns: new[] { "InstructorId", "Location" },
                values: new object[,]
                {
                    { new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893"), "Smith 17" },
                    { new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91"), "Gowan 27" },
                    { new Guid("e24a644d-9a45-4f66-966c-580fd191573a"), "Thompson 304" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Credits", "DepartmentId", "Title" },
                values: new object[,]
                {
                    { new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"), 3, new Guid("c19f20e6-e77d-492d-bbc2-dce3c7603448"), "Composition" },
                    { new Guid("83af998c-0bfd-4855-8c5a-4e1920b9d025"), 4, new Guid("c8eee19f-7040-492f-81c8-62cbe50d8467"), "Trigonometry" },
                    { new Guid("854f1892-e043-49e0-9573-5544e833a8d3"), 3, new Guid("00c4512a-6c05-482b-9026-3f413f477132"), "Microeconomics" },
                    { new Guid("ad18dff5-58ee-4e02-ba83-ffd1c8a1f56e"), 3, new Guid("00c4512a-6c05-482b-9026-3f413f477132"), "Macroeconomics" },
                    { new Guid("b178e749-1f02-4461-8e5d-bb97c49eb375"), 4, new Guid("c19f20e6-e77d-492d-bbc2-dce3c7603448"), "Literature" },
                    { new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"), 3, new Guid("ce1815fb-6730-4b7a-9e3c-322db0c98414"), "Chemistry" },
                    { new Guid("db564e68-2fe5-42e5-ba48-b2b49034d3d2"), 4, new Guid("c8eee19f-7040-492f-81c8-62cbe50d8467"), "Calculus" }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseId", "InstructorId" },
                values: new object[,]
                {
                    { new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"), new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148") },
                    { new Guid("83af998c-0bfd-4855-8c5a-4e1920b9d025"), new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91") },
                    { new Guid("854f1892-e043-49e0-9573-5544e833a8d3"), new Guid("455dfcc1-552a-45fa-b94e-d973906490cc") },
                    { new Guid("ad18dff5-58ee-4e02-ba83-ffd1c8a1f56e"), new Guid("455dfcc1-552a-45fa-b94e-d973906490cc") },
                    { new Guid("b178e749-1f02-4461-8e5d-bb97c49eb375"), new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148") },
                    { new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"), new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91") },
                    { new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"), new Guid("e24a644d-9a45-4f66-966c-580fd191573a") },
                    { new Guid("db564e68-2fe5-42e5-ba48-b2b49034d3d2"), new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893") }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("2a429451-5c56-4924-9704-96b39015714c"), new Guid("83af998c-0bfd-4855-8c5a-4e1920b9d025"), 1, new Guid("798acf1b-7339-44bd-8367-7132a978d7b1") },
                    { new Guid("2ab277ef-3910-431a-a2c2-ac191119ce85"), new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"), 1, new Guid("7a1be69a-38ac-4cde-a105-615de38c2d12") },
                    { new Guid("2b3c15bb-d240-4a23-85d9-161de7df89e9"), new Guid("ad18dff5-58ee-4e02-ba83-ffd1c8a1f56e"), 1, new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2") },
                    { new Guid("32703941-2485-4dc9-bfe3-5e9a6fda5135"), new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"), 0, new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2") },
                    { new Guid("45805987-c6c9-4f76-adcb-375a9ab8cd3c"), new Guid("db564e68-2fe5-42e5-ba48-b2b49034d3d2"), 1, new Guid("798acf1b-7339-44bd-8367-7132a978d7b1") },
                    { new Guid("62d4b9f7-0f76-48f7-af2d-fc341a83e49d"), new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"), 1, new Guid("798acf1b-7339-44bd-8367-7132a978d7b1") },
                    { new Guid("66b78962-24b1-4da8-bd0a-d7a3c9b4a87c"), new Guid("854f1892-e043-49e0-9573-5544e833a8d3"), 2, new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2") },
                    { new Guid("6fbcb84e-af63-4514-a06a-3f5cc51ef302"), new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"), 1, new Guid("7d84360e-4967-4c7b-8e4c-0f085de7ca4d") },
                    { new Guid("80aa4d4f-c5c2-4ba3-a6e9-228b1016f0ab"), new Guid("854f1892-e043-49e0-9573-5544e833a8d3"), 1, new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb") },
                    { new Guid("9784bbb3-4d36-4277-b947-a57be8baf97f"), new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"), null, new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb") },
                    { new Guid("b769c021-3c35-4e50-8705-8a64ce7b9d8f"), new Guid("b178e749-1f02-4461-8e5d-bb97c49eb375"), 1, new Guid("5e9c10d4-3b0a-4ccb-8a77-fb2d7e702c6b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_InstructorId",
                table: "CourseAssignments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorId",
                table: "Departments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "OfficeAssignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
