using EFHotel.Data.EFStructures;
using EFHotel.Tests.Helpers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace EFHotel.Tests.Base;

public class BaseTest : IDisposable
{
    protected IConfiguration Configuration { get; }
    
    protected EFHotelContext Context { get; }
    
    protected ITestOutputHelper OutputHelper { get; }

    protected BaseTest(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
        Configuration = DatabaseSetupHelper.GetConfiguration();
        Context = DatabaseSetupHelper.GetEFHotelContext(Configuration);
    }

    public void Dispose() => Context.Dispose();

    protected void ExecuteQueryInATransaction(Action actionToExecute)
    {
        IExecutionStrategy strategy = Context.Database.CreateExecutionStrategy();

        strategy.Execute(
            () =>
            {
                using var transaction = Context.Database.BeginTransaction();
                actionToExecute();
                transaction.Rollback();
            }
        );
    }
}