using Benchmarking.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Benchmarking.Repositories;

public class DapperRepo
{
    private readonly string _cs;

    public DapperRepo(string cs) => _cs = cs;

    public void BulkInsert(List<User> data)
    {
        using var conn = new SqlConnection(_cs);
        conn.Execute(
            "INSERT INTO Users (FirstName, LastName, Email, Age, CreatedAt) VALUES (@FirstName,@LastName,@Email,@Age,@CreatedAt)",
            data);
    }

    public User? GetById(int id)
    {
        using var conn = new SqlConnection(_cs);
        return conn.QueryFirstOrDefault<User>(
            "SELECT * FROM Users WHERE Id=@Id", new { Id = id });
    }

    public IEnumerable<User> WhereAge(int age)
    {
        using var conn = new SqlConnection(_cs);
        return conn.Query<User>(
            "SELECT * FROM Users WHERE Age=@Age", new { Age = age });
    }

    public void Update(int id, string email)
    {
        using var conn = new SqlConnection(_cs);
        conn.Execute("UPDATE Users SET Email=@email WHERE Id=@id", new { id, email });
    }

    public void Delete(int id)
    {
        using var conn = new SqlConnection(_cs);
        conn.Execute("DELETE FROM Users WHERE Id=@id", new { id });
    }
}