using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FMS.Db
{
    public class BulkOperationResult
    {
        public int AffectedRows { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = null;
    }
    public static class BulkConfigurationSetup
    {

        public static readonly BulkConfig DefaultConfig = new()
        {
            SetOutputIdentity = true,
            PreserveInsertOrder = true,
            BatchSize = 1000,
            IncludeGraph = false
        };
    }
    public static class BulkExtensions
    {
        public static async Task<BulkOperationResult> BulkInsert<T>(this DbContext context, IList<T> entities, bool includeGraph = false) where T : class
        {
            var result = new BulkOperationResult();
            var startTime = DateTime.UtcNow;
            try
            {
                BulkConfigurationSetup.DefaultConfig.IncludeGraph = includeGraph;
                await context.BulkInsertAsync(entities, BulkConfigurationSetup.DefaultConfig);
                result.AffectedRows = entities.Count;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                result.ExecutionTime = DateTime.UtcNow - startTime;
            }
            return result;
        }
        public static async Task<BulkOperationResult> BulkUpdate<T>(this DbContext context, IList<T> entities, bool includeGraph = false) where T : class
        {
            var result = new BulkOperationResult();
            var startTime = DateTime.UtcNow;
            try
            {
                BulkConfigurationSetup.DefaultConfig.IncludeGraph = includeGraph;
                await context.BulkUpdateAsync(entities, BulkConfigurationSetup.DefaultConfig);
                result.AffectedRows = entities.Count;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                result.ExecutionTime = DateTime.UtcNow - startTime;
            }
            return result;
        }
        public static async Task<BulkOperationResult> BulkUpdateCollection(this DbContext context, IDictionary<string, IList> entityGroups)
        {
            var result = new BulkOperationResult();
            var startTime = DateTime.UtcNow;
            try
            {
                foreach (var group in entityGroups)
                {
                    if (group.Value.Count != 0)
                    {
                        var entityType = group.Value.GetType().GetGenericArguments()[0];
                        var method = typeof(DbContextBulkExtensions).GetMethods().FirstOrDefault(m => m.Name == "BulkUpdateAsync" && m.GetParameters().Length == 6 && m.GetParameters()[0].ParameterType == typeof(DbContext)) ?? throw new InvalidOperationException("Method 'BulkUpdateAsync' not found.");
                        var genericMethod = method.MakeGenericMethod(entityType);
                        var task = (Task)genericMethod.Invoke(null, new object[] { context, group.Value, BulkConfigurationSetup.DefaultConfig, null, null, CancellationToken.None });
                        await task;
                        result.AffectedRows += group.Value.Count;
                    }
                }
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                result.ExecutionTime = DateTime.UtcNow - startTime;
            }
            return result;
        }
        public static async Task<BulkOperationResult> BulkDelete<T>(this DbContext context, IList<T> entities) where T : class
        {
            var result = new BulkOperationResult();
            var startTime = DateTime.UtcNow;
            try
            {
                await context.BulkDeleteAsync(entities, BulkConfigurationSetup.DefaultConfig);
                result.AffectedRows = entities.Count;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                result.ExecutionTime = DateTime.UtcNow - startTime;
            }

            return result;
        }
        public static async Task<BulkOperationResult> BulkUDeleteCollecion(this DbContext context, IDictionary<string, IList> entityGroups)
        {
            var result = new BulkOperationResult();
            var startTime = DateTime.UtcNow;
            try
            {
                foreach (var group in entityGroups)
                {
                    if (group.Value.Count != 0)
                    {
                        var entityType = group.Value.GetType().GetGenericArguments()[0];
                        var method = typeof(DbContextBulkExtensions).GetMethods().FirstOrDefault(m => m.Name == "BulkDeleteAsync" && m.GetParameters().Length == 6 && m.GetParameters()[0].ParameterType == typeof(DbContext)) ?? throw new InvalidOperationException("Method 'BulkDeleteAsync' not found.");
                        var genericMethod = method.MakeGenericMethod(entityType);
                        var task = (Task)genericMethod.Invoke(null, new object[] { context, group.Value, BulkConfigurationSetup.DefaultConfig, null, null, CancellationToken.None });
                        await task;
                        result.AffectedRows += group.Value.Count;
                    }
                }
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                result.ExecutionTime = DateTime.UtcNow - startTime;
            }
            return result;
        }
    }
}
