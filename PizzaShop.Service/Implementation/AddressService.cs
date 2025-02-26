using PizzaShop.DataAccess.Data;
using PizzaShop.DataAccess.Interfaces;
using PizzaShop.Service.Interfaces;

namespace PizzaShop.Service.Implementation;

public class AddressService:IAddressService
{
    private readonly ICountryRepository _country;
    private readonly IStateRepository _state;
    private readonly ICityRepository _city;

    public AddressService(ICountryRepository country, IStateRepository state, ICityRepository city)
    {
        _country = country;
        _city = city;
        _state = state;
    }
    public List<State> GetAllStates(int id)
    {
        var states = _state.GetStatesByCountryId(id);
        return states;
    }

    public List<City> GetAllCities(int id)
    {
        var cities = _city.GetCitiesByStateId(id);
        return cities;
    }
    
    public List<Country> GetAllCountries()
    {
        var countries = _country.GetAllCountry();
        return countries;
    }

}
