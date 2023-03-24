using Demo.Cache.Api.Models;

namespace Demo.Cache.Api.Stores;

public interface ICarStore
{
    CarDto List();

    CarDto Get(int id);
}