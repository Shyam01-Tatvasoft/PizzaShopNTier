using PizzaShop.DataAccess.Data;

namespace PizzaShop.DataAccess.Interfaces;

public interface ICountryRepository
{
    public List<Country> GetAllCountry();
}
