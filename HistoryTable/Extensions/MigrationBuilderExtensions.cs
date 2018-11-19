using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryTable.Extensions
{
    public static class MigrationBuilderExtensions
    {
        public static void AddTemporalTableSupport(this MigrationBuilder builder, string tableName)
        {
            Console.WriteLine($"Creating History table for {tableName}");
            builder.Sql($@"ALTER TABLE {tableName} ADD 
            SysStartTime datetime2(0) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
            SysEndTime datetime2(0) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
            PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime);");
            builder.Sql($@"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = ON);");
        }
    }
}
