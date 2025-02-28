using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using WhereIsMyBarber.Domain.Extensions;

namespace WhereIsMyBarber.Infra.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrate(string connectionString, IServiceProvider service)
        {
            EnsureDatabaseCreated(connectionString);

            MigrationDatabase(service);
        }
        private static void EnsureDatabaseCreated(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var databaseName = connectionStringBuilder.InitialCatalog;
            connectionStringBuilder.Remove("Database");

            using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();

            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

            if (records.Any().IsFalse())
            {
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
            }
        }

        private static void MigrationDatabase(IServiceProvider service)
        {
            var runner = service.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();
            runner.MigrateUp();
        }
    }
}