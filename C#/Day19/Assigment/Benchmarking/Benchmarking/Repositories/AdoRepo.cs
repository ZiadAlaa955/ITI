using Benchmarking.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Benchmarking.Repositories;

public class AdoRepo
{
    private readonly string _cs;
    public AdoRepo(string cs) => _cs = cs;

    public void BulkInsert(List<User> data)
    {
        using var conn = new SqlConnection(_cs);
        conn.Open();

        using var bulk = new SqlBulkCopy(conn)
        {
            DestinationTableName = "Users"
        };

        bulk.ColumnMappings.Add("FirstName", "FirstName");
        bulk.ColumnMappings.Add("LastName", "LastName");
        bulk.ColumnMappings.Add("Email", "Email");
        bulk.ColumnMappings.Add("Age", "Age");
        bulk.ColumnMappings.Add("CreatedAt", "CreatedAt");

        var table = new DataTable();
        table.Columns.Add("FirstName");
        table.Columns.Add("LastName");
        table.Columns.Add("Email");
        table.Columns.Add("Age", typeof(int));
        table.Columns.Add("CreatedAt", typeof(DateTime));

        foreach (var u in data)
            table.Rows.Add(u.FirstName, u.LastName, u.Email, u.Age, u.CreatedAt);

        bulk.WriteToServer(table);
    }

    public User? GetById(int id)
    {
        using var conn = new SqlConnection(_cs);
        conn.Open();

        var cmd = new SqlCommand("SELECT * FROM Users WHERE Id=@Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        using var r = cmd.ExecuteReader();
        if (!r.Read()) return null;

        return new User
        {
            Id = (int)r["Id"],
            FirstName = r["FirstName"].ToString()!,
            LastName = r["LastName"].ToString()!,
            Email = r["Email"].ToString()!,
            Age = (int)r["Age"],
            CreatedAt = (DateTime)r["CreatedAt"]
        };
    }

    public void Update(int id, string email)
    {
        using var conn = new SqlConnection(_cs);
        conn.Open();

        var cmd = new SqlCommand("UPDATE Users SET Email=@Email WHERE Id=@Id", conn);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conn = new SqlConnection(_cs);
        conn.Open();

        var cmd = new SqlCommand("DELETE FROM Users WHERE Id=@Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }
}