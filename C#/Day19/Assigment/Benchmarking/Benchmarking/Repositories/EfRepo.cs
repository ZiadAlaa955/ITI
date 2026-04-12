using Benchmarking.Context;
using Benchmarking.Entities;
using Microsoft.EntityFrameworkCore;

namespace Benchmarking.Repositories;

public class EfRepo
{
    public void BulkInsert(List<User> data)
    {
        using var ctx = new BenchmarkingDbContext();
        ctx.ChangeTracker.AutoDetectChangesEnabled = false;
        ctx.Users.AddRange(data);
        ctx.SaveChanges();
    }

    public User? GetById(int id)
    {
        using var ctx = new BenchmarkingDbContext();
        return ctx.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public List<User> WhereAge(int age)
    {
        using var ctx = new BenchmarkingDbContext();
        return ctx.Users.AsNoTracking().Where(x => x.Age == age).ToList();
    }

    public void Update(int id, string email)
    {
        using var ctx = new BenchmarkingDbContext();
        var entity = new User { Id = id, Email = email };

        ctx.Users.Attach(entity);
        ctx.Entry(entity).Property(x => x.Email).IsModified = true;
        ctx.SaveChanges();
    }

    public void Delete(int id)
    {
        using var ctx = new BenchmarkingDbContext();
        var entity = new User { Id = id };

        ctx.Users.Attach(entity);
        ctx.Users.Remove(entity);
        ctx.SaveChanges();
    }
}