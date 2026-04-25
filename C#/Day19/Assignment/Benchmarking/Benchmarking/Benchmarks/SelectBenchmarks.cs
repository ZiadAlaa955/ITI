using BenchmarkDotNet.Attributes;
using Benchmarking.Data;
using Benchmarking.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Benchmarking.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(warmupCount: 2, iterationCount: 5)]
public class SelectBenchmarks
{
    private int _seedId;
    private EfRepo _ef = new();
    private DapperRepo _dapper;
    private AdoRepo _ado;

    private readonly string _cs = "Server=(localdb)\\mssqllocaldb;Database=BenchDb;Trusted_Connection=True;TrustServerCertificate=True";

    public SelectBenchmarks()
    {
        _dapper = new DapperRepo(_cs);
        _ado = new AdoRepo(_cs);
    }

    [GlobalSetup]
    public void Setup()
    {
        using var conn = new SqlConnection(_cs);
        conn.Execute("TRUNCATE TABLE Users");
        conn.Execute("DBCC CHECKIDENT ('Users', RESEED, 0)");

        var data = DataFactory.Generate(10_000);
        _ado.BulkInsert(data);

        _seedId = conn.QueryFirst<int>("SELECT TOP 1 Id FROM Users");
    }

    [Benchmark] public void EF_Select() => _ef.GetById(_seedId);
    [Benchmark] public void Dapper_Select() => _dapper.GetById(_seedId);
    [Benchmark] public void ADO_Select() => _ado.GetById(_seedId);
}