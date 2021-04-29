using System.Threading.Tasks;

namespace ConsumeAbpFromFlutterApp.Data
{
    public interface IConsumeAbpFromFlutterAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
