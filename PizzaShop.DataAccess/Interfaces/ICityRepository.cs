using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface ICityRepository
{
    public List<City> GetAllCities();
    public List<City> GetCitiesByStateId(int id);
}
