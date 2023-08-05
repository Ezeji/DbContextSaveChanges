# DbContextSaveChanges
This is an experimental project that shows the performance analysis of using Add() and AddRange() Entity Framework Core methods for a bulk create database operation.

The performance analysis clearly shows that AddRange() performs better compared to Add() when handling creation of a list or array of items. In addition, AddRange() tends to maintain
the ACID properties that characterizes a database operation when used for the scenario under analysis. Although, EfCore by default adopts the isolation level of the database provider which in this case is the MS SQL Server that
has its isolation level to be READ_COMMITTED. What this implies is that to achieve a concurrency state using either of the methods for their specific use cases would require some tweaking at the database level when dealing with a high traffic application.
Find reports of the analysis in this folder path: ...\DbContextSaveChanges\DbContextSaveChanges.Benchmarks\bin\Release\net7.0\BenchmarkDotNet.Artifacts\results