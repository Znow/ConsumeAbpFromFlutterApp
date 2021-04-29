using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ConsumeAbpFromFlutterApp.EntityFrameworkCore
{
    public static class ConsumeAbpFromFlutterAppDbContextModelCreatingExtensions
    {
        public static void ConfigureConsumeAbpFromFlutterApp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ConsumeAbpFromFlutterAppConsts.DbTablePrefix + "YourEntities", ConsumeAbpFromFlutterAppConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}