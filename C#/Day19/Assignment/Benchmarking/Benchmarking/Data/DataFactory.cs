using Bogus;
using Benchmarking.Entities;

namespace Benchmarking.Data
{
    public static class DataFactory
    {
        public static List<User> Generate(int count)
        {
            var faker = new Faker<User>()
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Email, f => $"{f.Internet.UserName()}{Guid.NewGuid():N}@test.com")
                .RuleFor(x => x.Age, f => f.Random.Int(18, 65))
                .RuleFor(x => x.CreatedAt, _ => DateTime.UtcNow);

            return faker.Generate(count);
        }
    }
}
