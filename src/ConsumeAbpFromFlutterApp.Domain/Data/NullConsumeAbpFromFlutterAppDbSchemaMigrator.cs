using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ConsumeAbpFromFlutterApp.Data
{
    /* This is used if database provider does't define
     * IConsumeAbpFromFlutterAppDbSchemaMigrator implementation.
     */
    public class NullConsumeAbpFromFlutterAppDbSchemaMigrator : IConsumeAbpFromFlutterAppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}