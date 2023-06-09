﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class getpositionbyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_GetPositionById
                        @posId INT
                    AS
                    BEGIN
                        SELECT *
                        FROM Positions
                        WHERE PosId = @posId;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_GetPositionById";
            migrationBuilder.Sql(sp);
        }
    }
}
