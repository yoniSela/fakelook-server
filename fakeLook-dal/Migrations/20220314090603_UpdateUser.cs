using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fakeLook_dal.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 11, 6, 2, 770, DateTimeKind.Local).AddTicks(3), 2.3070810828704991, 14.269409714205972, 23.334361508253359 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 11, 6, 2, 770, DateTimeKind.Local).AddTicks(66), 31.630282165333639, 19.593477744930425, 44.461301844518296 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 11, 6, 2, 770, DateTimeKind.Local).AddTicks(69), 47.476713939454179, 38.157296884696294, 22.355892716627956 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 11, 6, 2, 770, DateTimeKind.Local).AddTicks(71), 42.435612618617277, 4.0340405923640859, 41.941768690140002 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 11, 6, 2, 770, DateTimeKind.Local).AddTicks(73), 39.739253895112228, 19.608770890417894, 46.878105683733345 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 13, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 8, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 24, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CommentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 23, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 8, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "-1005799859");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "-1005799859");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "-1005799859");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "-1005799859");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "-1005799859");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 10, 57, 51, 327, DateTimeKind.Local).AddTicks(9367), 8.5029056567997916, 25.872723837160471, 25.554051000115351 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 10, 57, 51, 327, DateTimeKind.Local).AddTicks(9405), 47.122631091701599, 25.841955079374628, 8.6766281012075339 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 10, 57, 51, 327, DateTimeKind.Local).AddTicks(9407), 23.456642867342836, 43.735498523908824, 15.055678166189912 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 10, 57, 51, 327, DateTimeKind.Local).AddTicks(9408), 6.727240952554209, 42.914306230326716, 37.163397812348201 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 10, 57, 51, 327, DateTimeKind.Local).AddTicks(9410), 11.693966533827288, 5.3861715617288199, 27.041248512202117 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 10, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 12, 2 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommentId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 21, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 8, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CommentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 21, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 20, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "-576271933");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "-576271933");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "-576271933");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "-576271933");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "-576271933");
        }
    }
}
