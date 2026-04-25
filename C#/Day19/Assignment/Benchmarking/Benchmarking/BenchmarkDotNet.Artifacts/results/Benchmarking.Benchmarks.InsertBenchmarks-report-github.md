```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3)
Intel Core i7-10750H CPU 2.60GHz (Max: 2.59GHz), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3
  Job-ARDWEO : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v3

InvocationCount=1  IterationCount=5  UnrollFactor=1  
WarmupCount=2  

```
| Method        | Mean        | Error    | StdDev    | Gen0      | Allocated |
|-------------- |------------:|---------:|----------:|----------:|----------:|
| EF_Insert     |   351.67 ms | 58.91 ms | 15.300 ms | 1000.0000 |  76.02 MB |
| Dapper_Insert | 1,679.48 ms | 59.39 ms | 15.425 ms | 1000.0000 |  15.41 MB |
| ADO_Insert    |    58.51 ms | 27.12 ms |  7.042 ms |         - |   5.31 MB |
