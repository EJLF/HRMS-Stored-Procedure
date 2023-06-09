﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class adddepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_AddDepartment
                            @DeptName VARCHAR(50)
                        AS
                        BEGIN
                            INSERT INTO Departments (DeptName)
                            VALUES (@DeptName);
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_AddDepartment";
            migrationBuilder.Sql(sp);
        }
    }
}
