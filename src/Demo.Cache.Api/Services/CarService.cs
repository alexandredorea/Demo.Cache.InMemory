using Demo.Cache.Api.Data.Context;
using Demo.Cache.Api.Models;

namespace Demo.Cache.Api.Stores;

public class CarService : ICarService
{
    private readonly DataContext _context;

    public CarService(DataContext context)
    {
        _context = context;
    }

    public CarDto List()
    {
        var cars = _context.Cars.Where(x => x.Year == 2020);
        return new CarDto("Database", cars.ToArray());
    }

    public CarDto Get(int userid)
    {
        var cars = _context.Cars.FirstOrDefault(f => f.Id == userid);
        return new CarDto("Database", cars);
    }
}