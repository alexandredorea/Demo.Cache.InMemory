using Bogus;
using Demo.Cache.Api.Data.Context;
using Demo.Cache.Api.Models;

namespace Demo.Cache.Api.Data.Repositories;

public static class DummyDataGenerator
{
    public static void Generate(this DataContext context)
    {
        if (context.Cars.Any())
            return;

        var id = 0;
        var faker = new Faker<Car>()
            .RuleFor(o => o.Id, f => ++id)
            .RuleFor(o => o.Year, f => f.Random.Int(1950, 2023))
            .RuleFor(o => o.Brand, f => f.Vehicle.Manufacturer())
            .RuleFor(o => o.Model, f => f.Vehicle.Model());

        var carStorage = faker.Generate(1000);
        context.AddRange(carStorage);
        context.SaveChanges();
    }
}