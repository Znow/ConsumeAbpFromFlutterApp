using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConsumeAbpFromFlutterApp.Data;
using Volo.Abp.DependencyInjection;

namespace ConsumeAbpFromFlutterApp.EntityFrameworkCore
{
    public class EntityFrameworkCoreConsumeAbpFromFlutterAppDbSchemaMigrator
        : IConsumeAbpFromFlutterAppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreConsumeAbpFromFlutterAppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ConsumeAbpFromFlutterAppMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ConsumeAbpFromFlutterAppMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}