using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Data.Migrations;

public class MigrationManager
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationManager(string connectionString, Assembly assembly)
    {
        _serviceProvider = CreateServices(connectionString, assembly);
    }

    public void MigrateToLatest()
    {
        var runner = _serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }
    
    private static IServiceProvider CreateServices(string connectionString, Assembly assembly)
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }
}