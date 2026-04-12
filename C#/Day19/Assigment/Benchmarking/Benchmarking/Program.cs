using BenchmarkDotNet.Running;
using Benchmarking.Benchmarks;
using Benchmarking.Context;
using Microsoft.Data.SqlClient;

// Initialize database
InitializeDatabase();

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

void InitializeDatabase()
{
    var connectionString = "Server=(localdb)\\mssqllocaldb;Database=BenchDb;Trusted_Connection=True;TrustServerCertificate=True";
    var masterConnectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;TrustServerCertificate=True";

    try
    {
        // Create database if it doesn't exist
        using (var connection = new SqlConnection(masterConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'BenchDb')
                    BEGIN
                        CREATE DATABASE [BenchDb];
                    END";
                command.ExecuteNonQuery();
            }
        }

        // Create tables and schema
        using (var context = new BenchmarkingDbContext())
        {
            context.Database.EnsureCreated();
        }

        Console.WriteLine("✓ Database initialized successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"✗ Database initialization failed: {ex.Message}");
        throw;
    }
}