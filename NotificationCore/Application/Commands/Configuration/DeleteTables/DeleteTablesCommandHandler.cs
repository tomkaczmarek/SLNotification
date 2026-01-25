using Microsoft.EntityFrameworkCore;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Configuration.DeleteTables
{
    public class DeleteTablesCommandHandler : ICommandHandler<DeleteTablesCommand>
    {
        private NotificationDbContext notificationDbContext;

        public DeleteTablesCommandHandler(NotificationDbContext notificationDbContext)
        {
            this.notificationDbContext = notificationDbContext;
        }

        public async Task<ApiResponse> HandleAsync(DeleteTablesCommand command, CancellationToken cancellationToken)
        {
            await notificationDbContext.Database.ExecuteSqlRawAsync(@"
                                    DO
                                    $$
                                    DECLARE
                                        r RECORD;
                                        schemas text[] := ARRAY['notify', 'statistic'];
                                    BEGIN
                                        FOR r IN
                                            SELECT schemaname, tablename
                                            FROM pg_tables
                                            WHERE schemaname = ANY (schemas)
                                        LOOP
                                            EXECUTE format(
                                                'TRUNCATE TABLE %I.%I CASCADE;',
                                                r.schemaname,
                                                r.tablename
                                            );
                                        END LOOP;
                                    END
                                    $$;
                                    ");

            return new ApiResponse();
        }
    }
}
