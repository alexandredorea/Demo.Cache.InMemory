using Demo.Cache.Api.Models;

namespace Demo.Cache.Api.Stores;

public interface ICarService
{
    CarDto List();

    CarDto Get(int id);
}