using BenchmarkDotNet.Attributes;
using Benchmarking.Data;
using Benchmarking.Entities;
using Benchmarking.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Benchmarking.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(warmupCount: 2, iterationCount: 5)]
public class InsertBenchmarks
{
    private List<User> _data = null!;
    private readonly string _cs = "Server=(localdb)\\mssqllocaldb;Database=BenchDb;Trusted_Connection=True;TrustServerCertificate=True";

    private EfRepo _ef = new();
    private DapperRepo _dapper = null!;
    private AdoRepo _ado = null!;

    [GlobalSetup]
    public void Setup()
    {
        using var conn = new SqlConnection(_cs);
        conn.Execute("TRUNCATE TABLE Users");

        _dapper = new DapperRepo(_cs);
        _ado = new AdoRepo(_cs);
    }

    [IterationSetup]
    public void ResetDb()
    {
        using var conn = new SqlConnection(_cs);
        conn.Execute("TRUNCATE TABLE Users");

        _data = DataFactory.Generate(10_000);
        _ef = new EfRepo();
    }

    [Benchmark] public void EF_Insert() => _ef.BulkInsert(_data);
    [Benchmark] public void Dapper_Insert() => _dapper.BulkInsert(_data);
    [Benchmark] public void ADO_Insert() => _ado.BulkInsert(_data);
}