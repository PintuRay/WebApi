using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db
{
    public static class BulkConfigurationSetup
    {
        public static readonly BulkConfig DefaultConfig = new()
        {
            SetOutputIdentity = true,
            PreserveInsertOrder = true,
            BatchSize = 1000,
        };
    }
    public static class BulkExtensions
    {
        public static async Task BulkInsert<T>(this DbContext context,IList<T> entities) where T : class
        {
            await context.BulkInsertAsync(entities, BulkConfigurationSetup.DefaultConfig);
        } 
        public static async Task BulkUpdate<T>(this DbContext context,  IList<T> entities) where T : class
        {
            await context.BulkUpdateAsync(entities, BulkConfigurationSetup.DefaultConfig);
        }
        public static async Task BulkDelete<T>(this DbContext context, IList<T> entities) where T : class
        {
            await context.BulkDeleteAsync(entities, BulkConfigurationSetup.DefaultConfig);
        }
    }
}
