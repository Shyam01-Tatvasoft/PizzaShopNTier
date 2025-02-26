using PizzaShop.DataAccess.Data;

namespace PizzaShop.Service.Interfaces;

public interface IAddressService
{
    public List<State> GetAllStates(int id);
    public List<City> GetAllCities(int id);
    public List<Country> GetAllCountries();
}
